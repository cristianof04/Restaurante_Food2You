using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lab.Models
{
    public partial class Bloquear
    {
        [Column("Username_Administrador")]
        [StringLength(20)]
        public string UsernameAdministrador { get; set; }
        [Key]
        [Column("Username_Utilizador")]
        [StringLength(20)]
        public string UsernameUtilizador { get; set; }
        [Required]
        [Column("motivo")]
        [StringLength(50)]
        public string Motivo { get; set; }
        [Key]
        [Column(TypeName = "date")]
        public DateTime DataBloqueio { get; set; }

        [ForeignKey(nameof(UsernameAdministrador))]
        [InverseProperty(nameof(Administrador.Bloquear))]
        public virtual Administrador UsernameAdministradorNavigation { get; set; }
        [ForeignKey(nameof(UsernameUtilizador))]
        [InverseProperty(nameof(Utilizador.Bloquear))]
        public virtual Utilizador UsernameUtilizadorNavigation { get; set; }
    }
}
