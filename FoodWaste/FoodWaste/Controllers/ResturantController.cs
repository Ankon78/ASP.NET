using FoodWaste.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodWaste.Controllers
{
    public class ResturantController : Controller
    {
        // GET: Resturant
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Request r)
        {   
            TestEntities1 testEntities = new TestEntities1();
            testEntities.Requests.Add(r);
            testEntities.SaveChanges();
            return RedirectToAction("Index", "Resturant");
        }
    }
}