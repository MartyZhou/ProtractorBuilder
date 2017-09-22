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
                    TestCaseType = table.Column<int>(type: "INTEGER", nullable: false),
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
                name: "ModulesSuites",
                columns: table => new
                {
                    TestModuleId = table.Column<string>(type: "TEXT", nullable: false),
                    TestSuiteId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModulesSuites", x => new { x.TestModuleId, x.TestSuiteId });
                    table.ForeignKey(
                        name: "FK_ModulesSuites_Modules_TestModuleId",
                        column: x => x.TestModuleId,
                        principalTable: "Modules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ModulesSuites_Suites_TestSuiteId",
                        column: x => x.TestSuiteId,
                        principalTable: "Suites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Steps",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    ActionSequence = table.Column<int>(type: "INTEGER", nullable: false),
                    CurrentFailedElement = table.Column<string>(type: "TEXT", nullable: true),
                    LastSuccessfulElement = table.Column<string>(type: "TEXT", nullable: true),
                    Locator = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Order = table.Column<int>(type: "INTEGER", nullable: false),
                    ResultFromId = table.Column<string>(type: "TEXT", nullable: true),
                    TestCaseId = table.Column<string>(type: "TEXT", nullable: true),
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
                });

            migrationBuilder.CreateTable(
                name: "SuitesCases",
                columns: table => new
                {
                    TestSuiteId = table.Column<string>(type: "TEXT", nullable: false),
                    TestCaseId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuitesCases", x => new { x.TestSuiteId, x.TestCaseId });
                    table.ForeignKey(
                        name: "FK_SuitesCases_Cases_TestCaseId",
                        column: x => x.TestCaseId,
                        principalTable: "Cases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SuitesCases_Suites_TestSuiteId",
                        column: x => x.TestSuiteId,
                        principalTable: "Suites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CasesSteps",
                columns: table => new
                {
                    TestCaseId = table.Column<string>(type: "TEXT", nullable: false),
                    TestStepId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CasesSteps", x => new { x.TestCaseId, x.TestStepId });
                    table.ForeignKey(
                        name: "FK_CasesSteps_Cases_TestCaseId",
                        column: x => x.TestCaseId,
                        principalTable: "Cases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CasesSteps_Steps_TestStepId",
                        column: x => x.TestStepId,
                        principalTable: "Steps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cases_TestSuiteId",
                table: "Cases",
                column: "TestSuiteId");

            migrationBuilder.CreateIndex(
                name: "IX_CasesSteps_TestStepId",
                table: "CasesSteps",
                column: "TestStepId");

            migrationBuilder.CreateIndex(
                name: "IX_ModulesSuites_TestSuiteId",
                table: "ModulesSuites",
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
                name: "IX_Suites_TestModuleId",
                table: "Suites",
                column: "TestModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_SuitesCases_TestCaseId",
                table: "SuitesCases",
                column: "TestCaseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CasesSteps");

            migrationBuilder.DropTable(
                name: "ModulesSuites");

            migrationBuilder.DropTable(
                name: "SuitesCases");

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
