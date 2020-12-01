CREATE TABLE `Accounting_Accounts` (
    `Id` bigint NOT NULL AUTO_INCREMENT,
    `AccountId` char(36) NOT NULL,
    `AccountCode` varchar(256) NOT NULL,
    `AccountName` varchar(512) NOT NULL,
    `AccountDescription` longtext NULL,
    `ParentAccountId` char(36) NULL,
    `DebitOrCredit` int NOT NULL,
    `IsHidden` bit NOT NULL,
    `MetaCreatedTimeCode` bigint NOT NULL,
    `MetaModifiedTimeCode` bigint NOT NULL,
    `MetaIsDeleted` bit NOT NULL,
    `MetaRowVersion` datetime(6) NULL DEFAULT CURRENT_TIMESTAMP(6) ON UPDATE CURRENT_TIMESTAMP(6),
    CONSTRAINT `PK_Accounting_Accounts` PRIMARY KEY (`Id`),
    CONSTRAINT `AK_Accounting_Accounts_AccountId` UNIQUE (`AccountId`),
    CONSTRAINT `FK_Accounting_Accounts_Accounting_Accounts_ParentAccountId` FOREIGN KEY (`ParentAccountId`) REFERENCES `Accounting_Accounts` (`AccountId`) ON DELETE RESTRICT
);

CREATE TABLE `Accounting_Options` (
    `Id` bigint NOT NULL AUTO_INCREMENT,
    `OptionId` char(36) NOT NULL,
    `OptionCode` varchar(256) NOT NULL,
    `OptionName` varchar(512) NOT NULL,
    `OptionDescription` longtext NULL,
    `OptionGroup` varchar(256) NULL,
    `LanguageCode` varchar(256) NULL,
    `MetaCreatedTimeCode` bigint NOT NULL,
    `MetaModifiedTimeCode` bigint NOT NULL,
    `MetaIsDeleted` bit NOT NULL,
    `MetaRowVersion` datetime(6) NULL DEFAULT CURRENT_TIMESTAMP(6) ON UPDATE CURRENT_TIMESTAMP(6),
    CONSTRAINT `PK_Accounting_Options` PRIMARY KEY (`Id`)
);

CREATE TABLE `Accounting_Transactions` (
    `Id` bigint NOT NULL AUTO_INCREMENT,
    `TransactionId` char(36) NOT NULL,
    `TransactionCode` varchar(256) NOT NULL,
    `TransactionName` varchar(512) NOT NULL,
    `DebitAccountId` char(36) NOT NULL,
    `CreditAccountId` char(36) NOT NULL,
    `TransactionAmount` decimal(65, 30) NOT NULL,
    `IssuedTimeCode` bigint NOT NULL,
    `MetaCreatedTimeCode` bigint NOT NULL,
    `MetaModifiedTimeCode` bigint NOT NULL,
    `MetaIsDeleted` bit NOT NULL,
    `MetaRowVersion` datetime(6) NULL DEFAULT CURRENT_TIMESTAMP(6) ON UPDATE CURRENT_TIMESTAMP(6),
    CONSTRAINT `PK_Accounting_Transactions` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Accounting_Transactions_Accounting_Accounts_CreditAccountId` FOREIGN KEY (`CreditAccountId`) REFERENCES `Accounting_Accounts` (`AccountId`) ON DELETE RESTRICT,
    CONSTRAINT `FK_Accounting_Transactions_Accounting_Accounts_DebitAccountId` FOREIGN KEY (`DebitAccountId`) REFERENCES `Accounting_Accounts` (`AccountId`) ON DELETE RESTRICT
);

CREATE UNIQUE INDEX `UX_AccountCode` ON `Accounting_Accounts` (`AccountCode`);

CREATE UNIQUE INDEX `UX_AccountId` ON `Accounting_Accounts` (`AccountId`);

CREATE INDEX `IX_Accounting_Accounts_ParentAccountId` ON `Accounting_Accounts` (`ParentAccountId`);

CREATE UNIQUE INDEX `UX_OptionCode` ON `Accounting_Options` (`OptionCode`);

CREATE UNIQUE INDEX `UX_OptionId` ON `Accounting_Options` (`OptionId`);

CREATE INDEX `IX_Accounting_Transactions_CreditAccountId` ON `Accounting_Transactions` (`CreditAccountId`);

CREATE INDEX `IX_Accounting_Transactions_DebitAccountId` ON `Accounting_Transactions` (`DebitAccountId`);

CREATE UNIQUE INDEX `UX_TransactionCode` ON `Accounting_Transactions` (`TransactionCode`);

CREATE UNIQUE INDEX `UX_TransactionId` ON `Accounting_Transactions` (`TransactionId`);

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('00000000000002_BasicAccountAndTransaction', '2.2.6-servicing-10079');

