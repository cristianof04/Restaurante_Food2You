using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lab.Models
{
    public partial class Restaurante
    {
        public Restaurante()
        {
            AvaliarRestaurates = new HashSet<AvaliarRestaurates>();
            Possuir = new HashSet<Possuir>();
        }

        [Key]
        [StringLength(20)]
        public string Username { get; set; }
        [Required]
        [StringLength(35)]
        public string Nome { get; set; }
        [Required]
        [Column("morada")]
        [StringLength(50)]
        public string Morada { get; set; }
        [Column("telefone")]
        public int Telefone { get; set; }
        [Required]
        [Column("gps")]
        [StringLength(50)]
        public string Gps { get; set; }
        [Required]
        [Column("horario")]
        [StringLength(100)]
        public string Horario { get; set; }
        [Required]
        [Column("Dia_Descanso")]
        [StringLength(25)]
        public string DiaDescanso { get; set; }
        [Required]
        [Column("tipo_servico")]
        [StringLength(50)]
        public string TipoServico { get; set; }
        [StringLength(50)]
        public string Foto { get; set; }
        [StringLength(20)]
        public string QuemAprovou { get; set; }

        [ForeignKey(nameof(Username))]
        [InverseProperty(nameof(Utilizador.Restaurante))]
        public virtual Utilizador UsernameNavigation { get; set; }
        [InverseProperty("UsernameRestauranteNavigation")]
        public virtual RestaurantesFavoritos RestaurantesFavoritos { get; set; }
        [InverseProperty("UsernameRestauranteNavigation")]
        public virtual ICollection<AvaliarRestaurates> AvaliarRestaurates { get; set; }
        [InverseProperty("UsernameRestauranteNavigation")]
        public virtual ICollection<Possuir> Possuir { get; set; }
    }
}
