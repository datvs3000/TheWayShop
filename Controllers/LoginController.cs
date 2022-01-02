using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopOnlineDemo.Models;

namespace ShopOnlineDemo.Controllers
{
    public class LoginController : Controller
    {
        public object Encrypt { get; private set; }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(String Acc, String Pass)
        {
            try
            {
                
                TaiKhoan ttdn = new ShopOnline_DemoEntities()
                                 .TaiKhoans.Where(x => x.taiKhoan1.Equals(Acc.ToLower().Trim()) && x.matKhau.Equals(Pass))
                                 .First<TaiKhoan>();

                bool dieukien = ttdn != null && ttdn.taiKhoan1.Equals(Acc.ToLower().Trim()) && ttdn.matKhau.Equals(Pass);
                if (dieukien)
                {
                    Session["DangNhap"] = ttdn;
                    return RedirectToAction("Index", "Dashboard", new { Area = "PrivatePages" });
                }
            }
            catch
            {

            }
            return View();
        }
    }
}