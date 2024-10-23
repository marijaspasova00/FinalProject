using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AmortizationPlansForLoansFinalProject.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class initAddedSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductID", "Code", "Name", "ProductConditionID", "Status" },
                values: new object[,]
                {
                    { 1, "P001", "Home Loan", 0, 0 },
                    { 2, "P002", "Agro Loan", 0, 0 },
                    { 3, "P003", "Auto Loan", 0, 0 },
                    { 4, "P004", "Education Loan", 0, 0 },
                    { 5, "P005", "Personal Loan", 0, 0 },
                    { 6, "P006", "Business Loan", 0, 0 }
                });

            migrationBuilder.InsertData(
                table: "ProductConditions",
                columns: new[] { "ProductConditionID", "AdminFee", "Description", "MaxAmount", "MaxInterestRate", "MaxNumberOfInstallments", "MinAmount", "MinInterestRate", "MinNumberOfInstallments", "ProductID" },
                values: new object[,]
                {
                    { 1, 0m, "Standard home financing", 100000m, 5.5m, 60, 10000m, 2m, 10, 1 },
                    { 2, 1500m, "Standard Agro loan", 500000m, 4.5m, 60, 10000m, 3m, 10, 2 },
                    { 3, 2000m, "Financing for vehicles", 50000m, 4.5m, 60, 2000m, 2.5m, 10, 3 },
                    { 4, 500m, "Loan for Education", 15000m, 3.5m, 60, 5000m, 2m, 10, 4 },
                    { 5, 600m, "Unsecured personal loan", 7000m, 5.5m, 60, 1500m, 2m, 10, 5 },
                    { 6, 3500m, "Standard business loan", 500000m, 7m, 60, 30000m, 3.5m, 10, 6 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductConditions",
                keyColumn: "ProductConditionID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProductConditions",
                keyColumn: "ProductConditionID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProductConditions",
                keyColumn: "ProductConditionID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ProductConditions",
                keyColumn: "ProductConditionID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ProductConditions",
                keyColumn: "ProductConditionID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ProductConditions",
                keyColumn: "ProductConditionID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 6);
        }
    }
}
