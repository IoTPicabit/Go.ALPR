
namespace Go.ALPR.Sri.WinForms
{
    partial class frmIdentificacionManual
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
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblMotivo = new System.Windows.Forms.Label();
            this.txtMotivo = new System.Windows.Forms.TextBox();
            this.picMatricula = new System.Windows.Forms.PictureBox();
            this.picRemolque = new System.Windows.Forms.PictureBox();
            this.txtMatricula = new System.Windows.Forms.TextBox();
            this.txtRemolque = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.picMatricula)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRemolque)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackgroundImage = global::Go.ALPR.Sri.WinForms.Properties.Resources.aceptar;
            this.btnAceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAceptar.Location = new System.Drawing.Point(417, 297);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(70, 70);
            this.btnAceptar.TabIndex = 5;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = global::Go.ALPR.Sri.WinForms.Properties.Resources.cancelar;
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(52, 297);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(70, 70);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblMotivo
            // 
            this.lblMotivo.AutoSize = true;
            this.lblMotivo.Location = new System.Drawing.Point(20, 114);
            this.lblMotivo.Name = "lblMotivo";
            this.lblMotivo.Size = new System.Drawing.Size(71, 25);
            this.lblMotivo.TabIndex = 2;
            this.lblMotivo.Text = "Motivo";
            // 
            // txtMotivo
            // 
            this.txtMotivo.Location = new System.Drawing.Point(20, 142);
            this.txtMotivo.Multiline = true;
            this.txtMotivo.Name = "txtMotivo";
            this.txtMotivo.Size = new System.Drawing.Size(514, 113);
            this.txtMotivo.TabIndex = 3;
            this.txtMotivo.TextChanged += new System.EventHandler(this.txtMotivo_TextChanged);
            // 
            // picMatricula
            // 
            this.picMatricula.BackColor = System.Drawing.SystemColors.Control;
            this.picMatricula.Image = global::Go.ALPR.Sri.WinForms.Properties.Resources.matricula;
            this.picMatricula.Location = new System.Drawing.Point(20, 16);
            this.picMatricula.Name = "picMatricula";
            this.picMatricula.Size = new System.Drawing.Size(248, 73);
            this.picMatricula.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picMatricula.TabIndex = 7;
            this.picMatricula.TabStop = false;
            // 
            // picRemolque
            // 
            this.picRemolque.BackColor = System.Drawing.SystemColors.Control;
            this.picRemolque.Image = global::Go.ALPR.Sri.WinForms.Properties.Resources.matricula_remolque;
            this.picRemolque.Location = new System.Drawing.Point(286, 16);
            this.picRemolque.Name = "picRemolque";
            this.picRemolque.Size = new System.Drawing.Size(248, 73);
            this.picRemolque.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picRemolque.TabIndex = 8;
            this.picRemolque.TabStop = false;
            // 
            // txtMatricula
            // 
            this.txtMatricula.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMatricula.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtMatricula.Location = new System.Drawing.Point(52, 24);
            this.txtMatricula.Name = "txtMatricula";
            this.txtMatricula.Size = new System.Drawing.Size(205, 54);
            this.txtMatricula.TabIndex = 0;
            this.txtMatricula.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMatricula.TextChanged += new System.EventHandler(this.txtMatricula_TextChanged);
            // 
            // txtRemolque
            // 
            this.txtRemolque.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtRemolque.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtRemolque.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtRemolque.Location = new System.Drawing.Point(292, 24);
            this.txtRemolque.Name = "txtRemolque";
            this.txtRemolque.Size = new System.Drawing.Size(233, 54);
            this.txtRemolque.TabIndex = 1;
            this.txtRemolque.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // frmIdentificacionManual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 385);
            this.ControlBox = false;
            this.Controls.Add(this.txtRemolque);
            this.Controls.Add(this.txtMatricula);
            this.Controls.Add(this.picRemolque);
            this.Controls.Add(this.picMatricula);
            this.Controls.Add(this.txtMotivo);
            this.Controls.Add(this.lblMotivo);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmIdentificacionManual";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Identificación manual";
            this.Load += new System.EventHandler(this.frmIdentificacionManual_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picMatricula)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRemolque)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lblMotivo;
        private System.Windows.Forms.TextBox txtMotivo;
        private System.Windows.Forms.PictureBox picMatricula;
        private System.Windows.Forms.PictureBox picRemolque;
        private System.Windows.Forms.TextBox txtMatricula;
        private System.Windows.Forms.TextBox txtRemolque;
    }
}