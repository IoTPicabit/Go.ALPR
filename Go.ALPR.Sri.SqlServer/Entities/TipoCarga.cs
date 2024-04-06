using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Go.ALPR.Sri.SqlServer.Entities
{
    [Table("TipoCarga")]
    public partial class TipoCarga
    {
        public TipoCarga()
        {
            Contactos = new HashSet<Contacto>();
            InverseIdTipoCargaPadreNavigation = new HashSet<TipoCarga>();
            Transportes = new HashSet<Transporte>();
        }

        [Key]
        public int IdTipoCarga { get; set; }
        [Required]
        [StringLength(255)]
        public string Nombre { get; set; }
        [Column("CodigoLER")]
        [StringLength(7)]
        public string CodigoLer { get; set; }
        public byte IdTipoOperacion { get; set; }
        [Column("DenominacionADR")]
        [StringLength(255)]
        public string DenominacionAdr { get; set; }
        public int? IdTipoCargaPadre { get; set; }
        public int? IdEmpresaExpedicion { get; set; }

        [ForeignKey(nameof(IdEmpresaExpedicion))]
        [InverseProperty(nameof(Empresa.TipoCargas))]
        public virtual Empresa IdEmpresaExpedicionNavigation { get; set; }
        [ForeignKey(nameof(IdTipoCargaPadre))]
        [InverseProperty(nameof(TipoCarga.InverseIdTipoCargaPadreNavigation))]
        public virtual TipoCarga IdTipoCargaPadreNavigation { get; set; }
        [ForeignKey(nameof(IdTipoOperacion))]
        [InverseProperty(nameof(TipoOperacion.TipoCargas))]
        public virtual TipoOperacion IdTipoOperacionNavigation { get; set; }
        [InverseProperty(nameof(Contacto.IdTipoCargaNavigation))]
        public virtual ICollection<Contacto> Contactos { get; set; }
        [InverseProperty(nameof(TipoCarga.IdTipoCargaPadreNavigation))]
        public virtual ICollection<TipoCarga> InverseIdTipoCargaPadreNavigation { get; set; }
        [InverseProperty(nameof(Transporte.IdTipoCargaNavigation))]
        public virtual ICollection<Transporte> Transportes { get; set; }
    }
}
