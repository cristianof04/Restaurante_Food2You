using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lab.Models
{
    public partial class PratosFavoritos
    {
        [Required]
        [StringLength(20)]
        public string UsernameCliente { get; set; }
        [Key]
        [Column("Id_Prato")]
        public int IdPrato { get; set; }

        [ForeignKey(nameof(IdPrato))]
        [InverseProperty(nameof(PratoDia.PratosFavoritos))]
        public virtual PratoDia IdPratoNavigation { get; set; }
        [ForeignKey(nameof(UsernameCliente))]
        [InverseProperty(nameof(Cliente.PratosFavoritos))]
        public virtual Cliente UsernameClienteNavigation { get; set; }
    }
}
