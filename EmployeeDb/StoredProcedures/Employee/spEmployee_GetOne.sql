CREATE PROCEDURE [dbo].[spEmployee_GetOne]
	@Id INT
AS
BEGIN
	SELECT [e].[Id], [e].[Name], [e].[Title], [e].[Active], [e].[DateCreated], [e].[DateUpdated], [e].[Shift_Id], [s].[Id], [s].[Name]
	FROM Employee e LEFT JOIN Shift s ON e.Shift_Id = s.Id
	WHERE e.Id = @Id
END
