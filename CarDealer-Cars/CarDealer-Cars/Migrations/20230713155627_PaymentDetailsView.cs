using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarDealer_Cars.Migrations
{
    /// <inheritdoc />
    public partial class PaymentDetailsView : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // migrationBuilder.Sql(@"create view PaymentDetails as select Payments.Id as Id, Payments.IsPaid as IsPaid, Payments.TotalPrice as TotalPrice, Orders.StartDate as StartDate, Orders.EndDate as EndDate, Cars.Mark as Mark, Cars.Model as Model from Payments inner join Orders on Payments.OrderId=Orders.Id inner join Cars on Orders.CarId=Cars.Id;");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // migrationBuilder.Sql(@"drop view PaymentDetails");
        }
    }
}
