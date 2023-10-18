/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/



if not exists (select * from dbo.Shift)
begin
    insert into dbo.Shift (Name) 
    values 
        ('Day'),
        ('Night')
end

if not exists (select * from dbo.Employee)
begin
    declare @dayShift int;
    declare @nightShift int;

    select @dayShift = Id from dbo.Shift where Name = 'Day';
    select @nightShift = Id from dbo.Shift where Name = 'Night';

    insert into dbo.Employee (Name, Title, Active, DateCreated, DateUpdated, Shift_Id) 
    values 
          ('Stephen Lamb', 'Manager', 1, GETDATE(), GETDATE(), @dayShift),
          ('Noah Holloway', 'Assistant Manager', 1, GETDATE(), GETDATE(), @dayShift),
          ('Whoopi Herring', 'Assistant Manager', 0, GETDATE(), GETDATE(), @dayShift),
          ('Dean Davidson', 'Assistant Manager', 1, GETDATE(), GETDATE(), @nightShift),
          ('Fuller Sosa', 'Clerk', 1, GETDATE(), GETDATE(), @dayShift),
          ('Igor Michael', 'Clerk', 1, GETDATE(), GETDATE(), @nightShift),
          ('Astra Marsh', 'Clerk', 1, GETDATE(), GETDATE(), @dayShift),
          ('Althea Cash', 'Clerk', 1, GETDATE(), GETDATE(), @nightShift),
          ('Dennis Bright', 'Clerk', 0, GETDATE(), GETDATE(), @nightShift),
          ('Amity Preston', 'Clerk', 1, GETDATE(), GETDATE(), @dayShift)
end