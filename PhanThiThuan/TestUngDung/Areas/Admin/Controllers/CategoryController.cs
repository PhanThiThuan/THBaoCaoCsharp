using ModelEF.DAO;
using ModelEF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace TestUngDung.Areas.Admin.Controllers
{
    public class CategoryController : BaseController
    {
        // GET: Admin/Category
        [HttpGet]
        public ActionResult Index(int page = 1, int pageSize = 5)
        {
            var dao = new CategoryDao();
            var model = dao.ListAll();
            return View(model.ToPagedList(page, pageSize));
        }
        /*
                public ActionResult Index(string searchString, int page = 1, int pageSize = 5)
        {
            var dao = new MenuTypeDao();
            var model = dao.ListAll(searchString, page, pageSize);
            return View(model);
        }
         */
        [HttpPost]
        public ActionResult Index(string searchString, int page = 1, int pagesize = 5)
        {
            var menu = new CategoryDao();
            var model = menu.ListAllPaging(searchString, page, pagesize);
            ViewBag.SearchString = searchString;
            return View(model.ToPagedList(page, pagesize));
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var menu = new CategoryDao().ViewDetail(id);
            return View(menu);
        }
        [HttpPost]



        public ActionResult Edit(Category Category)
        {
            if (ModelState.IsValid)
            {
                var dao = new CategoryDao();
                var result = dao.Update(Category);
                if (result)
                {
                    SetAlert("cập nhật menu type thành công", "success");
                    return RedirectToAction("Index", "MenuType");

                }
                else
                {
                    ModelState.AddModelError("", "Cật nhật user không thành công");
                }
            }
            return View("Index");

        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new CategoryDao().Delete(id);
            return RedirectToAction("Index");
        }


    }
}
