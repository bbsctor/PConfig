namespace PConfigUI
{
    partial class ProbeInfoDialog
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
            this.probeInfo_type = new System.Windows.Forms.TextBox();
            this.probeInfo_serialNumber = new System.Windows.Forms.TextBox();
            this.probeInfo_addr = new System.Windows.Forms.TextBox();
            this.probeInfo_version = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.probeInfo_addrLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.probeInfo_refresh = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // probeInfo_type
            // 
            this.probeInfo_type.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.probeInfo_type.Enabled = false;
            this.probeInfo_type.Location = new System.Drawing.Point(70, 6);
            this.probeInfo_type.Name = "probeInfo_type";
            this.probeInfo_type.Size = new System.Drawing.Size(147, 21);
            this.probeInfo_type.TabIndex = 0;
            // 
            // probeInfo_serialNumber
            // 
            this.probeInfo_serialNumber.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.probeInfo_serialNumber.Enabled = false;
            this.probeInfo_serialNumber.Location = new System.Drawing.Point(69, 40);
            this.probeInfo_serialNumber.Name = "probeInfo_serialNumber";
            this.probeInfo_serialNumber.Size = new System.Drawing.Size(149, 21);
            this.probeInfo_serialNumber.TabIndex = 1;
            // 
            // probeInfo_addr
            // 
            this.probeInfo_addr.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.probeInfo_addr.Location = new System.Drawing.Point(69, 74);
            this.probeInfo_addr.Name = "probeInfo_addr";
            this.probeInfo_addr.Size = new System.Drawing.Size(149, 21);
            this.probeInfo_addr.TabIndex = 2;
            this.probeInfo_addr.TextChanged += new System.EventHandler(this.probeInfo_addr_TextChanged);
            // 
            // probeInfo_version
            // 
            this.probeInfo_version.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.probeInfo_version.Enabled = false;
            this.probeInfo_version.Location = new System.Drawing.Point(69, 110);
            this.probeInfo_version.Name = "probeInfo_version";
            this.probeInfo_version.Size = new System.Drawing.Size(149, 21);
            this.probeInfo_version.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "类型";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "编号";
            // 
            // probeInfo_addrLabel
            // 
            this.probeInfo_addrLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.probeInfo_addrLabel.AutoSize = true;
            this.probeInfo_addrLabel.Location = new System.Drawing.Point(18, 79);
            this.probeInfo_addrLabel.Name = "probeInfo_addrLabel";
            this.probeInfo_addrLabel.Size = new System.Drawing.Size(29, 12);
            this.probeInfo_addrLabel.TabIndex = 6;
            this.probeInfo_addrLabel.Text = "地址";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "版本号";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.probeInfo_version, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.probeInfo_type, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.probeInfo_addrLabel, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.probeInfo_addr, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.probeInfo_serialNumber, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(221, 139);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // probeInfo_refresh
            // 
            this.probeInfo_refresh.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.probeInfo_refresh.Location = new System.Drawing.Point(32, 169);
            this.probeInfo_refresh.Name = "probeInfo_refresh";
            this.probeInfo_refresh.Size = new System.Drawing.Size(75, 23);
            this.probeInfo_refresh.TabIndex = 9;
            this.probeInfo_refresh.Text = "刷新";
            this.probeInfo_refresh.UseVisualStyleBackColor = true;
            this.probeInfo_refresh.Click += new System.EventHandler(this.probeInfo_refresh_Click);
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Location = new System.Drawing.Point(143, 169);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "关闭";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // ProbeInfoDialog
            // 
            this.AcceptButton = this.probeInfo_refresh;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(256, 213);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.probeInfo_refresh);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ProbeInfoDialog";
            this.Text = "探头信息";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox probeInfo_type;
        private System.Windows.Forms.TextBox probeInfo_serialNumber;
        private System.Windows.Forms.TextBox probeInfo_addr;
        private System.Windows.Forms.TextBox probeInfo_version;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label probeInfo_addrLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button probeInfo_refresh;
        private System.Windows.Forms.Button button1;
    }
}