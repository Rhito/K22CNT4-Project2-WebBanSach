using K22CNT4_TTCD1_DinhTienLuc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace K22CNT4_TTCD1_DinhTienLuc.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Index()
        {
            ShoppingCart cart = (ShoppingCart)Session["Cart"];
            if (cart != null)
            {
                return View(cart.items);
            }

            return View();
        }

        public ActionResult ShowCount()
        {
            ShoppingCart cart = (ShoppingCart)Session["Cart"];
            int totalQuantityInCart = 0; // Khởi tạo biến totalQuantityInCart

            // Kiểm tra xem cart có tồn tại và có items không
            if (cart != null && cart.items != null)
            {
                totalQuantityInCart = cart.items.Sum(x=>x.Quantity); // Tính tổng số lượng
            }

            return Json(new { count = totalQuantityInCart }, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult AddToCart(int id, int quantity)
        {
            var code = new { Success = false, msg = "", code = -1, count = 0 };
            var db = new Entities5();

            // Tìm sản phẩm
            var checkProduct = db.Saches.FirstOrDefault(x => x.Id == id);

            if (checkProduct != null)
            {
                // Nếu chưa có giỏ hàng thì tạo mới
                ShoppingCart cart = (ShoppingCart)Session["Cart"] ?? new ShoppingCart();

                Cart item = new Cart
                {
                    TenSach = checkProduct.Name,
                    IdSach = checkProduct.Id,
                    SachImages = checkProduct.Images,
                    Quantity = quantity,
                    Price = checkProduct.Price
                };

                // Tính tổng giá cho sản phẩm
                item.TotalPrice = item.Price * item.Quantity;

                // Thêm sản phẩm vào giỏ hàng
                cart.AddToCart(item, quantity);

                // Lưu giỏ hàng vào session
                Session["Cart"] = cart;

                // Tính tổng các sản phẩm trong giỏ hàng
                int totalQuantityInCart = cart.items.Sum(x => x.Quantity);

                // Cập nhật trạng thái trả về
                code = new { Success = true, msg = "Thêm sản phẩm vào giỏ hàng thành công", code = 1, count = totalQuantityInCart };
            }
            else
            {
                // Sản phẩm không tồn tại
                code = new { Success = false, msg = "Sản phẩm không tồn tại", code = 0, count = 0 };
            }
            return Json(code);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            // Khởi tạo object với tất cả các thuộc tính bao gồm cả isEmpty
            var code = new { Success = false, msg = "", code = -1, count = 0, isEmpty = false };

            ShoppingCart cart = (ShoppingCart)Session["Cart"];

            if (cart != null)
            {
                var checkProduct = cart.items.FirstOrDefault(x => x.IdSach == id);
                if (checkProduct != null)
                {
                    cart.RemoveFromCart(id);

                    // Cập nhật session với giỏ hàng mới
                    Session["Cart"] = cart;

                    // Kiểm tra xem giỏ hàng có còn sản phẩm nào không
                    bool isEmpty = !cart.items.Any();

                    // Cập nhật response với thông tin giỏ hàng hiện tại
                    code = new { Success = true, msg = "Xóa sản phẩm thành công", code = 1, count = cart.items.Count, isEmpty = isEmpty };
                }
                else
                {
                    // Sản phẩm không tồn tại trong giỏ hàng nhưng vẫn cần trả về isEmpty
                    bool isEmpty = !cart.items.Any();
                    code = new { Success = false, msg = "Sản phẩm không tồn tại trong giỏ hàng", code = 0, count = cart.items.Count, isEmpty = isEmpty };
                }
            }
            else
            {
                // Trường hợp giỏ hàng chưa được khởi tạo hoặc rỗng, isEmpty sẽ là true
                code = new { Success = false, msg = "Giỏ hàng rỗng", code = -1, count = 0, isEmpty = true };
            }

            return Json(code);
        }


    }
}