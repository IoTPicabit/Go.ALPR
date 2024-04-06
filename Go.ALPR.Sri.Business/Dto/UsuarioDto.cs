namespace Go.ALPR.Sri.Business
{
    public class UsuarioDto
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Login { get; set; }
        public string Clave { get; set; }
        public byte Tipo { get; set; }
        public string TipoNombre
        {
            get
            {
                return (this.Tipo == 1 ? "Administrador" : "Operario");
            }
        }
    }
}
