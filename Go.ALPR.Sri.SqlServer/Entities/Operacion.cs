using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Go.ALPR.Sri.SqlServer.Entities
{
    [Table("Operacion")]
    public partial class Operacion
    {
        public Operacion()
        {
            Fotos = new HashSet<Foto>();
        }

        [Key]
        public int IdOperacion { get; set; }
        [Required]
        [StringLength(10)]
        public string Matricula { get; set; }
        [StringLength(10)]
        public string Remolque { get; set; }
        public byte IdTipoOperacion { get; set; }
        public bool MatriculaEntradaManual { get; set; }
        public string MotivoMatriculaEntradaManual { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime FechaHoraEntrada { get; set; }
        public int PesoEntrada { get; set; }
        public bool PesoEntradaManual { get; set; }
        public string MotivoPesoEntradaManual { get; set; }
        [Required]
        [StringLength(255)]
        public string UsuarioEntrada { get; set; }
        public bool MatriculaSalidaManual { get; set; }
        public string MotivoMatriculaSalidaManual { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? FechaHoraSalida { get; set; }
        public int? PesoSalida { get; set; }
        public bool PesoSalidaManual { get; set; }
        public string MotivoPesoSalidaManual { get; set; }
        [StringLength(255)]
        public string UsuarioSalida { get; set; }
        public int? IdEmpresa { get; set; }
        [StringLength(255)]
        public string Empresa { get; set; }
        [StringLength(255)]
        public string EmpresaDireccion { get; set; }
        [Column("EmpresaCIF")]
        [StringLength(25)]
        public string EmpresaCif { get; set; }
        [Column("EmpresaNIMA")]
        [StringLength(25)]
        public string EmpresaNima { get; set; }
        [StringLength(255)]
        public string Conductor { get; set; }
        public int? IdTipoCarga { get; set; }
        [StringLength(255)]
        public string TipoCarga { get; set; }
        [Column("CodigoLER")]
        [StringLength(7)]
        public string CodigoLer { get; set; }
        [Column("DenominacionADR")]
        [StringLength(255)]
        public string DenominacionAdr { get; set; }
        [StringLength(255)]
        public string Origen { get; set; }
        [StringLength(255)]
        public string OrigenDireccion { get; set; }
        [Column("OrigenCIF")]
        [StringLength(25)]
        public string OrigenCif { get; set; }
        [Column("OrigenNIMA")]
        [StringLength(25)]
        public string OrigenNima { get; set; }
        [StringLength(255)]
        public string Destino { get; set; }
        [StringLength(255)]
        public string DestinoDireccion { get; set; }
        [Column("DestinoCIF")]
        [StringLength(25)]
        public string DestinoCif { get; set; }
        [Column("DestinoNIMA")]
        [StringLength(25)]
        public string DestinoNima { get; set; }
        [StringLength(255)]
        public string FirmaProductor { get; set; }
        public byte[] FirmaProductorImagen { get; set; }
        [StringLength(255)]
        public string FirmaConductor { get; set; }
        public byte[] FirmaConductorImagen { get; set; }
        [StringLength(255)]
        public string Expedidor { get; set; }
        [StringLength(255)]
        public string ExpedidorDireccion { get; set; }
        [Column("ExpedidorCIF")]
        [StringLength(25)]
        public string ExpedidorCif { get; set; }

        [ForeignKey(nameof(IdTipoOperacion))]
        [InverseProperty(nameof(TipoOperacion.Operacions))]
        public virtual TipoOperacion IdTipoOperacionNavigation { get; set; }
        [InverseProperty(nameof(Foto.IdOperacionNavigation))]
        public virtual ICollection<Foto> Fotos { get; set; }
    }
}
