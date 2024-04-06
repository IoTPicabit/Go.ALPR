using System;
using System.Windows.Forms;

namespace Go.ALPR.Sri.WinForms
{
    public partial class frmPesoManual : Form
    {

        public frmPesoManual()
        {
            InitializeComponent();
        }

        public string Peso
        {
            get
            {
                return txtPeso.Text;
            }
            set
            {
                txtPeso.Text = value;
            }
        }

        public string Motivo
        {
            get
            {
                return txtMotivo.Text;
            }
            set
            {
                txtMotivo.Text = value;
            }
        }

        private void frmPesoManual_Load(object sender, EventArgs e)
        {
            btnAceptar.Enabled = false;
        }

        private void txtPeso_TextChanged(object sender, EventArgs e)
        {
            HabilitarAceptar();
        }

        private void txtMotivo_TextChanged(object sender, EventArgs e)
        {
            HabilitarAceptar();
        }

        private void HabilitarAceptar()
        {
            btnAceptar.Enabled = (txtMotivo.Text.Trim().Length > 0) && (txtPeso.Text.Trim().Length > 0);
        }

        private void txtPeso_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();            
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Close();
        }

        
    }
}
