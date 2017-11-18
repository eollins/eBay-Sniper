using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace eBay_Sniper
{
    public partial class MultipleAuctions : Form
    {
        List<string> itemIds = new List<string>();
        List<double> maxBids = new List<double>();
        List<string> items = new List<string>();
        List<string> finishedIDs = new List<string>();
        string itemsString = "";

        public MultipleAuctions()
        {
            InitializeComponent();
        }

        private void getUpdates_Tick(object sender, EventArgs e)
        {
            //Adds new data to a formatted string, which is added to the main list
            string idString;
            try
            {
                idString = "";
                foreach (string id in itemIds)
                {
                    if (id == "")
                        continue;

                    idString += id + ",";
                }
                idString = idString.Substring(0, idString.Length - 1);
            }
            catch
            {
                return;
            }

            string callName;
            if (itemIds.Count == 1)
            {
                callName = "GetSingleItem";
            }
            else
            {
                callName = "GetMultipleItems";
            }

            XmlDocument doc = new XmlDocument();
            doc.Load("http://open.api.ebay.com/shopping?callname=" + callName + "&responseencoding=XML&appid=GregoryM-mailer-PRD-a45ed6035-97c14545&siteid=0&version=967&ItemID=" + idString);
            //Gets item information to find end time

            XmlNodeList nodes;
            if (callName == "GetSingleItem")
            {
                nodes = doc.GetElementsByTagName("GetSingleItemResponse");
            }
            else
            {
                nodes = ((XmlElement)doc.GetElementsByTagName("GetMultipleItemsResponse")[0]).GetElementsByTagName("Item");
            }

            items.Clear();
            int i = 0;
            foreach (XmlElement item in nodes)
            {
                string endTime = item.GetElementsByTagName("EndTime")[0].InnerText;
                string[] components1 = endTime.Split('T');
                string[] date = components1[0].Split('-');
                string[] time = components1[1].Split(':');
                time[2] = time[2].Substring(0, time[2].IndexOf('.'));
                DateTime endTimeDt = new DateTime(int.Parse(date[0]), int.Parse(date[1]), int.Parse(date[2]), int.Parse(time[0]), int.Parse(time[1]), int.Parse(time[2]));
                endTimeDt = endTimeDt.AddHours(-8);
                endTimeDt = endTimeDt.AddSeconds(2);

                DateTime yes = DateTime.Now;
                yes = yes.AddSeconds(10);

                string dateTime = endTimeDt.Month + "/" + endTimeDt.Day + "/" + endTimeDt.Year + " " + endTimeDt.Hour + ":" + endTimeDt.Minute + ":" + endTimeDt.Second;
                //string dateTime = yes.Month + "/" + yes.Day + "/" + yes.Year + " " + yes.Hour + ":" + yes.Minute + ":" + yes.Second;

                TimeSpan span = yes - DateTime.Now;
                string timeLeft = span.Days + "d " + span.Hours + "h " + span.Minutes + "m " + span.Seconds + "s";

                StringBuilder sb = new StringBuilder(item.GetElementsByTagName("Title")[0].InnerText);
                sb.Replace(',', ' ');
                string item2 = sb.ToString();

                //MessageBox.Show(maxBids[i].ToString());
                items.Add(item2 + "," + item.GetElementsByTagName("ItemID")[0].InnerText + "," + item.GetElementsByTagName("ConvertedCurrentPrice")[0].InnerText + "," + endTimeDt.Year + "," + endTimeDt.Month + "," + endTimeDt.Day + "," + endTimeDt.Hour + "," + endTimeDt.Minute + "," + endTimeDt.Second + "," + maxBids[i]);
                itemsString += items[items.Count - 1] + ";";
                //items.Add(item2 + "," + item.GetElementsByTagName("ItemID")[0].InnerText + "," + item.GetElementsByTagName("ConvertedCurrentPrice")[0].InnerText + "," + yes.Year + "," + yes.Month + "," + yes.Day + "," + yes.Hour + "," + yes.Minute + "," + yes.Second + "," + maxBid.Text);

                updateTime_Tick(updateTime, new EventArgs());
                //Compiles information string

                i++;
            }

            Log("Added item number " + itemIds[itemIds.Count - 1]);
        }

        private void MultipleAuctions_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void addItem_Click(object sender, EventArgs e)
        {
            itemIds.Add(itemNumber.Text);
            maxBids.Add(double.Parse(maxBid.Text));
            getUpdates_Tick(getInfo, new EventArgs());
        }

        private void updateTime_Tick(object sender, EventArgs e)
        {
            ListView.SelectedIndexCollection index = itemTable.SelectedIndices;

            DateTime closestTime = new DateTime(9999, 12, 31, 23, 59, 59);
            try
            {
                foreach (string item in items)
                {
                    string[] components = item.Split(',');
                    DateTime endTime = new DateTime(int.Parse(components[3]), int.Parse(components[4]), int.Parse(components[5]), int.Parse(components[6]), int.Parse(components[7]), int.Parse(components[8]));
                    
                    TimeSpan span = endTime - DateTime.Now;
                    TimeSpan closest = closestTime - DateTime.Now;

                    if (span < closest)
                    {
                        closestTime = endTime;
                        moveItemToTop(components[1]);
                    }
                }
            }
            catch { }

            //Finds the listing that is ending soonest and reorganizes the list accordingly

            itemTable.Items.Clear();
            foreach (string item in items)
            {
                string[] components = item.Split(',');   

                DateTime endTime = new DateTime(int.Parse(components[3]), int.Parse(components[4]), int.Parse(components[5]), int.Parse(components[6]), int.Parse(components[7]), int.Parse(components[8]));
                //endTime = endTime.AddHours(-8);
                string dateTime = endTime.Month + "/" + endTime.Day + "/" + endTime.Year + " " + endTime.Hour + ":" + endTime.Minute + ":" + endTime.Second;
                TimeSpan timeLeft = endTime - DateTime.Now;
                string timeLeft2 = timeLeft.Days + "d " + timeLeft.Hours + "h " + timeLeft.Minutes + "m " + timeLeft.Seconds + "s";
                string[] row = { components[0], components[1], GetCurrentPrice(components[1]), dateTime, timeLeft2, components[9] };
                var listViewItem = new ListViewItem(row);

                if (timeLeft.TotalMilliseconds <= (int)numericUpDown1.Value && timeLeft.TotalMilliseconds >= 0 && !finishedIDs.Contains(components[1]))
                {
                    BidOnItem(components[1], components[components.Length - 1]); //Sends bid request
                }
                
                if (timeLeft.TotalMilliseconds > 10)
                {
                    itemTable.Items.Add(listViewItem); //Controls addition or removal of items from list
                }
            }
        }

        public void moveItemToTop(string iID)
        {
            //Moves item to the top of the list
            int index = 0;
            string itemToRemove = "";
            foreach (string i in items)
            {
                if (i.Contains(iID))
                {
                    index = items.IndexOf(i);
                    itemToRemove = i;
                }
            }

            items.Remove(itemToRemove);
            items.Insert(0, itemToRemove);
        }

        private void checkTimes_Tick(object sender, EventArgs e)
        {
            if (items.Count == 0)
                return;

            foreach (string item in items)
            {

            }
        }

        private void BidOnItem(string ID, string maxBid)
        {
            //Cancels if the item has been bid on already
            if (finishedIDs.Contains(ID))
                return;

            XmlDocument doc2 = new XmlDocument();
            doc2.Load("http://open.api.ebay.com/shopping?callname=GetSingleItem&responseencoding=XML&appid=GregoryM-mailer-PRD-a45ed6035-97c14545&siteid=0&version=967&ItemID=" + ID + "&IncludeSelector=Details");
            //Gets item information for current price

            string price;

            try
            {
                price = ((XmlElement)doc2.GetElementsByTagName("GetSingleItemResponse")[0]).GetElementsByTagName("MinimumToBid")[0].InnerText;
            }
            catch
            {
                price = ((XmlElement)((XmlElement)doc2.GetElementsByTagName("GetSingleItemResponse")[0]).GetElementsByTagName("Item")[0]).GetElementsByTagName("ConvertedCurrentPrice")[0].InnerText;
            }
            //Finds the minimum price that needs to be bid

            try
            {
                if (double.Parse(price) < double.Parse(maxBid))
                {
                    //If specified bid is eligible, sends hidden WebBrowser to a confirmation screen
                    string finalPrice = maxBid;
                    webBrowser1.Url = new Uri("https://offer.ebay.com/ws/eBayISAPI.dll?MfcISAPICommand=MakeBid&uiid=1859999246&co_partnerid=2&fb=2&item=" + ID + "&maxbid=" + (double.Parse(maxBid)) + "&Ctn=Continue");
                    Log("Bid " + String.Format(maxBid, "C") + " on item number " + itemNumber.Text);
                    finishedIDs.Add(ID);
                }
                else
                {
                    //Logs failure of auctions whose current prices exceeded bid
                    Log("Bid amount " + String.Format(maxBid, "C") + " exceeded requested bid of " + price + " on item number " + itemNumber.Text);
                    finishedIDs.Add(ID);
                }
            }
            catch
            {
                
            }
        }

        private void logIn_Click(object sender, EventArgs e)
        {
            //Opens a sign in screen
            new signIn().ShowDialog();
            Import.Enabled = true;
            maxBid.Enabled = true;
            itemNumber.Enabled = true;
            addItem.Enabled = true;
            removeItem.Enabled = true;
            logIn.Enabled = false;
            viewLog.Enabled = true;

            Log("User logged in");
        }

        public void Log(string message)
        {
            //Logs events to a local file depending on date
            string logData = "[" + DateTime.Now.Year + " - " + DateTime.Now.Month + " - " + DateTime.Now.Day + " " + DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second + "] " + message + "\n";
            File.AppendAllText(CurrentDatePath(), logData + Environment.NewLine);
        }

        private string CurrentDatePath()
        {
            return @"Past Logs\auctionlog_" + DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + ".txt";
        }

        private void webBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            Log("Browser navigated to " + webBrowser1.Url.ToString());
        }

        private void checkWebpage_Tick(object sender, EventArgs e)
        {
            try
            {
                //Checks to see if confirmation screen is loaded
                if (webBrowser1.Document.GetElementsByTagName("html")[0].InnerHtml.Contains("position:relative;"))
                {
                    try
                    {
                        HtmlDocument doc3 = webBrowser1.Document;
                        HtmlElement head2 = doc3.GetElementsByTagName("html")[0];
                        HtmlElement s2 = doc3.CreateElement("script");
                        s2.SetAttribute("text", "function clickButton2() { document.getElementById('but_v4-2').click(); }");
                        head2.AppendChild(s2);
                        string html = webBrowser1.Document.GetElementsByTagName("html")[0].InnerHtml;
                        webBrowser1.Document.InvokeScript("clickButton2");
                        //Sends confirmation request and redirects the page
                    }
                    catch { }
                }
            }
            catch { }
        }

        private string GetCurrentPrice(string id)
        {
            //Gets current price of an item from the API
            XmlDocument doc2 = new XmlDocument();
            doc2.Load("http://open.api.ebay.com/shopping?callname=GetSingleItem&responseencoding=XML&appid=GregoryM-mailer-PRD-a45ed6035-97c14545&siteid=0&version=967&ItemID=" + id + "&IncludeSelector=Details");
            string price = ((XmlElement)((XmlElement)doc2.GetElementsByTagName("GetSingleItemResponse")[0]).GetElementsByTagName("Item")[0]).GetElementsByTagName("ConvertedCurrentPrice")[0].InnerText;
            return price;
        }

        private void removeItem_Click(object sender, EventArgs e)
        {
            //Removes an item from the list depending on the item number
            for (int i = items.Count - 1; i >= 0; i--)
            {
                if (items[i].Contains(itemNumber.Text))
                {
                    items.RemoveAt(i);
                    Log("Removed item number " + itemNumber.Text);
                }
            }
        }

        private void Import_Click(object sender, EventArgs e)
        {
            //Imports a spreadsheet of item numbers and bids
            if (openCSV.ShowDialog() == DialogResult.OK)
            {
                StreamReader reader = new StreamReader(openCSV.FileName);
                string data = reader.ReadToEnd();

                string[] lines = data.Split('\n');
                lines[0] = "";
                foreach (string s in lines)
                {
                    try
                    {
                        string[] comp = s.Split(',');
                        itemIds.Add(comp[0]);
                        maxBids.Add(double.Parse(comp[1]));
                        getUpdates_Tick(getInfo, new EventArgs());
                    }
                    catch
                    {
                        continue; //first line headings
                    }
                }

                Log("Imported item spreadsheet at " + openCSV.FileName);
            }
        }

        private void removeItem_TextChanged(object sender, EventArgs e)
        {

        }

        private void itemNumber_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            
        }

        private void itemNumber_TextChanged(object sender, EventArgs e)
        {
            if (itemNumber.Text == "")
            {
                removeItem.Text = "Clear Items";
            }
            else
            {
                removeItem.Text = "Remove Item";
            }
        }

        private void MultipleAuctions_Load(object sender, EventArgs e)
        {
            //if (!File.Exists(CurrentDatePath()))
            //{
            //    File.Create(CurrentDatePath());
            //}
        }

        private void viewLog_Click(object sender, EventArgs e)
        {
            //Opens current day's log for viewing
            Process.Start("notepad", CurrentDatePath());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process.Start(@"Past Logs");
        }
    }
}
