CREATE DATABASE DECOUVERTEMETIERTF;
GO
USE DECOUVERTEMETIERTF;
GO

CREATE TABLE [User]
(
    [Id] INT IDENTITY(1,1),
    [Username] NVARCHAR(50) NOT NULL,
    [Email] NVARCHAR(100) NOT NULL,
    [Password] NVARCHAR(50) NOT NULL,
    CONSTRAINT PK_User PRIMARY KEY ([Id]),
    CONSTRAINT UK_User_Username UNIQUE ([Username]),
    CONSTRAINT CK_User_Password CHECK (LEN([Password]) >= 6)
);

CREATE TABLE [Book]
(
    [Id] INT IDENTITY(1,1),
    [Title] NVARCHAR(100) NOT NULL,
    [Author] NVARCHAR(100) NOT NULL,
    [Description] NVARCHAR(MAX) NULL,
    [Image] NVARCHAR(100) DEFAULT 'noImage.jpg',
    CONSTRAINT PK_Book PRIMARY KEY ([Id]),
    CONSTRAINT UK_Book_Title_Author UNIQUE ([Title],[Author])
);

CREATE TABLE [Category]
(
    [Id] INT IDENTITY(1,1),
    [Name] NVARCHAR(50) NOT NULL,
    CONSTRAINT PK_Category PRIMARY KEY ([Id])
);

CREATE TABLE [BookCategory]
(
    [BookId] INT NOT NULL,
    [CategoryId] INT NOT NULL,
    CONSTRAINT PK_BookCategory PRIMARY KEY ([BookId], [CategoryId]),
    CONSTRAINT FK_BookCategory_Book_BookId FOREIGN KEY ([BookId]) REFERENCES [Book]([Id]),
    CONSTRAINT FK_BookCategory_Category_CategoryId FOREIGN KEY ([CategoryId]) REFERENCES [Category]([Id])
);

CREATE TABLE [UserBook]
(
    [UserId] INT NOT NULL,
    [BookId] INT NOT NULL,
    [IsRead] BIT NOT NULL DEFAULT 0,
    CONSTRAINT [PK_UserBook] PRIMARY KEY ([UserId], [BookId]),
    CONSTRAINT [FK_UserBook_User_UserId] FOREIGN KEY ([UserId]) REFERENCES [User]([Id]),
    CONSTRAINT [FK_UserBook_Book_BookId] FOREIGN KEY ([BookId]) REFERENCES [Book]([Id])
);

CREATE TABLE [List]
(
    [Id] INT IDENTITY(1,1),
    [Name] NVARCHAR(50) NOT NULL,
    [Description] NVARCHAR(MAX) NOT NULL,
    [UserId] INT NOT NULL,
    CONSTRAINT PK_List PRIMARY KEY ([Id]),
    CONSTRAINT FK_List_User FOREIGN KEY (UserId) REFERENCES [User](Id)
);

CREATE TABLE [BookList]
(
    [ListId] INT NOT NULL,
    [BookId] INT NOT NULL,
    CONSTRAINT PK_BookList PRIMARY KEY ([ListId], [BookId]),
    CONSTRAINT FK_BookList_Book_BookId FOREIGN KEY ([BookId]) REFERENCES [Book]([Id]),
    CONSTRAINT FK_BookList_List_ListId FOREIGN KEY ([ListId]) REFERENCES [List]([Id])
);
