CREATE PROCEDURE [dbo].[spShift_GetAll]
AS
BEGIN
	SELECT [Id], [Name]
	FROM Shift
END
