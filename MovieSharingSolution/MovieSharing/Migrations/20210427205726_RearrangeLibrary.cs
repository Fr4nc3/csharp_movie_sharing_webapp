using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieSharing.Migrations
{
    public partial class RearrangeLibrary : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BorrowMovie");

            migrationBuilder.RenameColumn(
                name: "OwnerRealmId",
                table: "Movie",
                newName: "OwnerName");

            migrationBuilder.AddColumn<string>(
                name: "OwnerEmailAddress",
                table: "Movie",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Movie",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OwnerEmailAddress",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Movie");

            migrationBuilder.RenameColumn(
                name: "OwnerName",
                table: "Movie",
                newName: "OwnerRealmId");

            migrationBuilder.CreateTable(
                name: "BorrowMovie",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieID = table.Column<long>(type: "bigint", nullable: false),
                    SharedWithEmailAddress = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    SharedWithName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Status = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BorrowMovie", x => x.ID);
                });
        }
    }
}
