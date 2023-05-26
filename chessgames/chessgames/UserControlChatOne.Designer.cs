namespace chessgames
{
    partial class UserControlChatOne
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.rtbContentChatOne = new System.Windows.Forms.RichTextBox();
            this.txtSendMsgChatOne = new System.Windows.Forms.TextBox();
            this.btnSendIconChatOne = new System.Windows.Forms.Button();
            this.btnSendMsgChatOne = new System.Windows.Forms.Button();
            this.btnCloseForm = new System.Windows.Forms.Button();
            this.pnlContainIconsChatOne = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // rtbContentChatOne
            // 
            this.rtbContentChatOne.Location = new System.Drawing.Point(3, 26);
            this.rtbContentChatOne.Name = "rtbContentChatOne";
            this.rtbContentChatOne.Size = new System.Drawing.Size(676, 345);
            this.rtbContentChatOne.TabIndex = 0;
            this.rtbContentChatOne.Text = "";
            // 
            // txtSendMsgChatOne
            // 
            this.txtSendMsgChatOne.Location = new System.Drawing.Point(3, 377);
            this.txtSendMsgChatOne.Multiline = true;
            this.txtSendMsgChatOne.Name = "txtSendMsgChatOne";
            this.txtSendMsgChatOne.Size = new System.Drawing.Size(461, 38);
            this.txtSendMsgChatOne.TabIndex = 1;
            // 
            // btnSendIconChatOne
            // 
            this.btnSendIconChatOne.Location = new System.Drawing.Point(470, 377);
            this.btnSendIconChatOne.Name = "btnSendIconChatOne";
            this.btnSendIconChatOne.Size = new System.Drawing.Size(95, 38);
            this.btnSendIconChatOne.TabIndex = 2;
            this.btnSendIconChatOne.Text = "...";
            this.btnSendIconChatOne.UseVisualStyleBackColor = true;
            this.btnSendIconChatOne.Click += new System.EventHandler(this.btnSendIconChatOne_Click);
            // 
            // btnSendMsgChatOne
            // 
            this.btnSendMsgChatOne.Location = new System.Drawing.Point(571, 377);
            this.btnSendMsgChatOne.Name = "btnSendMsgChatOne";
            this.btnSendMsgChatOne.Size = new System.Drawing.Size(107, 38);
            this.btnSendMsgChatOne.TabIndex = 3;
            this.btnSendMsgChatOne.Text = "Send";
            this.btnSendMsgChatOne.UseVisualStyleBackColor = true;
            this.btnSendMsgChatOne.Click += new System.EventHandler(this.btnSendMsgChatOne_Click);
            // 
            // btnCloseForm
            // 
            this.btnCloseForm.Location = new System.Drawing.Point(593, 4);
            this.btnCloseForm.Name = "btnCloseForm";
            this.btnCloseForm.Size = new System.Drawing.Size(85, 23);
            this.btnCloseForm.TabIndex = 4;
            this.btnCloseForm.Text = "Close";
            this.btnCloseForm.UseVisualStyleBackColor = true;
            this.btnCloseForm.Click += new System.EventHandler(this.btnCloseForm_Click);
            // 
            // pnlContainIconsChatOne
            // 
            this.pnlContainIconsChatOne.AutoScroll = true;
            this.pnlContainIconsChatOne.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnlContainIconsChatOne.Location = new System.Drawing.Point(423, 82);
            this.pnlContainIconsChatOne.Name = "pnlContainIconsChatOne";
            this.pnlContainIconsChatOne.Size = new System.Drawing.Size(256, 289);
            this.pnlContainIconsChatOne.TabIndex = 5;
            // 
            // UserControlChatOne
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlContainIconsChatOne);
            this.Controls.Add(this.btnCloseForm);
            this.Controls.Add(this.btnSendMsgChatOne);
            this.Controls.Add(this.btnSendIconChatOne);
            this.Controls.Add(this.txtSendMsgChatOne);
            this.Controls.Add(this.rtbContentChatOne);
            this.Name = "UserControlChatOne";
            this.Size = new System.Drawing.Size(679, 419);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbContentChatOne;
        private System.Windows.Forms.TextBox txtSendMsgChatOne;
        private System.Windows.Forms.Button btnSendIconChatOne;
        private System.Windows.Forms.Button btnSendMsgChatOne;
        private System.Windows.Forms.Button btnCloseForm;
        private System.Windows.Forms.Panel pnlContainIconsChatOne;
    }
}
