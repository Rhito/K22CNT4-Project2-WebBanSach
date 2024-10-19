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
        private Entities1 db = new Entities1 ();
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
                return RedirectToAction("Index");

            }else
            {
                return View(model);
            }
        }
    }
}