using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Autenticacao.Migrations
{
    public partial class inicio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Perfil",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Nome = table.Column<string>(maxLength: 256, nullable: true),
                    NomeNormalizado = table.Column<string>(maxLength: 256, nullable: true),
                    ChaveAlteracao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perfil", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    NomeUsuario = table.Column<string>(maxLength: 256, nullable: true),
                    NomeUsuarioNormalizado = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    EmailNormalizado = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmado = table.Column<bool>(nullable: false),
                    Senha = table.Column<string>(nullable: true),
                    ChaveSenha = table.Column<string>(nullable: true),
                    ChaveAlteracao = table.Column<string>(nullable: true),
                    Telefone = table.Column<string>(nullable: true),
                    TelefoneConfirmado = table.Column<bool>(nullable: false),
                    DoisFatoresAtivado = table.Column<bool>(nullable: false),
                    Saida = table.Column<DateTimeOffset>(nullable: true),
                    PodeSair = table.Column<bool>(nullable: false),
                    QuantidadeFalhas = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PerfilAtributo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PerfilId = table.Column<string>(nullable: false),
                    TipoAtributo = table.Column<string>(nullable: true),
                    ValorAtributo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PerfilAtributo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PerfilAtributo_Perfil_PerfilId",
                        column: x => x.PerfilId,
                        principalTable: "Perfil",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioAtributo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UsuarioId = table.Column<string>(nullable: false),
                    TipoAtributo = table.Column<string>(nullable: true),
                    ValorAtributo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioAtributo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsuarioAtributo_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioPerfil",
                columns: table => new
                {
                    UsuarioId = table.Column<string>(nullable: false),
                    PerfilId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioPerfil", x => new { x.UsuarioId, x.PerfilId });
                    table.ForeignKey(
                        name: "FK_UsuarioPerfil_Perfil_PerfilId",
                        column: x => x.PerfilId,
                        principalTable: "Perfil",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuarioPerfil_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioProvedor",
                columns: table => new
                {
                    UsuarioId = table.Column<string>(nullable: false),
                    LoginProvedor = table.Column<string>(maxLength: 128, nullable: false),
                    Nome = table.Column<string>(maxLength: 128, nullable: false),
                    Valor = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioProvedor", x => new { x.UsuarioId, x.LoginProvedor, x.Nome });
                    table.ForeignKey(
                        name: "FK_UsuarioProvedor_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioProvedorLogin",
                columns: table => new
                {
                    LoginProvedor = table.Column<string>(maxLength: 128, nullable: false),
                    ChaveProvedor = table.Column<string>(maxLength: 128, nullable: false),
                    NomeProvedor = table.Column<string>(nullable: true),
                    UsuarioId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioProvedorLogin", x => new { x.LoginProvedor, x.ChaveProvedor });
                    table.ForeignKey(
                        name: "FK_UsuarioProvedorLogin_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Perfil",
                column: "NomeNormalizado",
                unique: true,
                filter: "[NomeNormalizado] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_PerfilAtributo_PerfilId",
                table: "PerfilAtributo",
                column: "PerfilId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Usuario",
                column: "EmailNormalizado");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Usuario",
                column: "NomeUsuarioNormalizado",
                unique: true,
                filter: "[NomeUsuarioNormalizado] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioAtributo_UsuarioId",
                table: "UsuarioAtributo",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioPerfil_PerfilId",
                table: "UsuarioPerfil",
                column: "PerfilId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioProvedorLogin_UsuarioId",
                table: "UsuarioProvedorLogin",
                column: "UsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PerfilAtributo");

            migrationBuilder.DropTable(
                name: "UsuarioAtributo");

            migrationBuilder.DropTable(
                name: "UsuarioPerfil");

            migrationBuilder.DropTable(
                name: "UsuarioProvedor");

            migrationBuilder.DropTable(
                name: "UsuarioProvedorLogin");

            migrationBuilder.DropTable(
                name: "Perfil");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
