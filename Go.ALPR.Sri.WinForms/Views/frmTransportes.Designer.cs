
namespace Go.ALPR.Sri.WinForms
{
    partial class frmTransportes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTransportes));
            this.pnlTop = new System.Windows.Forms.Panel();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
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
            this.txtMatriculaFiltro = new System.Windows.Forms.TextBox();
            this.toolTippper = new System.Windows.Forms.ToolTip(this.components);
            this.btnCerrarFormulario = new System.Windows.Forms.Button();
            this.cmbTipoOperacionFiltro = new System.Windows.Forms.ComboBox();
            this.txtRemolqueFiltro = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtConductorFiltro = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pnlFormulario = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rdbDescarga = new System.Windows.Forms.RadioButton();
            this.rdbCarga = new System.Windows.Forms.RadioButton();
            this.cmbTipoCarga = new System.Windows.Forms.ComboBox();
            this.cmbEmpresa = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtConductor = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtRemolque = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtMatricula = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.pnlBotoneraFormulario = new System.Windows.Forms.Panel();
            this.txtEmpresaFiltro = new System.Windows.Forms.TextBox();
            this.txtTipoCargaFiltro = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.pnlTop.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            this.pnlPaginacion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.pnlFormulario.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pnlBotoneraFormulario.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.btnLimpiar);
            this.pnlTop.Controls.Add(this.btnBuscar);
            this.pnlTop.Controls.Add(this.btnNuevo);
            this.pnlTop.Controls.Add(this.btnEliminar);
            this.pnlTop.Controls.Add(this.btnEditar);
            this.pnlTop.Controls.Add(this.btnCerrar);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1008, 60);
            this.pnlTop.TabIndex = 8;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnLimpiar.BackgroundImage")));
            this.btnLimpiar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLimpiar.Location = new System.Drawing.Point(85, 3);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(54, 54);
            this.btnLimpiar.TabIndex = 21;
            this.toolTippper.SetToolTip(this.btnLimpiar, "Limpiar filtro");
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBuscar.BackgroundImage")));
            this.btnBuscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBuscar.Location = new System.Drawing.Point(16, 3);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(54, 54);
            this.btnBuscar.TabIndex = 20;
            this.toolTippper.SetToolTip(this.btnBuscar, "Buscar");
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnNuevo.Location = new System.Drawing.Point(190, 3);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(54, 54);
            this.btnNuevo.TabIndex = 9;
            this.toolTippper.SetToolTip(this.btnNuevo, "Nuevo");
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEliminar.Location = new System.Drawing.Point(310, 3);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(54, 54);
            this.btnEliminar.TabIndex = 11;
            this.toolTippper.SetToolTip(this.btnEliminar, "Eliminar");
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEditar.Location = new System.Drawing.Point(250, 3);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(54, 54);
            this.btnEditar.TabIndex = 10;
            this.toolTippper.SetToolTip(this.btnEditar, "Editar");
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCerrar.Location = new System.Drawing.Point(942, 3);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(54, 54);
            this.btnCerrar.TabIndex = 14;
            this.toolTippper.SetToolTip(this.btnCerrar, "Cerrar");
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGuardar.Location = new System.Drawing.Point(12, 3);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(54, 54);
            this.btnGuardar.TabIndex = 13;
            this.toolTippper.SetToolTip(this.btnGuardar, "Guardar");
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // pnlGrid
            // 
            this.pnlGrid.Controls.Add(this.pnlPaginacion);
            this.pnlGrid.Controls.Add(this.dgvData);
            this.pnlGrid.Location = new System.Drawing.Point(0, 209);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(1008, 520);
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
            this.pnlPaginacion.Location = new System.Drawing.Point(0, 460);
            this.pnlPaginacion.Name = "pnlPaginacion";
            this.pnlPaginacion.Size = new System.Drawing.Size(1008, 60);
            this.pnlPaginacion.TabIndex = 12;
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
            this.btnPrimera.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPrimera.BackgroundImage")));
            this.btnPrimera.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPrimera.Location = new System.Drawing.Point(360, 2);
            this.btnPrimera.Name = "btnPrimera";
            this.btnPrimera.Size = new System.Drawing.Size(54, 54);
            this.btnPrimera.TabIndex = 16;
            this.toolTippper.SetToolTip(this.btnPrimera, "Buscar");
            this.btnPrimera.UseVisualStyleBackColor = true;
            this.btnPrimera.Click += new System.EventHandler(this.btnPrimera_Click);
            // 
            // btnAnterior
            // 
            this.btnAnterior.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAnterior.BackgroundImage")));
            this.btnAnterior.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAnterior.Location = new System.Drawing.Point(429, 2);
            this.btnAnterior.Name = "btnAnterior";
            this.btnAnterior.Size = new System.Drawing.Size(54, 54);
            this.btnAnterior.TabIndex = 15;
            this.toolTippper.SetToolTip(this.btnAnterior, "Buscar");
            this.btnAnterior.UseVisualStyleBackColor = true;
            this.btnAnterior.Click += new System.EventHandler(this.btnAnterior_Click);
            // 
            // btnUltima
            // 
            this.btnUltima.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnUltima.BackgroundImage")));
            this.btnUltima.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnUltima.Location = new System.Drawing.Point(711, 2);
            this.btnUltima.Name = "btnUltima";
            this.btnUltima.Size = new System.Drawing.Size(54, 54);
            this.btnUltima.TabIndex = 14;
            this.toolTippper.SetToolTip(this.btnUltima, "Buscar");
            this.btnUltima.UseVisualStyleBackColor = true;
            this.btnUltima.Click += new System.EventHandler(this.btnUltima_Click);
            // 
            // btnSiguiente
            // 
            this.btnSiguiente.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSiguiente.BackgroundImage")));
            this.btnSiguiente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSiguiente.Location = new System.Drawing.Point(642, 2);
            this.btnSiguiente.Name = "btnSiguiente";
            this.btnSiguiente.Size = new System.Drawing.Size(54, 54);
            this.btnSiguiente.TabIndex = 13;
            this.toolTippper.SetToolTip(this.btnSiguiente, "Buscar");
            this.btnSiguiente.UseVisualStyleBackColor = true;
            this.btnSiguiente.Click += new System.EventHandler(this.btnSiguiente_Click);
            // 
            // lblPagina
            // 
            this.lblPagina.AutoSize = true;
            this.lblPagina.Location = new System.Drawing.Point(500, 15);
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
            this.dgvData.Size = new System.Drawing.Size(1008, 460);
            this.dgvData.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Matrícula";
            // 
            // txtMatriculaFiltro
            // 
            this.txtMatriculaFiltro.Location = new System.Drawing.Point(112, 76);
            this.txtMatriculaFiltro.MaxLength = 10;
            this.txtMatriculaFiltro.Name = "txtMatriculaFiltro";
            this.txtMatriculaFiltro.Size = new System.Drawing.Size(134, 32);
            this.txtMatriculaFiltro.TabIndex = 3;
            // 
            // btnCerrarFormulario
            // 
            this.btnCerrarFormulario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrarFormulario.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCerrarFormulario.Location = new System.Drawing.Point(942, 3);
            this.btnCerrarFormulario.Name = "btnCerrarFormulario";
            this.btnCerrarFormulario.Size = new System.Drawing.Size(54, 54);
            this.btnCerrarFormulario.TabIndex = 15;
            this.toolTippper.SetToolTip(this.btnCerrarFormulario, "Cancelar");
            this.btnCerrarFormulario.UseVisualStyleBackColor = true;
            this.btnCerrarFormulario.Click += new System.EventHandler(this.btnCerrarFormulario_Click);
            // 
            // cmbTipoOperacionFiltro
            // 
            this.cmbTipoOperacionFiltro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoOperacionFiltro.FormattingEnabled = true;
            this.cmbTipoOperacionFiltro.Location = new System.Drawing.Point(655, 170);
            this.cmbTipoOperacionFiltro.Name = "cmbTipoOperacionFiltro";
            this.cmbTipoOperacionFiltro.Size = new System.Drawing.Size(134, 33);
            this.cmbTipoOperacionFiltro.TabIndex = 25;
            this.toolTippper.SetToolTip(this.cmbTipoOperacionFiltro, "Tipo de operación");
            // 
            // txtRemolqueFiltro
            // 
            this.txtRemolqueFiltro.Location = new System.Drawing.Point(366, 76);
            this.txtRemolqueFiltro.MaxLength = 10;
            this.txtRemolqueFiltro.Name = "txtRemolqueFiltro";
            this.txtRemolqueFiltro.Size = new System.Drawing.Size(134, 32);
            this.txtRemolqueFiltro.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(268, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 25);
            this.label2.TabIndex = 9;
            this.label2.Text = "Remolque";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(548, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 25);
            this.label3.TabIndex = 11;
            this.label3.Text = "Conductor";
            // 
            // txtConductorFiltro
            // 
            this.txtConductorFiltro.Location = new System.Drawing.Point(655, 76);
            this.txtConductorFiltro.MaxLength = 255;
            this.txtConductorFiltro.Name = "txtConductorFiltro";
            this.txtConductorFiltro.Size = new System.Drawing.Size(341, 32);
            this.txtConductorFiltro.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 125);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 25);
            this.label4.TabIndex = 13;
            this.label4.Text = "Empresa";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(522, 125);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(127, 25);
            this.label5.TabIndex = 14;
            this.label5.Text = "Tipo de carga";
            // 
            // pnlFormulario
            // 
            this.pnlFormulario.Controls.Add(this.panel2);
            this.pnlFormulario.Controls.Add(this.cmbTipoCarga);
            this.pnlFormulario.Controls.Add(this.cmbEmpresa);
            this.pnlFormulario.Controls.Add(this.label6);
            this.pnlFormulario.Controls.Add(this.label7);
            this.pnlFormulario.Controls.Add(this.txtConductor);
            this.pnlFormulario.Controls.Add(this.label8);
            this.pnlFormulario.Controls.Add(this.txtRemolque);
            this.pnlFormulario.Controls.Add(this.label9);
            this.pnlFormulario.Controls.Add(this.txtMatricula);
            this.pnlFormulario.Controls.Add(this.label11);
            this.pnlFormulario.Controls.Add(this.pnlBotoneraFormulario);
            this.pnlFormulario.Location = new System.Drawing.Point(0, 173);
            this.pnlFormulario.Name = "pnlFormulario";
            this.pnlFormulario.Size = new System.Drawing.Size(1008, 395);
            this.pnlFormulario.TabIndex = 18;
            this.pnlFormulario.Visible = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rdbDescarga);
            this.panel2.Controls.Add(this.rdbCarga);
            this.panel2.Location = new System.Drawing.Point(655, 163);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(341, 48);
            this.panel2.TabIndex = 28;
            // 
            // rdbDescarga
            // 
            this.rdbDescarga.AutoSize = true;
            this.rdbDescarga.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rdbDescarga.Location = new System.Drawing.Point(209, 10);
            this.rdbDescarga.Name = "rdbDescarga";
            this.rdbDescarga.Size = new System.Drawing.Size(108, 29);
            this.rdbDescarga.TabIndex = 1;
            this.rdbDescarga.TabStop = true;
            this.rdbDescarga.Text = "Descarga";
            this.rdbDescarga.UseVisualStyleBackColor = true;
            this.rdbDescarga.CheckedChanged += new System.EventHandler(this.TipoOperacion_CheckedChanged);
            // 
            // rdbCarga
            // 
            this.rdbCarga.AutoSize = true;
            this.rdbCarga.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rdbCarga.Checked = true;
            this.rdbCarga.Location = new System.Drawing.Point(23, 10);
            this.rdbCarga.Name = "rdbCarga";
            this.rdbCarga.Size = new System.Drawing.Size(80, 29);
            this.rdbCarga.TabIndex = 0;
            this.rdbCarga.TabStop = true;
            this.rdbCarga.Text = "Carga";
            this.rdbCarga.UseVisualStyleBackColor = true;
            this.rdbCarga.CheckedChanged += new System.EventHandler(this.TipoOperacion_CheckedChanged);
            // 
            // cmbTipoCarga
            // 
            this.cmbTipoCarga.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoCarga.FormattingEnabled = true;
            this.cmbTipoCarga.Location = new System.Drawing.Point(655, 130);
            this.cmbTipoCarga.Name = "cmbTipoCarga";
            this.cmbTipoCarga.Size = new System.Drawing.Size(341, 33);
            this.cmbTipoCarga.TabIndex = 27;
            // 
            // cmbEmpresa
            // 
            this.cmbEmpresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEmpresa.FormattingEnabled = true;
            this.cmbEmpresa.Location = new System.Drawing.Point(112, 130);
            this.cmbEmpresa.Name = "cmbEmpresa";
            this.cmbEmpresa.Size = new System.Drawing.Size(388, 33);
            this.cmbEmpresa.TabIndex = 26;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(506, 133);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(127, 25);
            this.label6.TabIndex = 25;
            this.label6.Text = "Tipo de carga";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 133);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 25);
            this.label7.TabIndex = 24;
            this.label7.Text = "Empresa";
            // 
            // txtConductor
            // 
            this.txtConductor.Location = new System.Drawing.Point(655, 84);
            this.txtConductor.MaxLength = 255;
            this.txtConductor.Name = "txtConductor";
            this.txtConductor.Size = new System.Drawing.Size(341, 32);
            this.txtConductor.TabIndex = 23;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(548, 87);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(101, 25);
            this.label8.TabIndex = 22;
            this.label8.Text = "Conductor";
            // 
            // txtRemolque
            // 
            this.txtRemolque.Location = new System.Drawing.Point(366, 84);
            this.txtRemolque.MaxLength = 10;
            this.txtRemolque.Name = "txtRemolque";
            this.txtRemolque.Size = new System.Drawing.Size(134, 32);
            this.txtRemolque.TabIndex = 21;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(268, 87);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(96, 25);
            this.label9.TabIndex = 20;
            this.label9.Text = "Remolque";
            // 
            // txtMatricula
            // 
            this.txtMatricula.Location = new System.Drawing.Point(112, 84);
            this.txtMatricula.MaxLength = 10;
            this.txtMatricula.Name = "txtMatricula";
            this.txtMatricula.Size = new System.Drawing.Size(134, 32);
            this.txtMatricula.TabIndex = 19;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(14, 87);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(92, 25);
            this.label11.TabIndex = 18;
            this.label11.Text = "Matrícula";
            // 
            // pnlBotoneraFormulario
            // 
            this.pnlBotoneraFormulario.Controls.Add(this.btnCerrarFormulario);
            this.pnlBotoneraFormulario.Controls.Add(this.btnGuardar);
            this.pnlBotoneraFormulario.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBotoneraFormulario.Location = new System.Drawing.Point(0, 0);
            this.pnlBotoneraFormulario.Name = "pnlBotoneraFormulario";
            this.pnlBotoneraFormulario.Size = new System.Drawing.Size(1008, 60);
            this.pnlBotoneraFormulario.TabIndex = 1;
            // 
            // txtEmpresaFiltro
            // 
            this.txtEmpresaFiltro.Location = new System.Drawing.Point(112, 123);
            this.txtEmpresaFiltro.Name = "txtEmpresaFiltro";
            this.txtEmpresaFiltro.Size = new System.Drawing.Size(388, 32);
            this.txtEmpresaFiltro.TabIndex = 19;
            // 
            // txtTipoCargaFiltro
            // 
            this.txtTipoCargaFiltro.Location = new System.Drawing.Point(655, 122);
            this.txtTipoCargaFiltro.Name = "txtTipoCargaFiltro";
            this.txtTipoCargaFiltro.Size = new System.Drawing.Size(341, 32);
            this.txtTipoCargaFiltro.TabIndex = 20;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(600, 173);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(49, 25);
            this.label12.TabIndex = 24;
            this.label12.Text = "Tipo";
            // 
            // frmTransportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCerrar;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.ControlBox = false;
            this.Controls.Add(this.pnlFormulario);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.cmbTipoOperacionFiltro);
            this.Controls.Add(this.txtTipoCargaFiltro);
            this.Controls.Add(this.txtEmpresaFiltro);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtConductorFiltro);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtRemolqueFiltro);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMatriculaFiltro);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmTransportes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestión de transportes";
            this.Load += new System.EventHandler(this.frmTransportes_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlGrid.ResumeLayout(false);
            this.pnlPaginacion.ResumeLayout(false);
            this.pnlPaginacion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.pnlFormulario.ResumeLayout(false);
            this.pnlFormulario.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.pnlBotoneraFormulario.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMatriculaFiltro;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.ToolTip toolTippper;
        private System.Windows.Forms.TextBox txtRemolqueFiltro;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtConductorFiltro;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel pnlPaginacion;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmbPageSize;
        private System.Windows.Forms.Button btnPrimera;
        private System.Windows.Forms.Button btnAnterior;
        private System.Windows.Forms.Button btnUltima;
        private System.Windows.Forms.Button btnSiguiente;
        private System.Windows.Forms.Label lblPagina;
        private System.Windows.Forms.Panel pnlFormulario;
        private System.Windows.Forms.Panel pnlBotoneraFormulario;
        private System.Windows.Forms.Button btnCerrarFormulario;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton rdbDescarga;
        private System.Windows.Forms.RadioButton rdbCarga;
        private System.Windows.Forms.ComboBox cmbTipoCarga;
        private System.Windows.Forms.ComboBox cmbEmpresa;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtConductor;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtRemolque;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtMatricula;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtEmpresaFiltro;
        private System.Windows.Forms.TextBox txtTipoCargaFiltro;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cmbTipoOperacionFiltro;
    }
}