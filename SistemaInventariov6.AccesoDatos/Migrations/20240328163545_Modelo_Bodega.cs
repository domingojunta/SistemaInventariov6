using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaInventariov6.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class Modelo_Bodega : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "bodegas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bodegas", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bodegas");
        }
    }
}
