using ModelEF.DAO;
using ModelEF.Model;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestUngDung.Common;

namespace TestUngDung.Areas.Admin.Controllers
{
    public class CategoryController : BaseController
    {
        private LeXuanVienContext db = new LeXuanVienContext();

        // GET: Admin/Category
        public ActionResult Index(int page = 1, int pagesize = 5)
        {
            var category = new CategoryDao();
            var model = category.ListAll();
            return View(model.ToPagedList(page, pagesize));
        }


        [HttpPost]
        public ActionResult Index(string searchString, int page = 1, int pagesize = 5)
        {
            var cate = new CategoryDao();
            var model = cate.ListWhereAll(searchString, page, pagesize);
            ViewBag.SearchString = searchString;
            return View(model.ToPagedList(page, pagesize));
        }

        
        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category model)
        {
            try
            {

                var dao = new CategoryDao();
                string result;
                
                result = dao.Insert(model);

                if (result != null)
                {
                    SetAlert("More successful products!", "success");
                    return RedirectToAction("Index", "Category");
                }
                else
                {
                    SetAlert("Add product failed! Product code already exists!", "error");
                }

                db.Categories.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                Common.Common.WriteLog("Category", "Create-Post", ex.ToString());
            }
            return View(model);
        }

        [HttpDelete]
        public ActionResult Delete(string id)
        {
            var dao = new CategoryDao().Delete(id);
            return RedirectToAction("Index");
        }
    }
}