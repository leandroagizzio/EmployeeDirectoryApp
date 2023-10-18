CREATE PROCEDURE [dbo].[spEmployee_Upsert]
	@Id INT,
    @Name NVARCHAR(50),
    @Title NVARCHAR(50),
    @Shift_Id INT,
    @Employee_Id INT OUTPUT
AS
BEGIN
    IF EXISTS (SELECT 1 FROM Employee WHERE Id = @Id)
    BEGIN
        UPDATE Employee SET
            Name = @Name,
            Title = @Title,
            DateUpdated = GETDATE(),
            Shift_Id = @Shift_Id
            WHERE Id = @Id;        
        SET @Employee_Id = @Id
    END
    ELSE BEGIN
        INSERT INTO Employee (Name, Title, Active, DateCreated, DateUpdated, Shift_Id)
            VALUES (@Name, @Title, 1, GETDATE(), GETDATE(), @Shift_Id);
        SELECT @Employee_Id = SCOPE_IDENTITY();
    END
    --SELECT [Id], [Name], [Title], [Active], [DateCreated], [DateUpdated], [Shift_Id]
    --        FROM Employee WHERE Id = @Id;
END


	--[Id] INT NOT NULL PRIMARY KEY Identity, 
 --   [Name] NVARCHAR(50) NOT NULL, 
 --   [Title] NVARCHAR(50) NOT NULL, 
 --   [Active] BIT NOT NULL, 
 --   [DateCreated] DATETIME NOT NULL, 
 --   [DateUpdated] DATETIME NOT NULL, 
 --   [Shift_Id] INT NOT NULL, 