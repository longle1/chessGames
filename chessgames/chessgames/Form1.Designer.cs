namespace chessgames
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
            this.pnlContainPieces = new System.Windows.Forms.Panel();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCountTime = new System.Windows.Forms.TextBox();
            this.listChat = new System.Windows.Forms.RichTextBox();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.btnSendIcon = new System.Windows.Forms.Button();
            this.btnSendData = new System.Windows.Forms.Button();
            this.pnlContainsIcon = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // pnlContainPieces
            // 
            this.pnlContainPieces.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnlContainPieces.Location = new System.Drawing.Point(25, 128);
            this.pnlContainPieces.Name = "pnlContainPieces";
            this.pnlContainPieces.Size = new System.Drawing.Size(290, 497);
            this.pnlContainPieces.TabIndex = 0;
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(22, 21);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(158, 22);
            this.txtUsername.TabIndex = 1;
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(22, 66);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(158, 22);
            this.txtPort.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Username";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Port";
            // 
            // txtCountTime
            // 
            this.txtCountTime.BackColor = System.Drawing.Color.LemonChiffon;
            this.txtCountTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCountTime.Location = new System.Drawing.Point(702, 12);
            this.txtCountTime.Multiline = true;
            this.txtCountTime.Name = "txtCountTime";
            this.txtCountTime.ReadOnly = true;
            this.txtCountTime.Size = new System.Drawing.Size(152, 47);
            this.txtCountTime.TabIndex = 5;
            // 
            // listChat
            // 
            this.listChat.Location = new System.Drawing.Point(1033, 128);
            this.listChat.Name = "listChat";
            this.listChat.Size = new System.Drawing.Size(380, 447);
            this.listChat.TabIndex = 0;
            this.listChat.Text = "";
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(1033, 573);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(261, 42);
            this.txtMessage.TabIndex = 1;
            // 
            // btnSendIcon
            // 
            this.btnSendIcon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnSendIcon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSendIcon.Location = new System.Drawing.Point(1290, 573);
            this.btnSendIcon.Name = "btnSendIcon";
            this.btnSendIcon.Size = new System.Drawing.Size(58, 42);
            this.btnSendIcon.TabIndex = 6;
            this.btnSendIcon.Text = "...";
            this.btnSendIcon.UseVisualStyleBackColor = false;
            this.btnSendIcon.Click += new System.EventHandler(this.btnSendIcon_Click);
            // 
            // btnSendData
            // 
            this.btnSendData.BackColor = System.Drawing.Color.Red;
            this.btnSendData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSendData.Location = new System.Drawing.Point(1348, 573);
            this.btnSendData.Name = "btnSendData";
            this.btnSendData.Size = new System.Drawing.Size(65, 42);
            this.btnSendData.TabIndex = 7;
            this.btnSendData.Text = ">";
            this.btnSendData.UseVisualStyleBackColor = false;
            this.btnSendData.Click += new System.EventHandler(this.btnSendData_Click);
            // 
            // pnlContainsIcon
            // 
            this.pnlContainsIcon.Location = new System.Drawing.Point(1031, 262);
            this.pnlContainsIcon.Name = "pnlContainsIcon";
            this.pnlContainsIcon.Size = new System.Drawing.Size(382, 313);
            this.pnlContainsIcon.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LemonChiffon;
            this.ClientSize = new System.Drawing.Size(1443, 765);
            this.Controls.Add(this.pnlContainsIcon);
            this.Controls.Add(this.btnSendData);
            this.Controls.Add(this.btnSendIcon);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.listChat);
            this.Controls.Add(this.txtCountTime);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.pnlContainPieces);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlContainPieces;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCountTime;
        private System.Windows.Forms.RichTextBox listChat;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Button btnSendIcon;
        private System.Windows.Forms.Button btnSendData;
        private System.Windows.Forms.Panel pnlContainsIcon;
    }
}

