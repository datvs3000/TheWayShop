using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopOnlineDemo.Models;

namespace ShopOnlineDemo.Controllers
{
    public class CartsController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            //-- lấy giỏ hàng từ Session
            ShopCart gh = Session["GioHang"] as ShopCart;
            //-- truyền ra ngoài view
            ViewData["Cart"] = gh; 
            return View();

        }
        public ActionResult Increase(string maSP)
        {
            ShopCart gh = Session["GioHang"] as ShopCart;
            gh.addItem(maSP);
            Session["GioHang"] = gh;
            return RedirectToAction("Index");
        }
        public ActionResult Decrease(string maSP)
        {
            ShopCart gh = Session["GioHang"] as ShopCart;
            gh.decrease(maSP);
            Session["GioHang"] = gh;
            return RedirectToAction("Index");
        }
        public ActionResult RemoveItem(string maSP)
        {
            ShopCart gh = Session["GioHang"] as ShopCart;
            gh.deleteItem(maSP);
            Session["GioHang"] = gh;
            return RedirectToAction("Index");
        }
    }
}