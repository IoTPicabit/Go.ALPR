using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Go.ALPR.Sri.Business;
using Go.ALPR.Sri.PlcComm;

namespace Go.ALPR.Sri.Tests
{
    public partial class frmPLC : Form
    {
        private readonly IPLCService _plcService;
        private readonly IOperacionService _operacionService;

        public frmPLC(IPLCService plcService, IOperacionService operacionService)
        {
            InitializeComponent();

            _plcService = plcService;
            _operacionService = operacionService;
        }

        private void frmPLC_Load(object sender, EventArgs e)
        {
            _plcService.Inicializar();            
        }

        private async void btnPLCWrite_Click(object sender, EventArgs e)
        {
            var dtData = await _operacionService.ObtenerDatosAlbaran(int.Parse(txtOperacionId.Text));

            var resultado = await _plcService.EscribirAlbaran(dtData);

            Console.WriteLine(resultado);
        }
    }
}
