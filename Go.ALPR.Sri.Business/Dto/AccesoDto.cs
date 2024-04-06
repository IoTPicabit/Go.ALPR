using System;

namespace Go.ALPR.Sri.Business
{
    public class AccesoDto
    {
        public string Id { get; set; }
        public byte Tipo { get; set; }
        public DateTime Fecha { get; set; }
        public byte Estado { get; set; }
        public string EstadoNombre { get; set; }
        public string Matricula { get; set; }
        public bool Resultado { get; set; }
        public string ResultadoNombre { get; set; }
    }
}
