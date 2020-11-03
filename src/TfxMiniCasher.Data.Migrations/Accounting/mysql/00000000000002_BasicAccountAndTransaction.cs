using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Xyz.TForce.MiniCasher.Data.Migrations.Accounting.mysql
{
    public partial class BasicAccountAndTransaction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounting_Accounts",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AccountId = table.Column<Guid>(nullable: false),
                    AccountCode = table.Column<string>(maxLength: 256, nullable: false),
                    AccountName = table.Column<string>(maxLength: 512, nullable: false),
                    AccountDescription = table.Column<string>(maxLength: 4000, nullable: true),
                    ParentAccountId = table.Column<Guid>(nullable: true),
                    DebitOrCredit = table.Column<int>(nullable: false),
                    IsHidden = table.Column<bool>(nullable: false),
                    MetaCreatedTimeCode = table.Column<long>(nullable: false),
                    MetaModifiedTimeCode = table.Column<long>(nullable: false),
                    MetaIsDeleted = table.Column<bool>(nullable: false),
                    MetaRowVersion = table.Column<DateTime>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounting_Accounts", x => x.Id);
                    table.UniqueConstraint("AK_Accounting_Accounts_AccountId", x => x.AccountId);
                    table.ForeignKey(
                        name: "FK_Accounting_Accounts_Accounting_Accounts_ParentAccountId",
                        column: x => x.ParentAccountId,
                        principalTable: "Accounting_Accounts",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Accounting_Options",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    OptionId = table.Column<Guid>(nullable: false),
                    OptionCode = table.Column<string>(maxLength: 256, nullable: false),
                    OptionName = table.Column<string>(maxLength: 512, nullable: false),
                    OptionDescription = table.Column<string>(maxLength: 4000, nullable: true),
                    OptionGroup = table.Column<string>(maxLength: 256, nullable: true),
                    LanguageCode = table.Column<string>(maxLength: 256, nullable: true),
                    MetaCreatedTimeCode = table.Column<long>(nullable: false),
                    MetaModifiedTimeCode = table.Column<long>(nullable: false),
                    MetaIsDeleted = table.Column<bool>(nullable: false),
                    MetaRowVersion = table.Column<DateTime>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounting_Options", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Accounting_Transactions",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TransactionId = table.Column<Guid>(nullable: false),
                    TransactionCode = table.Column<string>(maxLength: 256, nullable: false),
                    TransactionName = table.Column<string>(maxLength: 512, nullable: false),
                    DebitAccountId = table.Column<Guid>(nullable: false),
                    CreditAccountId = table.Column<Guid>(nullable: false),
                    TransactionAmount = table.Column<decimal>(nullable: false),
                    IssuedTimeCode = table.Column<long>(nullable: false),
                    MetaCreatedTimeCode = table.Column<long>(nullable: false),
                    MetaModifiedTimeCode = table.Column<long>(nullable: false),
                    MetaIsDeleted = table.Column<bool>(nullable: false),
                    MetaRowVersion = table.Column<DateTime>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounting_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accounting_Transactions_Accounting_Accounts_CreditAccountId",
                        column: x => x.CreditAccountId,
                        principalTable: "Accounting_Accounts",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Accounting_Transactions_Accounting_Accounts_DebitAccountId",
                        column: x => x.DebitAccountId,
                        principalTable: "Accounting_Accounts",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "UX_AccountCode",
                table: "Accounting_Accounts",
                column: "AccountCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UX_AccountId",
                table: "Accounting_Accounts",
                column: "AccountId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Accounting_Accounts_ParentAccountId",
                table: "Accounting_Accounts",
                column: "ParentAccountId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UX_OptionCode",
                table: "Accounting_Options",
                column: "OptionCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UX_OptionId",
                table: "Accounting_Options",
                column: "OptionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Accounting_Transactions_CreditAccountId",
                table: "Accounting_Transactions",
                column: "CreditAccountId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Accounting_Transactions_DebitAccountId",
                table: "Accounting_Transactions",
                column: "DebitAccountId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UX_TransactionCode",
                table: "Accounting_Transactions",
                column: "TransactionCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UX_TransactionId",
                table: "Accounting_Transactions",
                column: "TransactionId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounting_Options");

            migrationBuilder.DropTable(
                name: "Accounting_Transactions");

            migrationBuilder.DropTable(
                name: "Accounting_Accounts");
        }
    }
}
