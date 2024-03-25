using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace One_to_Many_Relationship.Migrations
{
    /// <inheritdoc />
    public partial class mig_4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Calisanlar_Departmen_DId",
                table: "Calisanlar");

            migrationBuilder.AddForeignKey(
                name: "FK_Calisanlar_Departmen_DId",
                table: "Calisanlar",
                column: "DId",
                principalTable: "Departmen",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Calisanlar_Departmen_DId",
                table: "Calisanlar");

            migrationBuilder.AddForeignKey(
                name: "FK_Calisanlar_Departmen_DId",
                table: "Calisanlar",
                column: "DId",
                principalTable: "Departmen",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
