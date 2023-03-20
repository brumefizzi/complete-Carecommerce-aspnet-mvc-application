using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarSalesApp.Migrations
{
    /// <inheritdoc />
    public partial class AddForeignKeyConstraintToCarSalesmen : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarSalesmen_Salesmen_SalesmanId",
                table: "CarSalesmen");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Orders",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarSalesmen_Salesmen_SalesmanId",
                table: "CarSalesmen",
                column: "SalesmanId",
                principalTable: "Salesmen",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_UserId",
                table: "Orders",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.Sql(@"
                ALTER TABLE CarSalesmen
                ADD CONSTRAINT FK_CarSalesmen_Salesmen_SalesmanId 
                FOREIGN KEY (SalesmanId) REFERENCES Salesmen(Id) 
                ON DELETE NO ACTION;");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarSalesmen_Salesmen_SalesmanId",
                table: "CarSalesmen");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_UserId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_UserId",
                table: "Orders");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_CarSalesmen_Salesmen_SalesmanId",
                table: "CarSalesmen",
                column: "SalesmanId",
                principalTable: "Salesmen",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
