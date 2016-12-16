namespace PConfigUI
{
    partial class SerialDialog
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
            this.serial_port = new System.Windows.Forms.ComboBox();
            this.serial_baudRate = new System.Windows.Forms.ComboBox();
            this.serial_loggerID = new System.Windows.Forms.ComboBox();
            this.serial_connect = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.serial_cancel = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // serial_port
            // 
            this.serial_port.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.serial_port.FormattingEnabled = true;
            this.serial_port.Location = new System.Drawing.Point(78, 5);
            this.serial_port.Name = "serial_port";
            this.serial_port.Size = new System.Drawing.Size(121, 20);
            this.serial_port.TabIndex = 0;
            // 
            // serial_baudRate
            // 
            this.serial_baudRate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.serial_baudRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.serial_baudRate.FormattingEnabled = true;
            this.serial_baudRate.Location = new System.Drawing.Point(78, 35);
            this.serial_baudRate.Name = "serial_baudRate";
            this.serial_baudRate.Size = new System.Drawing.Size(121, 20);
            this.serial_baudRate.TabIndex = 1;
            // 
            // serial_loggerID
            // 
            this.serial_loggerID.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.serial_loggerID.FormattingEnabled = true;
            this.serial_loggerID.Location = new System.Drawing.Point(78, 65);
            this.serial_loggerID.Name = "serial_loggerID";
            this.serial_loggerID.Size = new System.Drawing.Size(121, 20);
            this.serial_loggerID.TabIndex = 2;
            // 
            // serial_connect
            // 
            this.serial_connect.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.serial_connect.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.serial_connect.Location = new System.Drawing.Point(21, 111);
            this.serial_connect.Name = "serial_connect";
            this.serial_connect.Size = new System.Drawing.Size(68, 23);
            this.serial_connect.TabIndex = 3;
            this.serial_connect.Text = "建立连接";
            this.serial_connect.UseVisualStyleBackColor = true;
            this.serial_connect.Click += new System.EventHandler(this.serial_connect_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "端口";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "波特率";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "记录器ID";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.serial_loggerID, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.serial_baudRate, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.serial_port, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(214, 90);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // serial_cancel
            // 
            this.serial_cancel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.serial_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.serial_cancel.Location = new System.Drawing.Point(122, 111);
            this.serial_cancel.Name = "serial_cancel";
            this.serial_cancel.Size = new System.Drawing.Size(75, 23);
            this.serial_cancel.TabIndex = 7;
            this.serial_cancel.Text = "退出";
            this.serial_cancel.UseVisualStyleBackColor = true;
            // 
            // SerialDialog
            // 
            this.AcceptButton = this.serial_connect;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.serial_cancel;
            this.ClientSize = new System.Drawing.Size(243, 151);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.serial_connect);
            this.Controls.Add(this.serial_cancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "SerialDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "串口连接";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox serial_port;
        private System.Windows.Forms.ComboBox serial_baudRate;
        private System.Windows.Forms.ComboBox serial_loggerID;
        private System.Windows.Forms.Button serial_connect;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button serial_cancel;
    }
}