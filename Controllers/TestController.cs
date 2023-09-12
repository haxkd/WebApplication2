using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class TestController : Controller
    {
        CrudEntities crudEntities = new CrudEntities();
        // GET: Test
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(DtoEmployee emp) // form employee
        {
            Employee employee2 = new Employee(); // database employee
            employee2.name = emp.name;
            employee2.email = emp.email;
            employee2.gender = emp.gender;
            employee2.password = emp.password;           
            crudEntities.Employees.Add(employee2);
            crudEntities.SaveChanges();
            return View();
        }


        public ActionResult Show()
        {
            List<Employee> emp =  crudEntities.Employees.ToList();
            return View(emp);
        }
    }
}