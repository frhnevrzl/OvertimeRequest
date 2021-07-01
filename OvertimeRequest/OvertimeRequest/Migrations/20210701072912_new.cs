using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OvertimeRequest.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RegisterVM",
                columns: table => new
                {
                    NIP = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Religion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Salary = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ManagerId = table.Column<int>(type: "int", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "TB_M_Department",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepartmentLoc = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_Department", x => x.DepartmentId);
                });

            migrationBuilder.CreateTable(
                name: "TB_M_OvertimeApply",
                columns: table => new
                {
                    OvertimeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OvertimeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubmissionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Task = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdditionalSalary = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_OvertimeApply", x => x.OvertimeId);
                });

            migrationBuilder.CreateTable(
                name: "TB_M_Role",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_Role", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "TB_M_Employee",
                columns: table => new
                {
                    NIP = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Religion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Salary = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ManagerId = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_Employee", x => x.NIP);
                    table.ForeignKey(
                        name: "FK_TB_M_Employee_TB_M_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "TB_M_Department",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_M_Account",
                columns: table => new
                {
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_Account", x => x.AccountId);
                    table.ForeignKey(
                        name: "FK_TB_M_Account_TB_M_Employee_AccountId",
                        column: x => x.AccountId,
                        principalTable: "TB_M_Employee",
                        principalColumn: "NIP",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_TR_OvertimeApplyEmployee",
                columns: table => new
                {
                    OvertimeEmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<int>(type: "int", nullable: false),
                    EmployeeNIP = table.Column<int>(type: "int", nullable: true),
                    NIP = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OvertimeApplyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_TR_OvertimeApplyEmployee", x => x.OvertimeEmployeeId);
                    table.ForeignKey(
                        name: "FK_TB_TR_OvertimeApplyEmployee_TB_M_Employee_EmployeeNIP",
                        column: x => x.EmployeeNIP,
                        principalTable: "TB_M_Employee",
                        principalColumn: "NIP",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TB_TR_OvertimeApplyEmployee_TB_M_OvertimeApply_OvertimeApplyId",
                        column: x => x.OvertimeApplyId,
                        principalTable: "TB_M_OvertimeApply",
                        principalColumn: "OvertimeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_TR_AccountRole",
                columns: table => new
                {
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_TR_AccountRole", x => new { x.AccountId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_TB_TR_AccountRole_TB_M_Account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "TB_M_Account",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_TR_AccountRole_TB_M_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "TB_M_Role",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_M_Employee_DepartmentId",
                table: "TB_M_Employee",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_TR_AccountRole_RoleId",
                table: "TB_TR_AccountRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_TR_OvertimeApplyEmployee_EmployeeNIP",
                table: "TB_TR_OvertimeApplyEmployee",
                column: "EmployeeNIP");

            migrationBuilder.CreateIndex(
                name: "IX_TB_TR_OvertimeApplyEmployee_OvertimeApplyId",
                table: "TB_TR_OvertimeApplyEmployee",
                column: "OvertimeApplyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RegisterVM");

            migrationBuilder.DropTable(
                name: "TB_TR_AccountRole");

            migrationBuilder.DropTable(
                name: "TB_TR_OvertimeApplyEmployee");

            migrationBuilder.DropTable(
                name: "TB_M_Account");

            migrationBuilder.DropTable(
                name: "TB_M_Role");

            migrationBuilder.DropTable(
                name: "TB_M_OvertimeApply");

            migrationBuilder.DropTable(
                name: "TB_M_Employee");

            migrationBuilder.DropTable(
                name: "TB_M_Department");
        }
    }
}
