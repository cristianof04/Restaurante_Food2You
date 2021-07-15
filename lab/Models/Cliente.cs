using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lab.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            AvaliarPratos = new HashSet<AvaliarPratos>();
            AvaliarRestaurates = new HashSet<AvaliarRestaurates>();
            PratosFavoritos = new HashSet<PratosFavoritos>();
            RestaurantesFavoritos = new HashSet<RestaurantesFavoritos>();
        }

        [Key]
        [StringLength(20)]
        public string Username { get; set; }

        [ForeignKey(nameof(Username))]
        [InverseProperty(nameof(Utilizador.Cliente))]
        public virtual Utilizador UsernameNavigation { get; set; }
        [InverseProperty("UsernameClienteNavigation")]
        public virtual ICollection<AvaliarPratos> AvaliarPratos { get; set; }
        [InverseProperty("UsernameClienteNavigation")]
        public virtual ICollection<AvaliarRestaurates> AvaliarRestaurates { get; set; }
        [InverseProperty("UsernameClienteNavigation")]
        public virtual ICollection<PratosFavoritos> PratosFavoritos { get; set; }
        [InverseProperty("UsernameClienteNavigation")]
        public virtual ICollection<RestaurantesFavoritos> RestaurantesFavoritos { get; set; }
    }
}
