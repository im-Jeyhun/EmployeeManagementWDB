using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace EmployeManagementWithDB.Atributs
{
    public class FinnValidation : ValidationAttribute
    {

        public override bool IsValid(object? value)
        {
            var fin = value.ToString();

            string regexed = @"^([A-Z0-9]{7}$)";

            return Regex.IsMatch(fin, regexed);
        

        }
    }
}
