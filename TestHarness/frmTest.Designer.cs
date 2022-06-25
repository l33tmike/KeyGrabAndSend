namespace TestHarness
{
    partial class frmTest
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
            this.lstProcesses = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.cmdSendMessage = new System.Windows.Forms.Button();
            this.cmdRefreshList = new System.Windows.Forms.Button();
            this.cmdEnableForward = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cmdDisableForward = new System.Windows.Forms.Button();
            this.chkSendOnlyMediaKeys = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select a process";
            // 
            // lstProcesses
            // 
            this.lstProcesses.FormattingEnabled = true;
            this.lstProcesses.Location = new System.Drawing.Point(12, 25);
            this.lstProcesses.Name = "lstProcesses";
            this.lstProcesses.Size = new System.Drawing.Size(167, 277);
            this.lstProcesses.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(207, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Message To Send";
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(210, 25);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(172, 20);
            this.txtMessage.TabIndex = 4;
            // 
            // cmdSendMessage
            // 
            this.cmdSendMessage.Location = new System.Drawing.Point(210, 51);
            this.cmdSendMessage.Name = "cmdSendMessage";
            this.cmdSendMessage.Size = new System.Drawing.Size(75, 23);
            this.cmdSendMessage.TabIndex = 5;
            this.cmdSendMessage.Text = "Send";
            this.cmdSendMessage.UseVisualStyleBackColor = true;
            this.cmdSendMessage.Click += new System.EventHandler(this.cmdSendMessage_Click);
            // 
            // cmdRefreshList
            // 
            this.cmdRefreshList.Location = new System.Drawing.Point(12, 308);
            this.cmdRefreshList.Name = "cmdRefreshList";
            this.cmdRefreshList.Size = new System.Drawing.Size(167, 23);
            this.cmdRefreshList.TabIndex = 6;
            this.cmdRefreshList.Text = "Refresh List";
            this.cmdRefreshList.UseVisualStyleBackColor = true;
            this.cmdRefreshList.Click += new System.EventHandler(this.cmdRefreshList_Click);
            // 
            // cmdEnableForward
            // 
            this.cmdEnableForward.Location = new System.Drawing.Point(210, 155);
            this.cmdEnableForward.Name = "cmdEnableForward";
            this.cmdEnableForward.Size = new System.Drawing.Size(91, 53);
            this.cmdEnableForward.TabIndex = 7;
            this.cmdEnableForward.Text = "Enable";
            this.cmdEnableForward.UseVisualStyleBackColor = true;
            this.cmdEnableForward.Click += new System.EventHandler(this.cmdEnableForward_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(207, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(210, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Forward all key-pushes to selected process";
            // 
            // cmdDisableForward
            // 
            this.cmdDisableForward.Enabled = false;
            this.cmdDisableForward.Location = new System.Drawing.Point(307, 155);
            this.cmdDisableForward.Name = "cmdDisableForward";
            this.cmdDisableForward.Size = new System.Drawing.Size(91, 53);
            this.cmdDisableForward.TabIndex = 9;
            this.cmdDisableForward.Text = "Disable";
            this.cmdDisableForward.UseVisualStyleBackColor = true;
            this.cmdDisableForward.Click += new System.EventHandler(this.cmdDisableForward_Click);
            // 
            // chkSendOnlyMediaKeys
            // 
            this.chkSendOnlyMediaKeys.AutoSize = true;
            this.chkSendOnlyMediaKeys.Checked = true;
            this.chkSendOnlyMediaKeys.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSendOnlyMediaKeys.Location = new System.Drawing.Point(210, 214);
            this.chkSendOnlyMediaKeys.Name = "chkSendOnlyMediaKeys";
            this.chkSendOnlyMediaKeys.Size = new System.Drawing.Size(133, 17);
            this.chkSendOnlyMediaKeys.TabIndex = 10;
            this.chkSendOnlyMediaKeys.Text = "Send Only Media Keys";
            this.chkSendOnlyMediaKeys.UseVisualStyleBackColor = true;
            // 
            // frmTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 346);
            this.Controls.Add(this.chkSendOnlyMediaKeys);
            this.Controls.Add(this.cmdDisableForward);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmdEnableForward);
            this.Controls.Add(this.cmdRefreshList);
            this.Controls.Add(this.cmdSendMessage);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lstProcesses);
            this.Controls.Add(this.label1);
            this.Name = "frmTest";
            this.Text = "KeyGrabAndSend Test Harness";
            this.Load += new System.EventHandler(this.frmTest_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstProcesses;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Button cmdSendMessage;
        private System.Windows.Forms.Button cmdRefreshList;
        private System.Windows.Forms.Button cmdEnableForward;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button cmdDisableForward;
        private System.Windows.Forms.CheckBox chkSendOnlyMediaKeys;
    }
}

