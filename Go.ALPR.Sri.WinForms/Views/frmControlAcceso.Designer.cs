
namespace Go.ALPR.Sri.WinForms
{
    partial class frmControlAcceso
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmControlAcceso));
            this.pnlBotonesPrincipales = new System.Windows.Forms.Panel();
            this.btnNuevaEntrada = new System.Windows.Forms.Button();
            this.grbIdentificacion = new System.Windows.Forms.GroupBox();
            this.lblResultadoHora = new System.Windows.Forms.Label();
            this.lblResultado = new System.Windows.Forms.Label();
            this.pnlSemaforo = new System.Windows.Forms.Panel();
            this.lblIndentificacionProgreso = new System.Windows.Forms.Label();
            this.lblMatricula = new System.Windows.Forms.Label();
            this.grbOtraInformacion = new System.Windows.Forms.GroupBox();
            this.lblConductor = new System.Windows.Forms.Label();
            this.lblEmpresa = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.picMatricula = new System.Windows.Forms.PictureBox();
            this.lstImagenes = new System.Windows.Forms.ImageList(this.components);
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
            this.btnLocalizaciones = new System.Windows.Forms.Button();
            this.btnEmpresas = new System.Windows.Forms.Button();
            this.btnTipoCargas = new System.Windows.Forms.Button();
            this.btnTransportes = new System.Windows.Forms.Button();
            this.toolTipper = new System.Windows.Forms.ToolTip(this.components);
            this.vvCamara1 = new LibVLCSharp.WinForms.VideoView();
            this.vvCamara2 = new LibVLCSharp.WinForms.VideoView();
            this.vvCamara3 = new LibVLCSharp.WinForms.VideoView();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.pnlFiltros = new System.Windows.Forms.Panel();
            this.cmbAcceso = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtMatricula = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dtpFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.dtpFechaFin = new System.Windows.Forms.DateTimePicker();
            this.pnlPaginacion = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbPageSize = new System.Windows.Forms.ComboBox();
            this.btnPrimera = new System.Windows.Forms.Button();
            this.btnAnterior = new System.Windows.Forms.Button();
            this.btnUltima = new System.Windows.Forms.Button();
            this.btnSiguiente = new System.Windows.Forms.Button();
            this.lblPagina = new System.Windows.Forms.Label();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.pnlBotonesPrincipales.SuspendLayout();
            this.grbIdentificacion.SuspendLayout();
            this.grbOtraInformacion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMatricula)).BeginInit();
            this.pnlTop.SuspendLayout();
            this.pnlTopMiddle.SuspendLayout();
            this.pnlTitulo.SuspendLayout();
            this.pnlBotonera.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vvCamara1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vvCamara2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vvCamara3)).BeginInit();
            this.pnlGrid.SuspendLayout();
            this.pnlFiltros.SuspendLayout();
            this.pnlPaginacion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBotonesPrincipales
            // 
            this.pnlBotonesPrincipales.Controls.Add(this.btnNuevaEntrada);
            this.pnlBotonesPrincipales.Location = new System.Drawing.Point(12, 78);
            this.pnlBotonesPrincipales.Name = "pnlBotonesPrincipales";
            this.pnlBotonesPrincipales.Size = new System.Drawing.Size(302, 279);
            this.pnlBotonesPrincipales.TabIndex = 3;
            // 
            // btnNuevaEntrada
            // 
            this.btnNuevaEntrada.BackColor = System.Drawing.SystemColors.Control;
            this.btnNuevaEntrada.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnNuevaEntrada.CausesValidation = false;
            this.btnNuevaEntrada.Location = new System.Drawing.Point(51, 39);
            this.btnNuevaEntrada.Name = "btnNuevaEntrada";
            this.btnNuevaEntrada.Size = new System.Drawing.Size(200, 200);
            this.btnNuevaEntrada.TabIndex = 0;
            this.btnNuevaEntrada.Text = "Entrada";
            this.btnNuevaEntrada.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevaEntrada.UseVisualStyleBackColor = true;
            this.btnNuevaEntrada.Click += new System.EventHandler(this.btnNuevaEntrada_Click);
            // 
            // grbIdentificacion
            // 
            this.grbIdentificacion.Controls.Add(this.lblResultadoHora);
            this.grbIdentificacion.Controls.Add(this.lblResultado);
            this.grbIdentificacion.Controls.Add(this.pnlSemaforo);
            this.grbIdentificacion.Controls.Add(this.lblIndentificacionProgreso);
            this.grbIdentificacion.Controls.Add(this.lblMatricula);
            this.grbIdentificacion.Controls.Add(this.grbOtraInformacion);
            this.grbIdentificacion.Controls.Add(this.picMatricula);
            this.grbIdentificacion.Location = new System.Drawing.Point(327, 78);
            this.grbIdentificacion.Name = "grbIdentificacion";
            this.grbIdentificacion.Size = new System.Drawing.Size(972, 449);
            this.grbIdentificacion.TabIndex = 4;
            this.grbIdentificacion.TabStop = false;
            this.grbIdentificacion.Text = "Último transporte identificado";
            // 
            // lblResultadoHora
            // 
            this.lblResultadoHora.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblResultadoHora.Location = new System.Drawing.Point(396, 66);
            this.lblResultadoHora.Name = "lblResultadoHora";
            this.lblResultadoHora.Size = new System.Drawing.Size(280, 37);
            this.lblResultadoHora.TabIndex = 20;
            this.lblResultadoHora.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblResultado
            // 
            this.lblResultado.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblResultado.Location = new System.Drawing.Point(646, 242);
            this.lblResultado.Name = "lblResultado";
            this.lblResultado.Size = new System.Drawing.Size(280, 37);
            this.lblResultado.TabIndex = 19;
            this.lblResultado.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pnlSemaforo
            // 
            this.pnlSemaforo.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pnlSemaforo.Location = new System.Drawing.Point(686, 26);
            this.pnlSemaforo.Name = "pnlSemaforo";
            this.pnlSemaforo.Size = new System.Drawing.Size(200, 200);
            this.pnlSemaforo.TabIndex = 18;
            // 
            // lblIndentificacionProgreso
            // 
            this.lblIndentificacionProgreso.AutoSize = true;
            this.lblIndentificacionProgreso.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblIndentificacionProgreso.Location = new System.Drawing.Point(75, 154);
            this.lblIndentificacionProgreso.Name = "lblIndentificacionProgreso";
            this.lblIndentificacionProgreso.Size = new System.Drawing.Size(127, 37);
            this.lblIndentificacionProgreso.TabIndex = 8;
            this.lblIndentificacionProgreso.Text = "Iniciada...";
            // 
            // lblMatricula
            // 
            this.lblMatricula.BackColor = System.Drawing.SystemColors.Control;
            this.lblMatricula.Font = new System.Drawing.Font("Segoe UI", 34F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblMatricula.Location = new System.Drawing.Point(115, 50);
            this.lblMatricula.Margin = new System.Windows.Forms.Padding(0);
            this.lblMatricula.Name = "lblMatricula";
            this.lblMatricula.Size = new System.Drawing.Size(254, 55);
            this.lblMatricula.TabIndex = 1;
            this.lblMatricula.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grbOtraInformacion
            // 
            this.grbOtraInformacion.Controls.Add(this.lblConductor);
            this.grbOtraInformacion.Controls.Add(this.lblEmpresa);
            this.grbOtraInformacion.Controls.Add(this.label1);
            this.grbOtraInformacion.Controls.Add(this.label4);
            this.grbOtraInformacion.Location = new System.Drawing.Point(51, 292);
            this.grbOtraInformacion.Name = "grbOtraInformacion";
            this.grbOtraInformacion.Size = new System.Drawing.Size(858, 142);
            this.grbOtraInformacion.TabIndex = 13;
            this.grbOtraInformacion.TabStop = false;
            this.grbOtraInformacion.Text = "Información adicional";
            // 
            // lblConductor
            // 
            this.lblConductor.Location = new System.Drawing.Point(152, 97);
            this.lblConductor.Name = "lblConductor";
            this.lblConductor.Size = new System.Drawing.Size(700, 25);
            this.lblConductor.TabIndex = 22;
            // 
            // lblEmpresa
            // 
            this.lblEmpresa.Location = new System.Drawing.Point(152, 40);
            this.lblEmpresa.Name = "lblEmpresa";
            this.lblEmpresa.Size = new System.Drawing.Size(700, 25);
            this.lblEmpresa.TabIndex = 21;
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(42, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 25);
            this.label4.TabIndex = 11;
            this.label4.Text = "Conductor";
            // 
            // picMatricula
            // 
            this.picMatricula.BackColor = System.Drawing.SystemColors.Control;
            this.picMatricula.Location = new System.Drawing.Point(75, 39);
            this.picMatricula.Name = "picMatricula";
            this.picMatricula.Size = new System.Drawing.Size(307, 88);
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
            this.pnlTopMiddle.Size = new System.Drawing.Size(945, 60);
            this.pnlTopMiddle.TabIndex = 3;
            // 
            // btnCaptura
            // 
            this.btnCaptura.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCaptura.Location = new System.Drawing.Point(862, 3);
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
            this.pnlBotonera.Controls.Add(this.btnLocalizaciones);
            this.pnlBotonera.Controls.Add(this.btnEmpresas);
            this.pnlBotonera.Controls.Add(this.btnTipoCargas);
            this.pnlBotonera.Controls.Add(this.btnTransportes);
            this.pnlBotonera.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlBotonera.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.pnlBotonera.Location = new System.Drawing.Point(1409, 0);
            this.pnlBotonera.Name = "pnlBotonera";
            this.pnlBotonera.Size = new System.Drawing.Size(509, 60);
            this.pnlBotonera.TabIndex = 1;
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSalir.Location = new System.Drawing.Point(450, 3);
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
            this.btnCambiarUsuario.Location = new System.Drawing.Point(381, 3);
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
            this.btnCambiarClave.Location = new System.Drawing.Point(317, 3);
            this.btnCambiarClave.Margin = new System.Windows.Forms.Padding(15, 3, 5, 3);
            this.btnCambiarClave.Name = "btnCambiarClave";
            this.btnCambiarClave.Size = new System.Drawing.Size(54, 54);
            this.btnCambiarClave.TabIndex = 2;
            this.toolTipper.SetToolTip(this.btnCambiarClave, "Cambiar la clave de usuario");
            this.btnCambiarClave.UseVisualStyleBackColor = true;
            this.btnCambiarClave.Click += new System.EventHandler(this.btnCambiarClave_Click);
            // 
            // btnLocalizaciones
            // 
            this.btnLocalizaciones.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLocalizaciones.Location = new System.Drawing.Point(243, 3);
            this.btnLocalizaciones.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.btnLocalizaciones.Name = "btnLocalizaciones";
            this.btnLocalizaciones.Size = new System.Drawing.Size(54, 54);
            this.btnLocalizaciones.TabIndex = 4;
            this.toolTipper.SetToolTip(this.btnLocalizaciones, "Gestión de localizaciones");
            this.btnLocalizaciones.UseVisualStyleBackColor = true;
            this.btnLocalizaciones.Visible = false;
            this.btnLocalizaciones.Click += new System.EventHandler(this.btnOrigenes_Click);
            // 
            // btnEmpresas
            // 
            this.btnEmpresas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEmpresas.Location = new System.Drawing.Point(179, 3);
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
            this.btnTipoCargas.Location = new System.Drawing.Point(115, 3);
            this.btnTipoCargas.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.btnTipoCargas.Name = "btnTipoCargas";
            this.btnTipoCargas.Size = new System.Drawing.Size(54, 54);
            this.btnTipoCargas.TabIndex = 6;
            this.toolTipper.SetToolTip(this.btnTipoCargas, "Gestión de tipos de carga");
            this.btnTipoCargas.UseVisualStyleBackColor = true;
            this.btnTipoCargas.Visible = false;
            this.btnTipoCargas.Click += new System.EventHandler(this.btnResiduos_Click);
            // 
            // btnTransportes
            // 
            this.btnTransportes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnTransportes.Location = new System.Drawing.Point(51, 3);
            this.btnTransportes.Margin = new System.Windows.Forms.Padding(15, 3, 5, 3);
            this.btnTransportes.Name = "btnTransportes";
            this.btnTransportes.Size = new System.Drawing.Size(54, 54);
            this.btnTransportes.TabIndex = 7;
            this.toolTipper.SetToolTip(this.btnTransportes, "Gestión de transportes");
            this.btnTransportes.UseVisualStyleBackColor = true;
            this.btnTransportes.Click += new System.EventHandler(this.btnTransportes_Click);
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
            // pnlGrid
            // 
            this.pnlGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlGrid.Controls.Add(this.pnlFiltros);
            this.pnlGrid.Controls.Add(this.pnlPaginacion);
            this.pnlGrid.Controls.Add(this.dgvData);
            this.pnlGrid.Location = new System.Drawing.Point(12, 533);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(1287, 444);
            this.pnlGrid.TabIndex = 18;
            // 
            // pnlFiltros
            // 
            this.pnlFiltros.Controls.Add(this.cmbAcceso);
            this.pnlFiltros.Controls.Add(this.label6);
            this.pnlFiltros.Controls.Add(this.btnLimpiar);
            this.pnlFiltros.Controls.Add(this.btnBuscar);
            this.pnlFiltros.Controls.Add(this.txtMatricula);
            this.pnlFiltros.Controls.Add(this.label2);
            this.pnlFiltros.Controls.Add(this.label7);
            this.pnlFiltros.Controls.Add(this.dtpFechaInicio);
            this.pnlFiltros.Controls.Add(this.label8);
            this.pnlFiltros.Controls.Add(this.dtpFechaFin);
            this.pnlFiltros.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlFiltros.Location = new System.Drawing.Point(0, 0);
            this.pnlFiltros.Name = "pnlFiltros";
            this.pnlFiltros.Size = new System.Drawing.Size(314, 444);
            this.pnlFiltros.TabIndex = 3;
            // 
            // cmbAcceso
            // 
            this.cmbAcceso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAcceso.FormattingEnabled = true;
            this.cmbAcceso.Location = new System.Drawing.Point(141, 207);
            this.cmbAcceso.Name = "cmbAcceso";
            this.cmbAcceso.Size = new System.Drawing.Size(149, 33);
            this.cmbAcceso.TabIndex = 35;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(64, 210);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 25);
            this.label6.TabIndex = 34;
            this.label6.Text = "Acceso";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnLimpiar.BackgroundImage")));
            this.btnLimpiar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLimpiar.Location = new System.Drawing.Point(165, 456);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(54, 54);
            this.btnLimpiar.TabIndex = 33;
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBuscar.BackgroundImage")));
            this.btnBuscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBuscar.Location = new System.Drawing.Point(96, 456);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(54, 54);
            this.btnBuscar.TabIndex = 32;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtMatricula
            // 
            this.txtMatricula.Location = new System.Drawing.Point(141, 149);
            this.txtMatricula.Name = "txtMatricula";
            this.txtMatricula.Size = new System.Drawing.Size(149, 32);
            this.txtMatricula.TabIndex = 31;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 152);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 25);
            this.label2.TabIndex = 30;
            this.label2.Text = "Matrícula";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(25, 41);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(112, 25);
            this.label7.TabIndex = 26;
            this.label7.Text = "Fecha inicio";
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.CustomFormat = "";
            this.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaInicio.Location = new System.Drawing.Point(141, 37);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.ShowCheckBox = true;
            this.dtpFechaInicio.Size = new System.Drawing.Size(149, 32);
            this.dtpFechaInicio.TabIndex = 27;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(47, 97);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 25);
            this.label8.TabIndex = 28;
            this.label8.Text = "Fecha fin";
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.CustomFormat = "";
            this.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFin.Location = new System.Drawing.Point(141, 93);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.ShowCheckBox = true;
            this.dtpFechaFin.Size = new System.Drawing.Size(149, 32);
            this.dtpFechaFin.TabIndex = 29;
            // 
            // pnlPaginacion
            // 
            this.pnlPaginacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPaginacion.Controls.Add(this.label10);
            this.pnlPaginacion.Controls.Add(this.cmbPageSize);
            this.pnlPaginacion.Controls.Add(this.btnPrimera);
            this.pnlPaginacion.Controls.Add(this.btnAnterior);
            this.pnlPaginacion.Controls.Add(this.btnUltima);
            this.pnlPaginacion.Controls.Add(this.btnSiguiente);
            this.pnlPaginacion.Controls.Add(this.lblPagina);
            this.pnlPaginacion.Location = new System.Drawing.Point(315, 486);
            this.pnlPaginacion.Name = "pnlPaginacion";
            this.pnlPaginacion.Size = new System.Drawing.Size(970, 50);
            this.pnlPaginacion.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(24, 11);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(141, 25);
            this.label10.TabIndex = 27;
            this.label10.Text = "Tamaño página";
            // 
            // cmbPageSize
            // 
            this.cmbPageSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPageSize.FormattingEnabled = true;
            this.cmbPageSize.Location = new System.Drawing.Point(171, 8);
            this.cmbPageSize.Name = "cmbPageSize";
            this.cmbPageSize.Size = new System.Drawing.Size(121, 33);
            this.cmbPageSize.TabIndex = 17;
            // 
            // btnPrimera
            // 
            this.btnPrimera.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnPrimera.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPrimera.BackgroundImage")));
            this.btnPrimera.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPrimera.Location = new System.Drawing.Point(450, 2);
            this.btnPrimera.Name = "btnPrimera";
            this.btnPrimera.Size = new System.Drawing.Size(44, 44);
            this.btnPrimera.TabIndex = 16;
            this.btnPrimera.UseVisualStyleBackColor = true;
            this.btnPrimera.Click += new System.EventHandler(this.btnPrimera_Click);
            // 
            // btnAnterior
            // 
            this.btnAnterior.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnAnterior.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAnterior.BackgroundImage")));
            this.btnAnterior.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAnterior.Location = new System.Drawing.Point(519, 2);
            this.btnAnterior.Name = "btnAnterior";
            this.btnAnterior.Size = new System.Drawing.Size(44, 44);
            this.btnAnterior.TabIndex = 15;
            this.btnAnterior.UseVisualStyleBackColor = true;
            this.btnAnterior.Click += new System.EventHandler(this.btnAnterior_Click);
            // 
            // btnUltima
            // 
            this.btnUltima.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnUltima.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnUltima.BackgroundImage")));
            this.btnUltima.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnUltima.Location = new System.Drawing.Point(801, 2);
            this.btnUltima.Name = "btnUltima";
            this.btnUltima.Size = new System.Drawing.Size(44, 44);
            this.btnUltima.TabIndex = 14;
            this.btnUltima.UseVisualStyleBackColor = true;
            this.btnUltima.Click += new System.EventHandler(this.btnUltima_Click);
            // 
            // btnSiguiente
            // 
            this.btnSiguiente.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnSiguiente.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSiguiente.BackgroundImage")));
            this.btnSiguiente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSiguiente.Location = new System.Drawing.Point(732, 2);
            this.btnSiguiente.Name = "btnSiguiente";
            this.btnSiguiente.Size = new System.Drawing.Size(44, 44);
            this.btnSiguiente.TabIndex = 13;
            this.btnSiguiente.UseVisualStyleBackColor = true;
            this.btnSiguiente.Click += new System.EventHandler(this.btnSiguiente_Click);
            // 
            // lblPagina
            // 
            this.lblPagina.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblPagina.AutoSize = true;
            this.lblPagina.Location = new System.Drawing.Point(583, 10);
            this.lblPagina.Name = "lblPagina";
            this.lblPagina.Size = new System.Drawing.Size(125, 25);
            this.lblPagina.TabIndex = 12;
            this.lblPagina.Text = "Página 0 de 0";
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.AllowUserToResizeRows = false;
            this.dgvData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvData.Location = new System.Drawing.Point(315, 0);
            this.dgvData.MultiSelect = false;
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(972, 393);
            this.dgvData.TabIndex = 2;
            // 
            // frmControlAcceso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnSalir;
            this.ClientSize = new System.Drawing.Size(1918, 985);
            this.ControlBox = false;
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.vvCamara3);
            this.Controls.Add(this.vvCamara2);
            this.Controls.Add(this.vvCamara1);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.grbIdentificacion);
            this.Controls.Add(this.pnlBotonesPrincipales);
            this.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmControlAcceso";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmControlAcceso_Load);
            this.pnlBotonesPrincipales.ResumeLayout(false);
            this.grbIdentificacion.ResumeLayout(false);
            this.grbIdentificacion.PerformLayout();
            this.grbOtraInformacion.ResumeLayout(false);
            this.grbOtraInformacion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMatricula)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.pnlTopMiddle.ResumeLayout(false);
            this.pnlTitulo.ResumeLayout(false);
            this.pnlTitulo.PerformLayout();
            this.pnlBotonera.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.vvCamara1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vvCamara2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vvCamara3)).EndInit();
            this.pnlGrid.ResumeLayout(false);
            this.pnlFiltros.ResumeLayout(false);
            this.pnlFiltros.PerformLayout();
            this.pnlPaginacion.ResumeLayout(false);
            this.pnlPaginacion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlBotonesPrincipales;
        private System.Windows.Forms.Button btnNuevaEntrada;
        private System.Windows.Forms.GroupBox grbIdentificacion;
        private System.Windows.Forms.Label lblMatricula;
        private System.Windows.Forms.PictureBox picMatricula;
        private System.Windows.Forms.ImageList lstImagenes;
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
        private System.Windows.Forms.ToolTip toolTipper;
        private System.Windows.Forms.Button btnLocalizaciones;
        private System.Windows.Forms.Button btnEmpresas;
        private System.Windows.Forms.Button btnTipoCargas;
        private System.Windows.Forms.Button btnTransportes;
        private System.Windows.Forms.GroupBox grbOtraInformacion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblEmpresa;
        private LibVLCSharp.WinForms.VideoView vvCamara1;
        private LibVLCSharp.WinForms.VideoView vvCamara2;
        private LibVLCSharp.WinForms.VideoView vvCamara3;
        private System.Windows.Forms.Panel pnlTopMiddle;
        private System.Windows.Forms.Button btnCaptura;
        private System.Windows.Forms.Label lblIndentificacionProgreso;
        private System.Windows.Forms.Panel pnlSemaforo;
        private System.Windows.Forms.Label lblConductor;
        private System.Windows.Forms.Label lblResultado;
        private System.Windows.Forms.Label lblResultadoHora;
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.Panel pnlFiltros;
        private System.Windows.Forms.Panel pnlPaginacion;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmbPageSize;
        private System.Windows.Forms.Button btnPrimera;
        private System.Windows.Forms.Button btnAnterior;
        private System.Windows.Forms.Button btnUltima;
        private System.Windows.Forms.Button btnSiguiente;
        private System.Windows.Forms.Label lblPagina;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtpFechaInicio;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtpFechaFin;
        private System.Windows.Forms.TextBox txtMatricula;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.ComboBox cmbAcceso;
        private System.Windows.Forms.Label label6;
    }
}