using MyShop.Core.Contracts;
using MyShop.Core.Models;
using MyShop.Core.ViewModels;
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
        public ActionResult Index(string Category=null)
        {
            List<Product> products;
            List<ProductCategory> categories = db.ProductCategories.ToList();

            if (Category == null)
            {
                products = db.Products.ToList();


            }
            else
            {
                products = db.Products.Where(p => p.Category == Category).ToList();

            }
                ProductListViewModel model = new ProductListViewModel();

            model.Products = products;
            model.ProductCategories = categories;

            return View(model);
        }


        public ActionResult Details(int Id)
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