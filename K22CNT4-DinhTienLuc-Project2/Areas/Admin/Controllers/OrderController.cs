using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using K22CNT4_TTCD1_DinhTienLuc.Models;

namespace K22CNT4_TTCD1_DinhTienLuc.Areas.Admin.Controllers
{
    public class OrderController : Controller
    {
        private Entities5 db = new Entities5();

        // GET: Admin/Order
        public ActionResult Index()
        {
            var user = Session["User"] as User;
            if (user?.Role == true)
            {
                var items = db.Orders.ToList();
                return View(items);
            }
            return RedirectToAction("Index", "Sach", new { area = "" });
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
        public ActionResult Add(Order model)
        {
            if (ModelState.IsValid)
            {
                db.Orders.Add(model);
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
                var item = db.Orders.Find(id);
                return View(item);
            }
            else
            {
                return RedirectToAction("", "Sach", new { area = "" });
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Order model)
        {
            if (ModelState.IsValid)
            {
                db.Orders.Attach(model);
                db.Entry(model).Property(x => x.CustomerName).IsModified = true;
                db.Entry(model).Property(x => x.Phone).IsModified = true;
                db.Entry(model).Property(x => x.Address).IsModified = true;
                db.Entry(model).Property(x => x.Email).IsModified = true;
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
            var order = db.Orders.Find(id);
            if (order != null)
            {
                // Xóa tất cả OrderDetail liên quan trước
                db.OrderDetails.RemoveRange(order.OrderDetails);

                // Xóa Order sau khi đã xóa các OrderDetail liên quan
                db.Orders.Remove(order);
                db.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }

    }
}
