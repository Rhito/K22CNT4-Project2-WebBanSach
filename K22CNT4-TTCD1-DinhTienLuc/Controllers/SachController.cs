using K22CNT4_TTCD1_DinhTienLuc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace K22CNT4_TTCD1_DinhTienLuc.Controllers
{
    public class SachController : Controller
    {
        protected Entities5 db = new Entities5();
        protected void LoadDanhMuc()
        {
            var danhMucSachs = db.DanhMucSaches.Where(x => x.Status == true).ToList();
            ViewBag.danhmuc = new SelectList(danhMucSachs, "Id", "Name");
        }
        public ActionResult Index()
        {
            ViewBag.mixBooks = db.Saches.Where((x) => x.Status == true).ToList();
            ViewBag.Vhhd = db.Saches.Where(x => x.Status == true && x.IdDanhMuc == 1).ToList();
            ViewBag.SachKt = db.Saches.Where(x => x.Status == true && x.IdDanhMuc == 4).ToList();
            ViewBag.SachTl = db.Saches.Where(x => x.Status == true && x.IdDanhMuc == 3).ToList();

            LoadDanhMuc();
            ViewBag.slide = db.Slides.ToList(); 

            return View();
        }

        public ActionResult Details (int id)
        {
            var item = db.Saches.Where(x => x.Id == id).ToList();
            /*if (item == null)
            {
                return HttpNotFound();
            }*/
            return View(item);
        }

        public ActionResult Register()
        {
            LoadDanhMuc();
            return View();
        }
        [HttpPost]
        public ActionResult AddToCart(int id, int quantity)
        {
            var code = new { Success = false, msg = "", code = -1 };
            var checkProduct = db.Saches.FirstOrDefault(x => x.Id == id);
            if (checkProduct == null)
            {
                ShoppingCart cart = (ShoppingCart)Session["Cart"];
                if(cart != null)
                {

                } else
                {
                    Cart item = new Cart{
                        Id = checkProduct.Id,
                        Quantity = quantity,
                    };
                    if(checkProduct.Images)
                    cart.AddToCart(checkProduct, quantity);
                }
            }
            return Json(code);
        }

        public ActionResult Login()
        {
            LoadDanhMuc();
            return View();
        }
        public ActionResult TinTuc()
        {
            LoadDanhMuc();
            return View();
        }

        public ActionResult LienHe()
        {
            LoadDanhMuc();
            return View();
        }
    }
}