using Microsoft.AspNetCore.Mvc;
using ProductMasterDetails.Data;
using ProductMasterDetails.Models;
using ProductMasterDetails.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductMasterDetails.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductDbContext _context;


        public ProductController(ProductDbContext context) // Dependency Injection
        {
            _context = context;
        }
        public IActionResult Index(int pg = 1)
        {
            List<Product> products = _context.Products.ToList();

            const int pageSize = 4;
            if (pg < 1)
                pg = 1;

            int recsCount = products.Count();

            var pager = new Pager(recsCount, pg, pageSize);

            int recSkip = (pg - 1) * pageSize;

            var data = products.Skip(recSkip).Take(pager.PageSize).ToList();

            this.ViewBag.Pager = pager;

            //return View(products);
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            Product prod = new Product();
            return View(prod);
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            float productCost = product.Cost;
            float productPrice = product.Price;
            HelperClass ult = new HelperClass();
            if (ult.compareprice(productCost, productPrice) && ModelState.IsValid)
            {
                _context.Add(product);
                _context.SaveChanges();
                return RedirectToAction("index");
            }

            return View(product);

        }

        public IActionResult Details(string Id)
        {
            Product prod = _context.Products.Where(p => p.Code == Id).FirstOrDefault();
            return View(prod);
        }
    }

}
