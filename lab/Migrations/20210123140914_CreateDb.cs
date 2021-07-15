using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace lab.Migrations
{
    public partial class CreateDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Prato_Dia",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(unicode: false, maxLength: 35, nullable: false),
                    tipo = table.Column<string>(unicode: false, maxLength: 15, nullable: false),
                    preco = table.Column<double>(nullable: false),
                    descricao = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    foto = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prato_Dia", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Utilizador",
                columns: table => new
                {
                    username = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
                    nome = table.Column<string>(unicode: false, maxLength: 35, nullable: false),
                    email = table.Column<string>(unicode: false, maxLength: 35, nullable: false),
                    pass_word = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
                    foto = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    ContaConfirmada = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Utilizad__F3DBC573CFA04D26", x => x.username);
                });

            migrationBuilder.CreateTable(
                name: "Administrador",
                columns: table => new
                {
                    Username = table.Column<string>(unicode: false, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Administ__536C85E5E8605C9E", x => x.Username);
                    table.ForeignKey(
                        name: "FK__Administr__Usern__2F10007B",
                        column: x => x.Username,
                        principalTable: "Utilizador",
                        principalColumn: "username",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Username = table.Column<string>(unicode: false, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Cliente__536C85E57F382FFA", x => x.Username);
                    table.ForeignKey(
                        name: "FK__Cliente__Usernam__267ABA7A",
                        column: x => x.Username,
                        principalTable: "Utilizador",
                        principalColumn: "username",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Restaurante",
                columns: table => new
                {
                    Username = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
                    Nome = table.Column<string>(unicode: false, maxLength: 35, nullable: false),
                    morada = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    telefone = table.Column<int>(nullable: false),
                    gps = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    horario = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    Dia_Descanso = table.Column<string>(unicode: false, maxLength: 25, nullable: false),
                    tipo_servico = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Foto = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    QuemAprovou = table.Column<string>(unicode: false, maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Restaura__536C85E5C7F21B4A", x => x.Username);
                    table.ForeignKey(
                        name: "FK__Restauran__Usern__31EC6D26",
                        column: x => x.Username,
                        principalTable: "Utilizador",
                        principalColumn: "username",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Bloquear",
                columns: table => new
                {
                    Username_Utilizador = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
                    DataBloqueio = table.Column<DateTime>(type: "date", nullable: false),
                    Username_Administrador = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
                    motivo = table.Column<string>(unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Bloquear__AA645613A67386E0", x => new { x.Username_Utilizador, x.DataBloqueio });
                    table.ForeignKey(
                        name: "FK__Bloquear__Userna__38996AB5",
                        column: x => x.Username_Administrador,
                        principalTable: "Administrador",
                        principalColumn: "Username",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Bloquear__Userna__398D8EEE",
                        column: x => x.Username_Utilizador,
                        principalTable: "Utilizador",
                        principalColumn: "username",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Avaliar_pratos",
                columns: table => new
                {
                    Id_prato = table.Column<int>(nullable: false),
                    Username_Cliente = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
                    avaliacao = table.Column<int>(nullable: true),
                    comentario = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Avaliar___E99671B0D641A2AB", x => new { x.Username_Cliente, x.Id_prato });
                    table.ForeignKey(
                        name: "FK__Avaliar_p__Id_pr__412EB0B6",
                        column: x => x.Id_prato,
                        principalTable: "Prato_Dia",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Avaliar_p__Usern__403A8C7D",
                        column: x => x.Username_Cliente,
                        principalTable: "Cliente",
                        principalColumn: "Username",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PratosFavoritos",
                columns: table => new
                {
                    Id_Prato = table.Column<int>(nullable: false),
                    UsernameCliente = table.Column<string>(unicode: false, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__PratosFa__1DFE7420F5A0C580", x => x.Id_Prato);
                    table.ForeignKey(
                        name: "FK__PratosFav__Id_Pr__2C3393D0",
                        column: x => x.Id_Prato,
                        principalTable: "Prato_Dia",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__PratosFav__Usern__2B3F6F97",
                        column: x => x.UsernameCliente,
                        principalTable: "Cliente",
                        principalColumn: "Username",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Avaliar_restaurates",
                columns: table => new
                {
                    Username_Restaurante = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
                    Username_Cliente = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
                    avaliacao = table.Column<int>(nullable: true),
                    comentario = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Avaliar___19552EDD7199D50E", x => new { x.Username_Restaurante, x.Username_Cliente });
                    table.ForeignKey(
                        name: "FK__Avaliar_r__Usern__3C69FB99",
                        column: x => x.Username_Cliente,
                        principalTable: "Cliente",
                        principalColumn: "Username",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Avaliar_r__Usern__3D5E1FD2",
                        column: x => x.Username_Restaurante,
                        principalTable: "Restaurante",
                        principalColumn: "Username",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Possuir",
                columns: table => new
                {
                    ID_Prato = table.Column<int>(nullable: false),
                    Username_Restaurante = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
                    Data_PratoDia = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Possuir__39240DE5C96464DC", x => new { x.ID_Prato, x.Username_Restaurante });
                    table.ForeignKey(
                        name: "FK__Possuir__ID_Prat__44FF419A",
                        column: x => x.ID_Prato,
                        principalTable: "Prato_Dia",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Possuir__Usernam__440B1D61",
                        column: x => x.Username_Restaurante,
                        principalTable: "Restaurante",
                        principalColumn: "Username",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RestaurantesFavoritos",
                columns: table => new
                {
                    UsernameRestaurante = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
                    UsernameCliente = table.Column<string>(unicode: false, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Restaura__1A7D218F9084FC44", x => x.UsernameRestaurante);
                    table.ForeignKey(
                        name: "FK__Restauran__Usern__34C8D9D1",
                        column: x => x.UsernameCliente,
                        principalTable: "Cliente",
                        principalColumn: "Username",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Restauran__Usern__35BCFE0A",
                        column: x => x.UsernameRestaurante,
                        principalTable: "Restaurante",
                        principalColumn: "Username",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Avaliar_pratos_Id_prato",
                table: "Avaliar_pratos",
                column: "Id_prato");

            migrationBuilder.CreateIndex(
                name: "IX_Avaliar_restaurates_Username_Cliente",
                table: "Avaliar_restaurates",
                column: "Username_Cliente");

            migrationBuilder.CreateIndex(
                name: "IX_Bloquear_Username_Administrador",
                table: "Bloquear",
                column: "Username_Administrador");

            migrationBuilder.CreateIndex(
                name: "IX_Possuir_Username_Restaurante",
                table: "Possuir",
                column: "Username_Restaurante");

            migrationBuilder.CreateIndex(
                name: "IX_PratosFavoritos_UsernameCliente",
                table: "PratosFavoritos",
                column: "UsernameCliente");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantesFavoritos_UsernameCliente",
                table: "RestaurantesFavoritos",
                column: "UsernameCliente");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Avaliar_pratos");

            migrationBuilder.DropTable(
                name: "Avaliar_restaurates");

            migrationBuilder.DropTable(
                name: "Bloquear");

            migrationBuilder.DropTable(
                name: "Possuir");

            migrationBuilder.DropTable(
                name: "PratosFavoritos");

            migrationBuilder.DropTable(
                name: "RestaurantesFavoritos");

            migrationBuilder.DropTable(
                name: "Administrador");

            migrationBuilder.DropTable(
                name: "Prato_Dia");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Restaurante");

            migrationBuilder.DropTable(
                name: "Utilizador");
        }
    }
}
