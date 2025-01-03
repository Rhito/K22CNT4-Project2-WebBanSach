﻿using K22CNT4_TTCD1_DinhTienLuc.Models;
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
            if (Session["User"] is User user && user.Role == true)
            {
                var items = db.Users;
                return View(items);
            }
            else
            {
                return RedirectToAction("", "Sach", new { area = "" });
            }         
        }
        public ActionResult Add()
        {
            if (Session["User"] is User user && user.Role == true)
            {                
                return View();
            }
            else
            {
                return RedirectToAction("", "Sach", new { area = "" });
            }           
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(User model)
        {
            if (ModelState.IsValid)
            {
                // Kiểm tra email có tồn tại không
                var existingUser = db.Users.FirstOrDefault(u => u.Email == model.Email);
                if (existingUser != null)
                {
                    ModelState.AddModelError("Email", "Email này đã được sử dụng.");
                    return View(model); // Trả lại view với thông báo lỗi
                }
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
            if (Session["User"] is User user && user.Role == true)
            {
                var item = db.Users.Find(id);
                return View(item);
            }
            else
            {
                return RedirectToAction("", "Sach", new { area = "" });
            }           
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(User model)
        {
            // Tìm đối tượng sách từ CSDL
            var existingItem = db.Users.Find(model.Id);
            var existingUser = db.Users.FirstOrDefault(u => u.Email == model.Email);
            if (existingUser != null)
            {
                ModelState.AddModelError("Email", "Email này đã được sử dụng.");
                return View(model); // Trả lại view với thông báo lỗi
            }
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
                ModelState.AddModelError("", "Lỗi, thêm không thành công");
                return View(model);
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