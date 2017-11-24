using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using System.Xml;
using static System.Windows.Forms.ListViewItem;

namespace eBay_Sniper
{
    public partial class MultipleAuctions : Form
    {
        Point buttonCoordinates = new Point(0, 0);
        List<ItemInformation> items = new List<ItemInformation>();
        public MultipleAuctions()
        {
            InitializeComponent();
        }

        private void addItem_Click(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("http://open.api.ebay.com/shopping?callname=GetSingleItem&responseencoding=XML&appid=GregoryM-mailer-PRD-a45ed6035-97c14545&siteid=0&version=967&ItemID=" + itemNumber.Text);

            XmlNodeList nodes = doc.GetElementsByTagName("GetSingleItemResponse");
            XmlElement ele = (XmlElement)nodes[0];

            string endTime = ele.GetElementsByTagName("EndTime")[0].InnerText;
            string[] components1 = endTime.Split('T');
            string[] date = components1[0].Split('-');
            string[] time = components1[1].Split(':');
            time[2] = time[2].Substring(0, time[2].IndexOf('.'));
            DateTime endTimeDt = new DateTime(int.Parse(date[0]), int.Parse(date[1]), int.Parse(date[2]), int.Parse(time[0]), int.Parse(time[1]), int.Parse(time[2]));
            endTimeDt = endTimeDt.AddHours(-8);
            endTimeDt = endTimeDt.AddSeconds(2);

            ItemInformation info = new ItemInformation();
            info.Name = ele.GetElementsByTagName("Title")[0].InnerText;
            info.ItemNumber = itemNumber.Text;
            info.Price = ele.GetElementsByTagName("ConvertedCurrentPrice")[0].InnerText;
            info.EndTime = endTimeDt;
            info.Bid = maxBid.Text;

            items.Add(info);

            itemNumber.Text = "";
            maxBid.Text = "";

            Log("Added item number " + info.ItemNumber);
        }

