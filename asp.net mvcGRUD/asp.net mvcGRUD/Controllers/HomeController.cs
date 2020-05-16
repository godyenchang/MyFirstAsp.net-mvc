using asp.net_mvcGRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace asp.net_mvcGRUD.Controllers
{
    public class HomeController : Controller
    {
        dbEmployeeEntities db = new dbEmployeeEntities();
        // GET: Home
        public ActionResult Index()
        {
            var emps = db.tEmployee.OrderByDescending(m => m.fId).ToList();
            return View(emps);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(string fName, string fPhone, int fSalary)
        {
            tEmployee emp = new tEmployee();
            emp.fName = fName;
            emp.fPhone = fPhone;
            emp.fSalary = fSalary;
            db.tEmployee.Add(emp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int fId)
        {
            var emp = db.tEmployee.Where(m => m.fId == fId).FirstOrDefault();
            db.tEmployee.Remove(emp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int fId)
        {
            var emp = db.tEmployee.Where(m => m.fId == fId).FirstOrDefault();
            return View(emp);
        }

        [HttpPost]
        public ActionResult Edit(int fId, string fName, string fPhone, int fSalary)
        {
            var emp = db.tEmployee.Where(m => m.fId == fId).FirstOrDefault();
            emp.fName = fName;
            emp.fPhone = fPhone;
            emp.fSalary = fSalary;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}