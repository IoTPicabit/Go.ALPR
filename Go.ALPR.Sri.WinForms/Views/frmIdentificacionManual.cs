using System;
using System.Drawing;
using System.Windows.Forms;

namespace Go.ALPR.Sri.WinForms
{
    public partial class frmIdentificacionManual : Form
    {
        private readonly SpanishPlateFont spf;

        public frmIdentificacionManual(SpanishPlateFont spanishPlateFont)
        {
            InitializeComponent();

            this.spf = spanishPlateFont;

            txtMatricula.Font = new Font(this.spf.GetFontFamily(), txtMatricula.Font.Size);
            txtRemolque.Font = new Font(this.spf.GetFontFamily(), txtRemolque.Font.Size);
            txtRemolque.BackColor = ColorTranslator.FromHtml("#F03E46");
        }

        public string Matricula
        {
            get
            {
                return txtMatricula.Text;
            }
            set
            {
                txtMatricula.Text = value;
            }
        }

        public string Remolque
        {
            get
            {
                return txtRemolque.Text;
            }
            set
            {
                txtRemolque.Text = value;
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

        private void frmIdentificacionManual_Load(object sender, EventArgs e)
        {
            btnAceptar.Enabled = false;
        }

        private void txtMatricula_TextChanged(object sender, EventArgs e)
        {
            HabilitarAceptar();
        }

        private void txtMotivo_TextChanged(object sender, EventArgs e)
        {
            HabilitarAceptar();
        }

        private void HabilitarAceptar()
        {
            btnAceptar.Enabled = (txtMotivo.Text.Trim().Length > 0) && (txtMatricula.Text.Trim().Length > 0);
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
