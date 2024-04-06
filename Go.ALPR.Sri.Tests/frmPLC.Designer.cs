
namespace Go.ALPR.Sri.Tests
{
    partial class frmPLC
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
            this.btnPLCWrite = new System.Windows.Forms.Button();
            this.txtOperacionId = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnPLCWrite
            // 
            this.btnPLCWrite.Location = new System.Drawing.Point(56, 38);
            this.btnPLCWrite.Name = "btnPLCWrite";
            this.btnPLCWrite.Size = new System.Drawing.Size(152, 77);
            this.btnPLCWrite.TabIndex = 0;
            this.btnPLCWrite.Text = "Escribir";
            this.btnPLCWrite.UseVisualStyleBackColor = true;
            this.btnPLCWrite.Click += new System.EventHandler(this.btnPLCWrite_Click);
            // 
            // txtOperacionId
            // 
            this.txtOperacionId.Font = new System.Drawing.Font("Segoe UI", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtOperacionId.Location = new System.Drawing.Point(231, 53);
            this.txtOperacionId.Name = "txtOperacionId";
            this.txtOperacionId.Size = new System.Drawing.Size(109, 52);
            this.txtOperacionId.TabIndex = 1;
            this.txtOperacionId.Text = "7025";
            // 
            // frmPLC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtOperacionId);
            this.Controls.Add(this.btnPLCWrite);
            this.Name = "frmPLC";
            this.Text = "frmPLC";
            this.Load += new System.EventHandler(this.frmPLC_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPLCWrite;
        private System.Windows.Forms.TextBox txtOperacionId;
    }
}