using WorkForce.JobManagementSystem.Interfaces;

namespace WorkForce.JobManagementSystem.Models.Employees
{
    // Base abstract class for all types of employees
    // Implements IEmployee interface

    // Why abstract?
    // - We never create "Employee" directly
    // - Only specific types (StandartEmployee, PartTimeEmployee)
    // - Provides shared logic for all employees

    public abstract class Employee : IEmployee
    {
        // Constructor sets common properties for all employees
        public Employee(string name, int weeklyWorkingHours)
        {
            this.Name = name;
            this.WorkHoursPerWeek = weeklyWorkingHours;
        }

        // Employee name (read-only after creation)
        public string Name { get; private set; }

        // Weekly working capacity (read-only)
        public int WorkHoursPerWeek { get; }
    }
}