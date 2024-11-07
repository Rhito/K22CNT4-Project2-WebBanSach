using K22CNT4_TTCD1_DinhTienLuc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace K22CNT4_TTCD1_DinhTienLuc.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        Entities5 db = new Entities5();
        // GET: Admin/Home
        public ActionResult Index()
        {
            if (Session["User"] is User user && user.Role == true)
            {
                var model = new DashboardViewModel
                {
                    TotalDM = db.DanhMucSaches.Count(),
                    TotalSach = db.Saches.Count(),
                    TotalUsers = db.Users.Count(),
                    TotalSlides = db.Slides.Count()
                };

                return View(model);
            }
            else
            {
                return RedirectToAction("", "Sach", new { area = "" });
            }
        }
    }
}