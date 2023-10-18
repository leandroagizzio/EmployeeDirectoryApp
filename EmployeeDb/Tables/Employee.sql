CREATE TABLE [dbo].[Employee]
(
	[Id] INT NOT NULL PRIMARY KEY Identity, 
    [Name] NVARCHAR(50) NOT NULL, 
    [Title] NVARCHAR(50) NOT NULL, 
    [Active] BIT NOT NULL, 
    [DateCreated] DATETIME NOT NULL, 
    [DateUpdated] DATETIME NOT NULL, 
    [Shift_Id] INT NOT NULL, 
    CONSTRAINT [FK_Employee_ToTable_Shift] FOREIGN KEY ([Shift_Id]) REFERENCES [Shift]([Id])
)
