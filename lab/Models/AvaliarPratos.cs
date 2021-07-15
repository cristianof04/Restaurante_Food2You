using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lab.Models
{
    [Table("Avaliar_pratos")]
    public partial class AvaliarPratos
    {
        [Key]
        [Column("Id_prato")]
        public int IdPrato { get; set; }
        [Key]
        [Column("Username_Cliente")]
        [StringLength(20)]
        public string UsernameCliente { get; set; }
        [Column("avaliacao")]
        public int? Avaliacao { get; set; }
        [Column("comentario")]
        [StringLength(50)]
        public string Comentario { get; set; }

        [ForeignKey(nameof(IdPrato))]
        [InverseProperty(nameof(PratoDia.AvaliarPratos))]
        public virtual PratoDia IdPratoNavigation { get; set; }
        [ForeignKey(nameof(UsernameCliente))]
        [InverseProperty(nameof(Cliente.AvaliarPratos))]
        public virtual Cliente UsernameClienteNavigation { get; set; }
    }
}
