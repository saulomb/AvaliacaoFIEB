using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Avaliacao.Data.Migrations
{
    public partial class CriandoDataBaseInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FuncionarioCargo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(40)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuncionarioCargo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Funcionario",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(250)", nullable: true),
                    Cpf = table.Column<string>(type: "char(11)", nullable: true),
                    Email = table.Column<string>(type: "varchar(250)", nullable: true),
                    Telefone = table.Column<string>(type: "char(11)", nullable: true),
                    Habilitado = table.Column<bool>(nullable: false),
                    Ingles = table.Column<bool>(nullable: true),
                    Espanhol = table.Column<bool>(nullable: true),
                    Frances = table.Column<bool>(nullable: true),
                    Categoria = table.Column<string>(type: "char(1)", nullable: false),
                    CargoId = table.Column<int>(nullable: false),
                    Salario = table.Column<decimal>(type: "money", nullable: false),
                    Logradouro = table.Column<string>(type: "varchar(50)", nullable: true),
                    Numero = table.Column<string>(type: "varchar(10)", nullable: true),
                    Complemento = table.Column<string>(type: "varchar(100)", nullable: true),
                    Bairro = table.Column<string>(type: "varchar(50)", nullable: true),
                    Cep = table.Column<string>(type: "char(10)", nullable: true),
                    Cidade = table.Column<string>(type: "varchar(80)", nullable: true),
                    Estado = table.Column<string>(type: "char(2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Funcionario_FuncionarioCargo_CargoId",
                        column: x => x.CargoId,
                        principalTable: "FuncionarioCargo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FuncionarioEscala",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FuncionarioId = table.Column<int>(nullable: false),
                    DiaDaSemana = table.Column<int>(nullable: false),
                    HoraInicio = table.Column<TimeSpan>(type: "time(7)", nullable: false),
                    HoraTermino = table.Column<TimeSpan>(type: "time(7)", nullable: false),
                    TempoDescanso = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuncionarioEscala", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FuncionarioEscala_Funcionario_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Funcionario_CargoId",
                table: "Funcionario",
                column: "CargoId");

            migrationBuilder.CreateIndex(
                name: "IX_FuncionarioEscala_FuncionarioId",
                table: "FuncionarioEscala",
                column: "FuncionarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FuncionarioEscala");

            migrationBuilder.DropTable(
                name: "Funcionario");

            migrationBuilder.DropTable(
                name: "FuncionarioCargo");
        }
    }
}
