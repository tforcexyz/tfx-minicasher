CREATE TABLE [Accounting_Accounts] (
    [Id] bigint NOT NULL IDENTITY,
    [AccountId] uniqueidentifier NOT NULL,
    [AccountCode] nvarchar(256) NOT NULL,
    [AccountName] nvarchar(512) NOT NULL,
    [AccountDescription] nvarchar(4000) NULL,
    [ParentAccountId] uniqueidentifier NULL,
    [DebitOrCredit] int NOT NULL,
    [IsHidden] bit NOT NULL,
    [MetaCreatedTimeCode] bigint NOT NULL,
    [MetaModifiedTimeCode] bigint NOT NULL,
    [MetaIsDeleted] bit NOT NULL,
    [MetaRowVersion] rowversion NULL,
    CONSTRAINT [PK_Accounting_Accounts] PRIMARY KEY ([Id]),
    CONSTRAINT [AK_Accounting_Accounts_AccountId] UNIQUE ([AccountId]),
    CONSTRAINT [FK_Accounting_Accounts_Accounting_Accounts_ParentAccountId] FOREIGN KEY ([ParentAccountId]) REFERENCES [Accounting_Accounts] ([AccountId]) ON DELETE NO ACTION
);

GO

CREATE TABLE [Accounting_Options] (
    [Id] bigint NOT NULL IDENTITY,
    [OptionId] uniqueidentifier NOT NULL,
    [OptionCode] nvarchar(256) NOT NULL,
    [OptionName] nvarchar(512) NOT NULL,
    [OptionDescription] nvarchar(4000) NULL,
    [OptionGroup] nvarchar(256) NULL,
    [LanguageCode] nvarchar(256) NULL,
    [MetaCreatedTimeCode] bigint NOT NULL,
    [MetaModifiedTimeCode] bigint NOT NULL,
    [MetaIsDeleted] bit NOT NULL,
    [MetaRowVersion] rowversion NULL,
    CONSTRAINT [PK_Accounting_Options] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Accounting_Transactions] (
    [Id] bigint NOT NULL IDENTITY,
    [TransactionId] uniqueidentifier NOT NULL,
    [TransactionCode] nvarchar(256) NOT NULL,
    [TransactionName] nvarchar(512) NOT NULL,
    [DebitAccountId] uniqueidentifier NOT NULL,
    [CreditAccountId] uniqueidentifier NOT NULL,
    [TransactionAmount] decimal(18,2) NOT NULL,
    [IssuedTimeCode] bigint NOT NULL,
    [MetaCreatedTimeCode] bigint NOT NULL,
    [MetaModifiedTimeCode] bigint NOT NULL,
    [MetaIsDeleted] bit NOT NULL,
    [MetaRowVersion] rowversion NULL,
    CONSTRAINT [PK_Accounting_Transactions] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Accounting_Transactions_Accounting_Accounts_CreditAccountId] FOREIGN KEY ([CreditAccountId]) REFERENCES [Accounting_Accounts] ([AccountId]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Accounting_Transactions_Accounting_Accounts_DebitAccountId] FOREIGN KEY ([DebitAccountId]) REFERENCES [Accounting_Accounts] ([AccountId]) ON DELETE NO ACTION
);

GO

CREATE UNIQUE INDEX [UX_AccountCode] ON [Accounting_Accounts] ([AccountCode]);

GO

CREATE UNIQUE INDEX [UX_AccountId] ON [Accounting_Accounts] ([AccountId]);

GO

CREATE UNIQUE INDEX [IX_Accounting_Accounts_ParentAccountId] ON [Accounting_Accounts] ([ParentAccountId]) WHERE [ParentAccountId] IS NOT NULL;

GO

CREATE UNIQUE INDEX [UX_OptionCode] ON [Accounting_Options] ([OptionCode]);

GO

CREATE UNIQUE INDEX [UX_OptionId] ON [Accounting_Options] ([OptionId]);

GO

CREATE UNIQUE INDEX [IX_Accounting_Transactions_CreditAccountId] ON [Accounting_Transactions] ([CreditAccountId]);

GO

CREATE UNIQUE INDEX [IX_Accounting_Transactions_DebitAccountId] ON [Accounting_Transactions] ([DebitAccountId]);

GO

CREATE UNIQUE INDEX [UX_TransactionCode] ON [Accounting_Transactions] ([TransactionCode]);

GO

CREATE UNIQUE INDEX [UX_TransactionId] ON [Accounting_Transactions] ([TransactionId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'00000000000002_BasicAccountAndTransaction', N'2.2.6-servicing-10079');

GO

