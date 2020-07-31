using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SSMS.Areas.StockManager.Models;
using SSMS.Areas.StockManager.ViewModels;
using SSMS.Database;

namespace SSMS.Areas.StockManager.Controllers
{
    [Area("StockManager")]
    [Route("StockManager/[controller]/[action]")]
    public class HomeController : Controller
    {
        private readonly dataContext _context;
        [Obsolete]
        private readonly IHostingEnvironment hostingEnvironment;

        [Obsolete]
        public HomeController(dataContext context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            this.hostingEnvironment = hostingEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult AddStock()
        {
            ViewBag.ProductCatagory = new SelectList(_context.ProductCatagory.AsNoTracking().
                ToList(), "ProductCatagoryId", "ProductCatagoryName");
            return View();
        }
        [HttpGet]
        [HttpPost]
        public JsonResult GetProduct(int catagoryId)
        {
            var product = _context.ProductDetails.AsNoTracking().
                Where(s => s.ProductCatagoryId == catagoryId).
                Select(x => new
                {
                    Value = x.ProductId,
                    Text = x.ProductName
                });
            return Json(product);

        }
        [HttpPost]
        public IActionResult AddStock(StockVM stockVM)
        {
            ViewBag.ProductCatagory = new SelectList(_context.ProductCatagory.AsNoTracking().
                ToList(), "ProductCatagoryId", "ProductCatagoryName");

            var product = _context.ProductDetails.AsNoTracking()
                   .Where(q => q.ProductId == stockVM.ProductId).FirstOrDefault();

            var qt = _context.StockDetails.AsNoTracking()
                .Where(s => s.ProductId == stockVM.ProductId).LastOrDefault();

            if (qt != null)
            {
                if (product.QuantityId == 2)
                {
                    stockVM.AvailableStock = stockVM.Quantity * 1000 + qt.AvailableStock;
                }
                else
                {
                    stockVM.AvailableStock = stockVM.Quantity + qt.AvailableStock;
                }
            }
            else
            {
                if (product.QuantityId == 2)
                {
                    stockVM.AvailableStock = stockVM.Quantity * 1000;
                }
                else
                {
                    stockVM.AvailableStock = stockVM.Quantity;
                }
            }
            StockDetails sd = new StockDetails()
            {
                StockDetailsId = 0,
                ProductCatagoryId = stockVM.ProductCatagoryId,
                ProductId = stockVM.ProductId,
                PurchasedPrice = stockVM.PurchasedPrice,
                Quantity = stockVM.Quantity,
                AvailableStock = stockVM.AvailableStock,
                StockInDate = DateTime.Now
            };
            _context.StockDetails.Add(sd);
            _context.SaveChanges();
            ViewBag.Success = "You have successfully added " + product.ProductName + " in stock.";
            ModelState.Clear();
            return View();

        }
        public IActionResult StockDetails()
        {
            var a = _context.StockDetails.AsNoTracking().Include(q => q.ProductDetails)
                .OrderByDescending(x => x.StockInDate).ToList();
            var b = new List<StockVM>();
            var c = 1;
            foreach (var item in a)
            {
                StockVM d = new StockVM()
                {
                    Serial = c,
                    ProductName = item.ProductDetails.ProductName,
                    PurchasedPrice = item.PurchasedPrice,
                    Quantity = item.Quantity,
                    StockInDate = item.StockInDate
                };
                b.Add(d);
                c++;
            }
            return View(b);
        }
        public IActionResult AvailableStock()
        {
            var a = _context.StockDetails.AsNoTracking().Include(q => q.ProductDetails)
                .OrderByDescending(x=>x.StockInDate).Distinct().ToList();
            var b = new List<StockVM>();
            var c = 1;
            foreach (var item in a)
            {
                StockVM d = new StockVM()
                {
                    Serial = c,
                    ProductName = item.ProductDetails.ProductName,                 
                    StockInDate = item.StockInDate,
                    AvailableStock=item.AvailableStock
                };
                b.Add(d);
                c++;
            }
            return View(b);
        }
    }
}