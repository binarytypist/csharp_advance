namespace WorkForce.JobManagementSystem.Interfaces
{
    // Represents a contract for any type of employee in the system
    // This is an abstraction (NOT implementation)

    // Why interface?
    // - Allows different employee types (FullTime, PartTime)
    // - Enables polymorphism (engine works with any employee type)
    // - Supports Dependency Inversion Principle (DIP)

    public interface IEmployee
    {
        // Employee name (read-only, set only in constructor of implementing class)
        string Name { get; }

        // How many hours per week this employee can work
        int WorkHoursPerWeek { get; }
    }
}