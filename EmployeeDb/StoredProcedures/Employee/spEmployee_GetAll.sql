CREATE PROCEDURE [dbo].[spEmployee_GetAll]
AS
BEGIN
	SELECT [e].[Id], [e].[Name], [e].[Title], [e].[Active], [e].[DateCreated], [e].[DateUpdated], [e].[Shift_Id], [s].[Id], [s].[Name]
	FROM Employee e LEFT JOIN Shift s ON e.Shift_Id = s.Id
END
