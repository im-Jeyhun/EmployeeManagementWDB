using EmployeManagementWithDB.DataBase.Repository.Common;

namespace EmployeManagementWithDB.DataBase
{
    public class TablePkAutoRandomGenerator
    {
        static Random randomCode = new Random();

        public static string RandomEmpCode
        {
            get
            {
                DataContext dbContext = new DataContext();

                var employees = dbContext.Employees.ToList();



                string _empCode = "E" + randomCode.Next(10000, 100000);


                foreach (var employee in employees)
                {
                    if (employee.EmpCode == _empCode)
                    {
                        do
                        {
                            _empCode = "E" + randomCode.Next(10000, 100000);

                        } while (employee.EmpCode != _empCode);
                    }


                }


                return _empCode;
            }
        }

    }
}
