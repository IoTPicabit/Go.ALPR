
namespace Go.ALPR.Sri.WinForms
{
    partial class frmOperaciones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOperaciones));
            this.pnlTop = new System.Windows.Forms.Panel();
            this.btnEnviarAlbaran = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnGuardarAlbaran = new System.Windows.Forms.Button();
            this.btnImprimirAlbaran = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.pnlPaginacion = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbPageSize = new System.Windows.Forms.ComboBox();
            this.btnPrimera = new System.Windows.Forms.Button();
            this.btnAnterior = new System.Windows.Forms.Button();
            this.btnUltima = new System.Windows.Forms.Button();
            this.btnSiguiente = new System.Windows.Forms.Button();
            this.lblPagina = new System.Windows.Forms.Label();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMatricula = new System.Windows.Forms.TextBox();
            this.toolTippper = new System.Windows.Forms.ToolTip(this.components);
            this.cmbTipoOperacion = new System.Windows.Forms.ComboBox();
            this.dtpFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaFin = new System.Windows.Forms.DateTimePicker();
            this.btnCerrarDetalle = new System.Windows.Forms.Button();
            this.txtRemolque = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtConductor = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtEmpresa = new System.Windows.Forms.TextBox();
            this.txtTipoCarga = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.pnlFormulario = new System.Windows.Forms.Panel();
            this.grbCamarasSalida = new System.Windows.Forms.GroupBox();
            this.picCamara3Salida = new System.Windows.Forms.PictureBox();
            this.picCamara2Salida = new System.Windows.Forms.PictureBox();
            this.picCamara1Salida = new System.Windows.Forms.PictureBox();
            this.grbCamarasEntrada = new System.Windows.Forms.GroupBox();
            this.picCamara3Entrada = new System.Windows.Forms.PictureBox();
            this.picCamara2Entrada = new System.Windows.Forms.PictureBox();
            this.picCamara1Entrada = new System.Windows.Forms.PictureBox();
            this.pnlBotoneraDetalle = new System.Windows.Forms.Panel();
            this.pnlTop.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            this.pnlPaginacion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.pnlFormulario.SuspendLayout();
            this.grbCamarasSalida.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCamara3Salida)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCamara2Salida)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCamara1Salida)).BeginInit();
            this.grbCamarasEntrada.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCamara3Entrada)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCamara2Entrada)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCamara1Entrada)).BeginInit();
            this.pnlBotoneraDetalle.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.btnEnviarAlbaran);
            this.pnlTop.Controls.Add(this.btnEditar);
            this.pnlTop.Controls.Add(this.btnGuardarAlbaran);
            this.pnlTop.Controls.Add(this.btnImprimirAlbaran);
            this.pnlTop.Controls.Add(this.btnLimpiar);
            this.pnlTop.Controls.Add(this.btnBuscar);
            this.pnlTop.Controls.Add(this.btnCerrar);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1424, 60);
            this.pnlTop.TabIndex = 8;
            // 
            // btnEnviarAlbaran
            // 
            this.btnEnviarAlbaran.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEnviarAlbaran.Location = new System.Drawing.Point(452, 3);
            this.btnEnviarAlbaran.Name = "btnEnviarAlbaran";
            this.btnEnviarAlbaran.Size = new System.Drawing.Size(54, 54);
            this.btnEnviarAlbaran.TabIndex = 19;
            this.toolTippper.SetToolTip(this.btnEnviarAlbaran, "Enviar albarán por email");
            this.btnEnviarAlbaran.UseVisualStyleBackColor = true;
            this.btnEnviarAlbaran.Click += new System.EventHandler(this.btnEnviarAlbaran_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar.BackgroundImage")));
            this.btnEditar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEditar.Location = new System.Drawing.Point(239, 3);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(54, 54);
            this.btnEditar.TabIndex = 18;
            this.toolTippper.SetToolTip(this.btnEditar, "Ver imágenes");
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnGuardarAlbaran
            // 
            this.btnGuardarAlbaran.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGuardarAlbaran.BackgroundImage")));
            this.btnGuardarAlbaran.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGuardarAlbaran.Location = new System.Drawing.Point(383, 3);
            this.btnGuardarAlbaran.Name = "btnGuardarAlbaran";
            this.btnGuardarAlbaran.Size = new System.Drawing.Size(54, 54);
            this.btnGuardarAlbaran.TabIndex = 17;
            this.toolTippper.SetToolTip(this.btnGuardarAlbaran, "Guardar albarán como...");
            this.btnGuardarAlbaran.UseVisualStyleBackColor = true;
            this.btnGuardarAlbaran.Click += new System.EventHandler(this.btnGuardarAlbaran_Click);
            // 
            // btnImprimirAlbaran
            // 
            this.btnImprimirAlbaran.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimirAlbaran.BackgroundImage")));
            this.btnImprimirAlbaran.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnImprimirAlbaran.Location = new System.Drawing.Point(313, 3);
            this.btnImprimirAlbaran.Name = "btnImprimirAlbaran";
            this.btnImprimirAlbaran.Size = new System.Drawing.Size(54, 54);
            this.btnImprimirAlbaran.TabIndex = 16;
            this.toolTippper.SetToolTip(this.btnImprimirAlbaran, "Imprimir albarán");
            this.btnImprimirAlbaran.UseVisualStyleBackColor = true;
            this.btnImprimirAlbaran.Click += new System.EventHandler(this.btnImprimirAlbaran_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnLimpiar.BackgroundImage")));
            this.btnLimpiar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLimpiar.Location = new System.Drawing.Point(81, 3);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(54, 54);
            this.btnLimpiar.TabIndex = 15;
            this.toolTippper.SetToolTip(this.btnLimpiar, "Limpiar filtro");
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBuscar.BackgroundImage")));
            this.btnBuscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBuscar.Location = new System.Drawing.Point(12, 3);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(54, 54);
            this.btnBuscar.TabIndex = 9;
            this.toolTippper.SetToolTip(this.btnBuscar, "Buscar");
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCerrar.Location = new System.Drawing.Point(1358, 3);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(54, 54);
            this.btnCerrar.TabIndex = 14;
            this.toolTippper.SetToolTip(this.btnCerrar, "Cerrar");
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // pnlGrid
            // 
            this.pnlGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlGrid.Controls.Add(this.pnlPaginacion);
            this.pnlGrid.Controls.Add(this.dgvData);
            this.pnlGrid.Location = new System.Drawing.Point(0, 174);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(1424, 687);
            this.pnlGrid.TabIndex = 1;
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
            this.pnlPaginacion.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlPaginacion.Location = new System.Drawing.Point(0, 627);
            this.pnlPaginacion.Name = "pnlPaginacion";
            this.pnlPaginacion.Size = new System.Drawing.Size(1424, 60);
            this.pnlPaginacion.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(24, 17);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(141, 25);
            this.label10.TabIndex = 27;
            this.label10.Text = "Tamaño página";
            // 
            // cmbPageSize
            // 
            this.cmbPageSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPageSize.FormattingEnabled = true;
            this.cmbPageSize.Location = new System.Drawing.Point(171, 14);
            this.cmbPageSize.Name = "cmbPageSize";
            this.cmbPageSize.Size = new System.Drawing.Size(121, 33);
            this.cmbPageSize.TabIndex = 17;
            // 
            // btnPrimera
            // 
            this.btnPrimera.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnPrimera.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPrimera.BackgroundImage")));
            this.btnPrimera.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPrimera.Location = new System.Drawing.Point(509, 2);
            this.btnPrimera.Name = "btnPrimera";
            this.btnPrimera.Size = new System.Drawing.Size(54, 54);
            this.btnPrimera.TabIndex = 16;
            this.toolTippper.SetToolTip(this.btnPrimera, "Buscar");
            this.btnPrimera.UseVisualStyleBackColor = true;
            this.btnPrimera.Click += new System.EventHandler(this.btnPrimera_Click);
            // 
            // btnAnterior
            // 
            this.btnAnterior.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnAnterior.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAnterior.BackgroundImage")));
            this.btnAnterior.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAnterior.Location = new System.Drawing.Point(578, 2);
            this.btnAnterior.Name = "btnAnterior";
            this.btnAnterior.Size = new System.Drawing.Size(54, 54);
            this.btnAnterior.TabIndex = 15;
            this.toolTippper.SetToolTip(this.btnAnterior, "Buscar");
            this.btnAnterior.UseVisualStyleBackColor = true;
            this.btnAnterior.Click += new System.EventHandler(this.btnAnterior_Click);
            // 
            // btnUltima
            // 
            this.btnUltima.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnUltima.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnUltima.BackgroundImage")));
            this.btnUltima.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnUltima.Location = new System.Drawing.Point(860, 2);
            this.btnUltima.Name = "btnUltima";
            this.btnUltima.Size = new System.Drawing.Size(54, 54);
            this.btnUltima.TabIndex = 14;
            this.toolTippper.SetToolTip(this.btnUltima, "Buscar");
            this.btnUltima.UseVisualStyleBackColor = true;
            this.btnUltima.Click += new System.EventHandler(this.btnUltima_Click);
            // 
            // btnSiguiente
            // 
            this.btnSiguiente.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnSiguiente.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSiguiente.BackgroundImage")));
            this.btnSiguiente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSiguiente.Location = new System.Drawing.Point(791, 2);
            this.btnSiguiente.Name = "btnSiguiente";
            this.btnSiguiente.Size = new System.Drawing.Size(54, 54);
            this.btnSiguiente.TabIndex = 13;
            this.toolTippper.SetToolTip(this.btnSiguiente, "Buscar");
            this.btnSiguiente.UseVisualStyleBackColor = true;
            this.btnSiguiente.Click += new System.EventHandler(this.btnSiguiente_Click);
            // 
            // lblPagina
            // 
            this.lblPagina.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblPagina.AutoSize = true;
            this.lblPagina.Location = new System.Drawing.Point(649, 15);
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
            this.dgvData.Location = new System.Drawing.Point(0, 0);
            this.dgvData.MultiSelect = false;
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(1424, 627);
            this.dgvData.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(234, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Matrícula";
            // 
            // txtMatricula
            // 
            this.txtMatricula.Location = new System.Drawing.Point(332, 76);
            this.txtMatricula.MaxLength = 10;
            this.txtMatricula.Name = "txtMatricula";
            this.txtMatricula.Size = new System.Drawing.Size(105, 32);
            this.txtMatricula.TabIndex = 3;
            // 
            // cmbTipoOperacion
            // 
            this.cmbTipoOperacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoOperacion.FormattingEnabled = true;
            this.cmbTipoOperacion.Location = new System.Drawing.Point(112, 122);
            this.cmbTipoOperacion.Name = "cmbTipoOperacion";
            this.cmbTipoOperacion.Size = new System.Drawing.Size(134, 33);
            this.cmbTipoOperacion.TabIndex = 21;
            this.toolTippper.SetToolTip(this.cmbTipoOperacion, "Tipo de operación");
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.CustomFormat = "";
            this.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaInicio.Location = new System.Drawing.Point(389, 122);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.ShowCheckBox = true;
            this.dtpFechaInicio.Size = new System.Drawing.Size(149, 32);
            this.dtpFechaInicio.TabIndex = 23;
            this.toolTippper.SetToolTip(this.dtpFechaInicio, "Fecha de entrada");
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.CustomFormat = "";
            this.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFin.Location = new System.Drawing.Point(665, 123);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.ShowCheckBox = true;
            this.dtpFechaFin.Size = new System.Drawing.Size(149, 32);
            this.dtpFechaFin.TabIndex = 25;
            this.toolTippper.SetToolTip(this.dtpFechaFin, "Fecha de entrada");
            // 
            // btnCerrarDetalle
            // 
            this.btnCerrarDetalle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrarDetalle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCerrarDetalle.Location = new System.Drawing.Point(1055, 3);
            this.btnCerrarDetalle.Name = "btnCerrarDetalle";
            this.btnCerrarDetalle.Size = new System.Drawing.Size(54, 54);
            this.btnCerrarDetalle.TabIndex = 15;
            this.toolTippper.SetToolTip(this.btnCerrarDetalle, "Cerrar");
            this.btnCerrarDetalle.UseVisualStyleBackColor = true;
            this.btnCerrarDetalle.Click += new System.EventHandler(this.btnCerrarDetalle_Click);
            // 
            // txtRemolque
            // 
            this.txtRemolque.Location = new System.Drawing.Point(554, 76);
            this.txtRemolque.MaxLength = 10;
            this.txtRemolque.Name = "txtRemolque";
            this.txtRemolque.Size = new System.Drawing.Size(105, 32);
            this.txtRemolque.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(452, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 25);
            this.label2.TabIndex = 9;
            this.label2.Text = "Remolque";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(718, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 25);
            this.label3.TabIndex = 11;
            this.label3.Text = "Conductor";
            // 
            // txtConductor
            // 
            this.txtConductor.Location = new System.Drawing.Point(825, 76);
            this.txtConductor.MaxLength = 255;
            this.txtConductor.Name = "txtConductor";
            this.txtConductor.Size = new System.Drawing.Size(243, 32);
            this.txtConductor.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1079, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 25);
            this.label4.TabIndex = 13;
            this.label4.Text = "Empresa";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(895, 125);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(127, 25);
            this.label5.TabIndex = 14;
            this.label5.Text = "Tipo de carga";
            // 
            // txtEmpresa
            // 
            this.txtEmpresa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEmpresa.Location = new System.Drawing.Point(1169, 76);
            this.txtEmpresa.MaxLength = 255;
            this.txtEmpresa.Name = "txtEmpresa";
            this.txtEmpresa.Size = new System.Drawing.Size(243, 32);
            this.txtEmpresa.TabIndex = 18;
            // 
            // txtTipoCarga
            // 
            this.txtTipoCarga.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTipoCarga.Location = new System.Drawing.Point(1028, 122);
            this.txtTipoCarga.MaxLength = 255;
            this.txtTipoCarga.Name = "txtTipoCarga";
            this.txtTipoCarga.Size = new System.Drawing.Size(384, 32);
            this.txtTipoCarga.TabIndex = 19;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(57, 126);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 25);
            this.label6.TabIndex = 20;
            this.label6.Text = "Tipo";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(273, 126);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(112, 25);
            this.label7.TabIndex = 22;
            this.label7.Text = "Fecha inicio";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(571, 127);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 25);
            this.label8.TabIndex = 24;
            this.label8.Text = "Fecha fin";
            // 
            // txtNumero
            // 
            this.txtNumero.Location = new System.Drawing.Point(112, 76);
            this.txtNumero.MaxLength = 10;
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(86, 32);
            this.txtNumero.TabIndex = 27;
            this.txtNumero.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumero_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(25, 79);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(81, 25);
            this.label9.TabIndex = 26;
            this.label9.Text = "Número";
            // 
            // pnlFormulario
            // 
            this.pnlFormulario.Controls.Add(this.grbCamarasSalida);
            this.pnlFormulario.Controls.Add(this.grbCamarasEntrada);
            this.pnlFormulario.Controls.Add(this.pnlBotoneraDetalle);
            this.pnlFormulario.Location = new System.Drawing.Point(57, 154);
            this.pnlFormulario.Name = "pnlFormulario";
            this.pnlFormulario.Size = new System.Drawing.Size(1127, 605);
            this.pnlFormulario.TabIndex = 28;
            this.pnlFormulario.Visible = false;
            // 
            // grbCamarasSalida
            // 
            this.grbCamarasSalida.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbCamarasSalida.Controls.Add(this.picCamara3Salida);
            this.grbCamarasSalida.Controls.Add(this.picCamara2Salida);
            this.grbCamarasSalida.Controls.Add(this.picCamara1Salida);
            this.grbCamarasSalida.Location = new System.Drawing.Point(10, 336);
            this.grbCamarasSalida.Name = "grbCamarasSalida";
            this.grbCamarasSalida.Size = new System.Drawing.Size(1106, 258);
            this.grbCamarasSalida.TabIndex = 16;
            this.grbCamarasSalida.TabStop = false;
            this.grbCamarasSalida.Text = "Salida";
            // 
            // picCamara3Salida
            // 
            this.picCamara3Salida.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picCamara3Salida.Location = new System.Drawing.Point(737, 39);
            this.picCamara3Salida.Name = "picCamara3Salida";
            this.picCamara3Salida.Size = new System.Drawing.Size(360, 205);
            this.picCamara3Salida.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picCamara3Salida.TabIndex = 2;
            this.picCamara3Salida.TabStop = false;
            this.picCamara3Salida.Click += new System.EventHandler(this.picCamara3Salida_Click);
            // 
            // picCamara2Salida
            // 
            this.picCamara2Salida.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.picCamara2Salida.Location = new System.Drawing.Point(371, 39);
            this.picCamara2Salida.Name = "picCamara2Salida";
            this.picCamara2Salida.Size = new System.Drawing.Size(360, 205);
            this.picCamara2Salida.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picCamara2Salida.TabIndex = 1;
            this.picCamara2Salida.TabStop = false;
            this.picCamara2Salida.Click += new System.EventHandler(this.picCamara2Salida_Click);
            // 
            // picCamara1Salida
            // 
            this.picCamara1Salida.Location = new System.Drawing.Point(5, 39);
            this.picCamara1Salida.Name = "picCamara1Salida";
            this.picCamara1Salida.Size = new System.Drawing.Size(360, 205);
            this.picCamara1Salida.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picCamara1Salida.TabIndex = 0;
            this.picCamara1Salida.TabStop = false;
            this.picCamara1Salida.Click += new System.EventHandler(this.picCamara1Salida_Click);
            // 
            // grbCamarasEntrada
            // 
            this.grbCamarasEntrada.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbCamarasEntrada.Controls.Add(this.picCamara3Entrada);
            this.grbCamarasEntrada.Controls.Add(this.picCamara2Entrada);
            this.grbCamarasEntrada.Controls.Add(this.picCamara1Entrada);
            this.grbCamarasEntrada.Location = new System.Drawing.Point(10, 66);
            this.grbCamarasEntrada.Name = "grbCamarasEntrada";
            this.grbCamarasEntrada.Size = new System.Drawing.Size(1106, 264);
            this.grbCamarasEntrada.TabIndex = 15;
            this.grbCamarasEntrada.TabStop = false;
            this.grbCamarasEntrada.Text = "Entrada";
            // 
            // picCamara3Entrada
            // 
            this.picCamara3Entrada.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picCamara3Entrada.Location = new System.Drawing.Point(737, 39);
            this.picCamara3Entrada.Name = "picCamara3Entrada";
            this.picCamara3Entrada.Size = new System.Drawing.Size(360, 205);
            this.picCamara3Entrada.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picCamara3Entrada.TabIndex = 2;
            this.picCamara3Entrada.TabStop = false;
            this.picCamara3Entrada.Click += new System.EventHandler(this.picCamara3Entrada_Click);
            // 
            // picCamara2Entrada
            // 
            this.picCamara2Entrada.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.picCamara2Entrada.Location = new System.Drawing.Point(371, 39);
            this.picCamara2Entrada.Name = "picCamara2Entrada";
            this.picCamara2Entrada.Size = new System.Drawing.Size(360, 205);
            this.picCamara2Entrada.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picCamara2Entrada.TabIndex = 1;
            this.picCamara2Entrada.TabStop = false;
            this.picCamara2Entrada.Click += new System.EventHandler(this.picCamara2Entrada_Click);
            // 
            // picCamara1Entrada
            // 
            this.picCamara1Entrada.Location = new System.Drawing.Point(5, 39);
            this.picCamara1Entrada.Name = "picCamara1Entrada";
            this.picCamara1Entrada.Size = new System.Drawing.Size(360, 205);
            this.picCamara1Entrada.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picCamara1Entrada.TabIndex = 0;
            this.picCamara1Entrada.TabStop = false;
            this.picCamara1Entrada.Click += new System.EventHandler(this.picCamara1Entrada_Click);
            // 
            // pnlBotoneraDetalle
            // 
            this.pnlBotoneraDetalle.Controls.Add(this.btnCerrarDetalle);
            this.pnlBotoneraDetalle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBotoneraDetalle.Location = new System.Drawing.Point(0, 0);
            this.pnlBotoneraDetalle.Name = "pnlBotoneraDetalle";
            this.pnlBotoneraDetalle.Size = new System.Drawing.Size(1127, 60);
            this.pnlBotoneraDetalle.TabIndex = 0;
            // 
            // frmOperaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCerrar;
            this.ClientSize = new System.Drawing.Size(1424, 861);
            this.Controls.Add(this.pnlFormulario);
            this.Controls.Add(this.txtNumero);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.dtpFechaFin);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dtpFechaInicio);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmbTipoOperacion);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtTipoCarga);
            this.Controls.Add(this.txtEmpresa);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtConductor);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtRemolque);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMatricula);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MinimizeBox = false;
            this.Name = "frmOperaciones";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestión de operaciones";
            this.Load += new System.EventHandler(this.frmOperaciones_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlGrid.ResumeLayout(false);
            this.pnlPaginacion.ResumeLayout(false);
            this.pnlPaginacion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.pnlFormulario.ResumeLayout(false);
            this.grbCamarasSalida.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picCamara3Salida)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCamara2Salida)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCamara1Salida)).EndInit();
            this.grbCamarasEntrada.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picCamara3Entrada)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCamara2Entrada)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCamara1Entrada)).EndInit();
            this.pnlBotoneraDetalle.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMatricula;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.ToolTip toolTippper;
        private System.Windows.Forms.TextBox txtRemolque;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtConductor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtEmpresa;
        private System.Windows.Forms.TextBox txtTipoCarga;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbTipoOperacion;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtpFechaInicio;
        private System.Windows.Forms.DateTimePicker dtpFechaFin;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel pnlPaginacion;
        private System.Windows.Forms.Button btnPrimera;
        private System.Windows.Forms.Button btnAnterior;
        private System.Windows.Forms.Button btnUltima;
        private System.Windows.Forms.Button btnSiguiente;
        private System.Windows.Forms.Label lblPagina;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnImprimirAlbaran;
        private System.Windows.Forms.Button btnGuardarAlbaran;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbPageSize;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Panel pnlFormulario;
        private System.Windows.Forms.Panel pnlBotoneraDetalle;
        private System.Windows.Forms.Button btnCerrarDetalle;
        private System.Windows.Forms.GroupBox grbCamarasEntrada;
        private System.Windows.Forms.PictureBox picCamara3Entrada;
        private System.Windows.Forms.PictureBox picCamara2Entrada;
        private System.Windows.Forms.PictureBox picCamara1Entrada;
        private System.Windows.Forms.GroupBox grbCamarasSalida;
        private System.Windows.Forms.PictureBox picCamara3Salida;
        private System.Windows.Forms.PictureBox picCamara2Salida;
        private System.Windows.Forms.PictureBox picCamara1Salida;
        private System.Windows.Forms.Button btnEnviarAlbaran;
    }
}