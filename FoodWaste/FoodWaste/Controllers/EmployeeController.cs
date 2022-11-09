using FoodWaste.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodWaste.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
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
    }
}