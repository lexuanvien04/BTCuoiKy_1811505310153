using ModelEF.DAO;
using ModelEF.Model;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestUngDung.Areas.Admin.Controllers
{
    public class ProductController : BaseController
    {
        private LeXuanVienContext db = new LeXuanVienContext();

        // GET: Admin/Product

        public ActionResult Index(int page = 1, int pagesize = 10)
        {
            var product = new ProductDao();
            var model = product.ListAll();
            return View(model.ToPagedList(page, pagesize));
        }


        [HttpPost]
        public ActionResult Index(string searchString, int page = 1, int pagesize = 10)
        {
            var prod = new ProductDao();
            var model = prod.ListWhereAll(searchString, page, pagesize);
            ViewBag.SearchString = searchString;
            return View(model.ToPagedList(page, pagesize));
        }
        
        public ActionResult Create()
        {
            SetViewBag();
            return View();
        }

        

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product, HttpPostedFileBase image)
        {
            try
            {
                var dao = new ProductDao();
                string result;
                image = Request.Files["ImageData"];
                if (image != null && image.ContentLength > 0)
                {
                    product.image = new byte[image.ContentLength]; // image stored-in binary formate
                    image.InputStream.Read(product.image, 0, image.ContentLength);
                    string fileName = System.IO.Path.GetFileName(image.FileName);
                    string urlImage = Server.MapPath("~/Assets/Image/" + fileName);
                    image.SaveAs(urlImage);
                }
                result = dao.Insert(product);

                if (result != null)
                {
                    SetAlert("More successful products!", "success");
                    return RedirectToAction("Index", "Product");
                }
                else
                {
                    SetAlert("Add product failed! Product code already exists!", "error");
                }

                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                Common.Common.WriteLog("Product", "Create-Post", ex.ToString());
            }
            return View(product);
        }

        [HttpGet]
        public ActionResult Update(string id)
        {
            var product = new ProductDao();
            var result = product.Find(id);
            if (result != null)
                return View(result);
            SetViewBag();
            return View();
        }

        [HttpPost]
        public ActionResult Update(Product product, HttpPostedFileBase image)
        {
            try
            {
                var dao = new ProductDao();
                string result;
                image = Request.Files["ImageData"];
                if (image != null && image.ContentLength > 0)
                {
                    product.image = new byte[image.ContentLength]; // image stored-in binary formate
                    image.InputStream.Read(product.image, 0, image.ContentLength);
                    string fileName = System.IO.Path.GetFileName(image.FileName);
                    string urlImage = Server.MapPath("~/Assets/Image/" + fileName);
                    image.SaveAs(urlImage);
                }
                result = dao.Update(product);

                if (result != null)
                {
                    SetAlert("More successful products!", "success");
                    return RedirectToAction("Index", "Product");
                }
                else
                {
                    SetAlert("Add product failed! Product code already exists!", "error");
                }

                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                Common.Common.WriteLog("Product", "Update-Post", ex.ToString());
            }
            return View(product);
        }

        [HttpDelete]
        public ActionResult Delete(string id)
        {
            try
            {
                var dao = new ProductDao().Delete(id);
            }
            catch (Exception ex)
            {
                Common.Common.WriteLog("Product", "Delete-Post", ex.ToString());
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(string id)
        {
            var product = db.Products.Select(p => p).Where(p => p.ProductID == id).FirstOrDefault();
            return View(product);
        }

        public void SetViewBag(string selectdid = null)
        {
            var dao = new CategoryDao();
            ViewBag.CategoryID = new SelectList(dao.ListAll(), "CategoryID", "CategoryName", selectdid);
        }

        //Hamf trả về Json
        [HttpPost]
        public JsonResult ChangeStatus(string id)
        {
            var result = new UserDao().ChangeStatus(id);

            return Json(new
            {
                status = result
            });
        }
    }


}