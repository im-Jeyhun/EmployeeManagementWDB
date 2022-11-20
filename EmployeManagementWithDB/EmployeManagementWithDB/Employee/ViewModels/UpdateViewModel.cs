using EmployeManagementWithDB.Atributs;
using System.ComponentModel.DataAnnotations;

namespace EmployeManagementWithDB.Employee.ViewModels
{
    public class UpdateViewModel
    {
        [RegularExpression(@"[A-Za-z]{3,20}", ErrorMessage = "Name must be upper than 3 char and must consist of letters")]
        [Required]
        public string Name { get; set; }

        [RegularExpression(@"[A-Za-z]{3,20}", ErrorMessage = "Name must be upper than 3 char and must consist of letters")]
        [Required]
        public string Surname { get; set; }

        [RegularExpression(@"[A-Za-z]{3,20}", ErrorMessage = "Name must be upper than 3 char and must consist of letters")]
        [Required]
        public string Fathername { get; set; }

        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        [Required]
        public string Email { get; set; }

        [Required]

        [FinnValidation(ErrorMessage = "Finn code must be exist of 7 char , less 1 fiqure and less 1 letter")]
        public string Finn { get; set; }

        [Required]
        public string EmpCode { get; set; }

        public UpdateViewModel()
        {

        }
        public UpdateViewModel(string name, string surname, string fathername, string email, string finn, string empCode)
        {

            Name = name;
            Surname = surname;
            Fathername = fathername;
            Email = email;
            Finn = finn;
            EmpCode = empCode;
        }
    }
}
