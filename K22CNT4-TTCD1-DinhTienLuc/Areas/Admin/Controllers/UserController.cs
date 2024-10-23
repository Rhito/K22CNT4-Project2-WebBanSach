using K22CNT4_TTCD1_DinhTienLuc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace K22CNT4_TTCD1_DinhTienLuc.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        // GET: Admin/User
        private Entities5 db = new Entities5();

        public ActionResult Index()
        {
            var items = db.Users;
            return View(items);
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(User model)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            else
            {
                return View(model);
            }
        }
        public ActionResult Edit(int id)
        {
            var item = db.Users.Find(id);
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(User model)
        {
            // Tìm đối tượng sách từ CSDL
            var existingItem = db.Users.Find(model.Id);

            if (existingItem != null)
            {
                // Cập nhật các thuộc tính
                existingItem.Name = model.Name;
                existingItem.Email = model.Email;
                existingItem.Password = model.Password;
                existingItem.Status = model.Status;
                existingItem.Role = model.Role;
                // Lưu thay đổi
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return HttpNotFound();
            }
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var item = db.Users.Find(id);
            if (item != null)
            {
                /*var DeleteItem = db.Users.Attach(item);*/
                db.Users.Remove(item);
                db.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }
    }
}