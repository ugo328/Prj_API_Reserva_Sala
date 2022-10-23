                aausing System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgendaSalas.Migrations
{
    public partial class Inicial01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(240)", maxLength: 240, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Celular = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cpf = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rg = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.ClienteId);
                });

            migrationBuilder.CreateTable(
                name: "Reserva",
                columns: table => new
                {
                    ReservaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FazerContratacao = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reserva", x => x.ReservaId);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(240)", maxLength: 240, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Celular = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cpf = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rg = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.UsuarioId);
                });

            migrationBuilder.CreateTable(
                name: "DisponibilidadeSala",
                columns: table => new
                {
                    DisponibilidadeSalaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReservaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisponibilidadeSala", x => x.DisponibilidadeSalaId);
                    table.ForeignKey(
                        name: "FK_DisponibilidadeSala_Reserva_ReservaId",
                        column: x => x.ReservaId,
                        principalTable: "Reserva",
                        principalColumn: "ReservaId");
                });

            migrationBuilder.CreateTable(
                name: "Equipamento",
                columns: table => new
                {
                    EquipamentosId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(550)", maxLength: 550, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(550)", maxLength: 550, nullable: false),
                    Voltagem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Peso = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Volume = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustoTotal = table.Column<float>(type: "real", nullable: false),
                    CustoSeguro = table.Column<float>(type: "real", nullable: false),
                    CustoHora = table.Column<float>(type: "real", nullable: false),
                    ReservaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipamento", x => x.EquipamentosId);
                    table.ForeignKey(
                        name: "FK_Equipamento_Reserva_ReservaId",
                        column: x => x.ReservaId,
                        principalTable: "Reserva",
                        principalColumn: "ReservaId");
                });

            migrationBuilder.CreateTable(
                name: "Obgetos",
                columns: table => new
                {
                    ObgetosID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(240)", maxLength: 240, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReservaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Obgetos", x => x.ObgetosID);
                    table.ForeignKey(
                        name: "FK_Obgetos_Reserva_ReservaId",
                        column: x => x.ReservaId,
                        principalTable: "Reserva",
                        principalColumn: "ReservaId");
                });

            migrationBuilder.CreateTable(
                name: "Servicos",
                columns: table => new
                {
                    ServicoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Custo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReservaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicos", x => x.ServicoID);
                    table.ForeignKey(
                        name: "FK_Servicos_Reserva_ReservaId",
                        column: x => x.ReservaId,
                        principalTable: "Reserva",
                        principalColumn: "ReservaId");
                });

            migrationBuilder.CreateTable(
                name: "Periodo",
                columns: table => new
                {
                    PeriodoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dia = table.Column<int>(type: "int", maxLength: 1, nullable: false),
                    Preco = table.Column<float>(type: "real", nullable: false),
                    estaAtiva = table.Column<bool>(type: "bit", nullable: true),
                    DisponibilidadeSalaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Periodo", x => x.PeriodoId);
                    table.ForeignKey(
                        name: "FK_Periodo_DisponibilidadeSala_DisponibilidadeSalaId",
                        column: x => x.DisponibilidadeSalaId,
                        principalTable: "DisponibilidadeSala",
                        principalColumn: "DisponibilidadeSalaId");
                });

            migrationBuilder.CreateTable(
                name: "Sala",
                columns: table => new
                {
                    SalaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Identificacao = table.Column<string>(type: "nvarchar(240)", maxLength: 240, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(600)", maxLength: 600, nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Voltagem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    medidaLado1EmMetros = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    medidaLado2EmMetros = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    numeroMaximoDePessoas = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    Janelas = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DisponibilidadeSalaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sala", x => x.SalaId);
                    table.ForeignKey(
                        name: "FK_Sala_DisponibilidadeSala_DisponibilidadeSalaId",
                        column: x => x.DisponibilidadeSalaId,
                        principalTable: "DisponibilidadeSala",
                        principalColumn: "DisponibilidadeSalaId");
                });

            migrationBuilder.CreateTable(
                name: "Horario",
                columns: table => new
                {
                    HorarioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Inicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Final = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PeriodoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Horario", x => x.HorarioId);
                    table.ForeignKey(
                        name: "FK_Horario_Periodo_PeriodoId",
                        column: x => x.PeriodoId,
                        principalTable: "Periodo",
                        principalColumn: "PeriodoId");
                });

            migrationBuilder.CreateTable(
                name: "Endereco",
                columns: table => new
                {
                    EnderecoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Logradouro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bairro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Numero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Complemento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SalaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endereco", x => x.EnderecoId);
                    table.ForeignKey(
                        name: "FK_Endereco_Sala_SalaId",
                        column: x => x.SalaId,
                        principalTable: "Sala",
                        principalColumn: "SalaId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DisponibilidadeSala_ReservaId",
                table: "DisponibilidadeSala",
                column: "ReservaId");

            migrationBuilder.CreateIndex(
                name: "IX_Endereco_SalaId",
                table: "Endereco",
                column: "SalaId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipamento_ReservaId",
                table: "Equipamento",
                column: "ReservaId");

            migrationBuilder.CreateIndex(
                name: "IX_Horario_PeriodoId",
                table: "Horario",
                column: "PeriodoId");

            migrationBuilder.CreateIndex(
                name: "IX_Obgetos_ReservaId",
                table: "Obgetos",
                column: "ReservaId");

            migrationBuilder.CreateIndex(
                name: "IX_Periodo_DisponibilidadeSalaId",
                table: "Periodo",
                column: "DisponibilidadeSalaId");

            migrationBuilder.CreateIndex(
                name: "IX_Sala_DisponibilidadeSalaId",
                table: "Sala",
                column: "DisponibilidadeSalaId");

            migrationBuilder.CreateIndex(
                name: "IX_Servicos_ReservaId",
                table: "Servicos",
                column: "ReservaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Endereco");

            migrationBuilder.DropTable(
                name: "Equipamento");

            migrationBuilder.DropTable(
                name: "Horario");

            migrationBuilder.DropTable(
                name: "Obgetos");

            migrationBuilder.DropTable(
                name: "Servicos");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Sala");

            migrationBuilder.DropTable(
                name: "Periodo");

            migrationBuilder.DropTable(
                name: "DisponibilidadeSala");

            migrationBuilder.DropTable(
                name: "Reserva");
        }
    }
}
