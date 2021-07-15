using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lab.Models
{
    public partial class Utilizador
    {
        public Utilizador()
        {
            Bloquear = new HashSet<Bloquear>();
        }

        [Required]
        [Column("nome")]
        [StringLength(35)]
        public string Nome { get; set; }
        [Required]
        [Column("email")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Insira um email válido!")]
        [StringLength(35)]
        public string Email { get; set; }
        [Key]
        [Column("username")]
        [StringLength(20)]
        public string Username { get; set; }
        [Required]
        [Column("pass_word")]
        [StringLength(20)]
        public string PassWord { get; set; }
        [NotMapped]
        [Required(ErrorMessage = "Precisas de confirmar a password!")]
        [CompareAttribute("PassWord", ErrorMessage = "As passwords não coincidem!")]
        public string ConfirmPassword { get; set; }
        [Column("foto")]
        [StringLength(50)]
        public string Foto { get; set; }
        public bool ContaConfirmada { get; set; }

        [InverseProperty("UsernameNavigation")]
        public virtual Administrador Administrador { get; set; }
        [InverseProperty("UsernameNavigation")]
        public virtual Cliente Cliente { get; set; }
        [InverseProperty("UsernameNavigation")]
        public virtual Restaurante Restaurante { get; set; }
        [InverseProperty("UsernameUtilizadorNavigation")]
        public virtual ICollection<Bloquear> Bloquear { get; set; }
    }
}
