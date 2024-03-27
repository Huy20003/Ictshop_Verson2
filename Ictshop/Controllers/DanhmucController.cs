using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Ictshop.Models;

namespace Ictshop.Controllers
{
    public class DanhmucController : Controller
    {
        Model1 db = new Model1();
        // GET: Danhmuc
        public ActionResult DanhmucPartial()
        {
            var danhmuc = db.Hangsanxuats.ToList();
            return PartialView(danhmuc);
        }
    
      
        public ActionResult ProductCategory(int Id)
        {
            var listProduct=db.Sanphams.Include(s => s.Hangsanxuat).Include(s => s.Hedieuhanh).Where(n=>n.Mahang==Id).ToList();
            return View(listProduct);
        }
    }
}