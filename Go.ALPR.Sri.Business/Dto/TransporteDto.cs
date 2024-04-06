namespace Go.ALPR.Sri.Business
{
    public class TransporteDto
    {
        public string Matricula { get; set; }
        public string Remolque { get; set; }
        public byte IdTipoOperacion { get; set; }
        public string NombreTipoOperacion { get; set; }
        public string Conductor { get; set; }
        public int? IdEmpresa { get; set; }
        public string NombreEmpresa { get; set; }

        public int? IdTipoCarga { get; set; }
        public string NombreTipoCarga { get; set; }
    }        

}