        private void removeItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].ItemNumber == itemNumber.Text)
                {
                    items.RemoveAt(i);
                    itemNumber.Text = "";
                    maxBid.Text = "";
                    label1.Text = "Next Upcoming Auction:";
                    label1.ForeColor = Color.Black;
                    Log("Removed item " + items[i].ItemNumber);
                }
            }
        }

        private void updateInformation_Tick(object sender, EventArgs e)
        {
            if (items.Count == 0)
                return;

            for (int i = 0; i < items.Count; i++)
            {
                try
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load("http://open.api.ebay.com/shopping?callname=GetSingleItem&responseencoding=XML&appid=GregoryM-mailer-PRD-a45ed6035-97c14545&siteid=0&version=967&ItemID=" + items[i].ItemNumber);
                    XmlNodeList nodes = doc.GetElementsByTagName("GetSingleItemResponse");
                    XmlElement ele = (XmlElement)nodes[0];

                    string endTime = ele.GetElementsByTagName("EndTime")[0].InnerText;
                    string[] components1 = endTime.Split('T');
                    string[] date = components1[0].Split('-');
                    string[] time = components1[1].Split(':');
                    time[2] = time[2].Substring(0, time[2].IndexOf('.'));
                    DateTime endTimeDt = new DateTime(int.Parse(date[0]), int.Parse(date[1]), int.Parse(date[2]), int.Parse(time[0]), int.Parse(time[1]), int.Parse(time[2]));
                    endTimeDt = endTimeDt.AddHours(-8);
                    endTimeDt = endTimeDt.AddSeconds(2);

                    ItemInformation newInfo = new ItemInformation();
                    newInfo.Name = ele.GetElementsByTagName("Title")[0].InnerText;
                    newInfo.ItemNumber = items[i].ItemNumber;
                    newInfo.Price = ele.GetElementsByTagName("ConvertedCurrentPrice")[0].InnerText;
                    newInfo.EndTime = endTimeDt;
                    newInfo.Bid = items[i].Bid;
                    items[i] = newInfo;
                }
                catch (Exception ex)
                {
                    Log(ex.Message);
                }
            }
        }

        private void updateTable_Tick(object sender, EventArgs e)
        {
            ListView.SelectedIndexCollection index = itemTable.SelectedIndices;
            Invoke(new Action(() => { itemTable.Items.Clear(); }));
            for (int i = 0; i < items.Count; i++)
            {
                string[] row = { items[i].Name, items[i].ItemNumber, items[i].Price, ConvertToDateString(items[i].EndTime), items[i].Bid };
                Invoke(new Action(() => { itemTable.Items.Add(new ListViewItem(row)); }));
            }

            int count = 0;
            Invoke(new Action(() => { count = index.Count; }));
            if (count == 0)
                return;

            Invoke(new Action(() => { itemTable.Items[index[0]].Selected = true; }));
        }

        public string ConvertToDateString(DateTime dtToConvert)
        {
            return dtToConvert.Month + "/" + dtToConvert.Day + "/" + dtToConvert.Year + " " + dtToConvert.Hour + ":" + dtToConvert.Minute + ":" + dtToConvert.Second;
        }

        private void Import_Click(object sender, EventArgs e)
        {
            if (openCSV.ShowDialog() == DialogResult.OK)
            {
                StreamReader reader = new StreamReader(openCSV.FileName);
                string data = reader.ReadToEnd();
                string[] lines = data.Split('\n');

                for (int i = 1; i < lines.Length; i++)
                {
                    string[] components = lines[i].Split(',');
                    itemNumber.Text = components[0];

                    if (components[1].Contains("\r"))
                    {
                        maxBid.Text = components[1].Substring(0, components[1].Length - 1);
                    }
                    else
                    {
                        maxBid.Text = components[1];
                    }

                    addItem_Click(addItem, new EventArgs());
                }

                Log("Imported spreadsheet");
            }
        }

        private void Calibrate_Click(object sender, EventArgs e)
        {
            if (itemNumber.Text == "" && maxBid.Text == "")
            {
                MessageBox.Show("Please enter valid example item information.");
            }
            else if (itemNumber.Text == "")
            {
                MessageBox.Show("Please enter a valid active item number.");
            }
            else if (maxBid.Text == "")
            {
                MessageBox.Show("Please enter a valid maximum bid amount.");
            }
            else
            {
                MessageBox.Show("An eBay confirmation page will be opened. Within five seconds, place your cursor over the \"Confirm Bid\" button.");

                Process process = new Process();
                ProcessStartInfo startInfo = new ProcessStartInfo("chrome", "https://offer.ebay.com/ws/eBayISAPI.dll?MfcISAPICommand=MakeBid&uiid=1859999246&co_partnerid=2&fb=2&item=" + itemNumber.Text + "&maxbid=" + (double.Parse(maxBid.Text)) + "&Ctn=Continue");
                startInfo.WindowStyle = ProcessWindowStyle.Maximized;
                process.StartInfo = startInfo;
                process.Start();

                Thread.Sleep(5000);

                this.Activate();

                buttonCoordinates = Cursor.Position;
                MessageBox.Show("Bid confirmation button placed at " + buttonCoordinates.X + ", " + buttonCoordinates.Y);
                addItem.Enabled = true;
                Import.Enabled = true;

                Log("Calibrated confirmation button to " + buttonCoordinates.X + ", " + buttonCoordinates.Y);
            }
        }

        private void viewLog_Click(object sender, EventArgs e)
        {
            Process.Start("notepad", CurrentDatePath());
        }

        public void Log(string message)
        {
            //Logs events to a local file depending on date
            string logData = "[" + DateTime.Now.Year + " - " + DateTime.Now.Month + " - " + DateTime.Now.Day + " " + DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second + "] " + message + "\n";

            bool success = false;
            try
            {
                File.AppendAllText(CurrentDatePath(), logData + Environment.NewLine);
            }
            catch
            {
                while (success == false)
                {
                    try
                    {
                        File.AppendAllText(CurrentDatePath(), logData + Environment.NewLine);
                        success = true;
                    }
                    catch
                    {
                        continue;
                    }
                }
            }
        }

        private string CurrentDatePath()
        {
            return @"Past Logs\auctionlog_" + DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + ".txt";
        }

        private void olderLogs_Click(object sender, EventArgs e)
        {
            Process.Start(@"Past Logs");
        }
        

        ItemInformation closestItem = new ItemInformation();
        DateTime endingTime = new DateTime();
        private void checkForEndingAuction_Tick(object sender, EventArgs e)
        {
            DateTime closestTime = new DateTime(9999, 12, 31, 23, 59, 59);
            for (int i = 0; i < items.Count; i++)
            {
                TimeSpan endSpan = items[i].EndTime - DateTime.Now;
                TimeSpan closestSpan = closestTime - DateTime.Now;
                if (endSpan < closestSpan)
                {
                    closestTime = items[i].EndTime;
                    endingTime = items[i].EndTime;
                    closestItem = items[i];
                }
            }

            if (closestTime.Year == 9999)
                return;

            TimeSpan timeLeft = endingTime - DateTime.Now;
            string timeLeftStr = timeLeft.Days + "d " + timeLeft.Hours + "h " + timeLeft.Minutes + "m " + timeLeft.Seconds + "s";
            if (timeLeft.TotalSeconds % 2 == 0)
            {
                Invoke(new Action(() => { label1.Text = "Next Upcoming Auction: " + closestItem.Name + " in " + timeLeftStr; }));
            }
            else
            {
                try
                {
                    Invoke(new Action(() => { label1.Text = "Next Upcoming Auction: " + closestItem.ItemNumber + " in " + timeLeftStr; }));
                }
                catch (Exception ex)
                {
                    Log(ex.Message);
                }
            }

            if (timeLeft.TotalMinutes < 10)
            {
                label1.ForeColor = Color.Red;
            }
            else
            {
                label1.ForeColor = Color.Black;
            }

            if (timeLeft.TotalMilliseconds < (double)numericUpDown1.Value)
            {
                BidOnItem(closestItem);
                Log("Sent bid request for " + closestItem.ItemNumber);
                items.Remove(closestItem);
                closestItem = new ItemInformation();
                endingTime = new DateTime();
                Invoke(new Action(() => { label1.ForeColor = Color.Black; }));
                Invoke(new Action(() => { label1.Text = "Next Upcoming Auction: "; }));
            }
        }

        List<string> finishedIDs = new List<string>();
        private void BidOnItem(ItemInformation item)
        {
            if (finishedIDs.Contains(item.ItemNumber))
                return;

            try
            {
                finishedIDs.Add(item.ItemNumber);
                if (double.Parse(item.Price) < double.Parse(item.Bid))
                {
                    string finalPrice = item.Bid;

                    ProcessStartInfo startInfo = new ProcessStartInfo("chrome", "https://offer.ebay.com/ws/eBayISAPI.dll?MfcISAPICommand=MakeBid&uiid=1859999246&co_partnerid=2&fb=2&item=" + item.ItemNumber + "&maxbid=" + (double.Parse(item.Bid)) + "&Ctn=Continue");
                    startInfo.WindowStyle = ProcessWindowStyle.Maximized;
                    Process.Start(startInfo);

                    Thread.Sleep(1500);

                    Cursor.Position = buttonCoordinates;
                    LeftMouseClick(buttonCoordinates.X, buttonCoordinates.Y);

                    Log("Confirmed bid for item " + item.ItemNumber);
                }
                else
                {
                    //Logs failure of auctions whose current prices exceeded bid
                    Log("Bid amount " + String.Format(item.Bid, "C") + " exceeded requested bid of " + item.Price + " on item number " + itemNumber.Text);
                }
            }
            catch
            {
                Log("Exception");
            }
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern bool SetCursorPos(int x, int y);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);

        public const int MOUSEEVENTF_LEFTDOWN = 0x02;
        public const int MOUSEEVENTF_LEFTUP = 0x04;

        public static void LeftMouseClick(int xpos, int ypos)
        {
            SetCursorPos(xpos, ypos);
            mouse_event(MOUSEEVENTF_LEFTDOWN, xpos, ypos, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, xpos, ypos, 0, 0);
        }

        private void MultipleAuctions_Load(object sender, EventArgs e)
        {
            System.Timers.Timer timer = new System.Timers.Timer(2500);
            timer.Elapsed += new ElapsedEventHandler(updateInformation_Tick);
            timer.Enabled = true;

            System.Timers.Timer timer2 = new System.Timers.Timer(1500);
            timer2.Elapsed += new ElapsedEventHandler(updateTable_Tick);
            timer2.Enabled = true;

            System.Timers.Timer timer3 = new System.Timers.Timer(200);
            timer3.Elapsed += new ElapsedEventHandler(checkForEndingAuction_Tick);
            timer3.Enabled = true;
        }
    }
}