using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Drawing;
using StoreFront.DATA.EF;
using StoreFront.UI.MVC.Models;
using System.Data;
using System.Data.Entity;
using System.Net;
using StoreFront.UI.MVC.Utility;

//namespace StoreFront.UI.MVC.Controllers
//{
//    public class OrignalProductsController : Controller
//    {
//        private StoreFrontEntities db = new StoreFrontEntities();

//        // GET: Products
//        public ActionResult Index()
//        {
//            var product = db.Products;
//            return View(product.ToList());
//        }

//        public ActionResult Details(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            Product product = db.Products.Find(id);
//            if (product == null)
//            {
//                return HttpNotFound();
//            }
//            return View(product);
//        }

//        public ActionResult AddToCart(int qty, int productID)
//        {
//            Dictionary<int, CartItemViewModel> shoppingCart = null;
//            if (Session["cart"] != null)
//            {
//                shoppingCart = (Dictionary<int, CartItemViewModel>)Session["cart"];
//            }
//            else
//            {
//                shoppingCart = new Dictionary<int, CartItemViewModel>();
//            }
//            Product product = db.Products.Where(p => p.ProductID == productID).FirstOrDefault();
//            if (product == null)
//            {
//                return RedirectToAction("Index");
//            }
//            else
//            {
//                CartItemViewModel item = new CartItemViewModel(qty, product);
//                if (shoppingCart.ContainsKey(product.ProductID))
//                {
//                    shoppingCart[product.ProductID].Qty += qty;
//                }
//                else
//                {
//                    shoppingCart.Add(product.ProductID, item);
//                }
//                Session["cart"] = shoppingCart;
//            }
//            return RedirectToAction("Index", "ShoppingCart");
//        }

//        public ActionResult Create()
//        {
//            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductID");
//            ViewBag.ManufacturerID = new SelectList(db.Manufacturers, "ManufacturerID", "ManufacturerName");
//            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName");
//            return View();
//        }

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Create([Bind(Include =
//            "ProductID, ProductName, Price, Description,StockStatusID,ManfacturerID,CategoryID")] Product product, HttpPostedFileBase productImage)
//        {
//            if (ModelState.IsValid)
//            {

//                #region File Upload
//                string file = "NoImage.png";

//                if (productImage != null)
//                {

//                    file = productImage.FileName;
//                    string ext = file.Substring(file.LastIndexOf('.'));
//                    string[] goodExts = { ".jpeg", ".jpg", ".png", ".gif" };

//                    if (goodExts.Contains(ext.ToLower()) && productImage.ContentLength <= 4194304)
//                    {

//                        file = Guid.NewGuid() + ext;

//                        string savePath = Server.MapPath("~/Content/assets/images/productimages/");

//                        Image convertedImage = Image.FromStream(productImage.InputStream);
//                        int maxImageSize = 500;
//                        int maxThumbSize = 100;


//                        ImageUtility.ResizeImage(savePath, file, convertedImage, maxImageSize, maxThumbSize);
//                    }
//                }

//                product.productImage = file;
//                #endregion

//                db.Products.Add(product);
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }

//            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductID", product.ProductID);
//            ViewBag.ManufacturerID = new SelectList(db.Manufacturers, "ManufacturerID", "ManufacturerName", product.ManufacturerID);
//            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName", product.CategoryID);
//            return View(product);
//        }

//        public ActionResult Edit(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            Product product = db.Products.Find(id);
//            if (product == null)
//            {
//                return HttpNotFound();
//            }
//            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductID");
//            ViewBag.ManufacturerID = new SelectList(db.Manufacturers, "ManufacturerID", "ManufacturerName");
//            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName");
//            return View(product);
//        }

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Edit([Bind(Include =
//            "ProductID, ProductName, Price, Description,StockStatusID,ManfacturerID,CategoryID")]Product product, HttpPostedFileBase productImage)
//        {
//            if (ModelState.IsValid)
//            {
//                #region File Upload
//                if (productImage != null)
//                {
//                    string file = productImage.FileName;

//                    string ext = file.Substring(file.LastIndexOf('.'));

//                    string[] goodExts = { ".jpeg", ".jpg", ".png", ".gif" };

//                    if (goodExts.Contains(ext.ToLower()) && productImage.ContentLength <= 4194304)
//                    {
//                        file = Guid.NewGuid() + ext;
//                        string savePath = Server.MapPath("~/Content/assets/images/productimages/");
//                        Image convertedImage = Image.FromStream(productImage.InputStream);
//                        int maxImageSize = 500;
//                        int maxThumbSize = 100;

//                        ImageUtility.ResizeImage(savePath, file, convertedImage, maxImageSize, maxThumbSize);

//                        if (product.productImage != null && product.productImage != "noimage.jpg")
//                        {
//                            string path = Server.MapPath("~/Content/assets/images/productimages/");
//                            ImageUtility.Delete(path, product.productImage);
//                        }

//                        product.productImage = file;
//                    }
//                }
//                #endregion

//                db.Entry(product).State = EntityState.Modified;
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }

//            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductID");
//            ViewBag.ManufacturerID = new SelectList(db.Manufacturers, "ManufacturerID", "ManufacturerName");
//            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName");
//            return View(product);
//        }

//        public ActionResult Delete(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            Product product = db.Products.Find(id);
//            if (product == null)
//            {
//                return HttpNotFound();
//            }
//            return View(product);
//        }

//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public ActionResult DeleteConfirmed(int id)
//        {
//            Product product = db.Products.Find(id);

//            string path = Server.MapPath("~/Content/assets/images/productimages/");

//            db.Products.Remove(product);
//            db.SaveChanges();
//            return RedirectToAction("Index");
//        }

//        protected override void Dispose(bool disposing)
//        {
//            if (disposing)
//            {
//                db.Dispose();
//            }
//            base.Dispose(disposing);
//        }

//    }
//}
