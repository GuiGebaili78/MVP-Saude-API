using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fiap.Api.MVPSaude.Migrations
{
    /// <inheritdoc />
    public partial class FirstMysql : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MEDICO",
                columns: table => new
                {
                    MEDICOID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NOMEMEDICO = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CRM = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ESPECIALIDADE = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CONTATO = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MEDICO", x => x.MEDICOID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PACIENTE",
                columns: table => new
                {
                    PACIENTEID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NOMEPACIENTE = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CPF = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DATANASCIMENTO = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    GENERO = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ENDERECO = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CONTATO = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PACIENTE", x => x.PACIENTEID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "USUARIO",
                columns: table => new
                {
                    USUARIOID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NOMEUSUARIO = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SENHAUSUARIO = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EMAILUSUARIO = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USUARIO", x => x.USUARIOID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CONSULTA",
                columns: table => new
                {
                    CONSULTAID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PACIENTEID = table.Column<int>(type: "int", nullable: false),
                    MEDICOID = table.Column<int>(type: "int", nullable: false),
                    DATACONSULTA = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    HORACONSULTA = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LOCALCONSULTA = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MENSAGEM = table.Column<string>(type: "varchar(4000)", maxLength: 4000, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CONSULTA", x => x.CONSULTAID);
                    table.ForeignKey(
                        name: "FK_CONSULTA_MEDICO_MEDICOID",
                        column: x => x.MEDICOID,
                        principalTable: "MEDICO",
                        principalColumn: "MEDICOID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CONSULTA_PACIENTE_PACIENTEID",
                        column: x => x.PACIENTEID,
                        principalTable: "PACIENTE",
                        principalColumn: "PACIENTEID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PRONTUARIO",
                columns: table => new
                {
                    PRONTUARIOID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PACIENTEID = table.Column<int>(type: "int", nullable: false),
                    HISTORICOPACIENTE = table.Column<string>(type: "varchar(4000)", maxLength: 4000, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MEDICAMENTO = table.Column<string>(type: "varchar(1000)", maxLength: 1000, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TRIAGEM = table.Column<string>(type: "varchar(1000)", maxLength: 1000, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    HISTORICOFAMILIAR = table.Column<string>(type: "varchar(2000)", maxLength: 2000, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EXAMES = table.Column<string>(type: "varchar(4000)", maxLength: 4000, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DATAPRONTUARIO = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    MEDICOID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRONTUARIO", x => x.PRONTUARIOID);
                    table.ForeignKey(
                        name: "FK_PRONTUARIO_MEDICO_MEDICOID",
                        column: x => x.MEDICOID,
                        principalTable: "MEDICO",
                        principalColumn: "MEDICOID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PRONTUARIO_PACIENTE_PACIENTEID",
                        column: x => x.PACIENTEID,
                        principalTable: "PACIENTE",
                        principalColumn: "PACIENTEID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_CONSULTA_MEDICOID",
                table: "CONSULTA",
                column: "MEDICOID");

            migrationBuilder.CreateIndex(
                name: "IX_CONSULTA_PACIENTEID",
                table: "CONSULTA",
                column: "PACIENTEID");

            migrationBuilder.CreateIndex(
                name: "IX_PRONTUARIO_MEDICOID",
                table: "PRONTUARIO",
                column: "MEDICOID");

            migrationBuilder.CreateIndex(
                name: "IX_PRONTUARIO_PACIENTEID",
                table: "PRONTUARIO",
                column: "PACIENTEID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CONSULTA");

            migrationBuilder.DropTable(
                name: "PRONTUARIO");

            migrationBuilder.DropTable(
                name: "USUARIO");

            migrationBuilder.DropTable(
                name: "MEDICO");

            migrationBuilder.DropTable(
                name: "PACIENTE");
        }
    }
}
