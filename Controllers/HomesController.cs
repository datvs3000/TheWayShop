using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopOnlineDemo.Models;

namespace ShopOnlineDemo.Controllers
{
    public class HomesController : Controller
    {
        // GET: Homes
        public ActionResult Index()
        {
            string tentMK = MaHoa.encryptSHA256("databc");
            List<SanPham> l = Hello.getProductByLoaiSP(4);
            return View();
        }
    }
}