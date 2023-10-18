CREATE PROCEDURE [dbo].[spShift_Upsert]
	@Id INT,
    @Name NVARCHAR(50),
    @Shift_Id INT OUTPUT
AS
BEGIN
    IF EXISTS (SELECT 1 FROM Shift WHERE Id = @Id)
    BEGIN
        UPDATE Shift SET
            Name = @Name
            WHERE Id = @Id;    
        Set @Shift_Id = @Id
    END
    ELSE BEGIN
        INSERT INTO Shift (Name)
            VALUES (@Name);
        SELECT @Shift_Id = SCOPE_IDENTITY();
    END
    --SELECT [Id], [Name]
    --        FROM Shift WHERE Id = @Id;
END
