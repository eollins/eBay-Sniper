using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eBay_Sniper
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            eBayBrowser.Url = new Uri("https://offer.ebay.com/ws/eBayISAPI.dll?MakeBid&fromPage=2047675&item=" + itemId.Text + "&fb=2");
            Confirm.Enabled = false;
            Begin.Enabled = true;
            bidAmount.Enabled = false;
            itemId.Enabled = false;
            userId.Enabled = false;
            Password.Enabled = false;

            HtmlDocument doc = eBayBrowser.Document;
            HtmlElement head = doc.GetElementsByTagName("head")[0];
            HtmlElement s = doc.CreateElement("script");
            s.SetAttribute("text", "function sayHello() { document.getElementById('maxbid').value = '" + bidAmount.Text + "'; }");
            head.AppendChild(s);
            eBayBrowser.Document.InvokeScript("sayHello");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            HtmlDocument doc = eBayBrowser.Document;
            HtmlElement head = doc.GetElementsByTagName("head")[0];
            HtmlElement s = doc.CreateElement("script");
            s.SetAttribute("text", "function runCommand() { document.getElementById('maxbid').value = '" + bidAmount.Text.Substring(1).Substring(bidAmount.Text.LastIndexOf(' ')) + "'; }");
            head.AppendChild(s);
            eBayBrowser.Document.InvokeScript("runCommand");

            s.SetAttribute("text", "function runCommand() { document.getElementById('but_v4-1').click(); }");
            head.AppendChild(s);
            eBayBrowser.Document.InvokeScript("runCommand");

            button1.Enabled = true;
            Begin.Enabled = false;
        }
    }
}
