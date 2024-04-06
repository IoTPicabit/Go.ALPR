namespace Go.ALPR.Sri.Business
{
    public class ContactoDto
    {
        public int IdContacto { get; set; }
        public string Email { get; set; }
        public string Nombre { get; set; }
        public int? IdEmpresa { get; set; }
        public string NombreEmpresa { get; set; }
        public int? IdTipoCarga { get; set; }
        public string NombreTipoCarga { get; set; }
        public bool Habilitado { get; set; }
    }
}
