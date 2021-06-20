using ModelEF.DAO;
using ModelEF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using System.IO;

namespace TestUngDung.Areas.Admin.Controllers
{
    public class ProductController : BaseController
    {
        // GET: Admin/Product
        [HttpGet]
        public ActionResult Index(int page = 1, int pageSize = 5)
        {
            var dao = new ProductDao();
            var model = dao.ListAll();
            return View(model.ToPagedList(page, pageSize));
        }
        [HttpPost]
        public ActionResult Index(string searchString, int page = 1, int pagesize = 15)
        {
            var product = new ProductDao();
            var model = product.ListAllPaging(searchString, page, pagesize);
            ViewBag.SearchString = searchString;
            return View(model.ToPagedList(page, pagesize));
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                var dao = new ProductDao();
                long id = dao.Find(product);

                if (id > 0)
                {
                    SetAlert("tạo mới sản phẩm thành công", "success");
                    return RedirectToAction("Index", "Product");

                }
                else
                {
                    ModelState.AddModelError("", "thêm product ko thành công");
                }
            }
            return View("Index");
        }
        public ActionResult Edit(int id)
        {
            var product = new ProductDao().ViewDetail(id);
            return View(product);
        }
        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                var dao = new ProductDao();
                var result = dao.Update(product);
                if (result)
                {
                    SetAlert("cập nhật sản phẩm thành công", "success");

                    return RedirectToAction("Index", "Product");

                }
                else
                {
                    ModelState.AddModelError("", "Cật nhật sản phẩm không thành công");
                }
            }
            return View("Index");

        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new ProductDao().Delete(id);
            return RedirectToAction("Index");
        }
        public ActionResult xemchitiet(long id)
        {
            var model = new ProductDao().View(id);
            return View(model);
        }

    }
}