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
    public partial class signIn : Form
    {
        public signIn()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (!webBrowser1.Url.ToString().Contains("signin"))
                {
                    this.Hide();
                }
            }
            catch { }
        }

        private void signIn_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void signIn_KeyDown(object sender, KeyEventArgs e)
        {

        }
    }
}
