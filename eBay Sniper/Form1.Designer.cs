namespace eBay_Sniper
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.eBayBrowser = new System.Windows.Forms.WebBrowser();
            this.bidAmount = new System.Windows.Forms.MaskedTextBox();
            this.itemId = new System.Windows.Forms.MaskedTextBox();
            this.Confirm = new System.Windows.Forms.Button();
            this.Begin = new System.Windows.Forms.Button();
            this.timeRemaining = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // eBayBrowser
            // 
            this.eBayBrowser.Location = new System.Drawing.Point(270, 9);
            this.eBayBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.eBayBrowser.Name = "eBayBrowser";
            this.eBayBrowser.ScriptErrorsSuppressed = true;
            this.eBayBrowser.Size = new System.Drawing.Size(681, 250);
            this.eBayBrowser.TabIndex = 0;
            this.eBayBrowser.Url = new System.Uri("", System.UriKind.Relative);
            this.eBayBrowser.Navigated += new System.Windows.Forms.WebBrowserNavigatedEventHandler(this.eBayBrowser_Navigated);
            // 
            // bidAmount
            // 
            this.bidAmount.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bidAmount.Location = new System.Drawing.Point(12, 12);
            this.bidAmount.Mask = "$00000.00";
            this.bidAmount.Name = "bidAmount";
            this.bidAmount.Size = new System.Drawing.Size(169, 37);
            this.bidAmount.TabIndex = 1;
            this.bidAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // itemId
            // 
            this.itemId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemId.Location = new System.Drawing.Point(12, 55);
            this.itemId.Mask = "000000000000";
            this.itemId.Name = "itemId";
            this.itemId.Size = new System.Drawing.Size(169, 26);
            this.itemId.TabIndex = 6;
            this.itemId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Confirm
            // 
            this.Confirm.Location = new System.Drawing.Point(12, 87);
            this.Confirm.Name = "Confirm";
            this.Confirm.Size = new System.Drawing.Size(80, 23);
            this.Confirm.TabIndex = 7;
            this.Confirm.Text = "Log In";
            this.Confirm.UseVisualStyleBackColor = true;
            this.Confirm.Click += new System.EventHandler(this.button1_Click);
            // 
            // Begin
            // 
            this.Begin.Enabled = false;
            this.Begin.Location = new System.Drawing.Point(101, 87);
            this.Begin.Name = "Begin";
            this.Begin.Size = new System.Drawing.Size(80, 23);
            this.Begin.TabIndex = 8;
            this.Begin.Text = "Begin";
            this.Begin.UseVisualStyleBackColor = true;
            this.Begin.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // timeRemaining
            // 
            this.timeRemaining.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeRemaining.Location = new System.Drawing.Point(12, 144);
            this.timeRemaining.Name = "timeRemaining";
            this.timeRemaining.Size = new System.Drawing.Size(169, 23);
            this.timeRemaining.TabIndex = 9;
            this.timeRemaining.Text = "0d 0h 0m 0s";
            this.timeRemaining.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(12, 115);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(169, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 200;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.Location = new System.Drawing.Point(72, 170);
            this.maskedTextBox1.Mask = "0000";
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.Size = new System.Drawing.Size(46, 20);
            this.maskedTextBox1.TabIndex = 11;
            this.maskedTextBox1.Text = "3500";
            this.maskedTextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(193, 199);
            this.Controls.Add(this.maskedTextBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.timeRemaining);
            this.Controls.Add(this.Begin);
            this.Controls.Add(this.Confirm);
            this.Controls.Add(this.itemId);
            this.Controls.Add(this.bidAmount);
            this.Controls.Add(this.eBayBrowser);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.WebBrowser eBayBrowser;
        private System.Windows.Forms.MaskedTextBox bidAmount;
        private System.Windows.Forms.MaskedTextBox itemId;
        private System.Windows.Forms.Button Confirm;
        private System.Windows.Forms.Button Begin;
        private System.Windows.Forms.Label timeRemaining;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
        private System.Windows.Forms.Timer timer2;
    }
}

