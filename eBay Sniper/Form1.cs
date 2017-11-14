using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace eBay_Sniper
{
    public partial class Form1 : Form
    {
        bool timing = false;
        bool submitted = false;
        DateTime end;

        public Form1()
        {
            InitializeComponent();
        }

        private void LogIn(object sender, EventArgs e)
        {
            Confirm.Enabled = false;
            Begin.Enabled = true;
            bidAmount.Enabled = false;
            itemId.Enabled = false;

            new signIn().Show();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            timing = false;
            Cancel.Enabled = false;
            Begin.Enabled = false;
            Confirm.Enabled = true;
            eBayBrowser.Url = new Uri("https://signin.ebay.com");
            bidAmount.Enabled = true;
            itemId.Enabled = true;
            timeRemaining.Text = "0d 0h 0m 0s";
            timeRemaining.ForeColor = Color.Black;
        }

        string finalPrice;
        private void TimeAuction_Click(object sender, EventArgs e)
        {
            if (timing)
            {
                TimeSpan span = end - DateTime.Now;
                if (span.TotalSeconds < 0)
                {
                    timeRemaining.Text = "Auction Ended";
                    timeRemaining.ForeColor = Color.Black;
                }
                else
                {
                    timeRemaining.Text = span.Days + "d " + span.Hours + "h " + span.Minutes + "m " + span.Seconds + "s";

                    if (span.TotalMinutes < 10)
                    {
                        timeRemaining.ForeColor = Color.Red;
                    }
                    else
                    {
                        timeRemaining.ForeColor = Color.Black;
                    }
                }

                XmlDocument doc2 = new XmlDocument();
                doc2.Load("http://open.api.ebay.com/shopping?callname=GetSingleItem&responseencoding=XML&appid=GregoryM-mailer-PRD-a45ed6035-97c14545&siteid=0&version=967&ItemID=" + itemId.Text);

                string price = ((XmlElement)((XmlElement)doc2.GetElementsByTagName("GetSingleItemResponse")[0]).GetElementsByTagName("Item")[0]).GetElementsByTagName("ConvertedCurrentPrice")[0].InnerText;
                string max = bidAmount.Text.Substring(bidAmount.Text.LastIndexOf(' '));
                
                if (span.TotalMilliseconds < int.Parse(millsecondsBefore.Text) && span.TotalMilliseconds > 0 && !submitted)
                {
                    
                    if (double.Parse(price) < double.Parse(max))
                    {
                        finalPrice = (double.Parse(price) + 0.01).ToString();
                        eBayBrowser.Url = new Uri("https://offer.ebay.com/ws/eBayISAPI.dll?MfcISAPICommand=MakeBid&uiid=1859999246&co_partnerid=2&fb=2&item=" + itemId.Text + "&maxbid=" + (double.Parse(price) + 0.01) + "&Ctn=Continue");
                        Cancel_Click(Cancel, new EventArgs());
                        timing = false;
                    
                    }
                    else
                    {
                        MessageBox.Show("Price exceeded maximum bid");
                        MessageBox.Show("Price: " + price + "Max: " + max);
                        timing = false;
                    }
                }
            }
        }

        public void Continue()
        {
            eBayBrowser.Document.InvokeScript("clickButton1");
        }

        public void ConfirmBid()
        {
            eBayBrowser.Document.InvokeScript("clickButton2");
        }

        private void CheckWebpage_Tick(object sender, EventArgs e)
        {
            if (eBayBrowser.Document.GetElementsByTagName("html")[0].InnerHtml.Contains("position:relative;"))
            {
                try
                {
                    HtmlDocument doc3 = eBayBrowser.Document;
                    HtmlElement head2 = doc3.GetElementsByTagName("html")[0];
                    HtmlElement s2 = doc3.CreateElement("script");
                    s2.SetAttribute("text", "function clickButton2() { document.getElementById('but_v4-2').click(); }");
                    head2.AppendChild(s2);
                    string html = eBayBrowser.Document.GetElementsByTagName("html")[0].InnerHtml;
                    eBayBrowser.Document.InvokeScript("clickButton2");
                    MessageBox.Show("Successfully bidded " + String.Format(finalPrice, "C"));
                    Cancel_Click(Cancel, new EventArgs());
                }
                catch { }
            }
        }

        private void Begin_Click(object sender, EventArgs e)
        {
            Begin.Enabled = false;
            Cancel.Enabled = true;

            XmlDocument doc2 = new XmlDocument();
            doc2.Load("http://open.api.ebay.com/shopping?callname=GetSingleItem&responseencoding=XML&appid=GregoryM-mailer-PRD-a45ed6035-97c14545&siteid=0&version=967&ItemID=" + itemId.Text);

            XmlNodeList nodes = ((XmlElement)((XmlElement)doc2.GetElementsByTagName("GetSingleItemResponse")[0]).GetElementsByTagName("Item")[0]).GetElementsByTagName("EndTime");
            string endTime = nodes[0].InnerText;
            string[] components1 = endTime.Split('T');
            string[] date = components1[0].Split('-');
            string[] time = components1[1].Split(':');
            time[2] = time[2].Substring(0, time[2].IndexOf('.'));
            DateTime endTimeDt = new DateTime(int.Parse(date[0]), int.Parse(date[1]), int.Parse(date[2]), int.Parse(time[0]), int.Parse(time[1]), int.Parse(time[2]));
            endTimeDt = endTimeDt.AddHours(-8);
            endTimeDt = endTimeDt.AddSeconds(-4);
            end = endTimeDt;

            DateTime yes = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
            yes = yes.AddSeconds(10);
            //end = yes;
            timing = true;
        }
    }
}
