using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Go.ALPR.Sri.SqlServer.Entities
{
    [Keyless]
    [Table("Estado_Procesos")]
    public partial class EstadoProceso
    {
        public string Nombre { get; set; }
        [Column("Bit_Vida")]
        public int? BitVida { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? TimeStamp { get; set; }
    }
}
