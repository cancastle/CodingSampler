CREATE PROCEDURE AddTimeEntry
(
	@HoursWorked decimal,
	@Date datetime,
	@EmpID int
)
AS
BEGIN
	INSERT INTO TimeSheet (HoursWorked, [Date], EmpID)
	VALUES (@HoursWorked, @Date, @EmpID)

END