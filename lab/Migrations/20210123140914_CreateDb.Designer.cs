﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using lab.Data;

namespace lab.Migrations
{
    [DbContext(typeof(labContext))]
    [Migration("20210123140914_CreateDb")]
    partial class CreateDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("lab.Models.Administrador", b =>
                {
                    b.Property<string>("Username")
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.HasKey("Username")
                        .HasName("PK__Administ__536C85E5E8605C9E");

                    b.ToTable("Administrador");
                });

            modelBuilder.Entity("lab.Models.AvaliarPratos", b =>
                {
                    b.Property<string>("UsernameCliente")
                        .HasColumnName("Username_Cliente")
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.Property<int>("IdPrato")
                        .HasColumnName("Id_prato")
                        .HasColumnType("int");

                    b.Property<int?>("Avaliacao")
                        .HasColumnName("avaliacao")
                        .HasColumnType("int");

                    b.Property<string>("Comentario")
                        .HasColumnName("comentario")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("UsernameCliente", "IdPrato")
                        .HasName("PK__Avaliar___E99671B0D641A2AB");

                    b.HasIndex("IdPrato");

                    b.ToTable("Avaliar_pratos");
                });

            modelBuilder.Entity("lab.Models.AvaliarRestaurates", b =>
                {
                    b.Property<string>("UsernameRestaurante")
                        .HasColumnName("Username_Restaurante")
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.Property<string>("UsernameCliente")
                        .HasColumnName("Username_Cliente")
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.Property<int?>("Avaliacao")
                        .HasColumnName("avaliacao")
                        .HasColumnType("int");

                    b.Property<string>("Comentario")
                        .HasColumnName("comentario")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("UsernameRestaurante", "UsernameCliente")
                        .HasName("PK__Avaliar___19552EDD7199D50E");

                    b.HasIndex("UsernameCliente");

                    b.ToTable("Avaliar_restaurates");
                });

            modelBuilder.Entity("lab.Models.Bloquear", b =>
                {
                    b.Property<string>("UsernameUtilizador")
                        .HasColumnName("Username_Utilizador")
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.Property<DateTime>("DataBloqueio")
                        .HasColumnType("date");

                    b.Property<string>("Motivo")
                        .IsRequired()
                        .HasColumnName("motivo")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("UsernameAdministrador")
                        .IsRequired()
                        .HasColumnName("Username_Administrador")
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.HasKey("UsernameUtilizador", "DataBloqueio")
                        .HasName("PK__Bloquear__AA645613A67386E0");

                    b.HasIndex("UsernameAdministrador");

                    b.ToTable("Bloquear");
                });

