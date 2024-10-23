using K22CNT4_TTCD1_DinhTienLuc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace K22CNT4_TTCD1_DinhTienLuc.Areas.Admin.Views.Home
{
    public class DanhMucController : Controller
    {
        private Entities5 db = new Entities5();
        // GET: Admin/DanhMuc

        public ActionResult Index()
        {
            var items = db.DanhMucSaches;
            return View(items);
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(DanhMucSach model)
        {
            if (ModelState.IsValid)
            {
                db.DanhMucSaches.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");

            }else
            {
                return View(model);
            }
        }
        public ActionResult Edit(int id)
        {
            var item = db.DanhMucSaches.Find(id);
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DanhMucSach model)
        {
            if (ModelState.IsValid)
            {
                db.DanhMucSaches.Attach(model);
                db.Entry(model).Property(x => x.Name).IsModified = true;
                db.Entry(model).Property(x => x.Status).IsModified = true;
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
            var item = db.DanhMucSaches.Find(id);
            if (item != null)
            {
                /*var DeleteItem = db.DanhMucSaches.Attach(item);*/
                db.DanhMucSaches.Remove(item);
                db.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }
    }
}