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
    public class UserController : BaseController
    {
        // GET: Admin/User
        public ActionResult Index(int page = 1, int pagesize = 5)
        {
            var user = new UserDao();
            var model = user.ListAll();
            return View(model.ToPagedList(page, pagesize));
        }

        [HttpPost]
        public ActionResult Index(string searchString, int page = 1, int pagesize = 5)
        {
            var user = new UserDao();
            var model = user.ListWhereAll(searchString, page, pagesize);
            ViewBag.SearchString = searchString;
            return View(model.ToPagedList(page, pagesize));
        }

        [HttpGet]
        public ActionResult Create(string user)
        {
            var dao = new UserDao();
            var result = dao.Find(user);
            if (result != null)
                return View(result);
            return View();
        }

        [HttpPost]
        public ActionResult Create(UserAccount model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //Phải đặt phía trước
                    if (string.IsNullOrEmpty(model.Password))
                    {
                        SetAlert("Không được để trống", "warning");
                        return View();
                    }
                    var dao = new UserDao();
                    var pass = Encryptor.EncryptMD5(model.Password);
                    model.Password = pass;
                    string result = "";
                    //Tìm tên đăng nhập có trùng không
                    //Nếu trùng thì trả về trang Create

                    result = dao.Insert(model);

                    if (!string.IsNullOrEmpty(result))
                    {
                        SetAlert("Add user successfully!", "success");
                        return RedirectToAction("Index", "User");
                    }
                    else
                    {
                        SetAlert("Add user failed!", "error");
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Common.WriteLog("User", "Create-Post", ex.ToString());
            }
            return View();
        }

        [HttpGet]
        public ActionResult Update(string user)
        {
            var dao = new UserDao();
            var result = dao.Find(user);
            if (result != null)
                return View(result);
            return View();
        }

        [HttpPost]
        public ActionResult Update(UserAccount model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //Phải đặt phía trước
                    if (string.IsNullOrEmpty(model.Password))
                    {
                        SetAlert("Không được để trống", "warning");
                        return View();
                    }
                    var dao = new UserDao();
                    var pass = Encryptor.EncryptMD5(model.Password);
                    model.Password = pass;
                    string result = "";
                    //Tìm tên đăng nhập có trùng không
                    //Nếu trùng thì trả về trang Create

                    result = dao.Update(model);

                    if (!string.IsNullOrEmpty(result))
                    {
                        SetAlert("Cập nhật người dùng thành công", "success");
                        return RedirectToAction("Index", "User");
                    }
                    else
                    {
                        SetAlert("Cập nhật người dùng không thành công", "error");
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Common.WriteLog("User", "Update-Post", ex.ToString());
            }
            return View();
        }

        [HttpDelete]
        public ActionResult Delete(string id)
        {
            var dao = new UserDao().Delete(id);
            return RedirectToAction("Index");
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