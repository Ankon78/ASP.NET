﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using WebApplicationCRUD.DB;

namespace WebApplicationCRUD.Controllers
{
    public class StudentController : Controller
    {
        

        // GET: Student
        public ActionResult Index()
        {
            var db = new DemoEntities();
            var students = db.Students.ToList();

            return View(students);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Student st)
        {
            var db = new DemoEntities();
            db.Students.Add(st);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var db = new DemoEntities();
            var ext = (from st in db.Students
                       where st.id == id
                       select st).SingleOrDefault();
            return View(ext);
        }
        [HttpPost]
        public ActionResult Edit(Student s)
        {
            var db = new DemoEntities();
            var ext = (from st in db.Students
                       where st.id == s.id
                       select st).SingleOrDefault();
            ext.Name = s.Name;
            ext.Age = s.Age;
            ext.Dept = s.Dept;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var db = new DemoEntities();
            var ext = (from st in db.Students
                       where st.id == id
                       select st).SingleOrDefault();
            return View(ext);
        }
        [HttpPost]
        public ActionResult Delete(Student s)
        {
            var db = new DemoEntities();
            var ext = (from st in db.Students
                       where st.id == s.id
                       select st).SingleOrDefault();
            db.Students.Remove(ext);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}