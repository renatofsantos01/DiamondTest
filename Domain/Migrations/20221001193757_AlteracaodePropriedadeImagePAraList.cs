using Microsoft.EntityFrameworkCore.Migrations;

namespace Domain.Migrations
{
    public partial class AlteracaodePropriedadeImagePAraList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Diamonds_Images_ImageId",
                table: "Diamonds");

            migrationBuilder.DropIndex(
                name: "IX_Diamonds_ImageId",
                table: "Diamonds");

            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "Images",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Images_ImageId",
                table: "Images",
                column: "ImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Diamonds_ImageId",
                table: "Images",
                column: "ImageId",
                principalTable: "Diamonds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Diamonds_ImageId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_ImageId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Images");

            migrationBuilder.CreateIndex(
                name: "IX_Diamonds_ImageId",
                table: "Diamonds",
                column: "ImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Diamonds_Images_ImageId",
                table: "Diamonds",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
