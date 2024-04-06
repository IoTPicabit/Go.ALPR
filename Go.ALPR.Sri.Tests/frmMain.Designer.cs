
namespace Go.ALPR.Sri.Tests
{
    partial class frmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnEntrada = new System.Windows.Forms.Button();
            this.btnSalida = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCamion = new System.Windows.Forms.Label();
            this.lblRemolque = new System.Windows.Forms.Label();
            this.rtbLog = new System.Windows.Forms.RichTextBox();
            this.picCamara1 = new System.Windows.Forms.PictureBox();
            this.picCamara2 = new System.Windows.Forms.PictureBox();
            this.picCamara3 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblPeso = new System.Windows.Forms.Label();
            this.btnBascula = new System.Windows.Forms.Button();
            this.btnEnviarPeso = new System.Windows.Forms.Button();
            this.txtPeso = new System.Windows.Forms.TextBox();
            this.btnImprimirAlbaran = new System.Windows.Forms.Button();
            this.btnFirma = new System.Windows.Forms.Button();
            this.picFirma = new System.Windows.Forms.PictureBox();
            this.btnMessageTest = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picCamara1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCamara2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCamara3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFirma)).BeginInit();
            this.SuspendLayout();
            // 
            // btnEntrada
            // 
            this.btnEntrada.Location = new System.Drawing.Point(31, 32);
            this.btnEntrada.Name = "btnEntrada";
            this.btnEntrada.Size = new System.Drawing.Size(149, 135);
            this.btnEntrada.TabIndex = 0;
            this.btnEntrada.Text = "ENTRADA";
            this.btnEntrada.UseVisualStyleBackColor = true;
            this.btnEntrada.Click += new System.EventHandler(this.btnEntrada_Click);
            // 
            // btnSalida
            // 
            this.btnSalida.Location = new System.Drawing.Point(31, 210);
            this.btnSalida.Name = "btnSalida";
            this.btnSalida.Size = new System.Drawing.Size(149, 135);
            this.btnSalida.TabIndex = 1;
            this.btnSalida.Text = "SALIDA";
            this.btnSalida.UseVisualStyleBackColor = true;
            this.btnSalida.Click += new System.EventHandler(this.btnSalida_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(204, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(272, 37);
            this.label1.TabIndex = 2;
            this.label1.Text = "MATRÍCULA CAMIÓN";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(204, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(307, 37);
            this.label2.TabIndex = 3;
            this.label2.Text = "MATRÍCULA REMOLQUE";
            // 
            // lblCamion
            // 
            this.lblCamion.BackColor = System.Drawing.SystemColors.Window;
            this.lblCamion.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblCamion.Location = new System.Drawing.Point(516, 32);
            this.lblCamion.Name = "lblCamion";
            this.lblCamion.Size = new System.Drawing.Size(272, 37);
            this.lblCamion.TabIndex = 4;
            this.lblCamion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRemolque
            // 
            this.lblRemolque.BackColor = System.Drawing.SystemColors.Window;
            this.lblRemolque.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblRemolque.Location = new System.Drawing.Point(516, 130);
            this.lblRemolque.Name = "lblRemolque";
            this.lblRemolque.Size = new System.Drawing.Size(272, 37);
            this.lblRemolque.TabIndex = 5;
            this.lblRemolque.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rtbLog
            // 
            this.rtbLog.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.rtbLog.Location = new System.Drawing.Point(0, 562);
            this.rtbLog.Name = "rtbLog";
            this.rtbLog.Size = new System.Drawing.Size(816, 119);
            this.rtbLog.TabIndex = 6;
            this.rtbLog.Text = "";
            // 
            // picCamara1
            // 
            this.picCamara1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picCamara1.Location = new System.Drawing.Point(282, 210);
            this.picCamara1.Name = "picCamara1";
            this.picCamara1.Size = new System.Drawing.Size(149, 135);
            this.picCamara1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picCamara1.TabIndex = 7;
            this.picCamara1.TabStop = false;
            this.picCamara1.Click += new System.EventHandler(this.picCamara1_Click);
            this.picCamara1.MouseLeave += new System.EventHandler(this.picCamara1_MouseLeave);
            this.picCamara1.MouseHover += new System.EventHandler(this.picCamara1_MouseHover);
            // 
            // picCamara2
            // 
            this.picCamara2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picCamara2.Location = new System.Drawing.Point(437, 210);
            this.picCamara2.Name = "picCamara2";
            this.picCamara2.Size = new System.Drawing.Size(149, 135);
            this.picCamara2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picCamara2.TabIndex = 8;
            this.picCamara2.TabStop = false;
            this.picCamara2.Click += new System.EventHandler(this.picCamara2_Click);
            this.picCamara2.MouseLeave += new System.EventHandler(this.picCamara2_MouseLeave);
            this.picCamara2.MouseHover += new System.EventHandler(this.picCamara2_MouseHover);
            // 
            // picCamara3
            // 
            this.picCamara3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picCamara3.Location = new System.Drawing.Point(592, 210);
            this.picCamara3.Name = "picCamara3";
            this.picCamara3.Size = new System.Drawing.Size(149, 135);
            this.picCamara3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picCamara3.TabIndex = 9;
            this.picCamara3.TabStop = false;
            this.picCamara3.Click += new System.EventHandler(this.picCamara3_Click);
            this.picCamara3.MouseLeave += new System.EventHandler(this.picCamara3_MouseLeave);
            this.picCamara3.MouseHover += new System.EventHandler(this.picCamara3_MouseHover);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(299, 175);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 32);
            this.label3.TabIndex = 10;
            this.label3.Text = "Cámara 1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(454, 175);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 32);
            this.label4.TabIndex = 11;
            this.label4.Text = "Cámara 2";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(609, 175);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 32);
            this.label5.TabIndex = 12;
            this.label5.Text = "Cámara 3";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(204, 366);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 37);
            this.label6.TabIndex = 13;
            this.label6.Text = "PESO";
            // 
            // lblPeso
            // 
            this.lblPeso.BackColor = System.Drawing.SystemColors.Window;
            this.lblPeso.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPeso.Location = new System.Drawing.Point(282, 366);
            this.lblPeso.Name = "lblPeso";
            this.lblPeso.Size = new System.Drawing.Size(156, 37);
            this.lblPeso.TabIndex = 14;
            this.lblPeso.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnBascula
            // 
            this.btnBascula.Location = new System.Drawing.Point(31, 356);
            this.btnBascula.Name = "btnBascula";
            this.btnBascula.Size = new System.Drawing.Size(149, 47);
            this.btnBascula.TabIndex = 15;
            this.btnBascula.Text = "BASCULA";
            this.btnBascula.UseVisualStyleBackColor = true;
            this.btnBascula.Click += new System.EventHandler(this.btnBascula_Click);
            // 
            // btnEnviarPeso
            // 
            this.btnEnviarPeso.Location = new System.Drawing.Point(488, 357);
            this.btnEnviarPeso.Name = "btnEnviarPeso";
            this.btnEnviarPeso.Size = new System.Drawing.Size(152, 46);
            this.btnEnviarPeso.TabIndex = 16;
            this.btnEnviarPeso.Text = "ENVIAR PESO";
            this.btnEnviarPeso.UseVisualStyleBackColor = true;
            this.btnEnviarPeso.Click += new System.EventHandler(this.btnEnviarPeso_Click);
            // 
            // txtPeso
            // 
            this.txtPeso.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtPeso.Location = new System.Drawing.Point(646, 360);
            this.txtPeso.Name = "txtPeso";
            this.txtPeso.Size = new System.Drawing.Size(142, 43);
            this.txtPeso.TabIndex = 17;
            // 
            // btnImprimirAlbaran
            // 
            this.btnImprimirAlbaran.Location = new System.Drawing.Point(204, 72);
            this.btnImprimirAlbaran.Name = "btnImprimirAlbaran";
            this.btnImprimirAlbaran.Size = new System.Drawing.Size(154, 55);
            this.btnImprimirAlbaran.TabIndex = 18;
            this.btnImprimirAlbaran.Text = "Albaran";
            this.btnImprimirAlbaran.UseVisualStyleBackColor = true;
            this.btnImprimirAlbaran.Click += new System.EventHandler(this.btnImprimirAlbaran_Click);
            // 
            // btnFirma
            // 
            this.btnFirma.Location = new System.Drawing.Point(31, 428);
            this.btnFirma.Name = "btnFirma";
            this.btnFirma.Size = new System.Drawing.Size(149, 109);
            this.btnFirma.TabIndex = 19;
            this.btnFirma.Text = "OBTENER FIRMA";
            this.btnFirma.UseVisualStyleBackColor = true;
            this.btnFirma.Click += new System.EventHandler(this.btnFirma_Click);
            // 
            // picFirma
            // 
            this.picFirma.Location = new System.Drawing.Point(238, 406);
            this.picFirma.Name = "picFirma";
            this.picFirma.Size = new System.Drawing.Size(200, 150);
            this.picFirma.TabIndex = 20;
            this.picFirma.TabStop = false;
            // 
            // btnMessageTest
            // 
            this.btnMessageTest.Location = new System.Drawing.Point(516, 409);
            this.btnMessageTest.Name = "btnMessageTest";
            this.btnMessageTest.Size = new System.Drawing.Size(213, 56);
            this.btnMessageTest.TabIndex = 21;
            this.btnMessageTest.Text = "MessageTest";
            this.btnMessageTest.UseVisualStyleBackColor = true;
            this.btnMessageTest.Click += new System.EventHandler(this.btnMessageTest_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(816, 681);
            this.Controls.Add(this.btnMessageTest);
            this.Controls.Add(this.picFirma);
            this.Controls.Add(this.btnFirma);
            this.Controls.Add(this.btnImprimirAlbaran);
            this.Controls.Add(this.txtPeso);
            this.Controls.Add(this.btnEnviarPeso);
            this.Controls.Add(this.btnBascula);
            this.Controls.Add(this.lblPeso);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.picCamara3);
            this.Controls.Add(this.picCamara2);
            this.Controls.Add(this.picCamara1);
            this.Controls.Add(this.rtbLog);
            this.Controls.Add(this.lblRemolque);
            this.Controls.Add(this.lblCamion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSalida);
            this.Controls.Add(this.btnEntrada);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pruebas";
            ((System.ComponentModel.ISupportInitialize)(this.picCamara1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCamara2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCamara3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFirma)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEntrada;
        private System.Windows.Forms.Button btnSalida;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCamion;
        private System.Windows.Forms.Label lblRemolque;
        private System.Windows.Forms.RichTextBox rtbLog;
        private System.Windows.Forms.PictureBox picCamara1;
        private System.Windows.Forms.PictureBox picCamara2;
        private System.Windows.Forms.PictureBox picCamara3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblPeso;
        private System.Windows.Forms.Button btnBascula;
        private System.Windows.Forms.Button btnEnviarPeso;
        private System.Windows.Forms.TextBox txtPeso;
        private System.Windows.Forms.Button btnImprimirAlbaran;
        private System.Windows.Forms.Button btnFirma;
        private System.Windows.Forms.PictureBox picFirma;
        private System.Windows.Forms.Button btnMessageTest;
    }
}

