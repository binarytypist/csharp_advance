namespace WorkForce.JobManagementSystem.Models.Employees
{
    // Represents a Part-Time employee in the system
    // Inherits from Employee base class

    // Why inheritance?
    // - Reuses shared Employee logic (Name, WorkHoursPerWeek)
    // - Only defines specific behavior (20 working hours)

    public class PartTimeEmployee : Employee
    {
        // Constant defines weekly working capacity for part-time employee
        private const int WeeklyWorkingHours = 20;

        // Constructor passes data to base Employee class
        public PartTimeEmployee(string name)
            : base(name, WeeklyWorkingHours)
        {
        }
    }
}