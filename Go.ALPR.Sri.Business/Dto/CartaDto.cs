using System;
using System.Collections.Generic;
using System.Text;

namespace Go.ALPR.Sri.Business
{
    [Serializable()]
    public class CartaDto
    {

        public int IdOperacion { get; set; }

        public byte IdTipoOperacion { get; set; }

        public string Matricula { get; set; }

        public string Remolque { get; set; }

        public DateTime FechaHoraEntrada { get; set; }

        public DateTime FechaHoraSalida { get; set; }

        public int PesoEntrada { get; set; }

        public int PesoSalida { get; set; }


        public string Empresa { get; set; }
        public string EmpresaDireccion { get; set; }
        public string EmpresaCIF { get; set; }
        public string EmpresaNIMA { get; set; }


        public string Conductor { get; set; }
        public string TipoCarga { get; set; }
        public string CodigoLER { get; set; }
        public string DenominacionADR { get; set; }

        public string Origen { get; set; }
        public string OrigenDireccion { get; set; }
        public string OrigenCIF { get; set; }
        public string OrigenNIMA { get; set; }


        public string Destino { get; set; }
        public string DestinoDireccion { get; set; }
        public string DestinoCIF { get; set; }
        public string DestinoNIMA { get; set; }

        public string Expedidor { get; set; }
        public string ExpedidorDireccion { get; set; }
        public string ExpedidorCif { get; set; }

        public string FirmaProductor { get; set; }
        public byte[] FirmaProductorImagen { get; set; }
        public string FirmaConductor { get; set; }
        public byte[] FirmaConductorImagen { get; set; }

    }
}
