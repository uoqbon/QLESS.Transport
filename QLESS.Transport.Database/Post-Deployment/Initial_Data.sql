/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
USE [QLESS.Transport.Database]

IF NOT EXISTS (SELECT 1 FROM [QLESS].CardType WHERE Id = 1)
BEGIN
    INSERT [QLESS].CardType (Id, [Name], Rate, InitialLoad) VALUES (1, 'Regular', 15.00, 100.00);
END

IF NOT EXISTS (SELECT 1 FROM [QLESS].CardType WHERE Id = 2)
BEGIN
    INSERT [QLESS].CardType (Id, [Name], Rate, InitialLoad) VALUES (2, 'Discounted', 10.00, 500.00);
END

IF NOT EXISTS (SELECT 1 FROM [QLESS].Station WHERE Id = 1)
BEGIN
    INSERT [QLESS].Station (Id, [Name], Distance) VALUES (1, 'Taft Ave', 0);
END

IF NOT EXISTS (SELECT 1 FROM [QLESS].Station WHERE Id = 2)
BEGIN
    INSERT [QLESS].Station (Id, [Name], Distance) VALUES (2, 'Magallanes', 5);
END 

IF NOT EXISTS (SELECT 1 FROM [QLESS].Station WHERE Id = 3)
BEGIN
    INSERT [QLESS].Station (Id, [Name], Distance) VALUES (3, 'Ayala Ave', 10);
END

IF NOT EXISTS (SELECT 1 FROM [QLESS].Station WHERE Id = 4)
BEGIN
    INSERT [QLESS].Station (Id, [Name], Distance) VALUES (4, 'Buendia', 15);
END

IF NOT EXISTS (SELECT 1 FROM [QLESS].Station WHERE Id = 5)
BEGIN
    INSERT [QLESS].Station (Id, [Name], Distance) VALUES (5, 'Guadalupe', 20);
END

IF NOT EXISTS (SELECT 1 FROM [QLESS].Station WHERE Id = 6)
BEGIN
    INSERT [QLESS].Station (Id, [Name], Distance) VALUES (6, 'Boni', 25);
END

IF NOT EXISTS (SELECT 1 FROM [QLESS].Station WHERE Id = 7)
BEGIN
    INSERT [QLESS].Station (Id, [Name], Distance) VALUES (7, 'Shaw', 30);
END