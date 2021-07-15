using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lab.Models
{
    [Table("Avaliar_restaurates")]
    public partial class AvaliarRestaurates
    {
        [Key]
        [Column("Username_Restaurante")]
        [StringLength(20)]
        public string UsernameRestaurante { get; set; }
        [Key]
        [Column("Username_Cliente")]
        [StringLength(20)]
        public string UsernameCliente { get; set; }
        [Column("avaliacao")]
        public int? Avaliacao { get; set; }
        [Column("comentario")]
        [StringLength(50)]
        public string Comentario { get; set; }

        [ForeignKey(nameof(UsernameCliente))]
        [InverseProperty(nameof(Cliente.AvaliarRestaurates))]
        public virtual Cliente UsernameClienteNavigation { get; set; }
        [ForeignKey(nameof(UsernameRestaurante))]
        [InverseProperty(nameof(Restaurante.AvaliarRestaurates))]
        public virtual Restaurante UsernameRestauranteNavigation { get; set; }
    }
}
