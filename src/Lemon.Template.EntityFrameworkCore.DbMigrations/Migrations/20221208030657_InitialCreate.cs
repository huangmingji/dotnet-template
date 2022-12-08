using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Lemon.Template.EntityFrameworkCore.DbMigrations.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PermissionData",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ParentId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Permission = table.Column<string>(type: "text", nullable: true),
                    CreatorId = table.Column<long>(type: "bigint", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifierId = table.Column<long>(type: "bigint", nullable: false),
                    LastModifyTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionData", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoleData",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    IsDefault = table.Column<bool>(type: "boolean", nullable: false),
                    IsStatic = table.Column<bool>(type: "boolean", nullable: false),
                    IsPublic = table.Column<bool>(type: "boolean", nullable: false),
                    CreatorId = table.Column<long>(type: "bigint", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifierId = table.Column<long>(type: "bigint", nullable: false),
                    LastModifyTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleData", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserData",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Account = table.Column<string>(type: "text", nullable: true),
                    NickName = table.Column<string>(type: "text", nullable: true),
                    HeadIcon = table.Column<string>(type: "text", nullable: true),
                    Mobile = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Password = table.Column<string>(type: "text", nullable: true),
                    SecretKey = table.Column<string>(type: "text", nullable: true),
                    MultiUserLogin = table.Column<bool>(type: "boolean", nullable: false),
                    LogonCount = table.Column<int>(type: "integer", nullable: false),
                    UserOnline = table.Column<bool>(type: "boolean", nullable: false),
                    AllowStartTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AllowEndTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LockStartTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LockEndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    FirstVisitTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    PreviousVisitTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastVisitTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ChangPasswordDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatorId = table.Column<long>(type: "bigint", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifierId = table.Column<long>(type: "bigint", nullable: false),
                    LastModifyTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserData", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RolePermissionData",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<long>(type: "bigint", nullable: false),
                    Permission = table.Column<string>(type: "text", nullable: true),
                    CreatorId = table.Column<long>(type: "bigint", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifierId = table.Column<long>(type: "bigint", nullable: false),
                    LastModifyTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolePermissionData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RolePermissionData_RoleData_RoleId",
                        column: x => x.RoleId,
                        principalTable: "RoleData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    RoleId = table.Column<long>(type: "bigint", nullable: false),
                    CreatorId = table.Column<long>(type: "bigint", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifierId = table.Column<long>(type: "bigint", nullable: false),
                    LastModifyTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRole_RoleData_RoleId",
                        column: x => x.RoleId,
                        principalTable: "RoleData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRole_UserData_UserId",
                        column: x => x.UserId,
                        principalTable: "UserData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RolePermissionData_RoleId",
                table: "RolePermissionData",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserData_Account",
                table: "UserData",
                column: "Account",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserData_Email",
                table: "UserData",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserData_Mobile",
                table: "UserData",
                column: "Mobile",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_RoleId",
                table: "UserRole",
                column: "RoleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_RoleId_UserId",
                table: "UserRole",
                columns: new[] { "RoleId", "UserId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_UserId",
                table: "UserRole",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PermissionData");

            migrationBuilder.DropTable(
                name: "RolePermissionData");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "RoleData");

            migrationBuilder.DropTable(
                name: "UserData");
        }
    }
}
