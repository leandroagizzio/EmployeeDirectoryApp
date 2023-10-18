CREATE PROCEDURE [dbo].[spShift_GetOne]
	@Id INT
AS
BEGIN
	SELECT [Id], [Name]
	FROM Shift
	WHERE Id = @Id
END