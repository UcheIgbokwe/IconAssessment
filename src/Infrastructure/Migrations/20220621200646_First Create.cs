using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class FirstCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LogisticsDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WeightKg_Weight = table.Column<double>(type: "float", nullable: true),
                    Dimension_Width = table.Column<double>(type: "float", maxLength: 255, nullable: true),
                    Dimension_Height = table.Column<double>(type: "float", maxLength: 255, nullable: true),
                    Dimension_Depth = table.Column<double>(type: "float", maxLength: 255, nullable: true),
                    Dimension_CalculatedDimension = table.Column<double>(type: "float", maxLength: 255, nullable: true)
                },
                constraints: table => table.PrimaryKey("PK_LogisticsDetails", x => x.Id));

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LogisticsUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_LogisticsDetails_LogisticsUserId",
                        column: x => x.LogisticsUserId,
                        principalTable: "LogisticsDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_LogisticsUserId",
                table: "User",
                column: "LogisticsUserId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "LogisticsDetails");
        }
    }
}
