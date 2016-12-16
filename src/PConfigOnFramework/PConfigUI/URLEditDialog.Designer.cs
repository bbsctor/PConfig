namespace PConfigUI
{
    partial class URLEditDialog
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.url_servAddr = new System.Windows.Forms.TextBox();
            this.url_path = new System.Windows.Forms.TextBox();
            this.url_port = new System.Windows.Forms.TextBox();
            this.url_userName = new System.Windows.Forms.TextBox();
            this.url_password = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.url_OK = new System.Windows.Forms.Button();
            this.url_cancel = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "服务器地址";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "路径";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "端口";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "用户名";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(39, 133);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "密码";
            // 
            // url_servAddr
            // 
            this.url_servAddr.Location = new System.Drawing.Point(74, 3);
            this.url_servAddr.Name = "url_servAddr";
            this.url_servAddr.Size = new System.Drawing.Size(132, 21);
            this.url_servAddr.TabIndex = 5;
            // 
            // url_path
            // 
            this.url_path.Location = new System.Drawing.Point(74, 34);
            this.url_path.Name = "url_path";
            this.url_path.Size = new System.Drawing.Size(132, 21);
            this.url_path.TabIndex = 6;
            // 
            // url_port
            // 
            this.url_port.Location = new System.Drawing.Point(74, 65);
            this.url_port.Name = "url_port";
            this.url_port.Size = new System.Drawing.Size(132, 21);
            this.url_port.TabIndex = 7;
            // 
            // url_userName
            // 
            this.url_userName.Location = new System.Drawing.Point(74, 96);
            this.url_userName.Name = "url_userName";
            this.url_userName.Size = new System.Drawing.Size(132, 21);
            this.url_userName.TabIndex = 8;
            // 
            // url_password
            // 
            this.url_password.Location = new System.Drawing.Point(74, 127);
            this.url_password.Name = "url_password";
            this.url_password.Size = new System.Drawing.Size(132, 21);
            this.url_password.TabIndex = 9;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.url_password, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.url_userName, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.url_port, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.url_path, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.url_servAddr, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(10, 13);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(239, 155);
            this.tableLayoutPanel1.TabIndex = 10;
            // 
            // url_OK
            // 
            this.url_OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.url_OK.Location = new System.Drawing.Point(39, 175);
            this.url_OK.Name = "url_OK";
            this.url_OK.Size = new System.Drawing.Size(75, 23);
            this.url_OK.TabIndex = 11;
            this.url_OK.Text = "确定";
            this.url_OK.UseVisualStyleBackColor = true;
            this.url_OK.Click += new System.EventHandler(this.url_OK_Click);
            // 
            // url_cancel
            // 
            this.url_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.url_cancel.Location = new System.Drawing.Point(141, 175);
            this.url_cancel.Name = "url_cancel";
            this.url_cancel.Size = new System.Drawing.Size(75, 23);
            this.url_cancel.TabIndex = 12;
            this.url_cancel.Text = "取消";
            this.url_cancel.UseVisualStyleBackColor = true;
            // 
            // URLEditDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(256, 210);
            this.Controls.Add(this.url_cancel);
            this.Controls.Add(this.url_OK);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "URLEditDialog";
            this.Text = "URLEditDialog";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox url_servAddr;
        private System.Windows.Forms.TextBox url_path;
        private System.Windows.Forms.TextBox url_port;
        private System.Windows.Forms.TextBox url_userName;
        private System.Windows.Forms.TextBox url_password;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button url_OK;
        private System.Windows.Forms.Button url_cancel;
    }
}