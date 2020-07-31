using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SSMS.Areas.Admin.Models;
using SSMS.Areas.Admin.ViewModels;
using SSMS.Database;
using X.PagedList;

namespace SSMS.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
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
        public IActionResult A()
        {
            return View();
        }
        public IActionResult SetProductCatagory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SetProductCatagory(ProductCatagoryVM productCatagoryVM)
        {
            var valid = _context.ProductCatagory.AsNoTracking().
                Where(t => t.ProductCatagoryName == productCatagoryVM.ProductCatagoryName).FirstOrDefault();
            if (valid != null)
            {
                ViewBag.Validation = "You have already added " + productCatagoryVM.ProductCatagoryName + ".";
                return View();
            }
            ProductCatagory pc = new ProductCatagory()
            {
                ProductCatagoryId = 0,
                ProductCatagoryName = productCatagoryVM.ProductCatagoryName
            };
            _context.ProductCatagory.Add(pc);
            _context.SaveChanges();
            ViewBag.Success = "You have successfully added " + productCatagoryVM.ProductCatagoryName + ".";
            ModelState.Clear();
            return View();
        }
        public IActionResult ProductCatagoryDetails()
        {
            var a = _context.ProductCatagory.AsNoTracking().ToList();
            var b = new List<ProductCatagoryVM>();
            var c = 1;
            foreach (var item in a)
            {
                ProductCatagoryVM d = new ProductCatagoryVM()
                {
                    Serial = c,
                    ProductCatagoryId = item.ProductCatagoryId,
                    ProductCatagoryName = item.ProductCatagoryName
                };
                b.Add(d);
                c++;
            }
            return View(b);
        }
        public IActionResult DeleteProductCatagory(int id)
        {
            var PCName = _context.ProductCatagory.AsNoTracking().Where(a => a.ProductCatagoryId == id).FirstOrDefault();
            _context.ProductCatagory.Remove(PCName);
            _context.SaveChanges();
            return RedirectToAction("ProductCatagoryDetails");
        }
        public IActionResult UpdateProductCatagory(int id)
        {
            var pc = _context.ProductCatagory.AsNoTracking().
                Where(t => t.ProductCatagoryId == id).FirstOrDefault();
            ProductCatagoryVM d = new ProductCatagoryVM()
            {
                ProductCatagoryId = pc.ProductCatagoryId,
                ProductCatagoryName = pc.ProductCatagoryName
            };
            return View(d);
        }
        [HttpPost]
        public IActionResult UpdateProductCatagory(ProductCatagoryVM productCatagoryVM)
        {
            var valid = _context.ProductCatagory.AsNoTracking().
                Where(t => t.ProductCatagoryName == productCatagoryVM.ProductCatagoryName).FirstOrDefault();
            if (valid != null)
            {
                ViewBag.Validation = "You have already added " + productCatagoryVM.ProductCatagoryName + ".";
                return View();
            }
            ProductCatagory pc = new ProductCatagory()
            {
                ProductCatagoryId = productCatagoryVM.ProductCatagoryId,
                ProductCatagoryName = productCatagoryVM.ProductCatagoryName
            };
            _context.ProductCatagory.Update(pc);
            _context.SaveChanges();
            return RedirectToAction("ProductCatagoryDetails");
        }

        //public IActionResult AddQuantityType()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public IActionResult AddQuantityType(QuantityTypeVM quantityTypeVM)
        //{
        //    var valid = _context.QuantityInfo.AsNoTracking().
        //        Where(t => t.QuantityType == quantityTypeVM.QuantityType).FirstOrDefault();
        //    if (valid != null)
        //    {
        //        ViewBag.Validation = "You have already added " + quantityTypeVM.QuantityType + ".";
        //        return View();
        //    }
        //    QuantityInfo pc = new QuantityInfo()
        //    {
        //        QuantityId = 0,
        //        QuantityType = quantityTypeVM.QuantityType
        //    };
        //    _context.QuantityInfo.Add(pc);
        //    _context.SaveChanges();
        //    ViewBag.Success = "You have successfully added " + quantityTypeVM.QuantityType + ".";
        //    ModelState.Clear();
        //    return View();
        //}
        //public IActionResult QuantityTypeDetails()
        //{
        //    var a = _context.QuantityInfo.AsNoTracking().ToList();
        //    var b = new List<QuantityTypeVM>();
        //    var c = 1;
        //    foreach (var item in a)
        //    {
        //        QuantityTypeVM d = new QuantityTypeVM()
        //        {
        //            Serial = c,
        //            QuantityId = item.QuantityId,
        //            QuantityType = item.QuantityType
        //        };
        //        b.Add(d);
        //        c++;
        //    }
        //    return View(b);
        //}
        //public IActionResult DeleteProductQualntityType(int id)
        //{
        //    var qt = _context.QuantityInfo.AsNoTracking().
        //        Where(a => a.QuantityId == id).FirstOrDefault();
        //    _context.QuantityInfo.Remove(qt);
        //    _context.SaveChanges();
        //    return RedirectToAction("QuantityTypeDetails");
        //}
        //public IActionResult UpdateProductQuantityType(int id)
        //{
        //    var qt = _context.QuantityInfo.AsNoTracking().
        //        Where(t => t.QuantityId == id).FirstOrDefault();
        //    QuantityTypeVM d = new QuantityTypeVM()
        //    {
        //        QuantityId = qt.QuantityId,
        //        QuantityType = qt.QuantityType
        //    };
        //    return View(d);
        //}
        //[HttpPost]
        //public IActionResult UpdateProductQuantityType(QuantityTypeVM quantityTypeVM)
        //{
        //    var valid = _context.QuantityInfo.AsNoTracking().
        //        Where(t => t.QuantityType == quantityTypeVM.QuantityType).FirstOrDefault();
        //    if (valid != null)
        //    {
        //        ViewBag.Validation = "You have already added " + quantityTypeVM.QuantityType + ".";
        //        return View();
        //    }
        //    QuantityInfo qt = new QuantityInfo()
        //    {
        //        QuantityId = quantityTypeVM.QuantityId,
        //        QuantityType = quantityTypeVM.QuantityType
        //    };
        //    _context.QuantityInfo.Update(qt);
        //    _context.SaveChanges();
        //    return RedirectToAction("QuantityTypeDetails");
        //}

        public IActionResult AddProduct()
        {
            ViewBag.ProductCatagory = new SelectList(_context.ProductCatagory.AsNoTracking().
                ToList(), "ProductCatagoryId", "ProductCatagoryName");
            ViewBag.Quantity = new SelectList(_context.QuantityInfo.AsNoTracking().
                ToList(), "QuantityId", "QuantityType");
            return View();
        }

        [Obsolete]
        [HttpPost]
        public IActionResult AddProduct(ProductVM addProductVM)
        {
            var valid = _context.ProductDetails.AsNoTracking().
                Where(t => t.ProductName == addProductVM.ProductName).FirstOrDefault();
            if (valid != null)
            {
                ViewBag.Validation = "You have already added " + addProductVM.ProductName + ".";
                return View();
            }
            string uniqueFileName = UploadedFile(addProductVM);
            ProductDetails pd = new ProductDetails()
            {
                ProductId = 0,
                ProductName = addProductVM.ProductName,
                ProductCatagoryId = addProductVM.ProductCatagoryId,
                QuantityId = addProductVM.QuantityId,
                Price = addProductVM.Price,
                Quantity = addProductVM.Quantity,
                Photopath = uniqueFileName
            };
            _context.ProductDetails.Add(pd);
            _context.SaveChanges();
            ViewBag.Success = "You have successfully added " + addProductVM.ProductName + ".";
            ViewBag.ProductCatagory = new SelectList(_context.ProductCatagory.AsNoTracking().
                ToList(), "ProductCatagoryId", "ProductCatagoryName");
            ViewBag.Quantity = new SelectList(_context.QuantityInfo.AsNoTracking().
                ToList(), "QuantityId", "QuantityType");
            ModelState.Clear();
            return View();
        }
        [Obsolete]
        private string UploadedFile(ProductVM model)
        {
            string uniqueFileName = null;
            if (model.Photopath != null)
            {
                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photopath.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.Photopath.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
        public IActionResult ProductList(int Page=1)
        {
            var a = _context.ProductDetails.AsNoTracking().Include(q => q.ProductCatagory).ToList();
            var b = new List<ProductVM>();
            var c = 1;
            foreach (var item in a)
            {
                ProductVM d = new ProductVM()
                {
                    Serial = c,
                    ProductId = item.ProductId,
                    ProductName = item.ProductName,
                    ProductCatagoryName = item.ProductCatagory.ProductCatagoryName,
                    Price = item.Price,
                    Photo = item.Photopath
                };
                b.Add(d);
                c++;
            }
            var list = b.ToPagedList(Page, 5);
            return View(list);
        }

        [Obsolete]
        public IActionResult DeleteProduct(int id)
        {
            var qt = _context.ProductDetails.AsNoTracking().
                            Where(a => a.ProductId == id).FirstOrDefault();
            if (qt.Photopath != null)
            {
                string filePath = Path.Combine(hostingEnvironment.WebRootPath,
                                              "images", qt.Photopath);
                System.IO.File.Delete(filePath);
            }
            _context.ProductDetails.Remove(qt);
            _context.SaveChanges();
            return RedirectToAction("ProductList");
        }
        [HttpGet]
        public IActionResult UpdateProduct(int id)
        {
            var a = _context.ProductDetails.AsNoTracking()
                .Where(t => t.ProductId == id).FirstOrDefault();
            ProductVM pv = new ProductVM()
            {
                ProductId = a.ProductId,
                ProductName = a.ProductName,
                ProductCatagoryId = a.ProductCatagoryId,
                QuantityId = a.QuantityId,
                Quantity = a.Quantity,
                Price = a.Price,
                Photo = a.Photopath
            };
            ViewBag.ProductCatagory = new SelectList(_context.ProductCatagory.AsNoTracking().
                ToList(), "ProductCatagoryId", "ProductCatagoryName");
            ViewBag.Quantity = new SelectList(_context.QuantityInfo.AsNoTracking().
                ToList(), "QuantityId", "QuantityType");
            return View(pv);
        }
        [HttpPost]
        [Obsolete]
        public IActionResult UpdateProduct(ProductVM productVM)
        {
            //var a = _context.ProductDetails.AsNoTracking()
            //    .Where(t => t.ProductId == addProductVM.ProductId).FirstOrDefault();
            //if (addProductVM.Photopath != null)
            //{
            //    string filePath = Path.Combine(hostingEnvironment.WebRootPath,
            //                              "images", a.Photopath);
            //    System.IO.File.Delete(filePath);
            //}
            ////uniqueFileName = UploadedFile(addProductVM);
            //ProductDetails pd = new ProductDetails()
            //{
            //    ProductId = a.ProductId,
            //    ProductName = addProductVM.ProductName,
            //    ProductCatagoryId = addProductVM.ProductCatagoryId,
            //    QuantityId = addProductVM.QuantityId,
            //    Price = addProductVM.Price,
            //    Quantity = addProductVM.Quantity,
            //    Photopath = UploadedFile(addProductVM)
            //};
            //_context.ProductDetails.Update(pd);
            //_context.SaveChanges();
            //return RedirectToAction("ProductList");
            if (ModelState.IsValid)
            {
                ProductDetails productDetails = _context.ProductDetails.AsNoTracking()
                                 .Where(t => t.ProductId == productVM.ProductId).FirstOrDefault();
                productDetails.ProductName = productVM.ProductName;
                productDetails.ProductCatagoryId = productVM.ProductCatagoryId;
                productDetails.Quantity = productVM.Quantity;
                productDetails.QuantityId = productVM.QuantityId;
                productDetails.Price = productVM.Price;
                if (productVM.Photopath != null)
                {
                    if (productVM.Photo != null)
                    {
                        string filePath = Path.Combine(hostingEnvironment.WebRootPath,
                                          "images", productVM.Photo);
                        System.IO.File.Delete(filePath);
                    }
                    productDetails.Photopath = UploadedFile(productVM);
                }
                _context.ProductDetails.Update(productDetails);
                _context.SaveChanges();
                return RedirectToAction("ProductList");
            }
            return View();
        }
        //[HttpGet]
        //public IActionResult UpdateProduct(int id)
        //{
        //    var p = _context.ProductDetails.AsNoTracking()
        //        .Where(t => t.ProductId == id).FirstOrDefault();
        //    ProductEditVM pe = new ProductEditVM()
        //    {
        //        ProductId=p.ProductId,
        //        ProductName=p.ProductName,
        //        ProductCatagoryId=p.ProductCatagoryId,
        //        Quantity=p.Quantity,
        //        QuantityId=p.QuantityId,
        //        Price=p.Price,
        //        ExistingPhoto=p.Photopath
        //    };
        //    ViewBag.ProductCatagory = new SelectList(_context.ProductCatagory.AsNoTracking().
        //        ToList(), "ProductCatagoryId", "ProductCatagoryName");
        //    ViewBag.Quantity = new SelectList(_context.QuantityInfo.AsNoTracking().
        //        ToList(), "QuantityId", "QuantityType");
        //    return View(pe);
        //}
        //[HttpPost]
        //[Obsolete]
        //public IActionResult UpdateProduct(ProductEditVM productEditVM)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        ProductDetails productDetails= _context.ProductDetails.AsNoTracking()
        //                         .Where(t => t.ProductId ==productEditVM.ProductId).FirstOrDefault();
        //        productDetails.ProductName = productEditVM.ProductName;
        //        productDetails.ProductCatagoryId = productEditVM.ProductCatagoryId;
        //        productDetails.Quantity = productEditVM.Quantity;
        //        productDetails.QuantityId = productEditVM.QuantityId;
        //        productDetails.Price = productEditVM.Price;
        //        if (productEditVM.Photopath!= null)
        //        {
        //            if (productEditVM.ExistingPhoto != null)
        //            {
        //                string filePath = Path.Combine(hostingEnvironment.WebRootPath,
        //                                  "images", productEditVM.ExistingPhoto);
        //                System.IO.File.Delete(filePath);
        //            }
        //            productDetails.Photopath = UploadedFile(productEditVM);
        //        }
        //        _context.ProductDetails.Update(productDetails);
        //        _context.SaveChanges();
        //        return RedirectToAction("ProductList");
        //    }
        //    return View();
        //}
        public IActionResult AddDesignation()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddDesignation(DesignationVM designationVM)
        {
            var valid = _context.Designation.AsNoTracking().
                Where(t => t.DesignationName == designationVM.DesignationName).FirstOrDefault();
            if (valid != null)
            {
                ViewBag.Validation = "You have already added " + designationVM.DesignationName + ".";
                return View();
            }
            Designation d = new Designation()
            {
                DesignationId = 0,
                DesignationName = designationVM.DesignationName
            };
            _context.Designation.Add(d);
            _context.SaveChanges();
            ViewBag.Success = "You have successfully added " + designationVM.DesignationName + ".";
            ModelState.Clear();
            return View();
        }
        public IActionResult DesignationList()
        {
            var a = _context.Designation.AsNoTracking().ToList();
            var b = new List<DesignationVM>();
            var c = 1;
            foreach (var item in a)
            {
                DesignationVM d = new DesignationVM()
                {
                    Serial = c,
                    DesignationId = item.DesignationId,
                    DesignationName = item.DesignationName
                };
                b.Add(d);
                c++;
            }
            return View(b);
        }
        public IActionResult DeleteDesignation(int id)
        {
            var dn = _context.Designation.AsNoTracking().Where(a => a.DesignationId == id).FirstOrDefault();
            _context.Designation.Remove(dn);
            _context.SaveChanges();
            return RedirectToAction("DesignationList");
        }
        [HttpGet]
        public IActionResult UpdateDesignation(int id)
        {
            var dn = _context.Designation.AsNoTracking().
                Where(t => t.DesignationId == id).FirstOrDefault();
            DesignationVM d = new DesignationVM()
            {
                DesignationId = dn.DesignationId,
                DesignationName = dn.DesignationName
            };
            return View(d);
        }
        [HttpPost]
        public IActionResult UpdateDesignation(DesignationVM designationVM)
        {
            var valid = _context.Designation.AsNoTracking().
                Where(t => t.DesignationName == designationVM.DesignationName).FirstOrDefault();
            if (valid != null)
            {
                ViewBag.Validation = "You have already added " + designationVM.DesignationName + ".";
                return View();
            }
            Designation qt = new Designation()
            {
                DesignationId = designationVM.DesignationId,
                DesignationName = designationVM.DesignationName
            };
            _context.Designation.Update(qt);
            _context.SaveChanges();
            return RedirectToAction("DesignationList");
        }
        public IActionResult AddEmployee()
        {
            ViewBag.Designation = new SelectList(_context.Designation.AsNoTracking().
                ToList(), "DesignationId", "DesignationName");
            return View();
        }
        [HttpPost]
        [Obsolete]
        public IActionResult AddEmployee(EmployeeVM employeeVM)
        {
            var valid = _context.EmployeeInfo.AsNoTracking().
                Where(t => t.Email == employeeVM.Email).FirstOrDefault();
            if (valid != null)
            {
                ViewBag.Validation = "This Email " + employeeVM.Email + " exist in another employee.";
                return View();
            }
            string uniqueFileName = UploadedFile(employeeVM);
            EmployeeInfo pd = new EmployeeInfo()
            {
                EmployeeId = 0,
                EmployeeName = employeeVM.EmployeeName,
                DesignationId = employeeVM.DesignationId,
                Email = employeeVM.Email,
                Cell = employeeVM.Cell,
                JoinDate = employeeVM.JoinDate,
                PhotoPath = uniqueFileName
            };
            _context.EmployeeInfo.Add(pd);
            _context.SaveChanges();
            ViewBag.Success = "You have successfully added " + employeeVM.EmployeeName + ".";
            ViewBag.Designation = new SelectList(_context.Designation.AsNoTracking().
                ToList(), "DesignationId", "DesignationName");
            ModelState.Clear();
            return View();
        }
        [Obsolete]
        private string UploadedFile(EmployeeVM model)
        {
            string uniqueFileName = null;
            if (model.PhotoPath != null)
            {
                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.PhotoPath.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.PhotoPath.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
        public IActionResult EmployeeList()
        {
            var a = _context.EmployeeInfo.AsNoTracking().Include(q => q.Designetion).ToList();
            var b = new List<EmployeeVM>();
            var c = 1;
            foreach (var item in a)
            {
                EmployeeVM d = new EmployeeVM()
                {
                    Serial = c,
                    EmployeeId = item.EmployeeId,
                    EmployeeName = item.EmployeeName,
                    DesignationId = item.DesignationId,
                    DesignationName = item.Designetion.DesignationName,
                    Email = item.Email,
                    Cell = item.Cell,
                    JoinDate = item.JoinDate,
                    ExistingPhoto = item.PhotoPath
                };
                b.Add(d);
                c++;
            }
            //var list = b.ToPagedList(Page, 5);
            return View(b);
        }

        [Obsolete]
        public IActionResult DeleteEmployee(int id)
        {
            var ei = _context.EmployeeInfo.AsNoTracking().
                            Where(a => a.EmployeeId == id).FirstOrDefault();
            if (ei.PhotoPath != null)
            {
                string filePath = Path.Combine(hostingEnvironment.WebRootPath,
                                              "images", ei.PhotoPath);
                System.IO.File.Delete(filePath);
            }
            _context.EmployeeInfo.Remove(ei);
            _context.SaveChanges();
            return RedirectToAction("EmployeeList");
        }
        [HttpGet]
        public IActionResult UpdateEmployee(int id)
        {
            var a = _context.EmployeeInfo.AsNoTracking()
                .Where(t => t.EmployeeId == id).FirstOrDefault();
            EmployeeVM pv = new EmployeeVM()
            {
                EmployeeId = a.EmployeeId,
                EmployeeName = a.EmployeeName,
                Email = a.Email,
                DesignationId = a.DesignationId,
                JoinDate = a.JoinDate,
                Cell = a.Cell,
                ExistingPhoto = a.PhotoPath
            };
            ViewBag.Designation = new SelectList(_context.Designation.AsNoTracking().
                ToList(), "DesignationId", "DesignationName");
            return View(pv);
        }
        [HttpPost]
        [Obsolete]
        public IActionResult UpdateEmployee(EmployeeVM employeeVM)
        {
            if (ModelState.IsValid)
            {
                EmployeeInfo employeeInfo = _context.EmployeeInfo.AsNoTracking()
                                .Where(t => t.EmployeeId == employeeVM.EmployeeId).FirstOrDefault();
                employeeInfo.EmployeeName = employeeVM.EmployeeName;
                employeeInfo.DesignationId = employeeVM.DesignationId;
                employeeInfo.Email = employeeVM.Email;
                employeeInfo.Cell = employeeVM.Cell;
                employeeInfo.JoinDate = employeeVM.JoinDate;
                if (employeeVM.PhotoPath != null)
                {
                    if (employeeVM.ExistingPhoto != null)
                    {
                        string filePath = Path.Combine(hostingEnvironment.WebRootPath,
                                          "images", employeeVM.ExistingPhoto);
                        System.IO.File.Delete(filePath);
                    }
                    employeeInfo.PhotoPath = UploadedFile(employeeVM);
                }
                _context.EmployeeInfo.Update(employeeInfo);
                _context.SaveChanges();
                return RedirectToAction("EmployeeList");
            }
            return View();
        }
    }
}
