CREATE PROCEDURE [dbo].[spEmployee_ToggleActive]
	@Id INT
AS
BEGIN
    DECLARE @Status BIT;
    
    SELECT @Status = Active FROM Employee WHERE Id = @Id;

    IF (@Status = 0)
        SET @Status = 1;
    ELSE
        SET @Status = 0;

    UPDATE Employee SET
        Active = @Status,
        DateUpdated = GETDATE()
        WHERE Id = @Id; 

    SELECT [Id], [Name], [Title], [Active], [DateCreated], [DateUpdated], [Shift_Id]
            FROM Employee WHERE Id = @Id;
END
