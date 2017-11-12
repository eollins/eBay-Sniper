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
            this.eBayBrowser = new System.Windows.Forms.WebBrowser();
            this.bidAmount = new System.Windows.Forms.MaskedTextBox();
            this.userId = new System.Windows.Forms.TextBox();
            this.Password = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.itemId = new System.Windows.Forms.MaskedTextBox();
            this.Confirm = new System.Windows.Forms.Button();
            this.Begin = new System.Windows.Forms.Button();
            this.timeRemaining = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // eBayBrowser
            // 
            this.eBayBrowser.Location = new System.Drawing.Point(187, 12);
            this.eBayBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.eBayBrowser.Name = "eBayBrowser";
            this.eBayBrowser.ScriptErrorsSuppressed = true;
            this.eBayBrowser.Size = new System.Drawing.Size(681, 250);
            this.eBayBrowser.TabIndex = 0;
            this.eBayBrowser.Url = new System.Uri("", System.UriKind.Relative);
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
            // userId
            // 
            this.userId.Location = new System.Drawing.Point(12, 75);
            this.userId.Name = "userId";
            this.userId.Size = new System.Drawing.Size(169, 20);
            this.userId.TabIndex = 2;
            // 
            // Password
            // 
            this.Password.Location = new System.Drawing.Point(12, 116);
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(169, 20);
            this.Password.TabIndex = 3;
            this.Password.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "User ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Password";
            // 
            // itemId
            // 
            this.itemId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemId.Location = new System.Drawing.Point(12, 152);
            this.itemId.Mask = "000000000000";
            this.itemId.Name = "itemId";
            this.itemId.Size = new System.Drawing.Size(169, 26);
            this.itemId.TabIndex = 6;
            this.itemId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Confirm
            // 
            this.Confirm.Location = new System.Drawing.Point(12, 184);
            this.Confirm.Name = "Confirm";
            this.Confirm.Size = new System.Drawing.Size(80, 23);
            this.Confirm.TabIndex = 7;
            this.Confirm.Text = "Confirm";
            this.Confirm.UseVisualStyleBackColor = true;
            this.Confirm.Click += new System.EventHandler(this.button1_Click);
            // 
            // Begin
            // 
            this.Begin.Enabled = false;
            this.Begin.Location = new System.Drawing.Point(101, 184);
            this.Begin.Name = "Begin";
            this.Begin.Size = new System.Drawing.Size(80, 23);
            this.Begin.TabIndex = 8;
            this.Begin.Text = "Begin";
            this.Begin.UseVisualStyleBackColor = true;
            this.Begin.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // timeRemaining
            // 
            this.timeRemaining.AutoSize = true;
            this.timeRemaining.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeRemaining.Location = new System.Drawing.Point(55, 241);
            this.timeRemaining.Name = "timeRemaining";
            this.timeRemaining.Size = new System.Drawing.Size(86, 24);
            this.timeRemaining.TabIndex = 9;
            this.timeRemaining.Text = "0h 0m 0s";
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(12, 212);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(169, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 271);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.timeRemaining);
            this.Controls.Add(this.Begin);
            this.Controls.Add(this.Confirm);
            this.Controls.Add(this.itemId);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Password);
            this.Controls.Add(this.userId);
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
        private System.Windows.Forms.TextBox userId;
        private System.Windows.Forms.TextBox Password;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox itemId;
        private System.Windows.Forms.Button Confirm;
        private System.Windows.Forms.Button Begin;
        private System.Windows.Forms.Label timeRemaining;
        private System.Windows.Forms.Button button1;
    }
}

