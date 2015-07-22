CREATE PROCEDURE GetAllTimeEntriesForOneEmp
(
	@EmpID int
)
AS

SELECT *
FROM TimeSheet
WHERE EmpID = @EmpID