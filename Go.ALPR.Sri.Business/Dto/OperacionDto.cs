using System;
using System.Collections.Generic;
using System.Text;

namespace Go.ALPR.Sri.Business
{
    public class OperacionDto
    {
        public int IdOperacion { get; set; }
        public string Matricula { get; set; }
        public string Remolque { get; set; }
        public byte IdTipoOperacion { get; set; }
        public string NombreTipoOperacion { get; set; }

        public bool MatriculaEntradaManual { get; set; }
        public string MotivoMatriculaEntradaManual { get; set; }
        public DateTime FechaHoraEntrada { get; set; }
        public int PesoEntrada { get; set; }
        public bool PesoEntradaManual { get; set; }
        public string MotivoPesoEntradaManual { get; set; }
        public string UsuarioEntrada { get; set; }


        public bool MatriculaSalidaManual { get; set; }
        public string MotivoMatriculaSalidaManual { get; set; }
        public DateTime FechaHoraSalida { get; set; }
        public int PesoSalida { get; set; }
        public bool PesoSalidaManual { get; set; }
        public string MotivoPesoSalidaManual { get; set; }
        public string UsuarioSalida { get; set; }

        public int? IdEmpresa { get; set; }
        public string Empresa { get; set; }
        public string EmpresaDireccion { get; set; }
        public string EmpresaCif { get; set; }
        public string EmpresaNima { get; set; }


        public string Conductor { get; set; }

        public int? IdTipoCarga { get; set; }
        public string TipoCarga { get; set; }
        public string CodigoLer { get; set; }
        public string DenominacionAdr { get; set; }

        public string Origen { get; set; }
        public string OrigenDireccion { get; set; }
        public string OrigenCif { get; set; }
        public string OrigenNima { get; set; }


        public string Destino { get; set; }
        public string DestinoDireccion { get; set; }
        public string DestinoCif { get; set; }
        public string DestinoNima { get; set; }


        public string FirmaProductor { get; set; }
        public byte[] FirmaProductorImagen { get; set; }
        public string FirmaTransportista { get; set; }
        public byte[] FirmaConductorImagen { get; set; }

        public string EmpresaContactos { get; set; }


        public string Expedidor { get; set; }
        public string ExpedidorDireccion { get; set; }
        public string ExpedidorCif { get; set; }
    }
}
