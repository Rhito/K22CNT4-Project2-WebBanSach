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
        public ActionResult Register(User user)
        {
            LoadDanhMuc();
            db.Users.Add(user);
            db.SaveChanges();
            return RedirectToAction("Login");
        }
        
        public ActionResult Login()
        {
            LoadDanhMuc();
            return View();
        }
        [HttpPost]
        public ActionResult Login(User user)
        {
            // Kiểm tra sesstion xem có tồn tại, nếu tồn tại đưa về trang chủ
            if (Session["User"] != null)
            {
                return RedirectToAction("Index");
            }

            LoadDanhMuc(); // Giả sử đây là phương thức để tải danh mục
            var tk = user.Email;
            var mk = user.Password;

            // Sửa đổi câu truy vấn LINQ để kiểm tra người dùng
            var checkUser = db.Users.FirstOrDefault(x => x.Email.Equals(tk) && x.Password.Equals(mk));

            if (checkUser.Status == false)
            {
                // Thông báo lỗi 
                ModelState.AddModelError("", "Tài khoản của người dùng bị khóa!!");
                return View(user); // Trả về view đăng nhập
            }
            // Kiểm tra nếu người dùng tồn tại và người dùng không bị khóa
            if (checkUser != null )
            {
                
                // Nếu đăng nhập thành công, có thể lưu thông tin người dùng vào session hoặc cookie
                Session["User"] = checkUser; 

                // Kiểm tra vai trò của người dùng nếu đúng đưa tới trang admin
                if (checkUser.Role == true)
                {
                    return RedirectToAction("Home", "Admin");
                }
              // Nếu là người fungf thông thường sẽ đưa về trang chủ
              return RedirectToAction("Index");
            }
            else
            {

                // Nếu không thành công, bạn có thể thông báo lỗi hoặc quay lại trang đăng nhập
                ModelState.AddModelError("", "Email hoặc mật khẩu không đúng!");
                return View(user); // Trả về view đăng nhập
            }
        }

        [HttpPost]
        public ActionResult DangXuat()
        {
            // Set Sesstion User bằng null
            Session["User"] = null;
            // Chuyển hướng tới trang chủ mà không có người dùng sẵn sàng đăng nhập
            return RedirectToAction("Index"); ;
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