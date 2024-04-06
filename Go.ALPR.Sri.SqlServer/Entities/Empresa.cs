using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Go.ALPR.Sri.SqlServer.Entities
{
    [Table("Empresa")]
    public partial class Empresa
    {
        public Empresa()
        {
            Contactos = new HashSet<Contacto>();
            TipoCargas = new HashSet<TipoCarga>();
            Transportes = new HashSet<Transporte>();
        }

        [Key]
        public int IdEmpresa { get; set; }
        [Required]
        [StringLength(255)]
        public string Nombre { get; set; }
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
        public bool Expedidor { get; set; }

        [InverseProperty(nameof(Contacto.IdEmpresaNavigation))]
        public virtual ICollection<Contacto> Contactos { get; set; }
        [InverseProperty(nameof(TipoCarga.IdEmpresaExpedicionNavigation))]
        public virtual ICollection<TipoCarga> TipoCargas { get; set; }
        [InverseProperty(nameof(Transporte.IdEmpresaNavigation))]
        public virtual ICollection<Transporte> Transportes { get; set; }
    }
}
