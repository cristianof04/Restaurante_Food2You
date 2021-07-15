using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lab.Models
{
    [Table("Prato_Dia")]
    public partial class PratoDia
    {
        public PratoDia()
        {
            AvaliarPratos = new HashSet<AvaliarPratos>();
            Possuir = new HashSet<Possuir>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Required]
        [StringLength(35)]
        public string Nome { get; set; }
        [Required]
        [Column("tipo")]
        [StringLength(15)]
        public string Tipo { get; set; }
        [Column("preco")]
        public double Preco { get; set; }
        [Required]
        [Column("descricao")]
        [StringLength(100)]
        public string Descricao { get; set; }
        [Column("foto")]
        [StringLength(50)]
        public string Foto { get; set; }

        [InverseProperty("IdPratoNavigation")]
        public virtual PratosFavoritos PratosFavoritos { get; set; }
        [InverseProperty("IdPratoNavigation")]
        public virtual ICollection<AvaliarPratos> AvaliarPratos { get; set; }
        [InverseProperty("IdPratoNavigation")]
        public virtual ICollection<Possuir> Possuir { get; set; }
    }
}
