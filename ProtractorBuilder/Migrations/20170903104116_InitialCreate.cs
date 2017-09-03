using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ProtractorBuilder.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Modules",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Enabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Order = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modules", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Suites",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Enabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Order = table.Column<int>(type: "INTEGER", nullable: false),
                    TestModuleId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Suites_Modules_TestModuleId",
                        column: x => x.TestModuleId,
                        principalTable: "Modules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cases",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Enabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    Log = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Order = table.Column<int>(type: "INTEGER", nullable: false),
                    TestSuiteId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cases_Suites_TestSuiteId",
                        column: x => x.TestSuiteId,
                        principalTable: "Suites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Steps",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    ActionSequence = table.Column<int>(type: "INTEGER", nullable: false),
                    CaseId = table.Column<string>(type: "TEXT", nullable: true),
                    CurrentFailedElement = table.Column<string>(type: "TEXT", nullable: true),
                    LastSuccessfulElement = table.Column<string>(type: "TEXT", nullable: true),
                    Locator = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Order = table.Column<int>(type: "INTEGER", nullable: false),
                    ResultFromId = table.Column<string>(type: "TEXT", nullable: true),
                    TestCaseId = table.Column<string>(type: "TEXT", nullable: true),
                    TestSuiteId = table.Column<string>(type: "TEXT", nullable: true),
                    TestSuiteId1 = table.Column<string>(type: "TEXT", nullable: true),
                    TestSuiteId2 = table.Column<string>(type: "TEXT", nullable: true),
                    TestSuiteId3 = table.Column<string>(type: "TEXT", nullable: true),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Steps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Steps_Steps_ResultFromId",
                        column: x => x.ResultFromId,
                        principalTable: "Steps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Steps_Cases_TestCaseId",
                        column: x => x.TestCaseId,
                        principalTable: "Cases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Steps_Suites_TestSuiteId",
                        column: x => x.TestSuiteId,
                        principalTable: "Suites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Steps_Suites_TestSuiteId1",
                        column: x => x.TestSuiteId1,
                        principalTable: "Suites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Steps_Suites_TestSuiteId2",
                        column: x => x.TestSuiteId2,
                        principalTable: "Suites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Steps_Suites_TestSuiteId3",
                        column: x => x.TestSuiteId3,
                        principalTable: "Suites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cases_TestSuiteId",
                table: "Cases",
                column: "TestSuiteId");

            migrationBuilder.CreateIndex(
                name: "IX_Steps_ResultFromId",
                table: "Steps",
                column: "ResultFromId");

            migrationBuilder.CreateIndex(
                name: "IX_Steps_TestCaseId",
                table: "Steps",
                column: "TestCaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Steps_TestSuiteId",
                table: "Steps",
                column: "TestSuiteId");

            migrationBuilder.CreateIndex(
                name: "IX_Steps_TestSuiteId1",
                table: "Steps",
                column: "TestSuiteId1");

            migrationBuilder.CreateIndex(
                name: "IX_Steps_TestSuiteId2",
                table: "Steps",
                column: "TestSuiteId2");

            migrationBuilder.CreateIndex(
                name: "IX_Steps_TestSuiteId3",
                table: "Steps",
                column: "TestSuiteId3");

            migrationBuilder.CreateIndex(
                name: "IX_Suites_TestModuleId",
                table: "Suites",
                column: "TestModuleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Steps");

            migrationBuilder.DropTable(
                name: "Cases");

            migrationBuilder.DropTable(
                name: "Suites");

            migrationBuilder.DropTable(
                name: "Modules");
        }
    }
}
