
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 07/02/2019 17:29:03
-- Generated from EDMX file: C:\Users\marti\Documents\ETNA\M1\C#\MovieNet\MovieNet.UI\DataModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [MyDatabase];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'UserSet'
CREATE TABLE [dbo].[UserSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Login] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'AvisSet'
CREATE TABLE [dbo].[AvisSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Comment] nvarchar(max)  NOT NULL,
    [Note] float  NULL,
    [User_Id] int  NOT NULL,
    [Movie_Id] int  NOT NULL
);
GO

-- Creating table 'MovieSet'
CREATE TABLE [dbo].[MovieSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Titre] nvarchar(max)  NOT NULL,
    [Genre] nvarchar(max)  NOT NULL,
    [Resume] nvarchar(max)  NOT NULL,
    [Moyenne] float  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'UserSet'
ALTER TABLE [dbo].[UserSet]
ADD CONSTRAINT [PK_UserSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AvisSet'
ALTER TABLE [dbo].[AvisSet]
ADD CONSTRAINT [PK_AvisSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'MovieSet'
ALTER TABLE [dbo].[MovieSet]
ADD CONSTRAINT [PK_MovieSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [User_Id] in table 'AvisSet'
ALTER TABLE [dbo].[AvisSet]
ADD CONSTRAINT [FK_UserAvis]
    FOREIGN KEY ([User_Id])
    REFERENCES [dbo].[UserSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserAvis'
CREATE INDEX [IX_FK_UserAvis]
ON [dbo].[AvisSet]
    ([User_Id]);
GO

-- Creating foreign key on [Movie_Id] in table 'AvisSet'
ALTER TABLE [dbo].[AvisSet]
ADD CONSTRAINT [FK_MovieAvis]
    FOREIGN KEY ([Movie_Id])
    REFERENCES [dbo].[MovieSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MovieAvis'
CREATE INDEX [IX_FK_MovieAvis]
ON [dbo].[AvisSet]
    ([Movie_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------