using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace L2.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Studios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FoundedYear = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Studios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AnimeCharacters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimeCharacters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnimeCharacters_Studios_StudioId",
                        column: x => x.StudioId,
                        principalTable: "Studios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Studios",
                columns: new[] { "Id", "Country", "FoundedYear", "Name" },
                values: new object[,]
                {
                    { 1, "Япония", 1979, "Pierrot" },
                    { 2, "Япония", 1948, "Toei Animation" },
                    { 3, "Япония", 1972, "Madhouse" }
                });

            migrationBuilder.InsertData(
                table: "AnimeCharacters",
                columns: new[] { "Id", "Age", "Description", "ImageUrl", "Name", "StudioId" },
                values: new object[,]
                {
                    { 1, 17, "Ниндзя.", "https://i1-c.pinimg.com/736x/85/2c/88/852c880e20debd8b1ed40b1ce53aa250.jpg", "Наруто Узумаки", 1 },
                    { 2, 35, "Сайян, защищающий Землю.", "https://i.pinimg.com/736x/e1/c4/d1/e1c4d1af1e67fa17ffa976df8285fcfc.jpg", "Гоку", 2 },
                    { 3, 23, "Гениальный школьник, нашедший тетрадь смерти.", "https://i.pinimg.com/736x/02/c1/11/02c11137c640b5a14e8428308a0a56ba.jpg", "Лайт Ягами", 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnimeCharacters_StudioId",
                table: "AnimeCharacters",
                column: "StudioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnimeCharacters");

            migrationBuilder.DropTable(
                name: "Studios");
        }
    }
}
