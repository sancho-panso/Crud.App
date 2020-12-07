using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Crud.App.Data.Migrations
{
    public partial class branchAdress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Branches_Adress_AdressID",
                table: "Branches");

            migrationBuilder.DropForeignKey(
                name: "FK_Branches_Adress_DeliveryAdressID",
                table: "Branches");

            migrationBuilder.AlterColumn<Guid>(
                name: "DeliveryAdressID",
                table: "Branches",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "AdressID",
                table: "Branches",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Branches_Adress_AdressID",
                table: "Branches",
                column: "AdressID",
                principalTable: "Adress",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Branches_Adress_DeliveryAdressID",
                table: "Branches",
                column: "DeliveryAdressID",
                principalTable: "Adress",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Branches_Adress_AdressID",
                table: "Branches");

            migrationBuilder.DropForeignKey(
                name: "FK_Branches_Adress_DeliveryAdressID",
                table: "Branches");

            migrationBuilder.AlterColumn<Guid>(
                name: "DeliveryAdressID",
                table: "Branches",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "AdressID",
                table: "Branches",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Branches_Adress_AdressID",
                table: "Branches",
                column: "AdressID",
                principalTable: "Adress",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Branches_Adress_DeliveryAdressID",
                table: "Branches",
                column: "DeliveryAdressID",
                principalTable: "Adress",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
