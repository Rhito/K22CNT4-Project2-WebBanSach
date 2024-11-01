using K22CNT4_TTCD1_DinhTienLuc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace K22CNT4_TTCD1_DinhTienLuc.Areas.Admin.Controllers
{
    public class SlideController : Controller
    {
        private Entities5 db = new Entities5();
        // GET: Admin/DanhMuc

        public ActionResult Index()
        {
            if (Session["User"] is User user && user.Role == true)
            {
                var items = db.Slides;
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
        public ActionResult Add(Slide model)
        {
            if (ModelState.IsValid)
            {
                db.Slides.Add(model);
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
                var item = db.Slides.Find(id);
                return View(item);
            }
            else
            {
                return RedirectToAction("", "Sach", new { area = "" });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Slide model)
        {
            if (ModelState.IsValid)
            {
                db.Slides.Attach(model);
                db.Entry(model).Property(x => x.Images).IsModified = true;
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            else
            {
                return View(model);
            }
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var item = db.Slides.Find(id);
            if (item != null)
            {
                /*var DeleteItem = db.Slides.Attach(item);*/
                db.Slides.Remove(item);
                db.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }
    }
}