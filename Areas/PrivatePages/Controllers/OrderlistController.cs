using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopOnlineDemo.Models;

namespace ShopOnlineDemo.Areas.PrivatePages.Controllers
{
    public class OrderlistController : Controller
    {
        //--static collection
        private static ShopOnline_DemoEntities db = new ShopOnline_DemoEntities();
        private static bool daDuyet; 
        [HttpGet]
        public ActionResult Index(string IsActive)
        {
            daDuyet = IsActive!=null && IsActive.Equals("1");
            CapNhatGiuLieuChoGiaoDien();
            return View();
        }
        [HttpPost]
        public ActionResult Delete(string maBaiViet)
        {
            //-- b1: Dùng lệnh để xóa bài viết 
            BaiViet x = db.BaiViets.Find(maBaiViet);
            db.BaiViets.Remove(x);
            //-- b2: Truy cập vào database 
            db.SaveChanges();
            //-- b3: hiển thị danh sách sau khi xóa
            CapNhatGiuLieuChoGiaoDien();
            return View("Index");
        }
        [HttpPost]
        public ActionResult Active(string maBaiViet)
        {
            //-- b1: Dùng để cấm bài viết 
            BaiViet x = db.BaiViets.Find(maBaiViet);
            x.daDuyet = !daDuyet;
            //-- b2: Truy cập vào database 
            db.SaveChanges();
            //-- b3: hiển thị danh sách sau khi xóa
            CapNhatGiuLieuChoGiaoDien();
            return View("Index");
        }
        /// <summary>
        /// Hàm phục vụ cho mục tiêu cập nhật dữ liệu View của controller này thông qua ViewData object 
        /// </summary>
        private void CapNhatGiuLieuChoGiaoDien()
        {
            List<BaiViet> l = db.BaiViets.Where(x => x.daDuyet == daDuyet).ToList<BaiViet>();
            ViewData["DanhSachBV"] = l;
            ViewBag.tdCuaNut = daDuyet ? "cấm" : "kiểm duyệt"; 
        }
    }

}