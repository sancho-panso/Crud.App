using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Crud.App.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Adress",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Building = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Index = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Street = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adress", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ClientsGroups",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientsGroups", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ItemsGroups",
                columns: table => new
                {
                    ItemsGroupID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ItemsGroupCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ItemsGroupName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ItemsGroupNameEN = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ItemsGroupNameRU = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ParentItemsGroupCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ItemsGroupID1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemsGroups", x => x.ItemsGroupID);
                    table.ForeignKey(
                        name: "FK_ItemsGroups_ItemsGroups_ItemsGroupID1",
                        column: x => x.ItemsGroupID1,
                        principalTable: "ItemsGroups",
                        principalColumn: "ItemsGroupID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BussinessID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    VAT_ID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdressID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeliveryAdressID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreditLimit = table.Column<double>(type: "float", nullable: false),
                    PricelistCode = table.Column<int>(type: "int", nullable: false),
                    ClientsGroupID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Clients_Adress_AdressID",
                        column: x => x.AdressID,
                        principalTable: "Adress",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Clients_Adress_DeliveryAdressID",
                        column: x => x.DeliveryAdressID,
                        principalTable: "Adress",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Clients_ClientsGroups_ClientsGroupID",
                        column: x => x.ClientsGroupID,
                        principalTable: "ClientsGroups",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    ItemID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ItemsGroupID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ItemNomNr = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ItemName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ItemNameEN = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ItemNameRU = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ItemQR = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Measure = table.Column<int>(type: "int", nullable: false),
                    Package = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<double>(type: "float", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Pricelist_A = table.Column<double>(type: "float", nullable: false),
                    Pricelist_B = table.Column<double>(type: "float", nullable: false),
                    Pricelist_C = table.Column<double>(type: "float", nullable: false),
                    Pricelist_D = table.Column<double>(type: "float", nullable: false),
                    WharehouseQNT = table.Column<double>(type: "float", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.ItemID);
                    table.ForeignKey(
                        name: "FK_Items_ItemsGroups_ItemsGroupID",
                        column: x => x.ItemsGroupID,
                        principalTable: "ItemsGroups",
                        principalColumn: "ItemsGroupID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Branches",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClientID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdressID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeliveryAdressID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Branches_Adress_AdressID",
                        column: x => x.AdressID,
                        principalTable: "Adress",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Branches_Adress_DeliveryAdressID",
                        column: x => x.DeliveryAdressID,
                        principalTable: "Adress",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Branches_Clients_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Clients",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Discounts",
                columns: table => new
                {
                    DiscountID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClientID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClientGroupID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ItemGroupID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ItemID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DiscountMultiplier = table.Column<double>(type: "float", nullable: false),
                    PricelictCode = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discounts", x => x.DiscountID);
                    table.ForeignKey(
                        name: "FK_Discounts_Clients_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Clients",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Discounts_ClientsGroups_ClientGroupID",
                        column: x => x.ClientGroupID,
                        principalTable: "ClientsGroups",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Discounts_Items_ItemID",
                        column: x => x.ItemID,
                        principalTable: "Items",
                        principalColumn: "ItemID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Discounts_ItemsGroups_ItemGroupID",
                        column: x => x.ItemGroupID,
                        principalTable: "ItemsGroups",
                        principalColumn: "ItemsGroupID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    OrderData = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeliveryAdressID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TotalAmount = table.Column<double>(type: "float", nullable: false),
                    ClientID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BranchID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OrderStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderID);
                    table.ForeignKey(
                        name: "FK_Orders_Adress_DeliveryAdressID",
                        column: x => x.DeliveryAdressID,
                        principalTable: "Adress",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Branches_BranchID",
                        column: x => x.BranchID,
                        principalTable: "Branches",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Clients_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Clients",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderedItems",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ItemID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ordered_QNT = table.Column<double>(type: "float", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    DiscountID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderedItems", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OrderedItems_Items_ItemID",
                        column: x => x.ItemID,
                        principalTable: "Items",
                        principalColumn: "ItemID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderedItems_Orders_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Orders",
                        principalColumn: "OrderID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Branches_AdressID",
                table: "Branches",
                column: "AdressID");

            migrationBuilder.CreateIndex(
                name: "IX_Branches_ClientID",
                table: "Branches",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_Branches_DeliveryAdressID",
                table: "Branches",
                column: "DeliveryAdressID");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_AdressID",
                table: "Clients",
                column: "AdressID");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_ClientsGroupID",
                table: "Clients",
                column: "ClientsGroupID");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_DeliveryAdressID",
                table: "Clients",
                column: "DeliveryAdressID");

            migrationBuilder.CreateIndex(
                name: "IX_Discounts_ClientGroupID",
                table: "Discounts",
                column: "ClientGroupID");

            migrationBuilder.CreateIndex(
                name: "IX_Discounts_ClientID",
                table: "Discounts",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_Discounts_ItemGroupID",
                table: "Discounts",
                column: "ItemGroupID");

            migrationBuilder.CreateIndex(
                name: "IX_Discounts_ItemID",
                table: "Discounts",
                column: "ItemID");

            migrationBuilder.CreateIndex(
                name: "IX_Items_ItemsGroupID",
                table: "Items",
                column: "ItemsGroupID");

            migrationBuilder.CreateIndex(
                name: "IX_ItemsGroups_ItemsGroupID1",
                table: "ItemsGroups",
                column: "ItemsGroupID1");

            migrationBuilder.CreateIndex(
                name: "IX_OrderedItems_ItemID",
                table: "OrderedItems",
                column: "ItemID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderedItems_OrderID",
                table: "OrderedItems",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_BranchID",
                table: "Orders",
                column: "BranchID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ClientID",
                table: "Orders",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DeliveryAdressID",
                table: "Orders",
                column: "DeliveryAdressID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Discounts");

            migrationBuilder.DropTable(
                name: "OrderedItems");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "ItemsGroups");

            migrationBuilder.DropTable(
                name: "Branches");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Adress");

            migrationBuilder.DropTable(
                name: "ClientsGroups");
        }
    }
}
