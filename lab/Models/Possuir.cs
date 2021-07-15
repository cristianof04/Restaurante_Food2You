using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lab.Models
{
    public partial class Possuir
    {
        [Key]
        [Column("ID_Prato")]
        public int IdPrato { get; set; }
        [Key]
        [Column("Username_Restaurante")]
        [StringLength(20)]
        public string UsernameRestaurante { get; set; }
        [Column("Data_PratoDia", TypeName = "date")]
        [DisplayName("Data do prato")]
        [DataType(DataType.DateTime)]
        public DateTime DataPratoDia { get; set; }

        [ForeignKey(nameof(IdPrato))]
        [InverseProperty(nameof(PratoDia.Possuir))]
        public virtual PratoDia IdPratoNavigation { get; set; }
        [ForeignKey(nameof(UsernameRestaurante))]
        [InverseProperty(nameof(Restaurante.Possuir))]
        public virtual Restaurante UsernameRestauranteNavigation { get; set; }
    }
}
