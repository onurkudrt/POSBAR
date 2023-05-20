
namespace POSBAR
{
    partial class CashierInterface
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
            this.cbCashiers = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lvScreen = new System.Windows.Forms.ListView();
            this.lblScreen = new System.Windows.Forms.Label();
            this.txtData = new System.Windows.Forms.TextBox();
            this.cbProcess = new System.Windows.Forms.ComboBox();
            this.lblData = new System.Windows.Forms.Label();
            this.lblCashierName = new System.Windows.Forms.Label();
            this.lblShopID = new System.Windows.Forms.Label();
            this.txtData2 = new System.Windows.Forms.TextBox();
            this.lblData2 = new System.Windows.Forms.Label();
            this.lblData3 = new System.Windows.Forms.Label();
            this.txtData3 = new System.Windows.Forms.TextBox();
            this.btnRun = new System.Windows.Forms.Button();
            this.gbCashierInfo = new System.Windows.Forms.GroupBox();
            this.gbCashierInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbCashiers
            // 
            this.cbCashiers.FormattingEnabled = true;
            this.cbCashiers.Location = new System.Drawing.Point(95, 17);
            this.cbCashiers.Name = "cbCashiers";
            this.cbCashiers.Size = new System.Drawing.Size(121, 21);
            this.cbCashiers.TabIndex = 0;
            this.cbCashiers.SelectedIndexChanged += new System.EventHandler(this.cbCashiers_SelectedIndexChanged);
            this.cbCashiers.TextUpdate += new System.EventHandler(this.btnRun_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Kasiyer Listesi:";
            // 
            // lvScreen
            // 
            this.lvScreen.HideSelection = false;
            this.lvScreen.Location = new System.Drawing.Point(549, 20);
            this.lvScreen.Name = "lvScreen";
            this.lvScreen.Size = new System.Drawing.Size(359, 475);
            this.lvScreen.TabIndex = 3;
            this.lvScreen.UseCompatibleStateImageBehavior = false;
            this.lvScreen.Visible = false;
            // 
            // lblScreen
            // 
            this.lblScreen.AutoSize = true;
            this.lblScreen.Location = new System.Drawing.Point(710, 4);
            this.lblScreen.Name = "lblScreen";
            this.lblScreen.Size = new System.Drawing.Size(44, 13);
            this.lblScreen.TabIndex = 4;
            this.lblScreen.Text = "EKRAN";
            this.lblScreen.Visible = false;
            // 
            // txtData
            // 
            this.txtData.Location = new System.Drawing.Point(21, 199);
            this.txtData.Name = "txtData";
            this.txtData.Size = new System.Drawing.Size(411, 20);
            this.txtData.TabIndex = 5;
            this.txtData.Visible = false;
            // 
            // cbProcess
            // 
            this.cbProcess.FormattingEnabled = true;
            this.cbProcess.Items.AddRange(new object[] {
            "Ödeme Yap",
            "İade Oluştur",
            "Ürün Oku"});
            this.cbProcess.Location = new System.Drawing.Point(57, 156);
            this.cbProcess.Name = "cbProcess";
            this.cbProcess.Size = new System.Drawing.Size(213, 21);
            this.cbProcess.TabIndex = 7;
            this.cbProcess.Text = "İşlem Seçiniz";
            this.cbProcess.Visible = false;
            this.cbProcess.SelectedIndexChanged += new System.EventHandler(this.cbProcess_SelectedIndexChanged);
            this.cbProcess.TextUpdate += new System.EventHandler(this.cbCashiers_SelectedIndexChanged);
            // 
            // lblData
            // 
            this.lblData.AutoSize = true;
            this.lblData.Location = new System.Drawing.Point(18, 183);
            this.lblData.Name = "lblData";
            this.lblData.Size = new System.Drawing.Size(40, 13);
            this.lblData.TabIndex = 8;
            this.lblData.Text = "lblData";
            this.lblData.Visible = false;
            // 
            // lblCashierName
            // 
            this.lblCashierName.AutoSize = true;
            this.lblCashierName.Location = new System.Drawing.Point(18, 29);
            this.lblCashierName.Name = "lblCashierName";
            this.lblCashierName.Size = new System.Drawing.Size(69, 13);
            this.lblCashierName.TabIndex = 10;
            this.lblCashierName.Text = "cashierName";
            // 
            // lblShopID
            // 
            this.lblShopID.AutoSize = true;
            this.lblShopID.Location = new System.Drawing.Point(18, 56);
            this.lblShopID.Name = "lblShopID";
            this.lblShopID.Size = new System.Drawing.Size(77, 13);
            this.lblShopID.TabIndex = 11;
            this.lblShopID.Text = "cashierShopID";
            // 
            // txtData2
            // 
            this.txtData2.Location = new System.Drawing.Point(20, 245);
            this.txtData2.Name = "txtData2";
            this.txtData2.Size = new System.Drawing.Size(411, 20);
            this.txtData2.TabIndex = 12;
            this.txtData2.Visible = false;
            // 
            // lblData2
            // 
            this.lblData2.AutoSize = true;
            this.lblData2.Location = new System.Drawing.Point(20, 229);
            this.lblData2.Name = "lblData2";
            this.lblData2.Size = new System.Drawing.Size(46, 13);
            this.lblData2.TabIndex = 13;
            this.lblData2.Text = "lblData2";
            this.lblData2.Visible = false;
            // 
            // lblData3
            // 
            this.lblData3.AutoSize = true;
            this.lblData3.Location = new System.Drawing.Point(22, 284);
            this.lblData3.Name = "lblData3";
            this.lblData3.Size = new System.Drawing.Size(46, 13);
            this.lblData3.TabIndex = 15;
            this.lblData3.Text = "lblData3";
            this.lblData3.Visible = false;
            // 
            // txtData3
            // 
            this.txtData3.Location = new System.Drawing.Point(22, 300);
            this.txtData3.Name = "txtData3";
            this.txtData3.Size = new System.Drawing.Size(411, 20);
            this.txtData3.TabIndex = 14;
            this.txtData3.Visible = false;
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(276, 156);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(154, 23);
            this.btnRun.TabIndex = 16;
            this.btnRun.Text = "YÜRÜT";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Visible = false;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click_1);
            // 
            // gbCashierInfo
            // 
            this.gbCashierInfo.Controls.Add(this.lblCashierName);
            this.gbCashierInfo.Controls.Add(this.lblShopID);
            this.gbCashierInfo.Location = new System.Drawing.Point(295, 20);
            this.gbCashierInfo.Name = "gbCashierInfo";
            this.gbCashierInfo.Size = new System.Drawing.Size(200, 100);
            this.gbCashierInfo.TabIndex = 17;
            this.gbCashierInfo.TabStop = false;
            this.gbCashierInfo.Text = "KASİYER BİLGİSİ";
            this.gbCashierInfo.Visible = false;
            // 
            // CashierInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PeachPuff;
            this.ClientSize = new System.Drawing.Size(932, 507);
            this.Controls.Add(this.gbCashierInfo);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.lblData3);
            this.Controls.Add(this.txtData3);
            this.Controls.Add(this.lblData2);
            this.Controls.Add(this.txtData2);
            this.Controls.Add(this.lblData);
            this.Controls.Add(this.cbProcess);
            this.Controls.Add(this.txtData);
            this.Controls.Add(this.lblScreen);
            this.Controls.Add(this.lvScreen);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbCashiers);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "CashierInterface";
            this.Text = "CashierInterface";
            this.Load += new System.EventHandler(this.CashierInterface_Load);
            this.gbCashierInfo.ResumeLayout(false);
            this.gbCashierInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbCashiers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lvScreen;
        private System.Windows.Forms.Label lblScreen;
        private System.Windows.Forms.TextBox txtData;
        private System.Windows.Forms.ComboBox cbProcess;
        private System.Windows.Forms.Label lblData;
        private System.Windows.Forms.Label lblCashierName;
        private System.Windows.Forms.Label lblShopID;
        private System.Windows.Forms.TextBox txtData2;
        private System.Windows.Forms.Label lblData2;
        private System.Windows.Forms.Label lblData3;
        private System.Windows.Forms.TextBox txtData3;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.GroupBox gbCashierInfo;
    }
}