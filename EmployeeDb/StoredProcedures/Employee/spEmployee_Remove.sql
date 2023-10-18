CREATE PROCEDURE [dbo].[spEmployee_Remove]
	@Id int
AS
BEGIN
	DELETE FROM Employee WHERE Id = @Id
END
