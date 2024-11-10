using K22CNT4_TTCD1_DinhTienLuc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace K22CNT4_TTCD1_DinhTienLuc.Areas.Admin.Controllers
{
    public class SachAdminController : Controller
    {
        // GET: Admin/SachAdmin
        private Entities5 db = new Entities5();

        public ActionResult Index()
        {
            if (Session["User"] is User user && user.Role == true)
            {               
                var items = db.Saches.Include("DanhMucSach").ToList();
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
                ViewBag.danhmuc = new SelectList(db.DanhMucSaches.Where(x => x.Status == true).ToList(), "Id", "Name");
                return View();
            }
            else
            {
                return RedirectToAction("", "Sach", new { area = "" });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Sach model)
        {
            if (ModelState.IsValid)
            {
                db.Saches.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                // Repopulate dropdown if model validation fails
                ViewBag.danhmuc = new SelectList(db.DanhMucSaches.Where(x => x.Status == true).ToList(), "Id", "Name");
                return View(model);
            }
        }

        public ActionResult Edit(int id)
        {
            if (Session["User"] is User user && user.Role == true)
            {
                var item = db.Saches.Find(id);
                if (item == null)
                {
                    ModelState.AddModelError("", "Không tìm thấy sản phẩm");
                }

                // Preselect current category (IdDanhMuc) for the dropdown
                ViewBag.danhmuc = new SelectList(db.DanhMucSaches.Where(x => x.Status == true).ToList(), "Id", "Name", item.IdDanhMuc);
                return View(item);
            }
            else
            {
                return RedirectToAction("", "Sach", new { area = "" });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Sach model)
        {
            if (ModelState.IsValid)
            {
                var existingItem = db.Saches.Find(model.Id);
                if (existingItem != null)
                {
                    // Update properties
                    existingItem.IdDanhMuc = model.IdDanhMuc;
                    existingItem.Name = model.Name;
                    existingItem.Quantity = model.Quantity;
                    existingItem.Price = model.Price;
                    existingItem.Description = model.Description;
                    existingItem.Images = model.Images;
                    existingItem.Status = model.Status;

                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return HttpNotFound();
            }

            // Repopulate dropdown if validation fails
            ViewBag.danhmuc = new SelectList(db.DanhMucSaches.Where(x => x.Status == true).ToList(), "Id", "Name", model.IdDanhMuc);
            return View(model);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var item = db.Saches.Find(id);
            if (item != null)
            {
                /*var DeleteItem = db.Saches.Attach(item);*/
                db.Saches.Remove(item);
                db.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }
    }
}