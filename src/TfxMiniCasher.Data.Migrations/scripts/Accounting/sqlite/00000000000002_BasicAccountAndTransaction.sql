CREATE TABLE "Accounting_Accounts" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Accounting_Accounts" PRIMARY KEY AUTOINCREMENT,
    "AccountId" BLOB NOT NULL,
    "AccountCode" TEXT NOT NULL,
    "AccountName" TEXT NOT NULL,
    "AccountDescription" TEXT NULL,
    "ParentAccountId" BLOB NULL,
    "DebitOrCredit" INTEGER NOT NULL,
    "IsHidden" INTEGER NOT NULL,
    "MetaCreatedTimeCode" INTEGER NOT NULL,
    "MetaModifiedTimeCode" INTEGER NOT NULL,
    "MetaIsDeleted" INTEGER NOT NULL,
    "MetaRowVersion" BLOB NULL,
    CONSTRAINT "AK_Accounting_Accounts_AccountId" UNIQUE ("AccountId"),
    CONSTRAINT "FK_Accounting_Accounts_Accounting_Accounts_ParentAccountId" FOREIGN KEY ("ParentAccountId") REFERENCES "Accounting_Accounts" ("AccountId") ON DELETE RESTRICT
);

CREATE TABLE "Accounting_Options" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Accounting_Options" PRIMARY KEY AUTOINCREMENT,
    "OptionId" BLOB NOT NULL,
    "OptionCode" TEXT NOT NULL,
    "OptionName" TEXT NOT NULL,
    "OptionDescription" TEXT NULL,
    "OptionGroup" TEXT NULL,
    "LanguageCode" TEXT NULL,
    "MetaCreatedTimeCode" INTEGER NOT NULL,
    "MetaModifiedTimeCode" INTEGER NOT NULL,
    "MetaIsDeleted" INTEGER NOT NULL,
    "MetaRowVersion" BLOB NULL
);

CREATE TABLE "Accounting_Transactions" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Accounting_Transactions" PRIMARY KEY AUTOINCREMENT,
    "TransactionId" BLOB NOT NULL,
    "TransactionCode" TEXT NOT NULL,
    "TransactionName" TEXT NOT NULL,
    "DebitAccountId" BLOB NOT NULL,
    "CreditAccountId" BLOB NOT NULL,
    "TransactionAmount" TEXT NOT NULL,
    "IssuedTimeCode" INTEGER NOT NULL,
    "MetaCreatedTimeCode" INTEGER NOT NULL,
    "MetaModifiedTimeCode" INTEGER NOT NULL,
    "MetaIsDeleted" INTEGER NOT NULL,
    "MetaRowVersion" BLOB NULL,
    CONSTRAINT "FK_Accounting_Transactions_Accounting_Accounts_CreditAccountId" FOREIGN KEY ("CreditAccountId") REFERENCES "Accounting_Accounts" ("AccountId") ON DELETE RESTRICT,
    CONSTRAINT "FK_Accounting_Transactions_Accounting_Accounts_DebitAccountId" FOREIGN KEY ("DebitAccountId") REFERENCES "Accounting_Accounts" ("AccountId") ON DELETE RESTRICT
);

CREATE UNIQUE INDEX "UX_AccountCode" ON "Accounting_Accounts" ("AccountCode");

CREATE UNIQUE INDEX "UX_AccountId" ON "Accounting_Accounts" ("AccountId");

CREATE INDEX "IX_Accounting_Accounts_ParentAccountId" ON "Accounting_Accounts" ("ParentAccountId");

CREATE UNIQUE INDEX "UX_OptionCode" ON "Accounting_Options" ("OptionCode");

CREATE UNIQUE INDEX "UX_OptionId" ON "Accounting_Options" ("OptionId");

CREATE INDEX "IX_Accounting_Transactions_CreditAccountId" ON "Accounting_Transactions" ("CreditAccountId");

CREATE INDEX "IX_Accounting_Transactions_DebitAccountId" ON "Accounting_Transactions" ("DebitAccountId");

CREATE UNIQUE INDEX "UX_TransactionCode" ON "Accounting_Transactions" ("TransactionCode");

CREATE UNIQUE INDEX "UX_TransactionId" ON "Accounting_Transactions" ("TransactionId");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('00000000000002_BasicAccountAndTransaction', '2.2.6-servicing-10079');

