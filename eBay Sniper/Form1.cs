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

        private void button1_Click(object sender, EventArgs e)
        {
            Confirm.Enabled = false;
            Begin.Enabled = true;
            bidAmount.Enabled = false;
            itemId.Enabled = false;

            new signIn().Show();


            //HtmlDocument doc = eBayBrowser.Document;
            //HtmlElement head = doc.GetElementsByTagName("head")[0];
            //HtmlElement s = doc.CreateElement("script");
            //s.SetAttribute("text", "function sayHello() { document.getElementById('userid').value = '" + userId.Text + "'; \n document.getElementById('pass').value = '" + Password.Text + "'; \n document.getElementById('sgnBt').click(); }");
            //head.AppendChild(s);
            //eBayBrowser.Document.InvokeScript("sayHello");

            //MessageBox.Show(GetForegroundWindow().ToString());
            //Process.Start("chrome", "https://signin.ebay.com");
            //MessageBox.Show(GetForegroundWindow().ToString());
            eBayBrowser.Url = new Uri("https://offer.ebay.com/ws/eBayISAPI.dll?MakeBid&fromPage=2047675&item=" + itemId.Text + "&fb=2");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            eBayBrowser.Url = new Uri("https://offer.ebay.com/ws/eBayISAPI.dll?MakeBid&fromPage=2047675&item=" + itemId.Text + "&fb=2");

            //HtmlDocument source = eBayBrowser.Document;
            //HtmlElement id = source.GetElementById("userid");
            //if (id != null)
            //{
            //    HtmlDocument doc2 = eBayBrowser.Document;
            //    HtmlElement head2 = doc2.GetElementsByTagName("head")[0];
            //    HtmlElement s2 = doc2.CreateElement("script");
            //    s2.SetAttribute("text", "function runCommand() { document.getElementById('userid').value = '" + userId.Text + "'; }");
            //    head2.AppendChild(s2);
            //    eBayBrowser.Document.InvokeScript("runCommand");

            //    s2.SetAttribute("text", "function runCommand() { document.getElementById('pass').value = '" + Password.Text + "'; }");
            //    head2.AppendChild(s2);
            //    eBayBrowser.Document.InvokeScript("runCommand");

            //    SendKeys.Send("{ENTER}");
            //}

            XmlDocument doc2 = new XmlDocument();
            doc2.Load("http://open.api.ebay.com/shopping?callname=GetSingleItem&responseencoding=XML&appid=GregoryM-mailer-PRD-a45ed6035-97c14545&siteid=0&version=967&ItemID=" + itemId.Text);
            //MessageBox.Show(doc2.InnerText);

            XmlNodeList nodes = ((XmlElement)((XmlElement)doc2.GetElementsByTagName("GetSingleItemResponse")[0]).GetElementsByTagName("Item")[0]).GetElementsByTagName("EndTime");
            string endTime = nodes[0].InnerText;
            string[] components1 = endTime.Split('T');
            string[] date = components1[0].Split('-');
            string[] time = components1[1].Split(':');
            time[2] = time[2].Substring(0, time[2].IndexOf('.'));
            DateTime endTimeDt = new DateTime(int.Parse(date[0]), int.Parse(date[1]), int.Parse(date[2]), int.Parse(time[0]) - 8, int.Parse(time[1]), int.Parse(time[2]) - 5);
            end = endTimeDt;

            //end = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second + 10);
            timing = true;

            if (eBayBrowser.Url.ToString() == "https://offer.ebay.com/ws/eBayISAPI.dll?MakeBid&fromPage=2047675&item=" + itemId.Text + "&fb=2")
            {
                button1.Enabled = true;
                Begin.Enabled = false;
            }
            else
            {
                MessageBox.Show("Invalid item number");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timing)
            {
                TimeSpan span = end - DateTime.Now;
                if (span.TotalSeconds < 0)
                {
                    timeRemaining.Text = "Auction Ended";
                }
                else
                {
                    timeRemaining.Text = span.Days + "d " + span.Hours + "h " + span.Minutes + "m " + span.Seconds + "s";
                }

                //if (span.TotalMilliseconds < int.Parse(maskedTextBox1.Text) && span.TotalMilliseconds > 0 && !submitted)
                {
                    XmlDocument doc2 = new XmlDocument();
                    doc2.Load("http://open.api.ebay.com/shopping?callname=GetSingleItem&responseencoding=XML&appid=GregoryM-mailer-PRD-a45ed6035-97c14545&siteid=0&version=967&ItemID=" + itemId.Text);

                    string price = ((XmlElement)((XmlElement)doc2.GetElementsByTagName("GetSingleItemResponse")[0]).GetElementsByTagName("Item")[0]).GetElementsByTagName("ConvertedCurrentPrice")[0].InnerText;
                    string max = bidAmount.Text.Substring(bidAmount.Text.LastIndexOf(' '));
                    if (double.Parse(price) < double.Parse(max))
                    {
                        SubmitBid(double.Parse(bidAmount.Text.Substring(1).Substring(bidAmount.Text.LastIndexOf(' '))) + 0.01);


                        string url = eBayBrowser.Url.ToString();

                        //while (url == eBayBrowser.Url.ToString())
                        //{
                        //    s.SetAttribute("text", "function runCommand() { document.getElementById('but_v4-2').click(); }");
                        //    head.AppendChild(s);
                        //    //eBayBrowser.Document.InvokeScript("runCommand");
                        //}

                        //MessageBox.Show("Bid placed");

                        HtmlDocument doc = eBayBrowser.Document;
                        HtmlElement head = doc.GetElementsByTagName("head")[0];
                        HtmlElement s = doc.CreateElement("script");
                        s.SetAttribute("text", "function submitBid() { document.getElementById('but_v4-2').click() }");
                        head.AppendChild(s);
                        eBayBrowser.Document.InvokeScript("submitBid");
                        //MessageBox.Show("Bid $" + price);
                        Cancel_Click(button1, new EventArgs());
                        //MessageBox.Show("Price: " + price + " Max: " + max);
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

        private void button1_Click_1(object sender, EventArgs e)
        {
            timing = false;
            button1.Enabled = false;
            Begin.Enabled = false;
            Confirm.Enabled = true;
            eBayBrowser.Url = new Uri("https://signin.ebay.com");
            bidAmount.Enabled = true;
            itemId.Enabled = true;
            timeRemaining.Text = "0d 0h 0m 0s";
        }

        public void SubmitBid(double price)
        {
            HtmlDocument doc = eBayBrowser.Document;
            HtmlElement head = doc.GetElementsByTagName("head")[0];
            HtmlElement s = doc.CreateElement("script");
            s.SetAttribute("text", "function sub() { document.getElementById('maxbid').value = '" + price + "'; \n document.getElementById('but_v4-1').click(); }");
            head.AppendChild(s);
            eBayBrowser.Document.InvokeScript("sub");
            submitted = true;
        }
    }
}
