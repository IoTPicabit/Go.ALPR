using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Go.ALPR.Sri.SqlServer.Entities
{
    [Table("T_Vision_acceso")]
    public partial class TVisionAcceso
    {
        [Key]
        [StringLength(11)]
        public string Id { get; set; }
        public byte Tipo { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime Fecha { get; set; }
        public byte Estado { get; set; }
        [Column("Matricula_C")]
        [StringLength(10)]
        public string MatriculaC { get; set; }
        [Column("Matricula_R")]
        [StringLength(10)]
        public string MatriculaR { get; set; }
        [StringLength(255)]
        public string Path { get; set; }
        [Column("Bit_Vida")]
        public int? BitVida { get; set; }
    }
}
