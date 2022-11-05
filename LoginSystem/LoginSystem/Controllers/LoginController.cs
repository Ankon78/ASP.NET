using LoginSystem.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoginSystem.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Registration(User r)
        {
            NGOEntities db = new NGOEntities();
            
            db.Users.Add(r);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(User r)
        {
            NGOEntities db = new NGOEntities();
            var login = (from c in db.Users
                          where c.Username == r.Username && c.Password == r.Password 
                           select c);
            if(login != null)
            {
                return RedirectToAction ("Index", "Admin");
            }
           /* else if(login != null && r.Role == "User"){
                return RedirectToAction("Index", "User");
            }
            else if(login != null && r.Role == "Doner"){
                return RedirectToAction("Index", "Doner");
            }*/

            return View();
        }
    }
}