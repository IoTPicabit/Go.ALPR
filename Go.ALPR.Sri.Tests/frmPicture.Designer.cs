
namespace Go.ALPR.Sri.Tests
{
    partial class frmPicture
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
            this.pnlPicture = new System.Windows.Forms.Panel();
            this.picCamara = new System.Windows.Forms.PictureBox();
            this.pnlPicture.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCamara)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlPicture
            // 
            this.pnlPicture.AutoScroll = true;
            this.pnlPicture.Controls.Add(this.picCamara);
            this.pnlPicture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPicture.Location = new System.Drawing.Point(0, 0);
            this.pnlPicture.Name = "pnlPicture";
            this.pnlPicture.Size = new System.Drawing.Size(784, 561);
            this.pnlPicture.TabIndex = 0;
            // 
            // picCamara
            // 
            this.picCamara.Location = new System.Drawing.Point(0, 0);
            this.picCamara.Name = "picCamara";
            this.picCamara.Size = new System.Drawing.Size(100, 50);
            this.picCamara.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picCamara.TabIndex = 0;
            this.picCamara.TabStop = false;
            this.picCamara.Paint += new System.Windows.Forms.PaintEventHandler(this.picCamara_Paint);
            this.picCamara.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picCamara_MouseDown);
            this.picCamara.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picCamara_MouseMove);
            this.picCamara.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picCamara_MouseUp);
            // 
            // frmPicture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.pnlPicture);
            this.MinimizeBox = false;
            this.Name = "frmPicture";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.frmPicture_Load);
            this.pnlPicture.ResumeLayout(false);
            this.pnlPicture.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCamara)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlPicture;
        private System.Windows.Forms.PictureBox picCamara;
    }
}