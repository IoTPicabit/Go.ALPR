
namespace Go.ALPR.Sri.WinForms
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.pnlBotonesPrincipales = new System.Windows.Forms.Panel();
            this.btnNuevaSalida = new System.Windows.Forms.Button();
            this.btnNuevaEntrada = new System.Windows.Forms.Button();
            this.grbIdentificacion = new System.Windows.Forms.GroupBox();
            this.lblIndentificacionProgreso = new System.Windows.Forms.Label();
            this.lblRemolque = new System.Windows.Forms.Label();
            this.picRemolque = new System.Windows.Forms.PictureBox();
            this.btnIdentificacionManual = new System.Windows.Forms.Button();
            this.lblMatricula = new System.Windows.Forms.Label();
            this.picMatricula = new System.Windows.Forms.PictureBox();
            this.lstImagenes = new System.Windows.Forms.ImageList(this.components);
            this.grpBascula = new System.Windows.Forms.GroupBox();
            this.grpPesoRealTime = new System.Windows.Forms.GroupBox();
            this.lblKgPesoRealTime = new System.Windows.Forms.Label();
            this.lblPesoRealTime = new System.Windows.Forms.Label();
            this.btnPesoManual = new System.Windows.Forms.Button();
            this.lblKg = new System.Windows.Forms.Label();
            this.lblPeso = new System.Windows.Forms.Label();
            this.pnlBotonesGuardado = new System.Windows.Forms.Panel();
            this.btnReiniciar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.timerHora = new System.Windows.Forms.Timer(this.components);
            this.pnlTop = new System.Windows.Forms.Panel();
            this.pnlTopMiddle = new System.Windows.Forms.Panel();
            this.btnCaptura = new System.Windows.Forms.Button();
            this.pnlTitulo = new System.Windows.Forms.Panel();
            this.lblOperario = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblHora = new System.Windows.Forms.Label();
            this.pnlBotonera = new System.Windows.Forms.FlowLayoutPanel();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnCambiarUsuario = new System.Windows.Forms.Button();
            this.btnCambiarClave = new System.Windows.Forms.Button();
            this.btnUsuarios = new System.Windows.Forms.Button();
            this.btnLocalizaciones = new System.Windows.Forms.Button();
            this.btnEmpresas = new System.Windows.Forms.Button();
            this.btnTipoCargas = new System.Windows.Forms.Button();
            this.btnContactos = new System.Windows.Forms.Button();
            this.btnTransportes = new System.Windows.Forms.Button();
            this.btnOperaciones = new System.Windows.Forms.Button();
            this.toolTipper = new System.Windows.Forms.ToolTip(this.components);
            this.grbOtraInformacion = new System.Windows.Forms.GroupBox();
            this.cmbTipoCarga = new System.Windows.Forms.ComboBox();
            this.cmbExpedidor = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblEmpresa = new System.Windows.Forms.Label();
            this.cmbDestino = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbOrigen = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtConductor = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.grbCamaras = new System.Windows.Forms.GroupBox();
            this.picCamara3 = new System.Windows.Forms.PictureBox();
            this.picCamara2 = new System.Windows.Forms.PictureBox();
            this.picCamara1 = new System.Windows.Forms.PictureBox();
            this.vvCamara1 = new LibVLCSharp.WinForms.VideoView();
            this.vvCamara2 = new LibVLCSharp.WinForms.VideoView();
            this.vvCamara3 = new LibVLCSharp.WinForms.VideoView();
            this.bgwPesoRealTime = new System.ComponentModel.BackgroundWorker();
            this.bgwControlEstabilidad = new System.ComponentModel.BackgroundWorker();
            this.pnlBotonesPrincipales.SuspendLayout();
            this.grbIdentificacion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picRemolque)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMatricula)).BeginInit();
            this.grpBascula.SuspendLayout();
            this.grpPesoRealTime.SuspendLayout();
            this.pnlBotonesGuardado.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlTopMiddle.SuspendLayout();
            this.pnlTitulo.SuspendLayout();
            this.pnlBotonera.SuspendLayout();
            this.grbOtraInformacion.SuspendLayout();
            this.grbCamaras.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCamara3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCamara2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCamara1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vvCamara1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vvCamara2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vvCamara3)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBotonesPrincipales
            // 
            this.pnlBotonesPrincipales.Controls.Add(this.btnNuevaSalida);
            this.pnlBotonesPrincipales.Controls.Add(this.btnNuevaEntrada);
            this.pnlBotonesPrincipales.Location = new System.Drawing.Point(3, 66);
            this.pnlBotonesPrincipales.Name = "pnlBotonesPrincipales";
            this.pnlBotonesPrincipales.Size = new System.Drawing.Size(168, 373);
            this.pnlBotonesPrincipales.TabIndex = 3;
            // 
            // btnNuevaSalida
            // 
            this.btnNuevaSalida.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnNuevaSalida.Location = new System.Drawing.Point(24, 216);
            this.btnNuevaSalida.Name = "btnNuevaSalida";
            this.btnNuevaSalida.Size = new System.Drawing.Size(121, 121);
            this.btnNuevaSalida.TabIndex = 1;
            this.btnNuevaSalida.Text = "Salida";
            this.btnNuevaSalida.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevaSalida.UseVisualStyleBackColor = true;
            this.btnNuevaSalida.Click += new System.EventHandler(this.btnNuevaSalida_Click);
            // 
            // btnNuevaEntrada
            // 
            this.btnNuevaEntrada.BackColor = System.Drawing.SystemColors.Control;
            this.btnNuevaEntrada.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnNuevaEntrada.CausesValidation = false;
            this.btnNuevaEntrada.Location = new System.Drawing.Point(24, 36);
            this.btnNuevaEntrada.Name = "btnNuevaEntrada";
            this.btnNuevaEntrada.Size = new System.Drawing.Size(121, 121);
            this.btnNuevaEntrada.TabIndex = 0;
            this.btnNuevaEntrada.Text = "Entrada";
            this.btnNuevaEntrada.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevaEntrada.UseVisualStyleBackColor = true;
            this.btnNuevaEntrada.Click += new System.EventHandler(this.btnNuevaEntrada_Click);
            // 
            // grbIdentificacion
            // 
            this.grbIdentificacion.Controls.Add(this.lblIndentificacionProgreso);
            this.grbIdentificacion.Controls.Add(this.lblRemolque);
            this.grbIdentificacion.Controls.Add(this.picRemolque);
            this.grbIdentificacion.Controls.Add(this.btnIdentificacionManual);
            this.grbIdentificacion.Controls.Add(this.lblMatricula);
            this.grbIdentificacion.Controls.Add(this.picMatricula);
            this.grbIdentificacion.Location = new System.Drawing.Point(219, 78);
            this.grbIdentificacion.Name = "grbIdentificacion";
            this.grbIdentificacion.Size = new System.Drawing.Size(722, 173);
            this.grbIdentificacion.TabIndex = 4;
            this.grbIdentificacion.TabStop = false;
            this.grbIdentificacion.Text = "Identificación transporte";
            // 
            // lblIndentificacionProgreso
            // 
            this.lblIndentificacionProgreso.AutoSize = true;
            this.lblIndentificacionProgreso.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblIndentificacionProgreso.Location = new System.Drawing.Point(132, 124);
            this.lblIndentificacionProgreso.Name = "lblIndentificacionProgreso";
            this.lblIndentificacionProgreso.Size = new System.Drawing.Size(127, 37);
            this.lblIndentificacionProgreso.TabIndex = 8;
            this.lblIndentificacionProgreso.Text = "Iniciada...";
            // 
            // lblRemolque
            // 
            this.lblRemolque.BackColor = System.Drawing.SystemColors.Control;
            this.lblRemolque.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblRemolque.Location = new System.Drawing.Point(468, 45);
            this.lblRemolque.Margin = new System.Windows.Forms.Padding(0);
            this.lblRemolque.Name = "lblRemolque";
            this.lblRemolque.Size = new System.Drawing.Size(230, 55);
            this.lblRemolque.TabIndex = 7;
            this.lblRemolque.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picRemolque
            // 
            this.picRemolque.BackColor = System.Drawing.SystemColors.Control;
            this.picRemolque.Location = new System.Drawing.Point(460, 38);
            this.picRemolque.Name = "picRemolque";
            this.picRemolque.Size = new System.Drawing.Size(248, 73);
            this.picRemolque.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picRemolque.TabIndex = 6;
            this.picRemolque.TabStop = false;
            // 
            // btnIdentificacionManual
            // 
            this.btnIdentificacionManual.BackColor = System.Drawing.SystemColors.Control;
            this.btnIdentificacionManual.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnIdentificacionManual.Location = new System.Drawing.Point(26, 40);
            this.btnIdentificacionManual.Name = "btnIdentificacionManual";
            this.btnIdentificacionManual.Size = new System.Drawing.Size(70, 70);
            this.btnIdentificacionManual.TabIndex = 4;
            this.toolTipper.SetToolTip(this.btnIdentificacionManual, "Identificación manual");
            this.btnIdentificacionManual.UseVisualStyleBackColor = true;
            this.btnIdentificacionManual.Click += new System.EventHandler(this.btnIdentificacionManual_Click);
            // 
            // lblMatricula
            // 
            this.lblMatricula.BackColor = System.Drawing.SystemColors.Control;
            this.lblMatricula.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblMatricula.Location = new System.Drawing.Point(162, 45);
            this.lblMatricula.Margin = new System.Windows.Forms.Padding(0);
            this.lblMatricula.Name = "lblMatricula";
            this.lblMatricula.Size = new System.Drawing.Size(207, 55);
            this.lblMatricula.TabIndex = 1;
            this.lblMatricula.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picMatricula
            // 
            this.picMatricula.BackColor = System.Drawing.SystemColors.Control;
            this.picMatricula.Location = new System.Drawing.Point(132, 39);
            this.picMatricula.Name = "picMatricula";
            this.picMatricula.Size = new System.Drawing.Size(248, 73);
            this.picMatricula.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picMatricula.TabIndex = 2;
            this.picMatricula.TabStop = false;
            // 
            // lstImagenes
            // 
            this.lstImagenes.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.lstImagenes.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("lstImagenes.ImageStream")));
            this.lstImagenes.TransparentColor = System.Drawing.Color.Transparent;
            this.lstImagenes.Images.SetKeyName(0, "CamionIzquierda.png");
            this.lstImagenes.Images.SetKeyName(1, "CamionCenital.png");
            this.lstImagenes.Images.SetKeyName(2, "CamionDerecha.png");
            // 
            // grpBascula
            // 
            this.grpBascula.Controls.Add(this.grpPesoRealTime);
            this.grpBascula.Controls.Add(this.btnPesoManual);
            this.grpBascula.Controls.Add(this.lblKg);
            this.grpBascula.Controls.Add(this.lblPeso);
            this.grpBascula.Location = new System.Drawing.Point(219, 265);
            this.grpBascula.Name = "grpBascula";
            this.grpBascula.Size = new System.Drawing.Size(1092, 124);
            this.grpBascula.TabIndex = 5;
            this.grpBascula.TabStop = false;
            this.grpBascula.Text = "Peso";
            // 
            // grpPesoRealTime
            // 
            this.grpPesoRealTime.Controls.Add(this.lblKgPesoRealTime);
            this.grpPesoRealTime.Controls.Add(this.lblPesoRealTime);
            this.grpPesoRealTime.Location = new System.Drawing.Point(651, 18);
            this.grpPesoRealTime.Name = "grpPesoRealTime";
            this.grpPesoRealTime.Size = new System.Drawing.Size(435, 100);
            this.grpPesoRealTime.TabIndex = 9;
            this.grpPesoRealTime.TabStop = false;
            // 
            // lblKgPesoRealTime
            // 
            this.lblKgPesoRealTime.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblKgPesoRealTime.Location = new System.Drawing.Point(328, 22);
            this.lblKgPesoRealTime.Name = "lblKgPesoRealTime";
            this.lblKgPesoRealTime.Size = new System.Drawing.Size(83, 53);
            this.lblKgPesoRealTime.TabIndex = 8;
            this.lblKgPesoRealTime.Text = "Kg";
            // 
            // lblPesoRealTime
            // 
            this.lblPesoRealTime.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblPesoRealTime.Location = new System.Drawing.Point(74, 22);
            this.lblPesoRealTime.Name = "lblPesoRealTime";
            this.lblPesoRealTime.Size = new System.Drawing.Size(266, 53);
            this.lblPesoRealTime.TabIndex = 7;
            this.lblPesoRealTime.Text = "--";
            this.lblPesoRealTime.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnPesoManual
            // 
            this.btnPesoManual.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPesoManual.Location = new System.Drawing.Point(26, 31);
            this.btnPesoManual.Name = "btnPesoManual";
            this.btnPesoManual.Size = new System.Drawing.Size(70, 70);
            this.btnPesoManual.TabIndex = 6;
            this.toolTipper.SetToolTip(this.btnPesoManual, "Introducción manual peso");
            this.btnPesoManual.UseVisualStyleBackColor = true;
            this.btnPesoManual.Click += new System.EventHandler(this.btnPesoManual_Click);
            // 
            // lblKg
            // 
            this.lblKg.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblKg.Location = new System.Drawing.Point(330, 40);
            this.lblKg.Name = "lblKg";
            this.lblKg.Size = new System.Drawing.Size(70, 53);
            this.lblKg.TabIndex = 1;
            this.lblKg.Text = "Kg";
            // 
            // lblPeso
            // 
            this.lblPeso.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPeso.Location = new System.Drawing.Point(102, 40);
            this.lblPeso.Name = "lblPeso";
            this.lblPeso.Size = new System.Drawing.Size(240, 53);
            this.lblPeso.TabIndex = 0;
            this.lblPeso.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // pnlBotonesGuardado
            // 
            this.pnlBotonesGuardado.Controls.Add(this.btnReiniciar);
            this.pnlBotonesGuardado.Controls.Add(this.btnGuardar);
            this.pnlBotonesGuardado.Location = new System.Drawing.Point(3, 445);
            this.pnlBotonesGuardado.Name = "pnlBotonesGuardado";
            this.pnlBotonesGuardado.Size = new System.Drawing.Size(168, 268);
            this.pnlBotonesGuardado.TabIndex = 7;
            // 
            // btnReiniciar
            // 
            this.btnReiniciar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnReiniciar.Location = new System.Drawing.Point(49, 23);
            this.btnReiniciar.Name = "btnReiniciar";
            this.btnReiniciar.Size = new System.Drawing.Size(70, 70);
            this.btnReiniciar.TabIndex = 1;
            this.toolTipper.SetToolTip(this.btnReiniciar, "Reiniciar Entrada/Salida");
            this.btnReiniciar.UseVisualStyleBackColor = true;
            this.btnReiniciar.Click += new System.EventHandler(this.btnReiniciar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGuardar.Location = new System.Drawing.Point(34, 154);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(100, 100);
            this.btnGuardar.TabIndex = 0;
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // timerHora
            // 
            this.timerHora.Tick += new System.EventHandler(this.timerHora_Tick);
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.pnlTopMiddle);
            this.pnlTop.Controls.Add(this.pnlTitulo);
            this.pnlTop.Controls.Add(this.pnlBotonera);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1918, 60);
            this.pnlTop.TabIndex = 12;
            // 
            // pnlTopMiddle
            // 
            this.pnlTopMiddle.Controls.Add(this.btnCaptura);
            this.pnlTopMiddle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTopMiddle.Location = new System.Drawing.Point(464, 0);
            this.pnlTopMiddle.Name = "pnlTopMiddle";
            this.pnlTopMiddle.Size = new System.Drawing.Size(646, 60);
            this.pnlTopMiddle.TabIndex = 3;
            // 
            // btnCaptura
            // 
            this.btnCaptura.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCaptura.Location = new System.Drawing.Point(584, 3);
            this.btnCaptura.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.btnCaptura.Name = "btnCaptura";
            this.btnCaptura.Size = new System.Drawing.Size(54, 54);
            this.btnCaptura.TabIndex = 9;
            this.toolTipper.SetToolTip(this.btnCaptura, "Captura de pantalla");
            this.btnCaptura.UseVisualStyleBackColor = true;
            this.btnCaptura.Click += new System.EventHandler(this.btnCaptura_Click);
            // 
            // pnlTitulo
            // 
            this.pnlTitulo.Controls.Add(this.lblOperario);
            this.pnlTitulo.Controls.Add(this.lblFecha);
            this.pnlTitulo.Controls.Add(this.lblHora);
            this.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlTitulo.Location = new System.Drawing.Point(0, 0);
            this.pnlTitulo.Name = "pnlTitulo";
            this.pnlTitulo.Size = new System.Drawing.Size(464, 60);
            this.pnlTitulo.TabIndex = 2;
            // 
            // lblOperario
            // 
            this.lblOperario.AutoSize = true;
            this.lblOperario.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblOperario.Location = new System.Drawing.Point(3, 32);
            this.lblOperario.Name = "lblOperario";
            this.lblOperario.Size = new System.Drawing.Size(91, 25);
            this.lblOperario.TabIndex = 14;
            this.lblOperario.Text = "Operario";
            // 
            // lblFecha
            // 
            this.lblFecha.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblFecha.Location = new System.Drawing.Point(0, 0);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(128, 27);
            this.lblFecha.TabIndex = 13;
            this.lblFecha.Text = "01/01/1900";
            this.lblFecha.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblHora
            // 
            this.lblHora.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblHora.Location = new System.Drawing.Point(134, 0);
            this.lblHora.Name = "lblHora";
            this.lblHora.Size = new System.Drawing.Size(69, 27);
            this.lblHora.TabIndex = 12;
            this.lblHora.Text = "23:45";
            this.lblHora.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // pnlBotonera
            // 
            this.pnlBotonera.Controls.Add(this.btnSalir);
            this.pnlBotonera.Controls.Add(this.btnCambiarUsuario);
            this.pnlBotonera.Controls.Add(this.btnCambiarClave);
            this.pnlBotonera.Controls.Add(this.btnUsuarios);
            this.pnlBotonera.Controls.Add(this.btnLocalizaciones);
            this.pnlBotonera.Controls.Add(this.btnEmpresas);
            this.pnlBotonera.Controls.Add(this.btnTipoCargas);
            this.pnlBotonera.Controls.Add(this.btnContactos);
            this.pnlBotonera.Controls.Add(this.btnTransportes);
            this.pnlBotonera.Controls.Add(this.btnOperaciones);
            this.pnlBotonera.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlBotonera.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.pnlBotonera.Location = new System.Drawing.Point(1110, 0);
            this.pnlBotonera.Name = "pnlBotonera";
            this.pnlBotonera.Size = new System.Drawing.Size(808, 60);
            this.pnlBotonera.TabIndex = 1;
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSalir.Location = new System.Drawing.Point(749, 3);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(10, 3, 5, 3);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(54, 54);
            this.btnSalir.TabIndex = 0;
            this.toolTipper.SetToolTip(this.btnSalir, "Salir de la aplicación");
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnCambiarUsuario
            // 
            this.btnCambiarUsuario.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCambiarUsuario.Location = new System.Drawing.Point(680, 3);
            this.btnCambiarUsuario.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.btnCambiarUsuario.Name = "btnCambiarUsuario";
            this.btnCambiarUsuario.Size = new System.Drawing.Size(54, 54);
            this.btnCambiarUsuario.TabIndex = 1;
            this.toolTipper.SetToolTip(this.btnCambiarUsuario, "Cambiar de usuario");
            this.btnCambiarUsuario.UseVisualStyleBackColor = true;
            this.btnCambiarUsuario.Click += new System.EventHandler(this.btnCambiarUsuario_Click);
            // 
            // btnCambiarClave
            // 
            this.btnCambiarClave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCambiarClave.Location = new System.Drawing.Point(616, 3);
            this.btnCambiarClave.Margin = new System.Windows.Forms.Padding(15, 3, 5, 3);
            this.btnCambiarClave.Name = "btnCambiarClave";
            this.btnCambiarClave.Size = new System.Drawing.Size(54, 54);
            this.btnCambiarClave.TabIndex = 2;
            this.toolTipper.SetToolTip(this.btnCambiarClave, "Cambiar la clave de usuario");
            this.btnCambiarClave.UseVisualStyleBackColor = true;
            this.btnCambiarClave.Click += new System.EventHandler(this.btnCambiarClave_Click);
            // 
            // btnUsuarios
            // 
            this.btnUsuarios.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnUsuarios.Location = new System.Drawing.Point(542, 3);
            this.btnUsuarios.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.btnUsuarios.Name = "btnUsuarios";
            this.btnUsuarios.Size = new System.Drawing.Size(54, 54);
            this.btnUsuarios.TabIndex = 3;
            this.toolTipper.SetToolTip(this.btnUsuarios, "Gestión de usuarios");
            this.btnUsuarios.UseVisualStyleBackColor = true;
            this.btnUsuarios.Click += new System.EventHandler(this.btnUsuarios_Click);
            // 
            // btnLocalizaciones
            // 
            this.btnLocalizaciones.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLocalizaciones.Location = new System.Drawing.Point(478, 3);
            this.btnLocalizaciones.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.btnLocalizaciones.Name = "btnLocalizaciones";
            this.btnLocalizaciones.Size = new System.Drawing.Size(54, 54);
            this.btnLocalizaciones.TabIndex = 4;
            this.toolTipper.SetToolTip(this.btnLocalizaciones, "Gestión de localizaciones");
            this.btnLocalizaciones.UseVisualStyleBackColor = true;
            this.btnLocalizaciones.Click += new System.EventHandler(this.btnOrigenes_Click);
            // 
            // btnEmpresas
            // 
            this.btnEmpresas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEmpresas.Location = new System.Drawing.Point(414, 3);
            this.btnEmpresas.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.btnEmpresas.Name = "btnEmpresas";
            this.btnEmpresas.Size = new System.Drawing.Size(54, 54);
            this.btnEmpresas.TabIndex = 5;
            this.toolTipper.SetToolTip(this.btnEmpresas, "Gestión de empresas");
            this.btnEmpresas.UseVisualStyleBackColor = true;
            this.btnEmpresas.Click += new System.EventHandler(this.btnEmpresas_Click);
            // 
            // btnTipoCargas
            // 
            this.btnTipoCargas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnTipoCargas.Location = new System.Drawing.Point(350, 3);
            this.btnTipoCargas.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.btnTipoCargas.Name = "btnTipoCargas";
            this.btnTipoCargas.Size = new System.Drawing.Size(54, 54);
            this.btnTipoCargas.TabIndex = 6;
            this.toolTipper.SetToolTip(this.btnTipoCargas, "Gestión de tipos de carga");
            this.btnTipoCargas.UseVisualStyleBackColor = true;
            this.btnTipoCargas.Click += new System.EventHandler(this.btnResiduos_Click);
            // 
            // btnContactos
            // 
            this.btnContactos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnContactos.Location = new System.Drawing.Point(286, 3);
            this.btnContactos.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.btnContactos.Name = "btnContactos";
            this.btnContactos.Size = new System.Drawing.Size(54, 54);
            this.btnContactos.TabIndex = 9;
            this.toolTipper.SetToolTip(this.btnContactos, "Gestión de contactos");
            this.btnContactos.UseVisualStyleBackColor = true;
            this.btnContactos.Click += new System.EventHandler(this.btnContactos_Click);
            // 
            // btnTransportes
            // 
            this.btnTransportes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnTransportes.Location = new System.Drawing.Point(222, 3);
            this.btnTransportes.Margin = new System.Windows.Forms.Padding(15, 3, 5, 3);
            this.btnTransportes.Name = "btnTransportes";
            this.btnTransportes.Size = new System.Drawing.Size(54, 54);
            this.btnTransportes.TabIndex = 7;
            this.toolTipper.SetToolTip(this.btnTransportes, "Gestión de transportes");
            this.btnTransportes.UseVisualStyleBackColor = true;
            this.btnTransportes.Click += new System.EventHandler(this.btnTransportes_Click);
            // 
            // btnOperaciones
            // 
            this.btnOperaciones.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnOperaciones.Location = new System.Drawing.Point(148, 3);
            this.btnOperaciones.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.btnOperaciones.Name = "btnOperaciones";
            this.btnOperaciones.Size = new System.Drawing.Size(54, 54);
            this.btnOperaciones.TabIndex = 8;
            this.toolTipper.SetToolTip(this.btnOperaciones, "Gestión de operaciones");
            this.btnOperaciones.UseVisualStyleBackColor = true;
            this.btnOperaciones.Click += new System.EventHandler(this.btnOperaciones_Click);
            // 
            // grbOtraInformacion
            // 
            this.grbOtraInformacion.Controls.Add(this.cmbTipoCarga);
            this.grbOtraInformacion.Controls.Add(this.cmbExpedidor);
            this.grbOtraInformacion.Controls.Add(this.label6);
            this.grbOtraInformacion.Controls.Add(this.lblEmpresa);
            this.grbOtraInformacion.Controls.Add(this.cmbDestino);
            this.grbOtraInformacion.Controls.Add(this.label5);
            this.grbOtraInformacion.Controls.Add(this.label3);
            this.grbOtraInformacion.Controls.Add(this.cmbOrigen);
            this.grbOtraInformacion.Controls.Add(this.label2);
            this.grbOtraInformacion.Controls.Add(this.label1);
            this.grbOtraInformacion.Controls.Add(this.txtConductor);
            this.grbOtraInformacion.Controls.Add(this.label4);
            this.grbOtraInformacion.Location = new System.Drawing.Point(219, 400);
            this.grbOtraInformacion.Name = "grbOtraInformacion";
            this.grbOtraInformacion.Size = new System.Drawing.Size(722, 407);
            this.grbOtraInformacion.TabIndex = 13;
            this.grbOtraInformacion.TabStop = false;
            this.grbOtraInformacion.Text = "Información adicional";
            // 
            // cmbTipoCarga
            // 
            this.cmbTipoCarga.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoCarga.FormattingEnabled = true;
            this.cmbTipoCarga.Items.AddRange(new object[] {
            "Seleccione...",
            "Lodos",
            "Fangos",
            "Barros",
            "Mascarillas"});
            this.cmbTipoCarga.Location = new System.Drawing.Point(149, 148);
            this.cmbTipoCarga.Name = "cmbTipoCarga";
            this.cmbTipoCarga.Size = new System.Drawing.Size(557, 33);
            this.cmbTipoCarga.TabIndex = 25;
            // 
            // cmbExpedidor
            // 
            this.cmbExpedidor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbExpedidor.FormattingEnabled = true;
            this.cmbExpedidor.Items.AddRange(new object[] {
            "Seleccione...",
            "Lodos",
            "Fangos",
            "Barros",
            "Mascarillas"});
            this.cmbExpedidor.Location = new System.Drawing.Point(152, 356);
            this.cmbExpedidor.Name = "cmbExpedidor";
            this.cmbExpedidor.Size = new System.Drawing.Size(557, 33);
            this.cmbExpedidor.TabIndex = 24;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(46, 359);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 25);
            this.label6.TabIndex = 23;
            this.label6.Text = "Expedidor";
            // 
            // lblEmpresa
            // 
            this.lblEmpresa.Location = new System.Drawing.Point(152, 40);
            this.lblEmpresa.Name = "lblEmpresa";
            this.lblEmpresa.Size = new System.Drawing.Size(556, 25);
            this.lblEmpresa.TabIndex = 21;
            // 
            // cmbDestino
            // 
            this.cmbDestino.FormattingEnabled = true;
            this.cmbDestino.Items.AddRange(new object[] {
            "Seleccione...",
            "Lodos",
            "Fangos",
            "Barros",
            "Mascarillas"});
            this.cmbDestino.Location = new System.Drawing.Point(151, 298);
            this.cmbDestino.Name = "cmbDestino";
            this.cmbDestino.Size = new System.Drawing.Size(557, 33);
            this.cmbDestino.TabIndex = 20;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(67, 301);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 25);
            this.label5.TabIndex = 18;
            this.label5.Text = "Destino";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(73, 246);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 25);
            this.label3.TabIndex = 17;
            this.label3.Text = "Origen";
            // 
            // cmbOrigen
            // 
            this.cmbOrigen.FormattingEnabled = true;
            this.cmbOrigen.Items.AddRange(new object[] {
            "Seleccione...",
            "Lodos",
            "Fangos",
            "Barros",
            "Mascarillas"});
            this.cmbOrigen.Location = new System.Drawing.Point(151, 243);
            this.cmbOrigen.Name = "cmbOrigen";
            this.cmbOrigen.Size = new System.Drawing.Size(557, 33);
            this.cmbOrigen.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 151);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 25);
            this.label2.TabIndex = 15;
            this.label2.Text = "Tipo de carga";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(59, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 25);
            this.label1.TabIndex = 13;
            this.label1.Text = "Empresa";
            // 
            // txtConductor
            // 
            this.txtConductor.Location = new System.Drawing.Point(152, 93);
            this.txtConductor.Name = "txtConductor";
            this.txtConductor.Size = new System.Drawing.Size(556, 32);
            this.txtConductor.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(42, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 25);
            this.label4.TabIndex = 11;
            this.label4.Text = "Conductor";
            // 
            // grbCamaras
            // 
            this.grbCamaras.Controls.Add(this.picCamara3);
            this.grbCamaras.Controls.Add(this.picCamara2);
            this.grbCamaras.Controls.Add(this.picCamara1);
            this.grbCamaras.Location = new System.Drawing.Point(177, 813);
            this.grbCamaras.Name = "grbCamaras";
            this.grbCamaras.Size = new System.Drawing.Size(1106, 258);
            this.grbCamaras.TabIndex = 14;
            this.grbCamaras.TabStop = false;
            this.grbCamaras.Text = "Cámaras";
            // 
            // picCamara3
            // 
            this.picCamara3.Location = new System.Drawing.Point(737, 39);
            this.picCamara3.Name = "picCamara3";
            this.picCamara3.Size = new System.Drawing.Size(360, 205);
            this.picCamara3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picCamara3.TabIndex = 2;
            this.picCamara3.TabStop = false;
            this.picCamara3.Click += new System.EventHandler(this.picCamara3_Click);
            // 
            // picCamara2
            // 
            this.picCamara2.Location = new System.Drawing.Point(371, 39);
            this.picCamara2.Name = "picCamara2";
            this.picCamara2.Size = new System.Drawing.Size(360, 205);
            this.picCamara2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picCamara2.TabIndex = 1;
            this.picCamara2.TabStop = false;
            this.picCamara2.Click += new System.EventHandler(this.picCamara2_Click);
            // 
            // picCamara1
            // 
            this.picCamara1.Location = new System.Drawing.Point(5, 39);
            this.picCamara1.Name = "picCamara1";
            this.picCamara1.Size = new System.Drawing.Size(360, 205);
            this.picCamara1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picCamara1.TabIndex = 0;
            this.picCamara1.TabStop = false;
            this.picCamara1.Click += new System.EventHandler(this.picCamara1_Click);
            // 
            // vvCamara1
            // 
            this.vvCamara1.BackColor = System.Drawing.Color.Black;
            this.vvCamara1.Location = new System.Drawing.Point(1326, 66);
            this.vvCamara1.MediaPlayer = null;
            this.vvCamara1.Name = "vvCamara1";
            this.vvCamara1.Size = new System.Drawing.Size(587, 330);
            this.vvCamara1.TabIndex = 15;
            this.vvCamara1.Text = "Cámara 1";
            // 
            // vvCamara2
            // 
            this.vvCamara2.BackColor = System.Drawing.Color.Black;
            this.vvCamara2.Location = new System.Drawing.Point(1326, 403);
            this.vvCamara2.MediaPlayer = null;
            this.vvCamara2.Name = "vvCamara2";
            this.vvCamara2.Size = new System.Drawing.Size(587, 330);
            this.vvCamara2.TabIndex = 16;
            this.vvCamara2.Text = "Cámara 2";
            // 
            // vvCamara3
            // 
            this.vvCamara3.BackColor = System.Drawing.Color.Black;
            this.vvCamara3.Location = new System.Drawing.Point(1326, 740);
            this.vvCamara3.MediaPlayer = null;
            this.vvCamara3.Name = "vvCamara3";
            this.vvCamara3.Size = new System.Drawing.Size(587, 330);
            this.vvCamara3.TabIndex = 17;
            this.vvCamara3.Text = "Cámara 3";
            // 
            // bgwPesoRealTime
            // 
            this.bgwPesoRealTime.WorkerReportsProgress = true;
            this.bgwPesoRealTime.WorkerSupportsCancellation = false;
            this.bgwPesoRealTime.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwPesoRealTime_DoWork);
            this.bgwPesoRealTime.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgwPesoRealTime_ProgressChanged);
            // 
            // bgwControlEstabilidad
            // 
            this.bgwControlEstabilidad.WorkerReportsProgress = true;
            this.bgwControlEstabilidad.WorkerSupportsCancellation = false;
            this.bgwControlEstabilidad.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwControlEstabilidad_DoWork);
            this.bgwControlEstabilidad.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgwControlEstabilidad_ProgressChanged);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnSalir;
            this.ClientSize = new System.Drawing.Size(1918, 985);
            this.ControlBox = false;
            this.Controls.Add(this.vvCamara3);
            this.Controls.Add(this.vvCamara2);
            this.Controls.Add(this.vvCamara1);
            this.Controls.Add(this.grbCamaras);
            this.Controls.Add(this.grbOtraInformacion);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.pnlBotonesGuardado);
            this.Controls.Add(this.grpBascula);
            this.Controls.Add(this.grbIdentificacion);
            this.Controls.Add(this.pnlBotonesPrincipales);
            this.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Shown += new System.EventHandler(this.frmMain_Shown);
            this.pnlBotonesPrincipales.ResumeLayout(false);
            this.grbIdentificacion.ResumeLayout(false);
            this.grbIdentificacion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picRemolque)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMatricula)).EndInit();
            this.grpBascula.ResumeLayout(false);
            this.grpPesoRealTime.ResumeLayout(false);
            this.pnlBotonesGuardado.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlTopMiddle.ResumeLayout(false);
            this.pnlTitulo.ResumeLayout(false);
            this.pnlTitulo.PerformLayout();
            this.pnlBotonera.ResumeLayout(false);
            this.grbOtraInformacion.ResumeLayout(false);
            this.grbOtraInformacion.PerformLayout();
            this.grbCamaras.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picCamara3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCamara2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCamara1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vvCamara1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vvCamara2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vvCamara3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlBotonesPrincipales;
        private System.Windows.Forms.Button btnNuevaSalida;
        private System.Windows.Forms.Button btnNuevaEntrada;
        private System.Windows.Forms.GroupBox grbIdentificacion;
        private System.Windows.Forms.Label lblMatricula;
        private System.Windows.Forms.PictureBox picMatricula;
        private System.Windows.Forms.Button btnIdentificacionManual;
        private System.Windows.Forms.ImageList lstImagenes;
        private System.Windows.Forms.GroupBox grpBascula;
        private System.Windows.Forms.Label lblPeso;
        private System.Windows.Forms.Label lblKg;
        private System.Windows.Forms.Button btnPesoManual;
        private System.Windows.Forms.Panel pnlBotonesGuardado;
        private System.Windows.Forms.Button btnReiniciar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Timer timerHora;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Panel pnlTitulo;
        private System.Windows.Forms.Label lblOperario;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label lblHora;
        private System.Windows.Forms.FlowLayoutPanel pnlBotonera;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnCambiarUsuario;
        private System.Windows.Forms.Button btnCambiarClave;
        private System.Windows.Forms.Button btnUsuarios;
        private System.Windows.Forms.ToolTip toolTipper;
        private System.Windows.Forms.Button btnLocalizaciones;
        private System.Windows.Forms.Button btnEmpresas;
        private System.Windows.Forms.Button btnTipoCargas;
        private System.Windows.Forms.Button btnTransportes;
        private System.Windows.Forms.Button btnOperaciones;
        private System.Windows.Forms.PictureBox picRemolque;
        private System.Windows.Forms.Label lblRemolque;
        private System.Windows.Forms.GroupBox grbOtraInformacion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtConductor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox grbCamaras;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbOrigen;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox picCamara3;
        private System.Windows.Forms.PictureBox picCamara2;
        private System.Windows.Forms.PictureBox picCamara1;
        private System.Windows.Forms.ComboBox cmbDestino;
        private System.Windows.Forms.Label lblEmpresa;
        private LibVLCSharp.WinForms.VideoView vvCamara1;
        private LibVLCSharp.WinForms.VideoView vvCamara2;
        private LibVLCSharp.WinForms.VideoView vvCamara3;
        private System.Windows.Forms.Panel pnlTopMiddle;
        private System.Windows.Forms.Button btnCaptura;
        private System.Windows.Forms.Label lblIndentificacionProgreso;
        private System.ComponentModel.BackgroundWorker bgwPesoRealTime;
        private System.Windows.Forms.Label lblKgPesoRealTime;
        private System.Windows.Forms.Label lblPesoRealTime;
        private System.ComponentModel.BackgroundWorker bgwControlEstabilidad;
        private System.Windows.Forms.ComboBox cmbExpedidor;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbTipoCarga;
        private System.Windows.Forms.GroupBox grpPesoRealTime;
        private System.Windows.Forms.Button btnContactos;
    }
}