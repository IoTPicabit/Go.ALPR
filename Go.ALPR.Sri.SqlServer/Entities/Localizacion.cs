using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Go.ALPR.Sri.SqlServer.Entities
{
    [Table("Localizacion")]
    public partial class Localizacion
    {
        [Key]
        public int IdLocalizacion { get; set; }
        [Required]
        [StringLength(255)]
        public string Nombre { get; set; }
        public byte IdTipoOperacion { get; set; }
        [StringLength(255)]
        public string Direccion { get; set; }
        [Column("CIF")]
        [StringLength(15)]
        public string Cif { get; set; }
        [Column("NIMA")]
        [StringLength(15)]
        public string Nima { get; set; }
        [Required]
        public bool? Habilitado { get; set; }

        [ForeignKey(nameof(IdTipoOperacion))]
        [InverseProperty(nameof(TipoOperacion.Localizacions))]
        public virtual TipoOperacion IdTipoOperacionNavigation { get; set; }
    }
}
