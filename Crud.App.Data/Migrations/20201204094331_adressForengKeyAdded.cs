using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Crud.App.Data.Migrations
{
    public partial class adressForengKeyAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Adress_AdressID",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Adress_DeliveryAdressID",
                table: "Clients");

            migrationBuilder.AlterColumn<Guid>(
                name: "DeliveryAdressID",
                table: "Clients",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "AdressID",
                table: "Clients",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Building",
                table: "Adress",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Adress_AdressID",
                table: "Clients",
                column: "AdressID",
                principalTable: "Adress",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Adress_DeliveryAdressID",
                table: "Clients",
                column: "DeliveryAdressID",
                principalTable: "Adress",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Adress_AdressID",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Adress_DeliveryAdressID",
                table: "Clients");

            migrationBuilder.AlterColumn<Guid>(
                name: "DeliveryAdressID",
                table: "Clients",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "AdressID",
                table: "Clients",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "Building",
                table: "Adress",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Adress_AdressID",
                table: "Clients",
                column: "AdressID",
                principalTable: "Adress",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Adress_DeliveryAdressID",
                table: "Clients",
                column: "DeliveryAdressID",
                principalTable: "Adress",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
