using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealEstates.Data.Migrations
{
    public partial class RemovedTagProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RealEstateProperties_Tags_TagId",
                table: "RealEstateProperties");

            migrationBuilder.DropForeignKey(
                name: "FK_RealEstatePropertyTags_RealEstateProperties_RealEstatePropertyId",
                table: "RealEstatePropertyTags");

            migrationBuilder.DropForeignKey(
                name: "FK_RealEstatePropertyTags_Tags_TagId",
                table: "RealEstatePropertyTags");

            migrationBuilder.DropIndex(
                name: "IX_RealEstateProperties_TagId",
                table: "RealEstateProperties");

            migrationBuilder.DropColumn(
                name: "TagId",
                table: "RealEstateProperties");

            migrationBuilder.AddForeignKey(
                name: "FK_RealEstatePropertyTags_RealEstateProperties_RealEstatePropertyId",
                table: "RealEstatePropertyTags",
                column: "RealEstatePropertyId",
                principalTable: "RealEstateProperties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RealEstatePropertyTags_Tags_TagId",
                table: "RealEstatePropertyTags",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RealEstatePropertyTags_RealEstateProperties_RealEstatePropertyId",
                table: "RealEstatePropertyTags");

            migrationBuilder.DropForeignKey(
                name: "FK_RealEstatePropertyTags_Tags_TagId",
                table: "RealEstatePropertyTags");

            migrationBuilder.AddColumn<int>(
                name: "TagId",
                table: "RealEstateProperties",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_RealEstateProperties_TagId",
                table: "RealEstateProperties",
                column: "TagId");

            migrationBuilder.AddForeignKey(
                name: "FK_RealEstateProperties_Tags_TagId",
                table: "RealEstateProperties",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RealEstatePropertyTags_RealEstateProperties_RealEstatePropertyId",
                table: "RealEstatePropertyTags",
                column: "RealEstatePropertyId",
                principalTable: "RealEstateProperties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RealEstatePropertyTags_Tags_TagId",
                table: "RealEstatePropertyTags",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
