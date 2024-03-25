using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace One_to_Many_Relationship.Migrations
{
    /// <inheritdoc />
    public partial class mig_3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Calisanlar_Departmen_DId",
                table: "Calisanlar");

            migrationBuilder.AlterColumn<int>(
                name: "DId",
                table: "Calisanlar",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Calisanlar_Departmen_DId",
                table: "Calisanlar",
                column: "DId",
                principalTable: "Departmen",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Calisanlar_Departmen_DId",
                table: "Calisanlar");

            migrationBuilder.AlterColumn<int>(
                name: "DId",
                table: "Calisanlar",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Calisanlar_Departmen_DId",
                table: "Calisanlar",
                column: "DId",
                principalTable: "Departmen",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
