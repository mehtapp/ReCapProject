using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class RenameCorporateCustomers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_IndividualCustomer",
                table: "IndividualCustomer");

            migrationBuilder.RenameTable(
                name: "IndividualCustomer",
                newName: "IndividualCustomers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IndividualCustomers",
                table: "IndividualCustomers",
                column: "IndividualCustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_IndividualCustomers",
                table: "IndividualCustomers");

            migrationBuilder.RenameTable(
                name: "IndividualCustomers",
                newName: "IndividualCustomer");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IndividualCustomer",
                table: "IndividualCustomer",
                column: "IndividualCustomerId");
        }
    }
}
