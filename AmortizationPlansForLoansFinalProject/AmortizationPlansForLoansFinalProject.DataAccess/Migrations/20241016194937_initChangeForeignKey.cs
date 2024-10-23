using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AmortizationPlansForLoansFinalProject.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class initChangeForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AmortizationPlan",
                table: "AmortizationPlans");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AmortizationPlan",
                table: "AmortizationPlans",
                type: "int",
                nullable: true);
        }
    }
}
