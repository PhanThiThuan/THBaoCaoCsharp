using ModelEF.DAO;
using ModelEF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;



namespace TestUngDung.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        // GET: Admin/User
        public ActionResult Index(string searchString,int page = 1 ,int pageSize=5)
        { var dao = new UserDao();
            var model = dao.ListAllPaging(searchString, page, pageSize);

            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Edit(int id)
        {
            var user = new UserDao().ViewDetail(id);
            return View(user);
        }
        [HttpPost]
        public ActionResult Create(UserAccount user)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                long id = dao.Insert(user);
                if (id > 0)
                {
                    SetAlert("tạo mới người dùng thành công", "success");
                    return RedirectToAction("Index", "User");

                }
                else
                {
                    ModelState.AddModelError("", "thêm user thành công");
                }
            }
            return View("Index");

        }
        [HttpPost]
       public ActionResult Edit(UserAccount user)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                var result = dao.Update(user);
                if (result)
                {
                    SetAlert("cập nhật người dùng thành công", "success");

                    return RedirectToAction("Index", "User");

                }
                else
                {
                    ModelState.AddModelError("", "Cật nhật user không thành công");
                }
            }
            return View("Index");

        }
        [HttpDelete]
        public ActionResult Delete (int id)
        {
            new UserDao().Delete(id);
            return RedirectToAction("Index");
        }


    }
}
