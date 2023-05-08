namespace chessgames
{
    partial class Dashboard
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
            this.btnChessGame1 = new System.Windows.Forms.Button();
            this.btnChessGame2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnChessGame1
            // 
            this.btnChessGame1.Location = new System.Drawing.Point(61, 56);
            this.btnChessGame1.Name = "btnChessGame1";
            this.btnChessGame1.Size = new System.Drawing.Size(214, 63);
            this.btnChessGame1.TabIndex = 0;
            this.btnChessGame1.Text = "Người tạo phòng";
            this.btnChessGame1.UseVisualStyleBackColor = true;
            this.btnChessGame1.Click += new System.EventHandler(this.btnChessGame1_Click);
            // 
            // btnChessGame2
            // 
            this.btnChessGame2.Location = new System.Drawing.Point(511, 56);
            this.btnChessGame2.Name = "btnChessGame2";
            this.btnChessGame2.Size = new System.Drawing.Size(214, 63);
            this.btnChessGame2.TabIndex = 1;
            this.btnChessGame2.Text = "Người chơi";
            this.btnChessGame2.UseVisualStyleBackColor = true;
            this.btnChessGame2.Click += new System.EventHandler(this.btnChessGame2_Click);
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnChessGame2);
            this.Controls.Add(this.btnChessGame1);
            this.Name = "Dashboard";
            this.Text = "Dashboard";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnChessGame1;
        private System.Windows.Forms.Button btnChessGame2;
    }
}