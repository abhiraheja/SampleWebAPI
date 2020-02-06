using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DbLayer.Migrations
{
    public partial class initials1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SA_LicenseInformation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Is_deleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    LicenseNo = table.Column<string>(nullable: true),
                    MAC_Address = table.Column<string>(nullable: true),
                    Application_Id = table.Column<string>(nullable: true),
                    Updated_date = table.Column<DateTime>(nullable: false),
                    Is_lock = table.Column<bool>(nullable: false),
                    Is_used = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SA_LicenseInformation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SA_Login",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Is_deleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SA_Login", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "user_Information",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Is_deleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Email_id = table.Column<string>(nullable: true),
                    Mobile_no = table.Column<string>(nullable: true),
                    Is_used = table.Column<bool>(nullable: false),
                    Is_lock = table.Column<bool>(nullable: false),
                    License_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_Information", x => x.Id);
                    table.ForeignKey(
                        name: "FK_user_Information_SA_LicenseInformation_License_id",
                        column: x => x.License_id,
                        principalTable: "SA_LicenseInformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "SA_Login",
                columns: new[] { "Id", "CreatedAt", "Is_deleted", "Password", "UpdatedAt", "Username" },
                values: new object[] { 1, new DateTime(2020, 2, 6, 10, 36, 37, 501, DateTimeKind.Local).AddTicks(6864), false, "admin", new DateTime(2020, 2, 6, 10, 36, 37, 502, DateTimeKind.Local).AddTicks(5525), "admin" });

            migrationBuilder.CreateIndex(
                name: "IX_user_Information_License_id",
                table: "user_Information",
                column: "License_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SA_Login");

            migrationBuilder.DropTable(
                name: "user_Information");

            migrationBuilder.DropTable(
                name: "SA_LicenseInformation");
        }
    }
}
