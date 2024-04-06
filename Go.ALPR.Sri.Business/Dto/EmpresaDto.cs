using System.Collections.Generic;


namespace Go.ALPR.Sri.Business
{
    public class EmpresaDto
    {
        public int IdEmpresa { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Cif { get; set; }
        public string Nima { get; set; }
        public bool Habilitado { get; set; }       
    }
    
}