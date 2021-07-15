using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lab.Models
{
    public partial class RestaurantesFavoritos
    {
        [Required]
        [StringLength(20)]
        public string UsernameCliente { get; set; }
        [Key]
        [StringLength(20)]
        public string UsernameRestaurante { get; set; }

        [ForeignKey(nameof(UsernameCliente))]
        [InverseProperty(nameof(Cliente.RestaurantesFavoritos))]
        public virtual Cliente UsernameClienteNavigation { get; set; }
        [ForeignKey(nameof(UsernameRestaurante))]
        [InverseProperty(nameof(Restaurante.RestaurantesFavoritos))]
        public virtual Restaurante UsernameRestauranteNavigation { get; set; }
    }
}
