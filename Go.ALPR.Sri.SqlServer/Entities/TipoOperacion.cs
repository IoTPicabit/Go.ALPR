using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Go.ALPR.Sri.SqlServer.Entities
{
    [Table("TipoOperacion")]
    public partial class TipoOperacion
    {
        public TipoOperacion()
        {
            Localizacions = new HashSet<Localizacion>();
            Operacions = new HashSet<Operacion>();
            TipoCargas = new HashSet<TipoCarga>();
            Transportes = new HashSet<Transporte>();
        }

        [Key]
        public byte IdTipoOperacion { get; set; }
        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [InverseProperty(nameof(Localizacion.IdTipoOperacionNavigation))]
        public virtual ICollection<Localizacion> Localizacions { get; set; }
        [InverseProperty(nameof(Operacion.IdTipoOperacionNavigation))]
        public virtual ICollection<Operacion> Operacions { get; set; }
        [InverseProperty(nameof(TipoCarga.IdTipoOperacionNavigation))]
        public virtual ICollection<TipoCarga> TipoCargas { get; set; }
        [InverseProperty(nameof(Transporte.IdTipoOperacionNavigation))]
        public virtual ICollection<Transporte> Transportes { get; set; }
    }
}
