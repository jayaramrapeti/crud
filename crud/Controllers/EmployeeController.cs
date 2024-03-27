using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using crud.Models;
namespace crud.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddEmployee()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddEmployee(EmpModel emp)
        {
            if (ModelState.IsValid)
            {
                EmpRepository obj = new EmpRepository();
                obj.AddEmployee(emp);
                return RedirectToAction("GetAllEmpDetails");
            }
            else
            {
                return View();
            }
        }

        public ActionResult GetAllEmpDetails()
        {
            EmpRepository obj = new EmpRepository();
            ModelState.Clear();
            return View(obj.GetAllEmployees());
        }

        public ActionResult EditEmpDetails(int id)
        {
            EmpRepository obj = new EmpRepository();
            return View(obj.GetAllEmployees().Find(Emp => Emp.Empid==id));
        }

        [HttpPost]
        public ActionResult EditEmpDetails(int id,EmpModel obj)
        {
            if (ModelState.IsValid)
            {
                EmpRepository obj1 = new EmpRepository();
                obj1.UpdateEmployee(obj);
                return RedirectToAction("GetAllEmpDetails");
            }
            return View();
        }

        public ActionResult DeleteEmp(int id)
        {
            if (ModelState.IsValid)
            {
                EmpRepository obj = new EmpRepository();
                obj.DeleteEmployee(id);
                return RedirectToAction("GetAllEmpDetails");
            }
            return View();
        }
    }
}