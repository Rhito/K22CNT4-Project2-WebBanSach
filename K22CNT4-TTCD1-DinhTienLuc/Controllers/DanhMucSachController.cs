using K22CNT4_TTCD1_DinhTienLuc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace K22CNT4_TTCD1_DinhTienLuc.Controllers
{
    public class DanhMucSachController : Controller
    {
        protected Entities5 db = new Entities5();
        protected void LoadDanhMuc()
        {
            var danhMucSachs = db.DanhMucSaches.Where(x => x.Status == true).ToList();
            ViewBag.danhmuc = new SelectList(danhMucSachs, "Id", "Name");
        }
        protected void VHHD()
        {
            ViewBag.Vhhd = db.Saches.Where(x => x.Status == true && x.IdDanhMuc == 1).ToList();
        }
        protected void Kinhte()
        {
            ViewBag.SachKt = db.Saches.Where(x => x.Status == true && x.IdDanhMuc == 4).ToList();
        }
        protected void Tamlyhoc()
        {
            ViewBag.SachTl = db.Saches.Where(x => x.Status == true && x.IdDanhMuc == 3).ToList();
        }

        // GET: Danhmuc
        public ActionResult Danhmuc()
        {
            ViewBag.mixBooks = db.Saches.Where((x) => x.Status == true).ToList();
            
            LoadDanhMuc();
            VHHD();
            Kinhte(); 
            Tamlyhoc();
            return View();
        }
        public ActionResult VanHocHienDai()
        {
            LoadDanhMuc();
            VHHD();
            return View();
        }
        public ActionResult KinhTeHoc()
        {
            LoadDanhMuc();
            Kinhte();
            return View();
        }
        public ActionResult TamLyHoc()
        {
            LoadDanhMuc();
            Tamlyhoc();
            return View();
        }
    }
}