using K22CNT4_TTCD1_DinhTienLuc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace K22CNT4_TTCD1_DinhTienLuc.Areas.Admin.Controllers
{
    public class OrderDetailsController : Controller
    {
        Entities5 db = new Entities5();

        // GET: Admin/OrderDetails
        public ActionResult Index()
        {
            var user = Session["User"] as User;
            if (user?.Role == true)
            {
                var items = db.OrderDetails.ToList();
                return View(items);
            }
            return RedirectToAction("Index", "Sach", new { area = "" });
        }
        public ActionResult Add()
        {
            if (Session["User"] is User user && user.Role == true)
            {
                ViewBag.Order = new SelectList(db.Orders.ToList(), "Id", "CustomerName");
                ViewBag.Sach = new SelectList(db.Saches.ToList(), "Id", "Name");

                return View();
            }
            else
            {
                return RedirectToAction("", "Sach", new { area = "" });
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(OrderDetail model)
        {
            if (ModelState.IsValid)
            {
                // Lấy thông tin sách từ database để tính giá theo số lượng
                var selectedSach = db.Saches.FirstOrDefault(s => s.Id == model.SachId);

                if (selectedSach != null)
                {
                    model.Price = selectedSach.Price * model.Quantity; // Tính tổng giá trị

                    db.OrderDetails.Add(model);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("SachId", "Sách không tồn tại");
                }
            }

            // Repopulate dropdowns if model validation fails or sách không tồn tại
            ViewBag.Order = new SelectList(db.Orders.ToList(), "Id", "CustomerName");
            ViewBag.Sach = new SelectList(db.Saches.ToList(), "Id", "Name");
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            if (Session["User"] is User user && user.Role == true)
            {
                ViewBag.Order = new SelectList(db.Orders.ToList(), "Id", "CustomerName");
                ViewBag.Sach = new SelectList(db.Saches.ToList(), "Id", "Name");

                var item = db.OrderDetails.Find(id);
                if (item == null)
                {
                    ModelState.AddModelError("", "Không tìm thấy sản phẩm");
                }
                return View(item);
            }
            else
            {
                return RedirectToAction("", "Sach", new { area = "" });
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(OrderDetail model)
        {
            if (ModelState.IsValid)
            {
                var selectedSach = db.Saches.FirstOrDefault(s => s.Id == model.SachId);
                var existingItem = db.OrderDetails.Find(model.Id);
                if (existingItem != null && selectedSach != null)
                {
                    // Update properties
                    existingItem.OrderId = model.OrderId;
                    existingItem.SachId = model.SachId;
                    existingItem.Quantity = model.Quantity;
                    existingItem.Price = selectedSach.Price * model.Quantity; ;

                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            return View(model);

        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var item = db.OrderDetails.Find(id);
            if (item != null)
            {               
                db.OrderDetails.Remove(item);
                db.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }
    }
}