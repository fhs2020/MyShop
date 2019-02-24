using MyShop.Core.Contracts;
using MyShop.Core.Models;
using MyShop.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyShop.WebUI.Controllers
{
    public class HomeController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Products
        public ActionResult Index()
        {
            return View(db.Products.ToList());
        }


        public ActionResult Details(string Id)
        {
            Product product = db.Products.Find(Id);
            
            if (product == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(product);
            }


        }



        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}