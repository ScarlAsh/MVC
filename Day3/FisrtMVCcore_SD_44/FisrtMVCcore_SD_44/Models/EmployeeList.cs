namespace FisrtMVCcore_SD_44.Models
{
    public class EmployeeList
    {
        public static List<Employee> Employees = new List<Employee>()
        {
            new Employee() { Id = 1, Name = "Mohamed", Age = 11, Email = "Mohamed@company.com" },
            new Employee() { Id = 2, Name = "Ali", Age = 12, Email = "Ali@company.com" },
            new Employee() { Id = 3, Name = "Asmaa", Age = 13, Email = "Asmaa@company.com" },
            new Employee() { Id = 4, Name = "Basma", Age = 14, Email = "Basma@company.com" },
            new Employee() { Id = 5, Name = "Mona", Age = 15, Email = "Mona@company.com" }
        };
    }

}
