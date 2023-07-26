using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rel2.Migrations
{
    /// <inheritdoc />
    public partial class EmpdetailsEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmpDetails",
                columns: table => new
                {
                    Empno = table.Column<int>(type: "int", nullable: false),
                    AadharNo = table.Column<long>(type: "bigint", nullable: false),
                    PanNo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpDetails", x => x.Empno);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmpDetails");
        }
    }
}
