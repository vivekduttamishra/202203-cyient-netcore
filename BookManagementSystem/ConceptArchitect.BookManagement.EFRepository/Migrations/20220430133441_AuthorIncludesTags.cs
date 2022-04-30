using Microsoft.EntityFrameworkCore.Migrations;

namespace ConceptArchitect.BookManagement.EFRepository.Migrations
{
    public partial class AuthorIncludesTags : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Tags",
                table: "AuthorTable",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tags",
                table: "AuthorTable");
        }
    }
}
