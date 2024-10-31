﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace K22CNT4_TTCD1_DinhTienLuc.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            if (Session["User"] != null)
            {
                return View();
            }else
            {
                return RedirectToAction("Login", "Sach", new { area = "" });
            }
        }
    }
}