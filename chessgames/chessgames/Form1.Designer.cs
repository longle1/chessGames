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
            this.SuspendLayout();
            // 
            // pnlContainPieces
            // 
            this.pnlContainPieces.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnlContainPieces.Location = new System.Drawing.Point(648, 64);
            this.pnlContainPieces.Name = "pnlContainPieces";
            this.pnlContainPieces.Size = new System.Drawing.Size(274, 434);
            this.pnlContainPieces.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 765);
            this.Controls.Add(this.pnlContainPieces);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlContainPieces;
    }
}

