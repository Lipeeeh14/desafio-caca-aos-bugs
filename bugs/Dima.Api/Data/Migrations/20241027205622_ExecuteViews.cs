using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dima.Api.Migrations
{
    /// <inheritdoc />
    public partial class ExecuteViews : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sqlDirectory = Path.Combine("Data/Views");

            var sqlFiles = new string[]
            {
                "vwGetExpensesByCategory.sql",
                "vwGetIncomesAndExpenses.sql",
                "vwGetIncomesByCategory.sql"
            };

            foreach (var item in sqlFiles)
            {
                var filePath = Path.Combine(sqlDirectory, item);
                var sqlQuery = File.ReadAllText(filePath);
                migrationBuilder.Sql(sqlQuery);
            }
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW vwGetExpensesByCategory");
            migrationBuilder.Sql("DROP VIEW vwGetIncomesAndExpenses");
            migrationBuilder.Sql("DROP VIEW vwGetIncomesByCategory");
        }
    }
}
