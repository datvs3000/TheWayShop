using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopOnlineDemo.Models;

namespace ShopOnlineDemo.Controllers
{
    public class AboutsController : Controller
    {
        // GET: Abouts
        public ActionResult Index(string maBV)
        {
            ShopOnline_DemoEntities db = new ShopOnline_DemoEntities();
            BaiViet z = db.BaiViets.Where(sp => sp.maBV.Equals(maBV)).First<BaiViet>();
            ViewData["BaiVietCanXem"] = z;
            return View();
        }
    }
}