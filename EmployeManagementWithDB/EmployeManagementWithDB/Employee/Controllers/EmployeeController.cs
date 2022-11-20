using EmployeManagementWithDB.DataBase;
using EmployeManagementWithDB.DataBase.Repository.Common;
using EmployeManagementWithDB.Employee.Models;
using EmployeManagementWithDB.Employee.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EmployeManagementWithDB.Employee.Controllers
{
    [Route("Employee")]
    public class EmployeeController : Controller
    {

        [HttpGet("Add", Name ="employee-add")]
        public ActionResult Add()
        {
            return View("~/Employee/Views/Add.cshtml");
        }

        [HttpPost("Add", Name = "employee-add")]
        public ActionResult Add(AddViewModel admodel)
        {

            if (!ModelState.IsValid)
            {
                return View("~/Employee/Views/Add.cshtml");
            }
            using DataContext dbContext = new DataContext();
            dbContext.Employees.Add(new Employees
            {


                EmpCode = TablePkAutoRandomGenerator.RandomEmpCode,

                Name = admodel.Name,
                Surname = admodel.Surname,
                Fathername = admodel.Fathername,
                Email = admodel.Email,
                Finn = admodel.Finn,
                IsDeleted = default



            });
            dbContext.SaveChanges();
            return RedirectToAction(nameof(List));
        }

        [HttpGet("List", Name = "employee-list")]
        public ActionResult List()
        {
            using DataContext dbContext = new DataContext();


            var model = dbContext.Employees
                .Select(e => new ListViewModel(e.EmpCode, e.Name, e.Surname, e.Fathername, e.IsDeleted))
                .ToList();

            return View("~/Employee/Views/List.cshtml", model);
        }


        [HttpGet("Delete/{empcode}", Name = "employee-delete")]
        public ActionResult Delete(string empcode)
        {
            using DataContext dbContext = new DataContext();

            var emp = dbContext.Employees.FirstOrDefault(e => e.EmpCode == empcode);

            if (emp == null)
            {
                return NotFound();
            }

            emp.IsDeleted = true;

            dbContext.SaveChanges();

            return RedirectToAction(nameof(List));

        }

        [HttpGet("Update/{empcode}", Name = "employee-update-empcode")]
        public ActionResult Update(string empcode)
        {
            using DataContext dbContext = new DataContext();

            var emp = dbContext.Employees.FirstOrDefault(e => e.EmpCode == empcode);

            if (emp == null && emp.IsDeleted == true)
            {
                return NotFound();
            }

            var oldEmp = new UpdateViewModel(emp.Name, emp.Surname, emp.Fathername, emp.Email, emp.Finn, emp.EmpCode);
            return View("~/Employee/Views/Update.cshtml", oldEmp);
        }
        [HttpPost("Update", Name = "employee-update")]
        public ActionResult Update(UpdateViewModel updatedModel)
        {
            using DataContext dbContext = new DataContext();

            var emp = dbContext.Employees.FirstOrDefault(e => e.EmpCode == updatedModel.EmpCode);

            if (emp == null && emp.IsDeleted == true)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View("~/Employee/Views/Update.cshtml", updatedModel);
            }
            emp.Name = updatedModel.Name;
            emp.Surname = updatedModel.Surname;
            emp.Fathername = updatedModel.Fathername;
            emp.Email = updatedModel.Email;
            emp.Finn = updatedModel.Finn;
            dbContext.SaveChanges();



            return RedirectToAction(nameof(List));
        }




    }
}
