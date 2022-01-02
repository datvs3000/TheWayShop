using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopOnlineDemo.Models;
namespace ShopOnlineDemo.Controllers
{
    public class ShopDetailController : Controller
    {
        public IEnumerable<object> SanPhams { get; private set; }

        // GET: ShopDetail
        public ActionResult Index(string MaSanPham)
        {
            ShopOnline_DemoEntities db = new ShopOnline_DemoEntities();
            SanPham x = db.SanPhams.Where(sp => sp.maSP.Equals(MaSanPham)).First();
            ViewData["SanPhamCanXem"] = x;
            return View();
        }
    }
}