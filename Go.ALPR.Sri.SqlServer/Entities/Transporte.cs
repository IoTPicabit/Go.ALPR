using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Go.ALPR.Sri.SqlServer.Entities
{
    [Table("Transporte")]
    public partial class Transporte
    {
        [Key]
        [StringLength(10)]
        public string Matricula { get; set; }
        [StringLength(10)]
        public string Remolque { get; set; }
        public byte IdTipoOperacion { get; set; }
        [StringLength(255)]
        public string Conductor { get; set; }
        public int? IdEmpresa { get; set; }
        public int? IdTipoCarga { get; set; }

        [ForeignKey(nameof(IdEmpresa))]
        [InverseProperty(nameof(Empresa.Transportes))]
        public virtual Empresa IdEmpresaNavigation { get; set; }
        [ForeignKey(nameof(IdTipoCarga))]
        [InverseProperty(nameof(TipoCarga.Transportes))]
        public virtual TipoCarga IdTipoCargaNavigation { get; set; }
        [ForeignKey(nameof(IdTipoOperacion))]
        [InverseProperty(nameof(TipoOperacion.Transportes))]
        public virtual TipoOperacion IdTipoOperacionNavigation { get; set; }
    }
}
