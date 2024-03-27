using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ictshop.Models;

namespace Ictshop.Controllers
{
    public class ReviewController : Controller
    {

        private Model1 db = new Model1();
        // GET: Review
        public ActionResult Index()
        {
            return View();
        }
     
        public ActionResult _Review(int productID)
        {
            ViewBag.SanPhamID = productID;
            //var item = new ReviewSanPham();
          
            return PartialView();
        }

        public ActionResult _Load_Review(int productID)
        {
            var item = db.ReviewSanPhams.Where(x => x.SanPhamID == productID).OrderByDescending(x => x.Id).ToList();
            ViewBag.Count = item.Count;
            return PartialView(item);

        }





      

        [HttpPost]
        public ActionResult PostReview(ReviewSanPham req)
        {
            if (ModelState.IsValid)
            {
                req.CreateDate = DateTime.Now;
                db.ReviewSanPhams.Add(req);
                db.SaveChanges();
                var item = db.ReviewSanPhams.Where(x => x.SanPhamID == req.SanPhamID).OrderByDescending(x => x.Id).ToList();
                ViewBag.Count = item.Count;
                return PartialView("_Load_Review", item);
            }
            return Json(new { Success = false });
        }

    }
}