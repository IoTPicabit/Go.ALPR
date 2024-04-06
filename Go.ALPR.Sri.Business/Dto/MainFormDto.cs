namespace Go.ALPR.Sri.Business
{
    public class MainFormDto
    {

        public MainFormDto()
        {
            Transporte = new TransporteCompletoDto();
            Origen = new LocalizacionDto();
            Destino = new LocalizacionDto();
        }

        //Datos identificacion
        public string IdIdentificacion { get; set; }
        public byte Tipo { get; set; }
        public byte Estado { get; set; }
        public string MatriculaLeida { get; set; }
        public string Camara1Path { get; set; }
        public string Camara2Path { get; set; }
        public string Camara3Path { get; set; }

        public TransporteCompletoDto Transporte { get; set; }        

        public bool TransporteReconocido { get; set; }

        public LocalizacionDto Origen { get; set; }

        public LocalizacionDto Destino { get; set; }

        public bool IdentificacionManual { get; set; }
        public string MotivoIdentificacionManual { get; set; }

       
        public int Peso { get; set; }
        public int PesoLeido { get; set; }

        public bool PesoCorrecto { get; set; }

        public bool PesoManual { get; set; }
        public string MotivoPesoManual { get; set; }

        public byte[] FirmaProductorImagen { get; set; }
        public byte[] FirmaConductorImagen { get; set; }

        public OperacionDto EntradaPrevia { get; set; }
    }
}
