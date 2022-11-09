using FoodWaste.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodWaste.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(User r)
        {
            TestEntities1 TestEntities1 = new TestEntities1();
            var login = (from c in TestEntities1.Users
                         where c.Name == r.Name && c.Password == r.Password && c.Role == r.Role
                         select c);
            if (login != null && r.Role=="Admin")
            {
                return RedirectToAction("Index", "Admin");
            }
            else if (login != null && r.Role == "Employee")
            {
                return RedirectToAction("Index", "Employee");
            }
            if (login != null && r.Role == "ROwner")
            {
                return RedirectToAction("Index", "Resturant");
            }
            return View();
        }
    }
}