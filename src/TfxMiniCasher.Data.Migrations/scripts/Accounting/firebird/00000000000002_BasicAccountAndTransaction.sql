CREATE TABLE "Accounting_Accounts" (
    "Id" BIGINT NOT NULL,
    "AccountId" CHAR(16) CHARACTER SET OCTETS NOT NULL,
    "AccountCode" VARCHAR(256) NOT NULL,
    "AccountName" VARCHAR(512) NOT NULL,
    "AccountDescription" VARCHAR(4000),
    "ParentAccountId" CHAR(16) CHARACTER SET OCTETS,
    "DebitOrCredit" INTEGER NOT NULL,
    "IsHidden" BOOLEAN NOT NULL,
    "MetaCreatedTimeCode" BIGINT NOT NULL,
    "MetaModifiedTimeCode" BIGINT NOT NULL,
    "MetaIsDeleted" BOOLEAN NOT NULL,
    "MetaRowVersion" BLOB SUB_TYPE BINARY,
    CONSTRAINT "PK_Accounting_Accounts" PRIMARY KEY ("Id"),
    CONSTRAINT "AK_Accounting_Accounts_Account~" UNIQUE ("AccountId"),
    CONSTRAINT "FK_Accounting_Accounts_Account~" FOREIGN KEY ("ParentAccountId") REFERENCES "Accounting_Accounts" ("AccountId") ON UPDATE NO ACTION
);

CREATE TABLE "Accounting_Options" (
    "Id" BIGINT NOT NULL,
    "OptionId" CHAR(16) CHARACTER SET OCTETS NOT NULL,
    "OptionCode" VARCHAR(256) NOT NULL,
    "OptionName" VARCHAR(512) NOT NULL,
    "OptionDescription" VARCHAR(4000),
    "OptionGroup" VARCHAR(256),
    "LanguageCode" VARCHAR(256),
    "MetaCreatedTimeCode" BIGINT NOT NULL,
    "MetaModifiedTimeCode" BIGINT NOT NULL,
    "MetaIsDeleted" BOOLEAN NOT NULL,
    "MetaRowVersion" BLOB SUB_TYPE BINARY,
    CONSTRAINT "PK_Accounting_Options" PRIMARY KEY ("Id")
);

CREATE TABLE "Accounting_Transactions" (
    "Id" BIGINT NOT NULL,
    "TransactionId" CHAR(16) CHARACTER SET OCTETS NOT NULL,
    "TransactionCode" VARCHAR(256) NOT NULL,
    "TransactionName" VARCHAR(512) NOT NULL,
    "DebitAccountId" CHAR(16) CHARACTER SET OCTETS NOT NULL,
    "CreditAccountId" CHAR(16) CHARACTER SET OCTETS NOT NULL,
    "TransactionAmount" DECIMAL(18,2) NOT NULL,
    "IssuedTimeCode" BIGINT NOT NULL,
    "MetaCreatedTimeCode" BIGINT NOT NULL,
    "MetaModifiedTimeCode" BIGINT NOT NULL,
    "MetaIsDeleted" BOOLEAN NOT NULL,
    "MetaRowVersion" BLOB SUB_TYPE BINARY,
    CONSTRAINT "PK_Accounting_Transactions" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Accounting_Transactions_Acc~" FOREIGN KEY ("CreditAccountId") REFERENCES "Accounting_Accounts" ("AccountId") ON UPDATE NO ACTION,
    CONSTRAINT "FK_Accounting_Transactions_Ac~1" FOREIGN KEY ("DebitAccountId") REFERENCES "Accounting_Accounts" ("AccountId") ON UPDATE NO ACTION
);

CREATE UNIQUE INDEX "UX_AccountCode" ON "Accounting_Accounts" ("AccountCode");

CREATE UNIQUE INDEX "UX_AccountId" ON "Accounting_Accounts" ("AccountId");

CREATE INDEX "IX_Accounting_Accounts_ParentA~" ON "Accounting_Accounts" ("ParentAccountId");

CREATE UNIQUE INDEX "UX_OptionCode" ON "Accounting_Options" ("OptionCode");

CREATE UNIQUE INDEX "UX_OptionId" ON "Accounting_Options" ("OptionId");

CREATE INDEX "IX_Accounting_Transactions_Cre~" ON "Accounting_Transactions" ("CreditAccountId");

CREATE INDEX "IX_Accounting_Transactions_Deb~" ON "Accounting_Transactions" ("DebitAccountId");

CREATE UNIQUE INDEX "UX_TransactionCode" ON "Accounting_Transactions" ("TransactionCode");

CREATE UNIQUE INDEX "UX_TransactionId" ON "Accounting_Transactions" ("TransactionId");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES (_UTF8'00000000000002_BasicAccountAndTransaction', _UTF8'2.2.6-servicing-10079');

