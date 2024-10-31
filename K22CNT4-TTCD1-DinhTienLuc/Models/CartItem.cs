using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace K22CNT4_TTCD1_DinhTienLuc.Models
{
    public class ShoppingCart
    {
        public List<Cart> items {  get; set; }
        public ShoppingCart()
        {
            this.items = new List<Cart>();
        }
        public void AddToCart(Cart item, int quantity)
        {
            // Kiểm tra sản phẩm trong giỏ hàng dựa trên IdSach thay vì Id (IdSach là mã sản phẩm)
            var checkExits = items.FirstOrDefault(x => x.IdSach == item.IdSach);

            if (checkExits != null)
            {
                // Nếu sản phẩm đã tồn tại, tăng số lượng và tính lại tổng giá
                checkExits.Quantity += quantity;
                checkExits.TotalPrice = checkExits.Price * checkExits.Quantity;
            }
            else
            {
                // Nếu sản phẩm chưa tồn tại, thêm sản phẩm vào giỏ
                item.Quantity = quantity; // Đảm bảo số lượng của item đúng
                item.TotalPrice = item.Price * item.Quantity; // Tính tổng giá
                items.Add(item);
            }
        }

        public void RemoveFromCart(int id)
        {
            var checkExits = items.FirstOrDefault(x => x.IdSach == id);
            if (checkExits != null)
            {
                items.Remove(checkExits);             
            }
            
        }

        public void UpdateQuantity(int id, int quantity) {
            var checkExits = items.FirstOrDefault(x => x.Id == id);       
            if (checkExits != null)
            {
                checkExits.Quantity += quantity;
                checkExits.TotalPrice = checkExits.Price * checkExits.Quantity;
            }
        }

        public decimal GetToTal()
        {
            return items.Sum(x => x.TotalPrice);
        } 
        public decimal GetToTalQuantity()
        {
            return items.Sum(x => x.Quantity);
        }

        public void ClearCart()
        {
            items.Clear();
        }
    }
}