using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BuildingAdmins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuildingName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuildingAdmins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BuildingTenants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuildingName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApartmentNumber = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SurName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApartmentRenting = table.Column<bool>(type: "bit", nullable: false),
                    ApartmentSale = table.Column<bool>(type: "bit", nullable: false),
                    GarageRenting = table.Column<bool>(type: "bit", nullable: false),
                    GarageSale = table.Column<bool>(type: "bit", nullable: false),
                    ApartmentDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuildingTenants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BuildingTenantId = table.Column<int>(type: "int", nullable: true),
                    BuildingAdminId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_BuildingAdmins_BuildingAdminId",
                        column: x => x.BuildingAdminId,
                        principalTable: "BuildingAdmins",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Comments_BuildingTenants_BuildingTenantId",
                        column: x => x.BuildingTenantId,
                        principalTable: "BuildingTenants",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_BuildingAdminId",
                table: "Comments",
                column: "BuildingAdminId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_BuildingTenantId",
                table: "Comments",
                column: "BuildingTenantId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "BuildingAdmins");

            migrationBuilder.DropTable(
                name: "BuildingTenants");
        }
    }
}
