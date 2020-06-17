using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class MyFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Enderecos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rua = table.Column<string>(maxLength: 150, nullable: true),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    Complemento = table.Column<string>(maxLength: 50, nullable: true),
                    Cidade = table.Column<string>(maxLength: 50, nullable: true),
                    Estado = table.Column<string>(maxLength: 15, nullable: true),
                    Cep = table.Column<string>(maxLength: 12, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enderecos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Funcionarios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: true),
                    RegistroGeral = table.Column<string>(maxLength: 50, nullable: true),
                    Cpf = table.Column<long>(type: "bigint", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime", nullable: true),
                    TB_ENDERECOId = table.Column<int>(nullable: true),
                    TelefoneResidencial = table.Column<int>(type: "int", nullable: true),
                    TelefoneCelular = table.Column<int>(type: "int", nullable: true),
                    TelefoneComercial = table.Column<int>(type: "int", nullable: true),
                    Salario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Cargo = table.Column<int>(nullable: false),
                    CRM = table.Column<int>(type: "int", nullable: true),
                    TB_ATENDIMENTOId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Funcionarios_Enderecos_TB_ENDERECOId",
                        column: x => x.TB_ENDERECOId,
                        principalTable: "Enderecos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Medicamentos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(maxLength: 150, nullable: true),
                    Dosagem = table.Column<double>(nullable: false),
                    TB_ATENDIMENTOId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicamentos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pacientes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: true),
                    RegistroGeral = table.Column<string>(maxLength: 50, nullable: true),
                    Cpf = table.Column<long>(type: "bigint", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime", nullable: true),
                    TB_ENDERECOId = table.Column<int>(nullable: true),
                    TelefoneResidencial = table.Column<int>(type: "int", nullable: true),
                    TelefoneCelular = table.Column<int>(type: "int", nullable: true),
                    TelefoneComercial = table.Column<int>(type: "int", nullable: true),
                    Convenio = table.Column<string>(maxLength: 50, nullable: true),
                    TB_ATENDIMENTOId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacientes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pacientes_Enderecos_TB_ENDERECOId",
                        column: x => x.TB_ENDERECOId,
                        principalTable: "Enderecos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Atendimentos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoraEntrada = table.Column<DateTime>(type: "datetime", nullable: false),
                    HoraSaida = table.Column<DateTime>(type: "datetime", nullable: true),
                    Diagnostico = table.Column<string>(nullable: true),
                    TB_FUNCIONARIOId = table.Column<int>(nullable: true),
                    TB_PACIENTEId = table.Column<int>(nullable: true),
                    ClassificacaoDeRisco = table.Column<int>(nullable: false),
                    Retorno = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atendimentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Atendimentos_Funcionarios_TB_FUNCIONARIOId",
                        column: x => x.TB_FUNCIONARIOId,
                        principalTable: "Funcionarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Atendimentos_Pacientes_TB_PACIENTEId",
                        column: x => x.TB_PACIENTEId,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Atendimentos_TB_FUNCIONARIOId",
                table: "Atendimentos",
                column: "TB_FUNCIONARIOId");

            migrationBuilder.CreateIndex(
                name: "IX_Atendimentos_TB_PACIENTEId",
                table: "Atendimentos",
                column: "TB_PACIENTEId");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_TB_ATENDIMENTOId",
                table: "Funcionarios",
                column: "TB_ATENDIMENTOId");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_TB_ENDERECOId",
                table: "Funcionarios",
                column: "TB_ENDERECOId");

            migrationBuilder.CreateIndex(
                name: "IX_Medicamentos_TB_ATENDIMENTOId",
                table: "Medicamentos",
                column: "TB_ATENDIMENTOId");

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_TB_ATENDIMENTOId",
                table: "Pacientes",
                column: "TB_ATENDIMENTOId");

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_TB_ENDERECOId",
                table: "Pacientes",
                column: "TB_ENDERECOId");

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionarios_Atendimentos_TB_ATENDIMENTOId",
                table: "Funcionarios",
                column: "TB_ATENDIMENTOId",
                principalTable: "Atendimentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Medicamentos_Atendimentos_TB_ATENDIMENTOId",
                table: "Medicamentos",
                column: "TB_ATENDIMENTOId",
                principalTable: "Atendimentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pacientes_Atendimentos_TB_ATENDIMENTOId",
                table: "Pacientes",
                column: "TB_ATENDIMENTOId",
                principalTable: "Atendimentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Atendimentos_Funcionarios_TB_FUNCIONARIOId",
                table: "Atendimentos");

            migrationBuilder.DropForeignKey(
                name: "FK_Atendimentos_Pacientes_TB_PACIENTEId",
                table: "Atendimentos");

            migrationBuilder.DropTable(
                name: "Medicamentos");

            migrationBuilder.DropTable(
                name: "Funcionarios");

            migrationBuilder.DropTable(
                name: "Pacientes");

            migrationBuilder.DropTable(
                name: "Atendimentos");

            migrationBuilder.DropTable(
                name: "Enderecos");
        }
    }
}
