IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230501013750_intial Update')
BEGIN
    CREATE TABLE [Files] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NULL,
        [Archivo] nvarchar(max) NULL,
        CONSTRAINT [PK_Files] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230501013750_intial Update')
BEGIN
    CREATE TABLE [Roles] (
        [Id] int NOT NULL IDENTITY,
        [NameRole] nvarchar(max) NULL,
        CONSTRAINT [PK_Roles] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230501013750_intial Update')
BEGIN
    CREATE TABLE [TypeDocs] (
        [Id] int NOT NULL IDENTITY,
        [NameTypeDoc] nvarchar(max) NULL,
        CONSTRAINT [PK_TypeDocs] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230501013750_intial Update')
BEGIN
    CREATE TABLE [Products] (
        [Id] int NOT NULL IDENTITY,
        [Activo] bit NOT NULL,
        [NameProduct] nvarchar(max) NULL,
        [Price] real NOT NULL,
        [Descriptions] nvarchar(max) NULL,
        [Quantity] int NOT NULL,
        [promotion] bit NOT NULL,
        [IdFile] int NOT NULL,
        CONSTRAINT [PK_Products] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Products_Files_IdFile] FOREIGN KEY ([IdFile]) REFERENCES [Files] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230501013750_intial Update')
BEGIN
    CREATE TABLE [Users] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NULL,
        [LastName] nvarchar(max) NULL,
        [Email] nvarchar(max) NULL,
        [Password] nvarchar(max) NULL,
        [Doc] nvarchar(max) NULL,
        [Status] bit NOT NULL,
        [IdRol] int NOT NULL,
        [IdTypeDoc] int NOT NULL,
        CONSTRAINT [PK_Users] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Users_Roles_IdRol] FOREIGN KEY ([IdRol]) REFERENCES [Roles] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_Users_TypeDocs_IdTypeDoc] FOREIGN KEY ([IdTypeDoc]) REFERENCES [TypeDocs] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230501013750_intial Update')
BEGIN
    CREATE INDEX [IX_Products_IdFile] ON [Products] ([IdFile]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230501013750_intial Update')
BEGIN
    CREATE INDEX [IX_Users_IdRol] ON [Users] ([IdRol]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230501013750_intial Update')
BEGIN
    CREATE INDEX [IX_Users_IdTypeDoc] ON [Users] ([IdTypeDoc]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230501013750_intial Update')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230501013750_intial Update', N'3.1.7');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230501014549_intial Update2')
BEGIN
    ALTER TABLE [Products] DROP CONSTRAINT [FK_Products_Files_IdFile];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230501014549_intial Update2')
BEGIN
    DROP INDEX [IX_Products_IdFile] ON [Products];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230501014549_intial Update2')
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Products]') AND [c].[name] = N'IdFile');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Products] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [Products] DROP COLUMN [IdFile];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230501014549_intial Update2')
BEGIN
    ALTER TABLE [Products] ADD [FileId] int NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230501014549_intial Update2')
BEGIN
    CREATE INDEX [IX_Products_FileId] ON [Products] ([FileId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230501014549_intial Update2')
BEGIN
    ALTER TABLE [Products] ADD CONSTRAINT [FK_Products_Files_FileId] FOREIGN KEY ([FileId]) REFERENCES [Files] ([Id]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230501014549_intial Update2')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230501014549_intial Update2', N'3.1.7');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230501015704_intial Update3')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230501015704_intial Update3', N'3.1.7');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230501023554_intial Update5')
BEGIN
    CREATE TABLE [ProductFile] (
        [ProductId] int NOT NULL,
        [FileId] int NOT NULL,
        CONSTRAINT [PK_ProductFile] PRIMARY KEY ([ProductId], [FileId]),
        CONSTRAINT [FK_ProductFile_Files_FileId] FOREIGN KEY ([FileId]) REFERENCES [Files] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_ProductFile_Products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Products] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230501023554_intial Update5')
BEGIN
    CREATE INDEX [IX_ProductFile_FileId] ON [ProductFile] ([FileId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230501023554_intial Update5')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230501023554_intial Update5', N'3.1.7');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230501025813_intial Update6')
BEGIN
    ALTER TABLE [ProductFile] DROP CONSTRAINT [FK_ProductFile_Files_FileId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230501025813_intial Update6')
BEGIN
    ALTER TABLE [ProductFile] DROP CONSTRAINT [FK_ProductFile_Products_ProductId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230501025813_intial Update6')
BEGIN
    ALTER TABLE [ProductFile] DROP CONSTRAINT [PK_ProductFile];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230501025813_intial Update6')
BEGIN
    EXEC sp_rename N'[ProductFile]', N'ProductFiles';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230501025813_intial Update6')
BEGIN
    EXEC sp_rename N'[ProductFiles].[IX_ProductFile_FileId]', N'IX_ProductFiles_FileId', N'INDEX';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230501025813_intial Update6')
BEGIN
    ALTER TABLE [ProductFiles] ADD CONSTRAINT [PK_ProductFiles] PRIMARY KEY ([ProductId], [FileId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230501025813_intial Update6')
BEGIN
    ALTER TABLE [ProductFiles] ADD CONSTRAINT [FK_ProductFiles_Files_FileId] FOREIGN KEY ([FileId]) REFERENCES [Files] ([Id]) ON DELETE CASCADE;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230501025813_intial Update6')
BEGIN
    ALTER TABLE [ProductFiles] ADD CONSTRAINT [FK_ProductFiles_Products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Products] ([Id]) ON DELETE CASCADE;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230501025813_intial Update6')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230501025813_intial Update6', N'3.1.7');
END;

GO

