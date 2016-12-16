namespace PConfigUI
{
    partial class ConfirmDialog
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
            this.confirm_OK = new System.Windows.Forms.Button();
            this.confirm_cancel = new System.Windows.Forms.Button();
            this.confirm_showPage = new System.Windows.Forms.Button();
            this.confirm_listView = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // confirm_OK
            // 
            this.confirm_OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.confirm_OK.Location = new System.Drawing.Point(147, 53);
            this.confirm_OK.Name = "confirm_OK";
            this.confirm_OK.Size = new System.Drawing.Size(75, 23);
            this.confirm_OK.TabIndex = 1;
            this.confirm_OK.Text = "确定";
            this.confirm_OK.UseVisualStyleBackColor = true;
            // 
            // confirm_cancel
            // 
            this.confirm_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.confirm_cancel.Location = new System.Drawing.Point(147, 105);
            this.confirm_cancel.Name = "confirm_cancel";
            this.confirm_cancel.Size = new System.Drawing.Size(75, 23);
            this.confirm_cancel.TabIndex = 2;
            this.confirm_cancel.Text = "退出";
            this.confirm_cancel.UseVisualStyleBackColor = true;
            // 
            // confirm_showPage
            // 
            this.confirm_showPage.DialogResult = System.Windows.Forms.DialogResult.Retry;
            this.confirm_showPage.Location = new System.Drawing.Point(147, 154);
            this.confirm_showPage.Name = "confirm_showPage";
            this.confirm_showPage.Size = new System.Drawing.Size(75, 23);
            this.confirm_showPage.TabIndex = 3;
            this.confirm_showPage.Text = "显示页面";
            this.confirm_showPage.UseVisualStyleBackColor = true;
            // 
            // confirm_listView
            // 
            this.confirm_listView.Location = new System.Drawing.Point(13, 53);
            this.confirm_listView.Name = "confirm_listView";
            this.confirm_listView.Size = new System.Drawing.Size(128, 124);
            this.confirm_listView.TabIndex = 4;
            this.confirm_listView.UseCompatibleStateImageBehavior = false;
            this.confirm_listView.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.confirm_listView_ItemChecked);
            // 
            // ConfirmDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(240, 217);
            this.Controls.Add(this.confirm_listView);
            this.Controls.Add(this.confirm_showPage);
            this.Controls.Add(this.confirm_cancel);
            this.Controls.Add(this.confirm_OK);
            this.Name = "ConfirmDialog";
            this.Text = "ConfirmDialog";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button confirm_OK;
        private System.Windows.Forms.Button confirm_cancel;
        private System.Windows.Forms.Button confirm_showPage;
        private System.Windows.Forms.ListView confirm_listView;
    }
}