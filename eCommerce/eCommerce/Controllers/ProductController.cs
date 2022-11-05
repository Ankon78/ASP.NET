using eCommerce.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eCommerce.Controllers
{
    public class ProductController : Controller
    {
        List<Item> li=new List<Item>();
        // GET: Product
        public ActionResult Index()
        {
            var db = new DemoEntities();
            var products = db.Items.ToList();
            return View(products);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Item it)
        {
            var db = new DemoEntities();
            db.Items.Add(it);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int Id)
        {
            var db = new DemoEntities();
            var ext = (from it in db.Items
                       where it.Id == Id
                       select it).SingleOrDefault();
            return View(ext);
        }
        [HttpPost]
        public ActionResult Edit(Item s)
        {
            var db = new DemoEntities();
            var ext = (from it in db.Items
                       where it.Id == s.Id
                       select it).SingleOrDefault();
            ext.Name = s.Name;
            ext.Price = s.Price;
            ext.Qty = s.Qty;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(int Id)
        {
            var db = new DemoEntities();
            var ext = (from it in db.Items
                       where it.Id == Id
                       select it).SingleOrDefault();
            return View(ext);
        }
        [HttpPost]
        public ActionResult Delete(Item s)
        {
            var db = new DemoEntities();
            var ext = (from it in db.Items
                       where it.Id == s.Id
                       select it).SingleOrDefault();
            db.Items.Remove(ext);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        /* [HttpGet]
         public ActionResult Product(int Id)
         {
             var db = new DemoEntities();
             var products = db.Items.ToList();
             return View(products);
         }
         [HttpPost]
         public ActionResult Product(Item s)
         {
             var db = new DemoEntities();
             var products = db.Items.ToList();
             var ext = (from it in db.Items
                        where it.Id == s.Id
                        select it).SingleOrDefault();
             ext.Name = s.Name;
             ext.Price = s.Price;
             ext.Qty = s.Qty;
             if (Session["cart"] == null)
             {
                 products.Add(ext);
                 Session["cart"] = products;
             }

             return RedirectToAction("Index");
         }*/
        [HttpGet]
        public ActionResult Buy(int Id)
        {
            //AddToCart(Id);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Buy(Item s)
        {
            /*ItemModel productModel = new ItemModel();
            
            if (Session["cart"] == null)
            {
                List<Item> cart = new List<Item>();
                cart.Add(new Item { Qty = productModel.find(Id), Quantity = 1 });
                cart.Add(cart[0]);
                Session["cart"] = cart;
            }
            else
            {
                List<Item> cart = (List<Item>)Session["cart"];
                int index = isExist(id);
                if (index != -1)
                {
                    cart[index]+;
                }
                else
                {
                    cart.Add(new Item { Product = productModel.find(Id), Quantity = 1 });
                }
                Session["cart"] = cart;
            }
            return RedirectToAction("Index");*/
            var db = new DemoEntities();
            var products = db.Items.ToList();
            var ext = (from it in db.Items
                       where it.Id == s.Id
                       select it).SingleOrDefault();
            ext.Name = s.Name;
            ext.Price = s.Price;
            ext.Qty = s.Qty;
            if (Session["cart"] == null)
            {
                products.Add(ext);
                Session["cart"] = products;
            }

            return RedirectToAction("Index");
        }

        public ActionResult Remove(string id)
        {
            /*List<Item> cart = (List<Item>)Session["cart"];
            int index = isExist(id);
            cart.RemoveAt(index);
            Session["cart"] = cart;*/
            return RedirectToAction("Index");
        }

       /* private int isExist(string id)
        {
            List<Item> cart = (List<Item>)Session["cart"];
            for (int i = 0; i < cart.Count; i++)
                if (cart[i].Product.Id.Equals(id))
                    return i;
            return -1;
        }*/
    }
 
}