--select * from Employee


--DECLARE @Id INT;

--SET @Id = 7;

--EXECUTE dbo.spEmployee_ToggleActive @Id
--GO

EXECUTE dbo.spEmployee_GetAll
GO

DECLARE @Id INT; -- = 1004;
DECLARE @Employee_Id INT;

DECLARE @Name NVARCHAR(50) = 'Lawrence Posquito';
DECLARE @Title NVARCHAR(50) = 'Clerk';
DECLARE @Shift_Id INT = 1;

EXECUTE dbo.spEmployee_Upsert @Id, @Name, @Title, @Shift_Id, @Employee_Id ;
--GO

SELECT @Employee_Id
GO

DECLARE @Id_Del INT = 3011;
EXECUTE dbo.spEmployee_Remove @Id_Del;