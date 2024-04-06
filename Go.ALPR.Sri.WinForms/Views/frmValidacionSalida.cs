using System;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

using Go.ALPR.Sri.Signature;

namespace Go.ALPR.Sri.WinForms
{
    public partial class frmValidacionSalida : Form
    {
        private int _idOperacion;

        private readonly SpanishPlateFont spf;
        private readonly ISignatureService _signatureService;

        public frmValidacionSalida(SpanishPlateFont spanishPlateFont,
                                    ISignatureService signatureService)
        {
            InitializeComponent();
            this.spf = spanishPlateFont;

            lblMatricula.Font = new Font(this.spf.GetFontFamily(), lblMatricula.Font.Size);
            lblRemolque.Font = new Font(this.spf.GetFontFamily(), lblRemolque.Font.Size);
            lblRemolque.BackColor = ColorTranslator.FromHtml("#F03E46");

            _signatureService = signatureService;
        }

        public int OperacionID
        {
            set
            {
                _idOperacion = value;
            }
        }

        public bool IdentificacionManual
        {
            set
            {
                lblIdentificacionManual.Visible = value;
            }
        }

        public bool PesoEntradaManual
        {
            set
            {
                lblPesoEntradaManual.Visible = value;
            }
        }

        public bool PesoSalidaManual
        {
            set
            {
                lblPesoSalidaManual.Visible = value;
            }
        }

        public string TituloPesoNeto
        {
            set
            {
                lblTituloPesoNeto.Text = value;
            }
        }

        public string Matricula
        {            
            set
            {
                lblMatricula.Text = value;
            }
        }

        public string Remolque
        {
            set
            {
                lblRemolque.Text = value;
            }
        }

        public int PesoEntrada
        {
            set
            {
                lblPesoEntrada.Text = value.ToString("##,0");
            }
        }

        public string HoraEntrada
        {
            set
            {
                lblHoraEntrada.Text = value;
            }
        }

        public int PesoSalida
        {
            set
            {
                lblPesoSalida.Text = value.ToString("##,0");
            }
        }

        public string HoraSalida
        {
            set
            {
                lblHoraSalida.Text = value;
            }
        }

        public int PesoNeto
        {
            set
            {
                lblPesoNeto.Text = value.ToString("##,0");
            }
        }

        public string TipoCarga
        {
            set
            {
                lblTipoCarga.Text = value;
            }
        }

        public string Origen
        {
            set
            {
                lblOrigen.Text = value;
            }
        }

        public string Destino
        {
            set
            {
                lblDestino.Text = value;
            }
        }
        

        public string Expedidor {
            set
            {
                lblExpedidor.Text = value;
            }
        }

        public string Operario
        {
            set
            {
                lblOperario.Text = value;
            }
        }

        public string Transportista
        {
            set
            {
                lblTransportista.Text = value;
            }
        }

        public byte[] FirmaOperario
        {
            get
            {
                if(picFirmaOperario.Image != null)
                {
                    MemoryStream ms = new MemoryStream();
                    picFirmaOperario.Image.Save(ms, ImageFormat.Png);
                    return ms.ToArray();
                }
                else
                {
                    return null;
                }
            }
        }

        public byte[] FirmaTransportista
        {
            get
            {
                if(picFirmaTransportista.Image != null)
                {
                    MemoryStream ms = new MemoryStream();
                    picFirmaTransportista.Image.Save(ms, ImageFormat.Png);
                    return ms.ToArray();
                }
                else
                {
                    return null;
                }                
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

        private void btnFirmaOperario_Click(object sender, EventArgs e)
        {
            try
            {
                Stream result = _signatureService.CaputurarFirma(lblOperario.Text, grbFirmaOperario.Text, _idOperacion);

                if (result != null)
                {
                    picFirmaOperario.Image = Image.FromStream(result);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFirmaTransportista_Click(object sender, EventArgs e)
        {
            try
            {
                Stream result = _signatureService.CaputurarFirma(lblTransportista.Text, grbFirmaTransportista.Text, _idOperacion);

                if (result != null)
                {
                    picFirmaTransportista.Image = Image.FromStream(result);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
