using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ictshop.DesignPattern.Prototype;
using Ictshop.Models;

namespace Ictshop.Controllers
{
    public class SanphamController : Controller
    {
        Model1 db = new Model1();

        public ActionResult Index()
        {
            var items = db.Sanphams.ToList();

            return View(items);
        }    


        // GET: Sanpham
        public ActionResult dtiphonepartial()
        {
            var ip = db.Sanphams.Where(n => n.Mahang == 2).Take(4).ToList();
            return PartialView(ip);
        }
        public ActionResult dtsamsungpartial()
        {
            var ss = db.Sanphams.Where(n => n.Mahang == 1).Take(4).ToList();
            return PartialView(ss);
        }
        public ActionResult dtxiaomipartial()
        {
            var mi = db.Sanphams.Where(n => n.Mahang == 3).Take(4).ToList();
            return PartialView(mi);
        }
        //public ActionResult dttheohang()
        //{
        //    var mi = db.Sanphams.Where(n => n.Mahang == 5).Take(4).ToList();
        //    return PartialView(mi);
        //}
        public ActionResult xemchitiet(int Masp = 0)
        {
            var chitiet = db.Sanphams.SingleOrDefault(n => n.Masp == Masp);
            if (chitiet == null)
            {


                Response.StatusCode = 404;
                return null;
            }
            else
            {
                db.Sanphams.Attach(chitiet);
                chitiet.ViewCout= chitiet.ViewCout + 1;
                db.Entry(chitiet).Property(x => x.ViewCout).IsModified = true;
                db.SaveChanges();
            }
            var countView = db.ReviewSanPhams.Where(x => x.SanPhamID == Masp).Count();
            ViewBag.CountReview = countView;
            return View(chitiet);
        }

          

        //    private Dictionary<string, SanphamPrototype> prototypes = new Dictionary<string, SanphamPrototype>();

        //    public SanphamController()
        //    {
        //        // Khởi tạo các prototype ở đây
        //        var ip = db.Sanphams.Where(n => n.Mahang == 2).Take(4).ToList();
        //        var ss = db.Sanphams.Where(n => n.Mahang == 1).Take(4).ToList();
        //        var mi = db.Sanphams.Where(n => n.Mahang == 3).Take(4).ToList();

        //        prototypes.Add("dtiphonepartial", new ConcreteSanphamPrototype(ip));
        //        prototypes.Add("dtsamsungpartial", new ConcreteSanphamPrototype(ss));
        //        prototypes.Add("dtxiaomipartial", new ConcreteSanphamPrototype(mi));
        //    }

        //    public ActionResult RenderPartial(string partialName)
        //    {
        //        // Sử dụng Prototype để tạo bản sao và render partial view
        //        if (prototypes.ContainsKey(partialName))
        //        {
        //            var clonedSanphams = prototypes[partialName].Clone();
        //            return PartialView(partialName, clonedSanphams);
        //        }

        //        // Nếu không tìm thấy partial name, trả về null hoặc xử lý khác tùy theo yêu cầu
        //        return null;
        //    }

        //    public ActionResult xemchitiet(int Masp = 0)
        //    {
        //        // Phần xem chi tiết ở đây
        //        var chitiet = db.Sanphams.SingleOrDefault(n => n.Masp == Masp);
        //        if (chitiet == null)
        //        {
        //            Response.StatusCode = 404;
        //            return null;
        //        }
        //        return View(chitiet);
        //    }

        //}
    }

}