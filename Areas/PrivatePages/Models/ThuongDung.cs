using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShopOnlineDemo.Models;

namespace ShopOnlineDemo.Areas.PrivatePages.Models
{
    public class ThuongDung
    {
        public static TaiKhoan GetTaiKhoanDD()
        {
            TaiKhoan kq = new TaiKhoan();
            kq = HttpContext.Current.Session["DangNhap"] as TaiKhoan;
            return kq;
        }
    /// <summary>
    /// lấy tên của tài khoản đã đăng nhập hệ thống
    /// </summary>
    /// <returns></returns>
    public static string GetTenTaiKhoan()
    {
        return GetTaiKhoanDD().taiKhoan1;
    }
}
}