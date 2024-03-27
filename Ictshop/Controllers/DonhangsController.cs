using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Ictshop.DesignPattern.Command;
using Ictshop.Models;

namespace Ictshop.Controllers
{
    public class DonhangsController : Controller
    {
        private Model1 db = new Model1();

        // GET: Donhangs
        // Hiển thị danh sách đơn hàng
        public ActionResult Index()
        {
            //Kiểm tra đang đăng nhập
            //if (Session["use"] == null || Session["use"].ToString() == "")
            //{
            //    return RedirectToAction("Dangnhap", "User");
            //}
            //Nguoidung kh = (Nguoidung)Session["use"];
            //int maND = kh.MaNguoiDung;
            //var donhangs = db.Donhangs.Include(d => d.Nguoidung).Where(d=>d.MaNguoidung == maND);
            //return View(donhangs.ToList());
            ICommand command = new IndexCommand(this);
            command.Execute();
            return View();

        }
        /// <summary>
        /// //
        /// </summary>
        public  void CheckLoggedInAndDisplayOrders()
        {
            if(Session["use"] == null || Session["use"].ToString() == "")
            {
                RedirectToAction("Dangnhap", "User");
                return;
            }
            Nguoidung kh = (Nguoidung)Session["use"];
            int maND = kh.MaNguoiDung;
            var donhangs = db.Donhangs.Include(d => d.Nguoidung).Where(d => d.MaNguoidung == maND);
            View(donhangs.ToList());
        }

        public void DisplayOrderDetails(int? id)
        {
            if (id == null)
            {
                HttpNotFound();
                return;
            }
            Donhang donhang = db.Donhangs.Find(id);
            var chitiet = db.Chitietdonhangs.Include(d => d.Sanpham).Where(d => d.Madon == id).ToList();
            if (donhang == null)
            {
                HttpNotFound();
                return;
            }
            View(chitiet);
        }
        /// <summary>
        ///                                 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: Donhangs/Details/5
        //Hiển thị chi tiết đơn hàng
        public ActionResult Details(int? id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //Donhang donhang = db.Donhangs.Find(id);
            //var chitiet = db.Chitietdonhangs.Include(d => d.Sanpham).Where(d=> d.Madon == id).ToList();
            //if (donhang == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(chitiet);
            ICommand command = new DetailsCommand(this, id);
            command.Execute();
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
