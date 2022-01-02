using System;
using System.Web;
using System.Web.Mvc;

using ShopOnlineDemo.Models;
using ShopOnlineDemo.Areas.PrivatePages.Models;
using System.IO;

namespace ShopOnlineDemo.Areas.PrivatePages.Controllers
{
    public class NewArticleController : Controller
    {
        // GET: PrivatePages/NewArticle
        [HttpGet]
        public ActionResult Index()
        {

            //------khai bao
            BaiViet e = new BaiViet();
            ShopOnline_DemoEntities sh = new ShopOnline_DemoEntities();
            //-- mac dinh cho 1 so cai
            e.daDuyet = false;
            e.ngayDang = DateTime.Now;
            //--lay tai khoan tu TtDangNhap
            e.taiKhoan = ThuongDung.GetTenTaiKhoan();
            e.soLanDoc = 0;
            e.loaiTin = "QC";
            //---đưa đường dẫn của hình qua bên ngoài view
            ViewBag.ddHinh = "/Asset/Images/sanPham/varsity1.jpg";
            //---------
            return View(e);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Index(BaiViet e, HttpPostedFileBase HinhDaiDien)
        {
            try
            {
                ShopOnline_DemoEntities sh = new ShopOnline_DemoEntities();
                e.daDuyet = false;
                e.ngayDang = DateTime.Now;
                e.taiKhoan = ThuongDung.GetTenTaiKhoan();
                e.loaiTin = "QC";
                e.maBV = string.Format("{0:ddMMyyhhmm}", DateTime.Now);
                e.soLanDoc = 0;
                if (HinhDaiDien != null)
                {
                    //----lưu hình vào thư mục bài viết UwU
                    string virPath = "/Asset/Images/baiViet/"; //-- đường dẫn ảo đi đến thư mục bài viết chứa ảnh
                    string phyPath = Server.MapPath("~/" + virPath); //- Sever.MapPath chỉ ổ đĩa sever tự chọn + đường dẫn vật lí
                    string moRong = Path.GetExtension(HinhDaiDien.FileName); //- phần đuôi của hình (.jpg) or (.png).v.v......
                    string fileName = "HDD" + e.maBV + moRong;
                    //---------lưu dựa vào đường dẫn----------------
                    HinhDaiDien.SaveAs(phyPath + fileName); //--lưu dựa vào đường dẫn vật lí sever chứa web
                                                            //--nhận đường dẫn truy cập tới hình đã lưu dữ dựa vào domain
                    e.hinhDD = virPath + fileName; //-đường dẫn ảo theo domain
                                                   //---cập nhật hình vừa đăng lên giao diện
                    ViewBag.ddHinh = e.hinhDD;
                }
                else { e.hinhDD = ""; }
                //-------thêm dữ liệu 
                sh.BaiViets.Add(e);
                //---lưu dữ liệu vừa thêm vào dataabase
                sh.SaveChanges();
                //--- nếu đăng bài thành công thì chuyển đến trang duyệt bài 
                return RedirectToAction("Index", "Orderlist", new { isActive = 0 });
            }
            catch
            {
                //---nếu không đăng thì 
                return View(e);
            }
        }

    }
}