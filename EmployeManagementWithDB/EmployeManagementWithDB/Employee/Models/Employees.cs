namespace EmployeManagementWithDB.Employee.Models
{
    public class Employees
    {
        public int Id { get; set; }

        public string EmpCode { get; set; }
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Fathername { get; set; }

        public string  Email { get; set; }

        public string Finn { get; set; }

        public bool IsDeleted { get; set; } 

    }
}
