using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Go.ALPR.Sri.SqlServer.Entities
{
    [Table("Contacto")]
    public partial class Contacto
    {
        [Key]
        public int IdContacto { get; set; }
        [Required]
        [StringLength(100)]
        public string Email { get; set; }
        [StringLength(255)]
        public string Nombre { get; set; }
        public int? IdEmpresa { get; set; }
        public int? IdTipoCarga { get; set; }
        [Required]
        public bool? Habilitado { get; set; }

        [ForeignKey(nameof(IdEmpresa))]
        [InverseProperty(nameof(Empresa.Contactos))]
        public virtual Empresa IdEmpresaNavigation { get; set; }
        [ForeignKey(nameof(IdTipoCarga))]
        [InverseProperty(nameof(TipoCarga.Contactos))]
        public virtual TipoCarga IdTipoCargaNavigation { get; set; }
    }
}
