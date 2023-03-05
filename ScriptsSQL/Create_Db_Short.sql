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
    CONSTRAINT UK_User_Email UNIQUE ([Email]),
    CONSTRAINT CK_User_Password CHECK (LEN([Password]) >= 6)
);
GO
CREATE TABLE [Category]
(
    [Id] INT IDENTITY(1,1),
    [Name] NVARCHAR(50) NOT NULL,
    CONSTRAINT PK_Category PRIMARY KEY ([Id]),
    CONSTRAINT UK_Category_Name UNIQUE ([Name])
);
GO
CREATE TABLE [Book]
(
    [Id] INT IDENTITY(1,1),
    [Title] NVARCHAR(100) NOT NULL,
    [Author] NVARCHAR(100) NOT NULL,
    [Description] NVARCHAR(MAX) NULL,
	[CategoryId] int NULL,
    CONSTRAINT PK_Book PRIMARY KEY ([Id]),
	CONSTRAINT FK_Book_Category FOREIGN KEY ([CategoryId]) REFERENCES [Category](Id),
    CONSTRAINT UK_Book_Title_Author UNIQUE ([Title],[Author])
);
GO
CREATE TABLE [UserFavorite]
(
    [UserId] INT NOT NULL,
    [BookId] INT NOT NULL,
    CONSTRAINT PK_UserFavorite PRIMARY KEY ([UserId], [BookId]),
    CONSTRAINT FK_UserFavorite_User_UserId FOREIGN KEY ([UserId]) REFERENCES [User]([Id]),
    CONSTRAINT FK_UserFavorite_Book_BookId FOREIGN KEY ([BookId]) REFERENCES [Book]([Id])
);
