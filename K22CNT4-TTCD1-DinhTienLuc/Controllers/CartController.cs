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
            return View();
        }
        [HttpPost]
        public ActionResult AddToCart(int id, int quantity)
        {
            var code = new { Success = false, msg = "", code = -1 };
            var db = new Entities5();
            var checkProduct = db.Saches.FirstOrDefault(x => x.Id == id);
            var checkUser = db.Users.FirstOrDefault(x=>x.Id == id);
            if (checkProduct == null)
            {
                ShoppingCart cart = (ShoppingCart)Session["Cart"];
                if (cart == null)
                {
                    cart = new ShoppingCart();
                };

                Cart item = new Cart
                {
                    TenSach = checkProduct.Name,
                    IdSach = checkProduct.Id,
                    IdUser = checkUser.Id,
                    SachImages = checkProduct.Images.Split(',').FirstOrDefault(),
                    Quantity = quantity,
                };

                item.Price = checkProduct.Price;
                item.TotalPrice = item.Price * item.Quantity;
                cart.AddToCart(item, quantity);

                cart = new { Success = true, msg = "Thêm sản phẩm vào giỏ hàng thành công", code = 1 }
            }
            return Json(code);
        }
    }
}