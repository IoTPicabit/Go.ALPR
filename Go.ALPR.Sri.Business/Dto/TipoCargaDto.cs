using System.Collections.Generic;

namespace Go.ALPR.Sri.Business
{
    public class TipoCargaDto
    {

        public TipoCargaDto()
        {
            DenominacionAdr = null;
        }


        public int IdTipoCarga { get; set; }
        public string Nombre { get; set; }
        public string CodigoLer { get; set; }
        public string DenominacionAdr { get; set; }
        public byte IdTipoOperacion { get; set; }
        public string NombreTipoOperacion { get; set; }
        public int? IdTipoCargaPadre { get; set; }
        public string NombrePadre { get; set; }
        public List<TipoCargaDto> Subproductos { get; set; }
        public int? IdEmpresaExpedicion { get; set; }
        public string NombreEmpresaExpedicion { get; set; }
    }
}