namespace EmployeManagementWithDB.Employee.ViewModels
{
    public class ListViewModel
    {
        public string EmpCode { get; set; }
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Fathername { get; set; }

        public bool IsDeleted { get; set; }

        public ListViewModel(string empCode, string name, string surname, string fathername, bool ısDeleted)
        {
            EmpCode = empCode;
            Name = name;
            Surname = surname;
            Fathername = fathername;
            IsDeleted = ısDeleted;
        }
    }
}
