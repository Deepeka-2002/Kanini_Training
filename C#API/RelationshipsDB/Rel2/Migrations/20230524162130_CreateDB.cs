using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rel2.Migrations
{
    /// <inheritdoc />
    public partial class CreateDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Depts",
                columns: table => new
                {
                    Deptno = table.Column<int>(type: "int", nullable: false),
                    Deptname = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Depts", x => x.Deptno);
                });

            migrationBuilder.CreateTable(
                name: "Emps",
                columns: table => new
                {
                    Empno = table.Column<int>(type: "int", nullable: false),
                    EName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Deptno = table.Column<int>(type: "int", nullable: true),
                    DeptnoNavigationDeptno = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emps", x => x.Empno);
                    table.ForeignKey(
                        name: "FK_Emps_Depts_DeptnoNavigationDeptno",
                        column: x => x.DeptnoNavigationDeptno,
                        principalTable: "Depts",
                        principalColumn: "Deptno");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Emps_DeptnoNavigationDeptno",
                table: "Emps",
                column: "DeptnoNavigationDeptno");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Emps");

            migrationBuilder.DropTable(
                name: "Depts");
        }
    }
}
