CREATE TABLE "Accounting_Accounts" (
    "Id" bigserial NOT NULL,
    "AccountId" uuid NOT NULL,
    "AccountCode" character varying(256) NOT NULL,
    "AccountName" character varying(512) NOT NULL,
    "AccountDescription" character varying(4000) NULL,
    "ParentAccountId" uuid NULL,
    "DebitOrCredit" integer NOT NULL,
    "IsHidden" boolean NOT NULL,
    "MetaCreatedTimeCode" bigint NOT NULL,
    "MetaModifiedTimeCode" bigint NOT NULL,
    "MetaIsDeleted" boolean NOT NULL,
    "MetaRowVersion" bytea NULL,
    CONSTRAINT "PK_Accounting_Accounts" PRIMARY KEY ("Id"),
    CONSTRAINT "AK_Accounting_Accounts_AccountId" UNIQUE ("AccountId"),
    CONSTRAINT "FK_Accounting_Accounts_Accounting_Accounts_ParentAccountId" FOREIGN KEY ("ParentAccountId") REFERENCES "Accounting_Accounts" ("AccountId") ON DELETE RESTRICT
);

CREATE TABLE "Accounting_Options" (
    "Id" bigserial NOT NULL,
    "OptionId" uuid NOT NULL,
    "OptionCode" character varying(256) NOT NULL,
    "OptionName" character varying(512) NOT NULL,
    "OptionDescription" character varying(4000) NULL,
    "OptionGroup" character varying(256) NULL,
    "LanguageCode" character varying(256) NULL,
    "MetaCreatedTimeCode" bigint NOT NULL,
    "MetaModifiedTimeCode" bigint NOT NULL,
    "MetaIsDeleted" boolean NOT NULL,
    "MetaRowVersion" bytea NULL,
    CONSTRAINT "PK_Accounting_Options" PRIMARY KEY ("Id")
);

CREATE TABLE "Accounting_Transactions" (
    "Id" bigserial NOT NULL,
    "TransactionId" uuid NOT NULL,
    "TransactionCode" character varying(256) NOT NULL,
    "TransactionName" character varying(512) NOT NULL,
    "DebitAccountId" uuid NOT NULL,
    "CreditAccountId" uuid NOT NULL,
    "TransactionAmount" numeric NOT NULL,
    "IssuedTimeCode" bigint NOT NULL,
    "MetaCreatedTimeCode" bigint NOT NULL,
    "MetaModifiedTimeCode" bigint NOT NULL,
    "MetaIsDeleted" boolean NOT NULL,
    "MetaRowVersion" bytea NULL,
    CONSTRAINT "PK_Accounting_Transactions" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Accounting_Transactions_Accounting_Accounts_CreditAccountId" FOREIGN KEY ("CreditAccountId") REFERENCES "Accounting_Accounts" ("AccountId") ON DELETE RESTRICT,
    CONSTRAINT "FK_Accounting_Transactions_Accounting_Accounts_DebitAccountId" FOREIGN KEY ("DebitAccountId") REFERENCES "Accounting_Accounts" ("AccountId") ON DELETE RESTRICT
);

CREATE UNIQUE INDEX "UX_AccountCode" ON "Accounting_Accounts" ("AccountCode");

CREATE UNIQUE INDEX "UX_AccountId" ON "Accounting_Accounts" ("AccountId");

CREATE UNIQUE INDEX "IX_Accounting_Accounts_ParentAccountId" ON "Accounting_Accounts" ("ParentAccountId");

CREATE UNIQUE INDEX "UX_OptionCode" ON "Accounting_Options" ("OptionCode");

CREATE UNIQUE INDEX "UX_OptionId" ON "Accounting_Options" ("OptionId");

CREATE UNIQUE INDEX "IX_Accounting_Transactions_CreditAccountId" ON "Accounting_Transactions" ("CreditAccountId");

CREATE UNIQUE INDEX "IX_Accounting_Transactions_DebitAccountId" ON "Accounting_Transactions" ("DebitAccountId");

CREATE UNIQUE INDEX "UX_TransactionCode" ON "Accounting_Transactions" ("TransactionCode");

CREATE UNIQUE INDEX "UX_TransactionId" ON "Accounting_Transactions" ("TransactionId");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('00000000000002_BasicAccountAndTransaction', '2.2.6-servicing-10079');

