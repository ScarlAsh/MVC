﻿namespace Day6Demo_SD44.Models
{
    public class EmployeeList
    {
        public static List<Employee> Employees = new List<Employee>()
        {
            new Employee() { ID = 1, Name = "Ahmed", Age = 40},
            new Employee() { ID = 2, Name = "Mohamed", Age = 30},
            new Employee() { ID = 3, Name = "Ali", Age = 20},
            new Employee() { ID = 4, Name = "Mostafa", Age = 10}
        };
    }
}
