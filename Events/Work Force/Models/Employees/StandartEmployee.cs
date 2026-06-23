namespace WorkForce.JobManagementSystem.Models.Employees
{
    // Represents a Standard (full-time) employee in the system
    // Inherits from Employee base class

    // Why inheritance?
    // - Reuses shared Employee logic (Name, WorkHoursPerWeek)
    // - Only defines specific working capacity (40 hours/week)

    public class StandartEmployee : Employee
    {
        // Constant defines weekly working capacity for standard employee
        private const int WeeklyWorkingHours = 40;

        // Constructor passes name and working hours to base class
        public StandartEmployee(string name)
            : base(name, WeeklyWorkingHours)
        {
        }
    }
}