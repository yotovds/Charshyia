using Microsoft.EntityFrameworkCore.Migrations;

namespace Charshyia.Data.Migrations
{
    public partial class test1111 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProducerMessage",
                table: "Orders",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProducerMessage",
                table: "Orders");
        }
    }
}
