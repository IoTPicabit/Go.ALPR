
namespace Go.ALPR.Sri.WinForms
{
    partial class frmTipoCargas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTipoCargas));
            this.pnlTop = new System.Windows.Forms.Panel();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
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
            this.txtNombreFiltro = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCodigoLerFiltro = new System.Windows.Forms.TextBox();
            this.toolTippper = new System.Windows.Forms.ToolTip(this.components);
            this.cmbTipoOperacion = new System.Windows.Forms.ComboBox();
            this.btnCerrarFormulario = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDenominacionADRFiltro = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.pnlFormulario = new System.Windows.Forms.Panel();
            this.cmbEmpresaExpedicion = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbTipoCargaPadre = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rdbDescarga = new System.Windows.Forms.RadioButton();
            this.rdbCarga = new System.Windows.Forms.RadioButton();
            this.txtDenominacionAdr = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCodigoLer = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlBotoneraFormulario = new System.Windows.Forms.Panel();
            this.pnlTop.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            this.pnlPaginacion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.pnlFormulario.SuspendLayout();
            this.panel1.SuspendLayout();
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
            this.btnLimpiar.Location = new System.Drawing.Point(86, 3);
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
            this.btnBuscar.Location = new System.Drawing.Point(17, 3);
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
            this.btnNuevo.Location = new System.Drawing.Point(180, 3);
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
            this.btnEliminar.Location = new System.Drawing.Point(300, 3);
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
            this.btnEditar.Location = new System.Drawing.Point(240, 3);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(54, 54);
            this.btnEditar.TabIndex = 10;
            this.toolTippper.SetToolTip(this.btnEditar, "Editar");
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCerrar.Location = new System.Drawing.Point(935, 3);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(54, 54);
            this.btnCerrar.TabIndex = 14;
            this.toolTippper.SetToolTip(this.btnCerrar, "Cerrar");
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // pnlGrid
            // 
            this.pnlGrid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlGrid.Controls.Add(this.pnlPaginacion);
            this.pnlGrid.Controls.Add(this.dgvData);
            this.pnlGrid.Location = new System.Drawing.Point(0, 164);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(1008, 397);
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
            this.pnlPaginacion.Location = new System.Drawing.Point(0, 337);
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
            this.dgvData.Size = new System.Drawing.Size(1008, 337);
            this.dgvData.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nombre";
            // 
            // txtNombreFiltro
            // 
            this.txtNombreFiltro.Location = new System.Drawing.Point(126, 76);
            this.txtNombreFiltro.MaxLength = 255;
            this.txtNombreFiltro.Name = "txtNombreFiltro";
            this.txtNombreFiltro.Size = new System.Drawing.Size(654, 32);
            this.txtNombreFiltro.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 25);
            this.label3.TabIndex = 4;
            this.label3.Text = "Código LER";
            // 
            // txtCodigoLerFiltro
            // 
            this.txtCodigoLerFiltro.Location = new System.Drawing.Point(126, 115);
            this.txtCodigoLerFiltro.MaxLength = 7;
            this.txtCodigoLerFiltro.Name = "txtCodigoLerFiltro";
            this.txtCodigoLerFiltro.Size = new System.Drawing.Size(105, 32);
            this.txtCodigoLerFiltro.TabIndex = 5;
            // 
            // cmbTipoOperacion
            // 
            this.cmbTipoOperacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoOperacion.FormattingEnabled = true;
            this.cmbTipoOperacion.Location = new System.Drawing.Point(855, 76);
            this.cmbTipoOperacion.Name = "cmbTipoOperacion";
            this.cmbTipoOperacion.Size = new System.Drawing.Size(134, 33);
            this.cmbTipoOperacion.TabIndex = 25;
            this.toolTippper.SetToolTip(this.cmbTipoOperacion, "Tipo de operación");
            // 
            // btnCerrarFormulario
            // 
            this.btnCerrarFormulario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrarFormulario.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCerrarFormulario.Location = new System.Drawing.Point(935, 4);
            this.btnCerrarFormulario.Name = "btnCerrarFormulario";
            this.btnCerrarFormulario.Size = new System.Drawing.Size(54, 54);
            this.btnCerrarFormulario.TabIndex = 15;
            this.toolTippper.SetToolTip(this.btnCerrarFormulario, "Cancelar");
            this.btnCerrarFormulario.UseVisualStyleBackColor = true;
            this.btnCerrarFormulario.Click += new System.EventHandler(this.btnCerrarFormulario_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGuardar.Location = new System.Drawing.Point(17, 4);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(54, 54);
            this.btnGuardar.TabIndex = 16;
            this.toolTippper.SetToolTip(this.btnGuardar, "Guardar");
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(800, 80);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 25);
            this.label6.TabIndex = 24;
            this.label6.Text = "Tipo";
            // 
            // txtDenominacionADRFiltro
            // 
            this.txtDenominacionADRFiltro.Location = new System.Drawing.Point(474, 115);
            this.txtDenominacionADRFiltro.Name = "txtDenominacionADRFiltro";
            this.txtDenominacionADRFiltro.Size = new System.Drawing.Size(515, 32);
            this.txtDenominacionADRFiltro.TabIndex = 30;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(280, 118);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(176, 25);
            this.label7.TabIndex = 29;
            this.label7.Text = "Denominación ADR";
            // 
            // pnlFormulario
            // 
            this.pnlFormulario.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlFormulario.Controls.Add(this.cmbEmpresaExpedicion);
            this.pnlFormulario.Controls.Add(this.label9);
            this.pnlFormulario.Controls.Add(this.cmbTipoCargaPadre);
            this.pnlFormulario.Controls.Add(this.label4);
            this.pnlFormulario.Controls.Add(this.panel1);
            this.pnlFormulario.Controls.Add(this.txtDenominacionAdr);
            this.pnlFormulario.Controls.Add(this.label5);
            this.pnlFormulario.Controls.Add(this.txtCodigoLer);
            this.pnlFormulario.Controls.Add(this.label8);
            this.pnlFormulario.Controls.Add(this.txtNombre);
            this.pnlFormulario.Controls.Add(this.label2);
            this.pnlFormulario.Controls.Add(this.pnlBotoneraFormulario);
            this.pnlFormulario.Location = new System.Drawing.Point(0, 146);
            this.pnlFormulario.Name = "pnlFormulario";
            this.pnlFormulario.Size = new System.Drawing.Size(1008, 287);
            this.pnlFormulario.TabIndex = 31;
            this.pnlFormulario.Visible = false;
            // 
            // cmbEmpresaExpedicion
            // 
            this.cmbEmpresaExpedicion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEmpresaExpedicion.FormattingEnabled = true;
            this.cmbEmpresaExpedicion.Location = new System.Drawing.Point(536, 231);
            this.cmbEmpresaExpedicion.Name = "cmbEmpresaExpedicion";
            this.cmbEmpresaExpedicion.Size = new System.Drawing.Size(460, 33);
            this.cmbEmpresaExpedicion.TabIndex = 21;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(349, 234);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(181, 25);
            this.label9.TabIndex = 20;
            this.label9.Text = "Empresa expedición";
            // 
            // cmbTipoCargaPadre
            // 
            this.cmbTipoCargaPadre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoCargaPadre.FormattingEnabled = true;
            this.cmbTipoCargaPadre.Location = new System.Drawing.Point(172, 171);
            this.cmbTipoCargaPadre.Name = "cmbTipoCargaPadre";
            this.cmbTipoCargaPadre.Size = new System.Drawing.Size(824, 33);
            this.cmbTipoCargaPadre.TabIndex = 19;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 174);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(147, 25);
            this.label4.TabIndex = 18;
            this.label4.Text = "Subproducto de";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rdbDescarga);
            this.panel1.Controls.Add(this.rdbCarga);
            this.panel1.Location = new System.Drawing.Point(14, 222);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(312, 48);
            this.panel1.TabIndex = 17;
            // 
            // rdbDescarga
            // 
            this.rdbDescarga.AutoSize = true;
            this.rdbDescarga.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rdbDescarga.Location = new System.Drawing.Point(166, 10);
            this.rdbDescarga.Name = "rdbDescarga";
            this.rdbDescarga.Size = new System.Drawing.Size(108, 29);
            this.rdbDescarga.TabIndex = 1;
            this.rdbDescarga.TabStop = true;
            this.rdbDescarga.Text = "Descarga";
            this.rdbDescarga.UseVisualStyleBackColor = true;
            // 
            // rdbCarga
            // 
            this.rdbCarga.AutoSize = true;
            this.rdbCarga.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rdbCarga.Checked = true;
            this.rdbCarga.Location = new System.Drawing.Point(17, 10);
            this.rdbCarga.Name = "rdbCarga";
            this.rdbCarga.Size = new System.Drawing.Size(80, 29);
            this.rdbCarga.TabIndex = 0;
            this.rdbCarga.TabStop = true;
            this.rdbCarga.Text = "Carga";
            this.rdbCarga.UseVisualStyleBackColor = true;
            // 
            // txtDenominacionAdr
            // 
            this.txtDenominacionAdr.Location = new System.Drawing.Point(435, 122);
            this.txtDenominacionAdr.MaxLength = 255;
            this.txtDenominacionAdr.Name = "txtDenominacionAdr";
            this.txtDenominacionAdr.Size = new System.Drawing.Size(561, 32);
            this.txtDenominacionAdr.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(253, 125);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(176, 25);
            this.label5.TabIndex = 15;
            this.label5.Text = "Denominación ADR";
            // 
            // txtCodigoLer
            // 
            this.txtCodigoLer.Location = new System.Drawing.Point(126, 122);
            this.txtCodigoLer.MaxLength = 7;
            this.txtCodigoLer.Name = "txtCodigoLer";
            this.txtCodigoLer.Size = new System.Drawing.Size(105, 32);
            this.txtCodigoLer.TabIndex = 12;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 125);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(108, 25);
            this.label8.TabIndex = 11;
            this.label8.Text = "Código LER";
            // 
            // txtNombre
            // 
            this.txtNombre.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNombre.Location = new System.Drawing.Point(126, 75);
            this.txtNombre.MaxLength = 255;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(870, 32);
            this.txtNombre.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nombre";
            // 
            // pnlBotoneraFormulario
            // 
            this.pnlBotoneraFormulario.Controls.Add(this.btnGuardar);
            this.pnlBotoneraFormulario.Controls.Add(this.btnCerrarFormulario);
            this.pnlBotoneraFormulario.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBotoneraFormulario.Location = new System.Drawing.Point(0, 0);
            this.pnlBotoneraFormulario.Name = "pnlBotoneraFormulario";
            this.pnlBotoneraFormulario.Size = new System.Drawing.Size(1008, 60);
            this.pnlBotoneraFormulario.TabIndex = 0;
            // 
            // frmTipoCargas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCerrar;
            this.ClientSize = new System.Drawing.Size(1008, 561);
            this.ControlBox = false;
            this.Controls.Add(this.pnlFormulario);
            this.Controls.Add(this.txtDenominacionADRFiltro);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbTipoOperacion);
            this.Controls.Add(this.txtCodigoLerFiltro);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNombreFiltro);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmTipoCargas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestión de tipo de cargas";
            this.Load += new System.EventHandler(this.frmTipoCargas_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlGrid.ResumeLayout(false);
            this.pnlPaginacion.ResumeLayout(false);
            this.pnlPaginacion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.pnlFormulario.ResumeLayout(false);
            this.pnlFormulario.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
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
        private System.Windows.Forms.TextBox txtNombreFiltro;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCodigoLerFiltro;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.ToolTip toolTippper;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbTipoOperacion;
        private System.Windows.Forms.TextBox txtDenominacionADRFiltro;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel pnlFormulario;
        private System.Windows.Forms.TextBox txtDenominacionAdr;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCodigoLer;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnlBotoneraFormulario;
        private System.Windows.Forms.Button btnCerrarFormulario;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rdbDescarga;
        private System.Windows.Forms.RadioButton rdbCarga;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Panel pnlPaginacion;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmbPageSize;
        private System.Windows.Forms.Button btnPrimera;
        private System.Windows.Forms.Button btnAnterior;
        private System.Windows.Forms.Button btnUltima;
        private System.Windows.Forms.Button btnSiguiente;
        private System.Windows.Forms.Label lblPagina;
        private System.Windows.Forms.ComboBox cmbTipoCargaPadre;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbEmpresaExpedicion;
        private System.Windows.Forms.Label label9;
    }
}