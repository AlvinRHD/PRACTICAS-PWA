using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tarea1.Migrations
{
    /// <inheritdoc />
    public partial class BD : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_Casa",
                columns: table => new
                {
                    idCasa = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Casa", x => x.idCasa);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Categoria",
                columns: table => new
                {
                    idCategoria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    orden = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Categoria", x => x.idCategoria);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Producto",
                columns: table => new
                {
                    idProducto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    descripcionCorta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Precio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    imagen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    idCategproia = table.Column<int>(type: "int", nullable: false),
                    idCategoria = table.Column<int>(type: "int", nullable: false),
                    idCasa = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Producto", x => x.idProducto);
                    table.ForeignKey(
                        name: "FK_tbl_Producto_tbl_Casa_idCasa",
                        column: x => x.idCasa,
                        principalTable: "tbl_Casa",
                        principalColumn: "idCasa",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_Producto_tbl_Categoria_idCategoria",
                        column: x => x.idCategoria,
                        principalTable: "tbl_Categoria",
                        principalColumn: "idCategoria",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Producto_idCasa",
                table: "tbl_Producto",
                column: "idCasa");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Producto_idCategoria",
                table: "tbl_Producto",
                column: "idCategoria");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_Producto");

            migrationBuilder.DropTable(
                name: "tbl_Casa");

            migrationBuilder.DropTable(
                name: "tbl_Categoria");
        }
    }
}
