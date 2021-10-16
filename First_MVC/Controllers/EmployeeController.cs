using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using First_MVC.Models;

namespace First_MVC.Controllers
{
    public class EmployeeController : Controller
    {
        public IEmployee Employee { get; }

        public EmployeeController(IEmployee _employee)
        {
            Employee = _employee;
        }

        public IActionResult Index()
        {
            var emps = Employee.GetEmployees();
            return View(emps);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]

        public IActionResult Create(Employee employee)
        {
            Employee.AddEmployee(employee);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int Id)
        {
            var r = Employee.DeleteEmployee(Id);
            if (r)
            {
                ViewBag.message = " Record Deleted Successfully!!!";

            }
            else
            {
                ViewBag.message = "Record Is Not Deleted.";
            }

            return RedirectToAction("Index");
        }
    }
}
