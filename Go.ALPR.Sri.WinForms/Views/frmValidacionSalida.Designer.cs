
namespace Go.ALPR.Sri.WinForms
{
    partial class frmValidacionSalida
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
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.lblKg = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblTituloPesoNeto = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.grbFirmaOperario = new System.Windows.Forms.GroupBox();
            this.picFirmaOperario = new System.Windows.Forms.PictureBox();
            this.lblOperario = new System.Windows.Forms.Label();
            this.btnFirmaOperario = new System.Windows.Forms.Button();
            this.grbFirmaTransportista = new System.Windows.Forms.GroupBox();
            this.picFirmaTransportista = new System.Windows.Forms.PictureBox();
            this.lblTransportista = new System.Windows.Forms.Label();
            this.btnFirmaTransportista = new System.Windows.Forms.Button();
            this.picRemolque = new System.Windows.Forms.PictureBox();
            this.picMatricula = new System.Windows.Forms.PictureBox();
            this.lblPesoEntrada = new System.Windows.Forms.Label();
            this.lblPesoSalida = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblPesoNeto = new System.Windows.Forms.Label();
            this.lblMatricula = new System.Windows.Forms.Label();
            this.lblRemolque = new System.Windows.Forms.Label();
            this.lblTipoCarga = new System.Windows.Forms.Label();
            this.lblOrigen = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblDestino = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblIdentificacionManual = new System.Windows.Forms.Label();
            this.lblPesoEntradaManual = new System.Windows.Forms.Label();
            this.lblPesoSalidaManual = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblHoraEntrada = new System.Windows.Forms.Label();
            this.lblHoraSalida = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblExpedidor = new System.Windows.Forms.Label();
            this.grbFirmaOperario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picFirmaOperario)).BeginInit();
            this.grbFirmaTransportista.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picFirmaTransportista)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRemolque)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMatricula)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = global::Go.ALPR.Sri.WinForms.Properties.Resources.cancelar;
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(195, 676);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(70, 70);
            this.btnCancelar.TabIndex = 11;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackgroundImage = global::Go.ALPR.Sri.WinForms.Properties.Resources.aceptar;
            this.btnAceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAceptar.Location = new System.Drawing.Point(521, 676);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(70, 70);
            this.btnAceptar.TabIndex = 12;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // lblKg
            // 
            this.lblKg.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblKg.Location = new System.Drawing.Point(311, 130);
            this.lblKg.Name = "lblKg";
            this.lblKg.Size = new System.Drawing.Size(80, 53);
            this.lblKg.TabIndex = 16;
            this.lblKg.Text = "Kg";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(311, 191);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 53);
            this.label1.TabIndex = 19;
            this.label1.Text = "Kg";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 192);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 25);
            this.label2.TabIndex = 17;
            this.label2.Text = "Peso salida";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(708, 168);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 53);
            this.label3.TabIndex = 21;
            this.label3.Text = "Kg";
            // 
            // lblTituloPesoNeto
            // 
            this.lblTituloPesoNeto.AutoSize = true;
            this.lblTituloPesoNeto.Location = new System.Drawing.Point(554, 135);
            this.lblTituloPesoNeto.Name = "lblTituloPesoNeto";
            this.lblTituloPesoNeto.Size = new System.Drawing.Size(94, 25);
            this.lblTituloPesoNeto.TabIndex = 22;
            this.lblTituloPesoNeto.Text = "Peso neto";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 256);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(127, 25);
            this.label5.TabIndex = 23;
            this.label5.Text = "Tipo de carga";
            // 
            // grbFirmaOperario
            // 
            this.grbFirmaOperario.Controls.Add(this.picFirmaOperario);
            this.grbFirmaOperario.Controls.Add(this.lblOperario);
            this.grbFirmaOperario.Controls.Add(this.btnFirmaOperario);
            this.grbFirmaOperario.Location = new System.Drawing.Point(19, 424);
            this.grbFirmaOperario.Name = "grbFirmaOperario";
            this.grbFirmaOperario.Size = new System.Drawing.Size(362, 232);
            this.grbFirmaOperario.TabIndex = 25;
            this.grbFirmaOperario.TabStop = false;
            this.grbFirmaOperario.Text = "Firma planta";
            // 
            // picFirmaOperario
            // 
            this.picFirmaOperario.Location = new System.Drawing.Point(56, 41);
            this.picFirmaOperario.Name = "picFirmaOperario";
            this.picFirmaOperario.Size = new System.Drawing.Size(200, 150);
            this.picFirmaOperario.TabIndex = 42;
            this.picFirmaOperario.TabStop = false;
            // 
            // lblOperario
            // 
            this.lblOperario.Location = new System.Drawing.Point(19, 197);
            this.lblOperario.Name = "lblOperario";
            this.lblOperario.Size = new System.Drawing.Size(335, 25);
            this.lblOperario.TabIndex = 41;
            // 
            // btnFirmaOperario
            // 
            this.btnFirmaOperario.BackgroundImage = global::Go.ALPR.Sri.WinForms.Properties.Resources.STU_500;
            this.btnFirmaOperario.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnFirmaOperario.Location = new System.Drawing.Point(292, 12);
            this.btnFirmaOperario.Name = "btnFirmaOperario";
            this.btnFirmaOperario.Size = new System.Drawing.Size(70, 70);
            this.btnFirmaOperario.TabIndex = 0;
            this.btnFirmaOperario.UseVisualStyleBackColor = true;
            this.btnFirmaOperario.Click += new System.EventHandler(this.btnFirmaOperario_Click);
            // 
            // grbFirmaTransportista
            // 
            this.grbFirmaTransportista.Controls.Add(this.picFirmaTransportista);
            this.grbFirmaTransportista.Controls.Add(this.lblTransportista);
            this.grbFirmaTransportista.Controls.Add(this.btnFirmaTransportista);
            this.grbFirmaTransportista.Location = new System.Drawing.Point(419, 424);
            this.grbFirmaTransportista.Name = "grbFirmaTransportista";
            this.grbFirmaTransportista.Size = new System.Drawing.Size(362, 232);
            this.grbFirmaTransportista.TabIndex = 26;
            this.grbFirmaTransportista.TabStop = false;
            this.grbFirmaTransportista.Text = "Firma transportista";
            // 
            // picFirmaTransportista
            // 
            this.picFirmaTransportista.Location = new System.Drawing.Point(57, 41);
            this.picFirmaTransportista.Name = "picFirmaTransportista";
            this.picFirmaTransportista.Size = new System.Drawing.Size(200, 150);
            this.picFirmaTransportista.TabIndex = 43;
            this.picFirmaTransportista.TabStop = false;
            // 
            // lblTransportista
            // 
            this.lblTransportista.Location = new System.Drawing.Point(18, 197);
            this.lblTransportista.Name = "lblTransportista";
            this.lblTransportista.Size = new System.Drawing.Size(327, 25);
            this.lblTransportista.TabIndex = 42;
            // 
            // btnFirmaTransportista
            // 
            this.btnFirmaTransportista.BackgroundImage = global::Go.ALPR.Sri.WinForms.Properties.Resources.STU_500;
            this.btnFirmaTransportista.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnFirmaTransportista.Location = new System.Drawing.Point(292, 12);
            this.btnFirmaTransportista.Name = "btnFirmaTransportista";
            this.btnFirmaTransportista.Size = new System.Drawing.Size(70, 70);
            this.btnFirmaTransportista.TabIndex = 28;
            this.btnFirmaTransportista.UseVisualStyleBackColor = true;
            this.btnFirmaTransportista.Click += new System.EventHandler(this.btnFirmaTransportista_Click);
            // 
            // picRemolque
            // 
            this.picRemolque.BackColor = System.Drawing.SystemColors.Control;
            this.picRemolque.Image = global::Go.ALPR.Sri.WinForms.Properties.Resources.matricula_remolque;
            this.picRemolque.Location = new System.Drawing.Point(409, 18);
            this.picRemolque.Name = "picRemolque";
            this.picRemolque.Size = new System.Drawing.Size(248, 73);
            this.picRemolque.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picRemolque.TabIndex = 28;
            this.picRemolque.TabStop = false;
            // 
            // picMatricula
            // 
            this.picMatricula.BackColor = System.Drawing.SystemColors.Control;
            this.picMatricula.Image = global::Go.ALPR.Sri.WinForms.Properties.Resources.matricula;
            this.picMatricula.Location = new System.Drawing.Point(143, 18);
            this.picMatricula.Name = "picMatricula";
            this.picMatricula.Size = new System.Drawing.Size(248, 73);
            this.picMatricula.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picMatricula.TabIndex = 27;
            this.picMatricula.TabStop = false;
            // 
            // lblPesoEntrada
            // 
            this.lblPesoEntrada.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPesoEntrada.Location = new System.Drawing.Point(151, 130);
            this.lblPesoEntrada.Name = "lblPesoEntrada";
            this.lblPesoEntrada.Size = new System.Drawing.Size(166, 53);
            this.lblPesoEntrada.TabIndex = 31;
            this.lblPesoEntrada.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblPesoSalida
            // 
            this.lblPesoSalida.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPesoSalida.Location = new System.Drawing.Point(151, 191);
            this.lblPesoSalida.Name = "lblPesoSalida";
            this.lblPesoSalida.Size = new System.Drawing.Size(166, 53);
            this.lblPesoSalida.TabIndex = 32;
            this.lblPesoSalida.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(29, 132);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(121, 25);
            this.label6.TabIndex = 33;
            this.label6.Text = "Peso entrada";
            // 
            // lblPesoNeto
            // 
            this.lblPesoNeto.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPesoNeto.Location = new System.Drawing.Point(528, 168);
            this.lblPesoNeto.Name = "lblPesoNeto";
            this.lblPesoNeto.Size = new System.Drawing.Size(166, 53);
            this.lblPesoNeto.TabIndex = 34;
            this.lblPesoNeto.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblMatricula
            // 
            this.lblMatricula.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblMatricula.Location = new System.Drawing.Point(175, 26);
            this.lblMatricula.Name = "lblMatricula";
            this.lblMatricula.Size = new System.Drawing.Size(205, 54);
            this.lblMatricula.TabIndex = 35;
            this.lblMatricula.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRemolque
            // 
            this.lblRemolque.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblRemolque.Location = new System.Drawing.Point(415, 26);
            this.lblRemolque.Name = "lblRemolque";
            this.lblRemolque.Size = new System.Drawing.Size(233, 54);
            this.lblRemolque.TabIndex = 36;
            this.lblRemolque.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTipoCarga
            // 
            this.lblTipoCarga.Location = new System.Drawing.Point(158, 256);
            this.lblTipoCarga.Name = "lblTipoCarga";
            this.lblTipoCarga.Size = new System.Drawing.Size(597, 25);
            this.lblTipoCarga.TabIndex = 37;
            // 
            // lblOrigen
            // 
            this.lblOrigen.Location = new System.Drawing.Point(158, 295);
            this.lblOrigen.Name = "lblOrigen";
            this.lblOrigen.Size = new System.Drawing.Size(597, 25);
            this.lblOrigen.TabIndex = 39;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(82, 295);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 25);
            this.label8.TabIndex = 38;
            this.label8.Text = "Origen";
            // 
            // lblDestino
            // 
            this.lblDestino.Location = new System.Drawing.Point(158, 334);
            this.lblDestino.Name = "lblDestino";
            this.lblDestino.Size = new System.Drawing.Size(597, 25);
            this.lblDestino.TabIndex = 41;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(76, 334);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(76, 25);
            this.label10.TabIndex = 40;
            this.label10.Text = "Destino";
            // 
            // lblIdentificacionManual
            // 
            this.lblIdentificacionManual.AutoSize = true;
            this.lblIdentificacionManual.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblIdentificacionManual.Location = new System.Drawing.Point(165, 94);
            this.lblIdentificacionManual.Name = "lblIdentificacionManual";
            this.lblIdentificacionManual.Size = new System.Drawing.Size(194, 25);
            this.lblIdentificacionManual.TabIndex = 42;
            this.lblIdentificacionManual.Text = "Identificación manual";
            // 
            // lblPesoEntradaManual
            // 
            this.lblPesoEntradaManual.AutoSize = true;
            this.lblPesoEntradaManual.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblPesoEntradaManual.Location = new System.Drawing.Point(374, 153);
            this.lblPesoEntradaManual.Name = "lblPesoEntradaManual";
            this.lblPesoEntradaManual.Size = new System.Drawing.Size(124, 25);
            this.lblPesoEntradaManual.TabIndex = 43;
            this.lblPesoEntradaManual.Text = "Valor manual";
            // 
            // lblPesoSalidaManual
            // 
            this.lblPesoSalidaManual.AutoSize = true;
            this.lblPesoSalidaManual.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblPesoSalidaManual.Location = new System.Drawing.Point(374, 209);
            this.lblPesoSalidaManual.Name = "lblPesoSalidaManual";
            this.lblPesoSalidaManual.Size = new System.Drawing.Size(124, 25);
            this.lblPesoSalidaManual.TabIndex = 44;
            this.lblPesoSalidaManual.Text = "Valor manual";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(39, 156);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 25);
            this.label4.TabIndex = 45;
            this.label4.Text = "Hora:";
            // 
            // lblHoraEntrada
            // 
            this.lblHoraEntrada.AutoSize = true;
            this.lblHoraEntrada.Location = new System.Drawing.Point(94, 156);
            this.lblHoraEntrada.Name = "lblHoraEntrada";
            this.lblHoraEntrada.Size = new System.Drawing.Size(0, 25);
            this.lblHoraEntrada.TabIndex = 46;
            // 
            // lblHoraSalida
            // 
            this.lblHoraSalida.AutoSize = true;
            this.lblHoraSalida.Location = new System.Drawing.Point(94, 216);
            this.lblHoraSalida.Name = "lblHoraSalida";
            this.lblHoraSalida.Size = new System.Drawing.Size(0, 25);
            this.lblHoraSalida.TabIndex = 48;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(39, 216);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(57, 25);
            this.label11.TabIndex = 47;
            this.label11.Text = "Hora:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(55, 376);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(97, 25);
            this.label7.TabIndex = 49;
            this.label7.Text = "Expedidor";
            // 
            // lblExpedidor
            // 
            this.lblExpedidor.Location = new System.Drawing.Point(158, 376);
            this.lblExpedidor.Name = "lblExpedidor";
            this.lblExpedidor.Size = new System.Drawing.Size(597, 25);
            this.lblExpedidor.TabIndex = 50;
            // 
            // frmValidacionSalida
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 800);
            this.ControlBox = false;
            this.Controls.Add(this.lblExpedidor);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblHoraSalida);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.lblHoraEntrada);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblPesoSalidaManual);
            this.Controls.Add(this.lblPesoEntradaManual);
            this.Controls.Add(this.lblIdentificacionManual);
            this.Controls.Add(this.lblDestino);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lblOrigen);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblTipoCarga);
            this.Controls.Add(this.lblRemolque);
            this.Controls.Add(this.lblMatricula);
            this.Controls.Add(this.lblPesoNeto);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblPesoSalida);
            this.Controls.Add(this.lblPesoEntrada);
            this.Controls.Add(this.picRemolque);
            this.Controls.Add(this.picMatricula);
            this.Controls.Add(this.grbFirmaTransportista);
            this.Controls.Add(this.grbFirmaOperario);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblTituloPesoNeto);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblKg);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmValidacionSalida";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.grbFirmaOperario.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picFirmaOperario)).EndInit();
            this.grbFirmaTransportista.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picFirmaTransportista)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRemolque)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMatricula)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Label lblKg;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblTituloPesoNeto;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox grbFirmaOperario;
        private System.Windows.Forms.GroupBox grbFirmaTransportista;
        private System.Windows.Forms.Button btnFirmaOperario;
        private System.Windows.Forms.Button btnFirmaTransportista;
        private System.Windows.Forms.PictureBox picRemolque;
        private System.Windows.Forms.PictureBox picMatricula;
        private System.Windows.Forms.Label lblPesoEntrada;
        private System.Windows.Forms.Label lblPesoSalida;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblPesoNeto;
        private System.Windows.Forms.Label lblMatricula;
        private System.Windows.Forms.Label lblRemolque;
        private System.Windows.Forms.Label lblTipoCarga;
        private System.Windows.Forms.Label lblOrigen;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblDestino;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblOperario;
        private System.Windows.Forms.Label lblTransportista;
        private System.Windows.Forms.Label lblIdentificacionManual;
        private System.Windows.Forms.Label lblPesoEntradaManual;
        private System.Windows.Forms.Label lblPesoSalidaManual;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblHoraEntrada;
        private System.Windows.Forms.Label lblHoraSalida;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.PictureBox picFirmaOperario;
        private System.Windows.Forms.PictureBox picFirmaTransportista;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblExpedidor;
    }
}