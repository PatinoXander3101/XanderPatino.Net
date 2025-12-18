using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Servicios.Migrations
{
    /// <inheritdoc />
    public partial class FK_CategoriaServicio_EnServicios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tecnicos");

            migrationBuilder.DropIndex(
                name: "IX_ServiciosManoObra_Codigo_Nombre",
                table: "ServiciosManoObra");

            migrationBuilder.DropColumn(
                name: "Categoria",
                table: "ServiciosManoObra");

            migrationBuilder.AddColumn<int>(
                name: "CategoriaServicioId",
                table: "ServiciosManoObra",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "CategoriasServicio",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ActualizadoPor",
                table: "CategoriasServicio",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreadoPor",
                table: "CategoriasServicio",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaActualizacion",
                table: "CategoriasServicio",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaCreacion",
                table: "CategoriasServicio",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_ServiciosManoObra_CategoriaServicioId_Activo",
                table: "ServiciosManoObra",
                columns: new[] { "CategoriaServicioId", "Activo" });

            migrationBuilder.CreateIndex(
                name: "IX_ServiciosManoObra_Codigo",
                table: "ServiciosManoObra",
                column: "Codigo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ServiciosManoObra_Nombre",
                table: "ServiciosManoObra",
                column: "Nombre");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiciosManoObra_CategoriasServicio_CategoriaServicioId",
                table: "ServiciosManoObra",
                column: "CategoriaServicioId",
                principalTable: "CategoriasServicio",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiciosManoObra_CategoriasServicio_CategoriaServicioId",
                table: "ServiciosManoObra");

            migrationBuilder.DropIndex(
                name: "IX_ServiciosManoObra_CategoriaServicioId_Activo",
                table: "ServiciosManoObra");

            migrationBuilder.DropIndex(
                name: "IX_ServiciosManoObra_Codigo",
                table: "ServiciosManoObra");

            migrationBuilder.DropIndex(
                name: "IX_ServiciosManoObra_Nombre",
                table: "ServiciosManoObra");

            migrationBuilder.DropColumn(
                name: "CategoriaServicioId",
                table: "ServiciosManoObra");

            migrationBuilder.DropColumn(
                name: "ActualizadoPor",
                table: "CategoriasServicio");

            migrationBuilder.DropColumn(
                name: "CreadoPor",
                table: "CategoriasServicio");

            migrationBuilder.DropColumn(
                name: "FechaActualizacion",
                table: "CategoriasServicio");

            migrationBuilder.DropColumn(
                name: "FechaCreacion",
                table: "CategoriasServicio");

            migrationBuilder.AddColumn<string>(
                name: "Categoria",
                table: "ServiciosManoObra",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "CategoriasServicio",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Tecnicos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Activo = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Documento = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Especialidad = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    NombreCompleto = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tecnicos", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServiciosManoObra_Codigo_Nombre",
                table: "ServiciosManoObra",
                columns: new[] { "Codigo", "Nombre" });

            migrationBuilder.CreateIndex(
                name: "IX_Tecnicos_Documento",
                table: "Tecnicos",
                column: "Documento",
                unique: true,
                filter: "[Documento] IS NOT NULL");
        }
    }
}