            modelBuilder.Entity("lab.Models.Cliente", b =>
                {
                    b.Property<string>("Username")
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.HasKey("Username")
                        .HasName("PK__Cliente__536C85E57F382FFA");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("lab.Models.Possuir", b =>
                {
                    b.Property<int>("IdPrato")
                        .HasColumnName("ID_Prato")
                        .HasColumnType("int");

                    b.Property<string>("UsernameRestaurante")
                        .HasColumnName("Username_Restaurante")
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.Property<DateTime>("DataPratoDia")
                        .HasColumnName("Data_PratoDia")
                        .HasColumnType("date");

                    b.HasKey("IdPrato", "UsernameRestaurante")
                        .HasName("PK__Possuir__39240DE5C96464DC");

                    b.HasIndex("UsernameRestaurante");

                    b.ToTable("Possuir");
                });

            modelBuilder.Entity("lab.Models.PratoDia", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnName("ID")
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnName("descricao")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<string>("Foto")
                        .HasColumnName("foto")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(35)")
                        .HasMaxLength(35)
                        .IsUnicode(false);

                    b.Property<double>("Preco")
                        .HasColumnName("preco")
                        .HasColumnType("float");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnName("tipo")
                        .HasColumnType("varchar(15)")
                        .HasMaxLength(15)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("Prato_Dia");
                });

            modelBuilder.Entity("lab.Models.PratosFavoritos", b =>
                {
                    b.Property<int>("IdPrato")
                        .HasColumnName("Id_Prato")
                        .HasColumnType("int");

                    b.Property<string>("UsernameCliente")
                        .IsRequired()
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.HasKey("IdPrato")
                        .HasName("PK__PratosFa__1DFE7420F5A0C580");

                    b.HasIndex("UsernameCliente");

                    b.ToTable("PratosFavoritos");
                });

            modelBuilder.Entity("lab.Models.Restaurante", b =>
                {
                    b.Property<string>("Username")
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.Property<string>("DiaDescanso")
                        .IsRequired()
                        .HasColumnName("Dia_Descanso")
                        .HasColumnType("varchar(25)")
                        .HasMaxLength(25)
                        .IsUnicode(false);

                    b.Property<string>("Foto")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("Gps")
                        .IsRequired()
                        .HasColumnName("gps")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("Horario")
                        .IsRequired()
                        .HasColumnName("horario")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<string>("Morada")
                        .IsRequired()
                        .HasColumnName("morada")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(35)")
                        .HasMaxLength(35)
                        .IsUnicode(false);

                    b.Property<string>("QuemAprovou")
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.Property<int>("Telefone")
                        .HasColumnName("telefone")
                        .HasColumnType("int");

                    b.Property<string>("TipoServico")
                        .IsRequired()
                        .HasColumnName("tipo_servico")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("Username")
                        .HasName("PK__Restaura__536C85E5C7F21B4A");

                    b.ToTable("Restaurante");
                });

            modelBuilder.Entity("lab.Models.RestaurantesFavoritos", b =>
                {
                    b.Property<string>("UsernameRestaurante")
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.Property<string>("UsernameCliente")
                        .IsRequired()
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.HasKey("UsernameRestaurante")
                        .HasName("PK__Restaura__1A7D218F9084FC44");

                    b.HasIndex("UsernameCliente");

                    b.ToTable("RestaurantesFavoritos");
                });

            modelBuilder.Entity("lab.Models.Utilizador", b =>
                {
                    b.Property<string>("Username")
                        .HasColumnName("username")
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.Property<bool>("ContaConfirmada")
                        .HasColumnType("bit");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("email")
                        .HasColumnType("varchar(35)")
                        .HasMaxLength(35)
                        .IsUnicode(false);

                    b.Property<string>("Foto")
                        .HasColumnName("foto")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("nome")
                        .HasColumnType("varchar(35)")
                        .HasMaxLength(35)
                        .IsUnicode(false);

                    b.Property<string>("PassWord")
                        .IsRequired()
                        .HasColumnName("pass_word")
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.HasKey("Username")
                        .HasName("PK__Utilizad__F3DBC573CFA04D26");

                    b.ToTable("Utilizador");
                });

            modelBuilder.Entity("lab.Models.Administrador", b =>
                {
                    b.HasOne("lab.Models.Utilizador", "UsernameNavigation")
                        .WithOne("Administrador")
                        .HasForeignKey("lab.Models.Administrador", "Username")
                        .HasConstraintName("FK__Administr__Usern__2F10007B")
                        .IsRequired();
                });

            modelBuilder.Entity("lab.Models.AvaliarPratos", b =>
                {
                    b.HasOne("lab.Models.PratoDia", "IdPratoNavigation")
                        .WithMany("AvaliarPratos")
                        .HasForeignKey("IdPrato")
                        .HasConstraintName("FK__Avaliar_p__Id_pr__412EB0B6")
                        .IsRequired();

                    b.HasOne("lab.Models.Cliente", "UsernameClienteNavigation")
                        .WithMany("AvaliarPratos")
                        .HasForeignKey("UsernameCliente")
                        .HasConstraintName("FK__Avaliar_p__Usern__403A8C7D")
                        .IsRequired();
                });

            modelBuilder.Entity("lab.Models.AvaliarRestaurates", b =>
                {
                    b.HasOne("lab.Models.Cliente", "UsernameClienteNavigation")
                        .WithMany("AvaliarRestaurates")
                        .HasForeignKey("UsernameCliente")
                        .HasConstraintName("FK__Avaliar_r__Usern__3C69FB99")
                        .IsRequired();

                    b.HasOne("lab.Models.Restaurante", "UsernameRestauranteNavigation")
                        .WithMany("AvaliarRestaurates")
                        .HasForeignKey("UsernameRestaurante")
                        .HasConstraintName("FK__Avaliar_r__Usern__3D5E1FD2")
                        .IsRequired();
                });

            modelBuilder.Entity("lab.Models.Bloquear", b =>
                {
                    b.HasOne("lab.Models.Administrador", "UsernameAdministradorNavigation")
                        .WithMany("Bloquear")
                        .HasForeignKey("UsernameAdministrador")
                        .HasConstraintName("FK__Bloquear__Userna__38996AB5")
                        .IsRequired();

                    b.HasOne("lab.Models.Utilizador", "UsernameUtilizadorNavigation")
                        .WithMany("Bloquear")
                        .HasForeignKey("UsernameUtilizador")
                        .HasConstraintName("FK__Bloquear__Userna__398D8EEE")
                        .IsRequired();
                });

            modelBuilder.Entity("lab.Models.Cliente", b =>
                {
                    b.HasOne("lab.Models.Utilizador", "UsernameNavigation")
                        .WithOne("Cliente")
                        .HasForeignKey("lab.Models.Cliente", "Username")
                        .HasConstraintName("FK__Cliente__Usernam__267ABA7A")
                        .IsRequired();
                });

            modelBuilder.Entity("lab.Models.Possuir", b =>
                {
                    b.HasOne("lab.Models.PratoDia", "IdPratoNavigation")
                        .WithMany("Possuir")
                        .HasForeignKey("IdPrato")
                        .HasConstraintName("FK__Possuir__ID_Prat__44FF419A")
                        .IsRequired();

                    b.HasOne("lab.Models.Restaurante", "UsernameRestauranteNavigation")
                        .WithMany("Possuir")
                        .HasForeignKey("UsernameRestaurante")
                        .HasConstraintName("FK__Possuir__Usernam__440B1D61")
                        .IsRequired();
                });

            modelBuilder.Entity("lab.Models.PratosFavoritos", b =>
                {
                    b.HasOne("lab.Models.PratoDia", "IdPratoNavigation")
                        .WithOne("PratosFavoritos")
                        .HasForeignKey("lab.Models.PratosFavoritos", "IdPrato")
                        .HasConstraintName("FK__PratosFav__Id_Pr__2C3393D0")
                        .IsRequired();

                    b.HasOne("lab.Models.Cliente", "UsernameClienteNavigation")
                        .WithMany("PratosFavoritos")
                        .HasForeignKey("UsernameCliente")
                        .HasConstraintName("FK__PratosFav__Usern__2B3F6F97")
                        .IsRequired();
                });

            modelBuilder.Entity("lab.Models.Restaurante", b =>
                {
                    b.HasOne("lab.Models.Utilizador", "UsernameNavigation")
                        .WithOne("Restaurante")
                        .HasForeignKey("lab.Models.Restaurante", "Username")
                        .HasConstraintName("FK__Restauran__Usern__31EC6D26")
                        .IsRequired();
                });

            modelBuilder.Entity("lab.Models.RestaurantesFavoritos", b =>
                {
                    b.HasOne("lab.Models.Cliente", "UsernameClienteNavigation")
                        .WithMany("RestaurantesFavoritos")
                        .HasForeignKey("UsernameCliente")
                        .HasConstraintName("FK__Restauran__Usern__34C8D9D1")
                        .IsRequired();

                    b.HasOne("lab.Models.Restaurante", "UsernameRestauranteNavigation")
                        .WithOne("RestaurantesFavoritos")
                        .HasForeignKey("lab.Models.RestaurantesFavoritos", "UsernameRestaurante")
                        .HasConstraintName("FK__Restauran__Usern__35BCFE0A")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
