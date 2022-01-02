using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopOnlineDemo.Models;
namespace ShopOnlineDemo.Controllers
{
    public class ShopsController : Controller
    {
        // GET: Shops
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddToCart(string maSP)
        {
            //-- lấy giỏ hàng 
            ShopCart gh = Session["GioHang"] as ShopCart;
            //-- thêm sản phẩm vừa chọn mua vào giỏ hàng
            gh.addItem(maSP);
            //-- cap nhật lại giỏ hàng vào trong Session
            Session["GioHang"] = gh;
            return View("Index");
        }
    }
}