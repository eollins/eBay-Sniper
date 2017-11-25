namespace eBay_Sniper
{
    partial class MultipleAuctions
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
            this.itemTable = new System.Windows.Forms.ListView();
            this.Title = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.itemID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.currentPrice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.endTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.bid = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Import = new System.Windows.Forms.Button();
            this.addItem = new System.Windows.Forms.Button();
            this.removeItem = new System.Windows.Forms.Button();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.maxBid = new System.Windows.Forms.TextBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.viewLog = new System.Windows.Forms.Button();
            this.itemNumber = new System.Windows.Forms.TextBox();
            this.olderLogs = new System.Windows.Forms.Button();
            this.Calibrate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.updateTable = new System.Windows.Forms.Timer(this.components);
            this.updateInformation = new System.Windows.Forms.Timer(this.components);
            this.checkForEndingAuction = new System.Windows.Forms.Timer(this.components);
            this.openCSV = new System.Windows.Forms.OpenFileDialog();
            this.checkAuction = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // itemTable
            // 
            this.itemTable.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Title,
            this.itemID,
            this.currentPrice,
            this.endTime,
            this.bid});
            this.itemTable.FullRowSelect = true;
            this.itemTable.Location = new System.Drawing.Point(13, 13);
            this.itemTable.Name = "itemTable";
            this.itemTable.Size = new System.Drawing.Size(671, 455);
            this.itemTable.TabIndex = 0;
            this.itemTable.UseCompatibleStateImageBehavior = false;
            this.itemTable.View = System.Windows.Forms.View.Details;
            // 
            // Title
            // 
            this.Title.Text = "Item Title";
            this.Title.Width = 299;
            // 
            // itemID
            // 
            this.itemID.Text = "Item ID";
            this.itemID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.itemID.Width = 123;
            // 
            // currentPrice
            // 
            this.currentPrice.Text = "Current Price";
            this.currentPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.currentPrice.Width = 79;
            // 
            // endTime
            // 
            this.endTime.Text = "End Time";
            this.endTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.endTime.Width = 108;
            // 
            // bid
            // 
            this.bid.Text = "Bid";
            this.bid.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Import
            // 
            this.Import.Enabled = false;
            this.Import.Location = new System.Drawing.Point(13, 522);
            this.Import.Name = "Import";
            this.Import.Size = new System.Drawing.Size(122, 30);
            this.Import.TabIndex = 1;
            this.Import.Text = "Import Spreadsheet";
            this.Import.UseVisualStyleBackColor = true;
            this.Import.Click += new System.EventHandler(this.Import_Click);
            // 
            // addItem
            // 
            this.addItem.Enabled = false;
            this.addItem.Location = new System.Drawing.Point(295, 523);
            this.addItem.Name = "addItem";
            this.addItem.Size = new System.Drawing.Size(60, 55);
            this.addItem.TabIndex = 5;
            this.addItem.Text = "Add Item";
            this.addItem.UseVisualStyleBackColor = true;
            this.addItem.Click += new System.EventHandler(this.addItem_Click);
            // 
            // removeItem
            // 
            this.removeItem.Location = new System.Drawing.Point(361, 523);
            this.removeItem.Name = "removeItem";
            this.removeItem.Size = new System.Drawing.Size(71, 55);
            this.removeItem.TabIndex = 6;
            this.removeItem.Text = "Clear Items";
            this.removeItem.UseVisualStyleBackColor = true;
            this.removeItem.Click += new System.EventHandler(this.removeItem_Click);
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(792, 13);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.ScriptErrorsSuppressed = true;
            this.webBrowser1.Size = new System.Drawing.Size(296, 502);
            this.webBrowser1.TabIndex = 7;
            // 
            // maxBid
            // 
            this.maxBid.Location = new System.Drawing.Point(157, 523);
            this.maxBid.Name = "maxBid";
            this.maxBid.Size = new System.Drawing.Size(132, 20);
            this.maxBid.TabIndex = 3;
            this.maxBid.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(13, 558);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown1.TabIndex = 2;
            this.numericUpDown1.Value = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            // 
            // viewLog
            // 
            this.viewLog.Location = new System.Drawing.Point(566, 522);
            this.viewLog.Name = "viewLog";
            this.viewLog.Size = new System.Drawing.Size(118, 30);
            this.viewLog.TabIndex = 8;
            this.viewLog.Text = "Today\'s Log";
            this.viewLog.UseVisualStyleBackColor = true;
            this.viewLog.Click += new System.EventHandler(this.viewLog_Click);
            // 
            // itemNumber
            // 
            this.itemNumber.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemNumber.Location = new System.Drawing.Point(157, 550);
            this.itemNumber.Name = "itemNumber";
            this.itemNumber.Size = new System.Drawing.Size(132, 27);
            this.itemNumber.TabIndex = 4;
            this.itemNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // olderLogs
            // 
            this.olderLogs.Location = new System.Drawing.Point(566, 553);
            this.olderLogs.Name = "olderLogs";
            this.olderLogs.Size = new System.Drawing.Size(118, 25);
            this.olderLogs.TabIndex = 9;
            this.olderLogs.Text = "Older Logs";
            this.olderLogs.UseVisualStyleBackColor = true;
            this.olderLogs.Click += new System.EventHandler(this.olderLogs_Click);
            // 
            // Calibrate
            // 
            this.Calibrate.Location = new System.Drawing.Point(438, 523);
            this.Calibrate.Name = "Calibrate";
            this.Calibrate.Size = new System.Drawing.Size(122, 54);
            this.Calibrate.TabIndex = 7;
            this.Calibrate.Text = "Calibrate";
            this.Calibrate.UseVisualStyleBackColor = true;
            this.Calibrate.Click += new System.EventHandler(this.Calibrate_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 475);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(257, 29);
            this.label1.TabIndex = 10;
            this.label1.Text = "Next Upcoming Auction:";
            // 
            // updateTable
            // 
            this.updateTable.Interval = 2500;
            this.updateTable.Tick += new System.EventHandler(this.updateTable_Tick);
            // 
            // updateInformation
            // 
            this.updateInformation.Interval = 1000;
            this.updateInformation.Tick += new System.EventHandler(this.updateInformation_Tick);
            // 
            // checkForEndingAuction
            // 
            this.checkForEndingAuction.Interval = 200;
            this.checkForEndingAuction.Tick += new System.EventHandler(this.checkForEndingAuction_Tick);
            // 
            // checkAuction
            // 
            this.checkAuction.Enabled = true;
            this.checkAuction.Tick += new System.EventHandler(this.checkAuction_Tick);
            // 
            // MultipleAuctions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(697, 590);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Calibrate);
            this.Controls.Add(this.olderLogs);
            this.Controls.Add(this.itemNumber);
            this.Controls.Add(this.viewLog);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.maxBid);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.removeItem);
            this.Controls.Add(this.addItem);
            this.Controls.Add(this.Import);
            this.Controls.Add(this.itemTable);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "MultipleAuctions";
            this.Text = "eBay Browser Sniper";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MultipleAuctions_FormClosing);
            this.Load += new System.EventHandler(this.MultipleAuctions_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView itemTable;
        private System.Windows.Forms.ColumnHeader itemID;
        private System.Windows.Forms.ColumnHeader currentPrice;
        private System.Windows.Forms.ColumnHeader endTime;
        private System.Windows.Forms.Button Import;
        private System.Windows.Forms.Button addItem;
        private System.Windows.Forms.Button removeItem;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.ColumnHeader Title;
        private System.Windows.Forms.TextBox maxBid;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.ColumnHeader bid;
        private System.Windows.Forms.Button viewLog;
        private System.Windows.Forms.TextBox itemNumber;
        private System.Windows.Forms.Button olderLogs;
        private System.Windows.Forms.Button Calibrate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer updateTable;
        private System.Windows.Forms.Timer updateInformation;
        private System.Windows.Forms.Timer checkForEndingAuction;
        private System.Windows.Forms.OpenFileDialog openCSV;
        private System.Windows.Forms.Timer checkAuction;
    }
}