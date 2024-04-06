namespace Go.ALPR.Sri.Business
{
    public class LocalizacionDto
    {
        public int IdLocalizacion { get; set; }
        public string Nombre { get; set; }
        public byte IdTipoOperacion { get; set; }
        public string NombreTipoOperacion { get; set; }
        public string Direccion { get; set; }
        public string Cif { get; set; }
        public string Nima { get; set; }
        public bool Habilitado { get; set; }

    }
}
