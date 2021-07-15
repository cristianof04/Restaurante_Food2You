using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lab.Models
{
    public partial class Administrador
    {
        public Administrador()
        {
            Bloquear = new HashSet<Bloquear>();
        }

        [Key]
        [StringLength(20)]
        public string Username { get; set; }

        [ForeignKey(nameof(Username))]
        [InverseProperty(nameof(Utilizador.Administrador))]
        public virtual Utilizador UsernameNavigation { get; set; }
        [InverseProperty("UsernameAdministradorNavigation")]
        public virtual ICollection<Bloquear> Bloquear { get; set; }
    }
}
