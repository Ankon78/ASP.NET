using FoodWaste.DB;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodWaste.Controllers
{
    public class AdminController : Controller
    {
        public IEnumerable Employees { get; private set; }

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult List()
        {
            var db = new TestEntities1();
            var foods = db.Requests.ToList();
            return View(foods);
        }
        [HttpGet]
        public ActionResult AddEmployees(int id)
        {
            var db = new TestEntities1();
            var ext = (from it in db.Requests
                       where it.id == id
                       select it).SingleOrDefault();
            ViewBag.List = new SelectList(Employees, "id", "Name");
            return View();
        }
        [HttpPost]
        public ActionResult AddEmployees(Request r)
        {
            var db = new TestEntities1();
            var ext = (from it in db.Requests
                       where it.id == r.id
                       select it).SingleOrDefault();
            ext.Food = r.Food;
            ext.ExpireDate = r.ExpireDate;
            ext.State = r.State;
            ext.AssignEmployee = r.AssignEmployee;
            
            db.SaveChanges();
            return RedirectToAction("List", "Admin");
        }
    }
}