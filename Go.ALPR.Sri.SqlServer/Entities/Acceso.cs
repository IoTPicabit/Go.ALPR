using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Go.ALPR.Sri.SqlServer.Entities
{
    [Table("Acceso")]
    public partial class Acceso
    {
        [Key]
        [StringLength(11)]
        public string Id { get; set; }
        public byte Tipo { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime Fecha { get; set; }
        public byte Estado { get; set; }
        [StringLength(10)]
        public string Matricula { get; set; }
        public bool Resultado { get; set; }
    }
}
