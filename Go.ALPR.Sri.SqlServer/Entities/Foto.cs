using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Go.ALPR.Sri.SqlServer.Entities
{
    [Table("Foto")]
    public partial class Foto
    {
        [Key]
        public int IdOperacion { get; set; }
        [Key]
        public byte Tipo { get; set; }
        [StringLength(255)]
        public string Camara1 { get; set; }
        [StringLength(255)]
        public string Camara2 { get; set; }
        [StringLength(255)]
        public string Camara3 { get; set; }

        [ForeignKey(nameof(IdOperacion))]
        [InverseProperty(nameof(Operacion.Fotos))]
        public virtual Operacion IdOperacionNavigation { get; set; }
    }
}
