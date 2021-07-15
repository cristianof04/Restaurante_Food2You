using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using lab.Models;

namespace lab.Data
{
    public partial class labContext : DbContext
    {
        public labContext()
        {
        }

        public labContext(DbContextOptions<labContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Administrador> Administrador { get; set; }
        public virtual DbSet<AvaliarPratos> AvaliarPratos { get; set; }
        public virtual DbSet<AvaliarRestaurates> AvaliarRestaurates { get; set; }
        public virtual DbSet<Bloquear> Bloquear { get; set; }
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Possuir> Possuir { get; set; }
        public virtual DbSet<PratoDia> PratoDia { get; set; }
        public virtual DbSet<PratosFavoritos> PratosFavoritos { get; set; }
        public virtual DbSet<Restaurante> Restaurante { get; set; }
        public virtual DbSet<RestaurantesFavoritos> RestaurantesFavoritos { get; set; }
        public virtual DbSet<Utilizador> Utilizador { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("name=labContext");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Administrador>(entity =>
            {
                entity.HasKey(e => e.Username)
                    .HasName("PK__Administ__536C85E5E8605C9E");

                entity.Property(e => e.Username).IsUnicode(false);

                entity.HasOne(d => d.UsernameNavigation)
                    .WithOne(p => p.Administrador)
                    .HasForeignKey<Administrador>(d => d.Username)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Administr__Usern__2F10007B");
            });

            modelBuilder.Entity<AvaliarPratos>(entity =>
            {
                entity.HasKey(e => new { e.UsernameCliente, e.IdPrato })
                    .HasName("PK__Avaliar___E99671B0D641A2AB");

                entity.Property(e => e.UsernameCliente).IsUnicode(false);

                entity.Property(e => e.Comentario).IsUnicode(false);

                entity.HasOne(d => d.IdPratoNavigation)
                    .WithMany(p => p.AvaliarPratos)
                    .HasForeignKey(d => d.IdPrato)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Avaliar_p__Id_pr__412EB0B6");

                entity.HasOne(d => d.UsernameClienteNavigation)
                    .WithMany(p => p.AvaliarPratos)
                    .HasForeignKey(d => d.UsernameCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Avaliar_p__Usern__403A8C7D");
            });

            modelBuilder.Entity<AvaliarRestaurates>(entity =>
            {
                entity.HasKey(e => new { e.UsernameRestaurante, e.UsernameCliente })
                    .HasName("PK__Avaliar___19552EDD7199D50E");

                entity.Property(e => e.UsernameRestaurante).IsUnicode(false);

                entity.Property(e => e.UsernameCliente).IsUnicode(false);

                entity.Property(e => e.Comentario).IsUnicode(false);

                entity.HasOne(d => d.UsernameClienteNavigation)
                    .WithMany(p => p.AvaliarRestaurates)
                    .HasForeignKey(d => d.UsernameCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Avaliar_r__Usern__3C69FB99");

                entity.HasOne(d => d.UsernameRestauranteNavigation)
                    .WithMany(p => p.AvaliarRestaurates)
                    .HasForeignKey(d => d.UsernameRestaurante)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Avaliar_r__Usern__3D5E1FD2");
            });

            modelBuilder.Entity<Bloquear>(entity =>
            {
                entity.HasKey(e => new { e.UsernameUtilizador, e.DataBloqueio })
                    .HasName("PK__Bloquear__AA645613A67386E0");

                entity.Property(e => e.UsernameUtilizador).IsUnicode(false);

                entity.Property(e => e.Motivo).IsUnicode(false);

                entity.Property(e => e.UsernameAdministrador).IsUnicode(false);

                entity.HasOne(d => d.UsernameAdministradorNavigation)
                    .WithMany(p => p.Bloquear)
                    .HasForeignKey(d => d.UsernameAdministrador)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Bloquear__Userna__38996AB5");

                entity.HasOne(d => d.UsernameUtilizadorNavigation)
                    .WithMany(p => p.Bloquear)
                    .HasForeignKey(d => d.UsernameUtilizador)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Bloquear__Userna__398D8EEE");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.Username)
                    .HasName("PK__Cliente__536C85E57F382FFA");

                entity.Property(e => e.Username).IsUnicode(false);

                entity.HasOne(d => d.UsernameNavigation)
                    .WithOne(p => p.Cliente)
                    .HasForeignKey<Cliente>(d => d.Username)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Cliente__Usernam__267ABA7A");
            });

            modelBuilder.Entity<Possuir>(entity =>
            {
                entity.HasKey(e => new { e.IdPrato, e.UsernameRestaurante })
                    .HasName("PK__Possuir__39240DE5C96464DC");

                entity.Property(e => e.UsernameRestaurante).IsUnicode(false);

                entity.HasOne(d => d.IdPratoNavigation)
                    .WithMany(p => p.Possuir)
                    .HasForeignKey(d => d.IdPrato)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Possuir__ID_Prat__44FF419A");

                entity.HasOne(d => d.UsernameRestauranteNavigation)
                    .WithMany(p => p.Possuir)
                    .HasForeignKey(d => d.UsernameRestaurante)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Possuir__Usernam__440B1D61");
            });

            modelBuilder.Entity<PratoDia>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Descricao).IsUnicode(false);

                entity.Property(e => e.Foto).IsUnicode(false);

                entity.Property(e => e.Nome).IsUnicode(false);

                entity.Property(e => e.Tipo).IsUnicode(false);
            });

            modelBuilder.Entity<PratosFavoritos>(entity =>
            {
                entity.HasKey(e => e.IdPrato)
                    .HasName("PK__PratosFa__1DFE7420F5A0C580");

                entity.Property(e => e.IdPrato).ValueGeneratedNever();

                entity.Property(e => e.UsernameCliente).IsUnicode(false);

                entity.HasOne(d => d.IdPratoNavigation)
                    .WithOne(p => p.PratosFavoritos)
                    .HasForeignKey<PratosFavoritos>(d => d.IdPrato)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PratosFav__Id_Pr__2C3393D0");

                entity.HasOne(d => d.UsernameClienteNavigation)
                    .WithMany(p => p.PratosFavoritos)
                    .HasForeignKey(d => d.UsernameCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PratosFav__Usern__2B3F6F97");
            });

            modelBuilder.Entity<Restaurante>(entity =>
            {
                entity.HasKey(e => e.Username)
                    .HasName("PK__Restaura__536C85E5C7F21B4A");

                entity.Property(e => e.Username).IsUnicode(false);

                entity.Property(e => e.DiaDescanso).IsUnicode(false);

                entity.Property(e => e.Foto).IsUnicode(false);

                entity.Property(e => e.Gps).IsUnicode(false);

                entity.Property(e => e.Horario).IsUnicode(false);

                entity.Property(e => e.Morada).IsUnicode(false);

                entity.Property(e => e.Nome).IsUnicode(false);

                entity.Property(e => e.QuemAprovou).IsUnicode(false);

                entity.Property(e => e.TipoServico).IsUnicode(false);

                entity.HasOne(d => d.UsernameNavigation)
                    .WithOne(p => p.Restaurante)
                    .HasForeignKey<Restaurante>(d => d.Username)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Restauran__Usern__31EC6D26");
            });

            modelBuilder.Entity<RestaurantesFavoritos>(entity =>
            {
                entity.HasKey(e => e.UsernameRestaurante)
                    .HasName("PK__Restaura__1A7D218F9084FC44");

                entity.Property(e => e.UsernameRestaurante).IsUnicode(false);

                entity.Property(e => e.UsernameCliente).IsUnicode(false);

                entity.HasOne(d => d.UsernameClienteNavigation)
                    .WithMany(p => p.RestaurantesFavoritos)
                    .HasForeignKey(d => d.UsernameCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Restauran__Usern__34C8D9D1");

                entity.HasOne(d => d.UsernameRestauranteNavigation)
                    .WithOne(p => p.RestaurantesFavoritos)
                    .HasForeignKey<RestaurantesFavoritos>(d => d.UsernameRestaurante)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Restauran__Usern__35BCFE0A");
            });

            modelBuilder.Entity<Utilizador>(entity =>
            {
                entity.HasKey(e => e.Username)
                    .HasName("PK__Utilizad__F3DBC573CFA04D26");

                entity.Property(e => e.Username).IsUnicode(false);

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.Foto).IsUnicode(false);

                entity.Property(e => e.Nome).IsUnicode(false);

                entity.Property(e => e.PassWord).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
