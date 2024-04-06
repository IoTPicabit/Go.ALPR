namespace Go.ALPR.Sri.Business
{
    public class TransporteCompletoDto
    {

        public TransporteCompletoDto()
        {
            TipoOperacion = new TipoOperacionDto();
            Empresa = new EmpresaDto();
            TipoCarga = new TipoCargaDto();
            Expedidor = new EmpresaDto();
        }

        public string Matricula { get; set; }

        public string Remolque { get; set; }

        public string Conductor { get; set; }

        public TipoOperacionDto TipoOperacion { get; set; }        

        public EmpresaDto Empresa { get; set; }

        public TipoCargaDto TipoCarga { get; set; }

        public EmpresaDto Expedidor { get; set; }

    }
}
