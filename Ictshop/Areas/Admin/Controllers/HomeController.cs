﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ictshop.DesignPattern.Builder;
using Ictshop.Models;
using PagedList;

namespace Ictshop.Areas.Admin.Controllers
{
    public class HomeController : Controller
        
    {
        Model1 db = new Model1();
       
        // GET: Admin/Home
        
        public ActionResult Index(int ?page)
        {
            // 1. Tham số int? dùng để thể hiện null và kiểu int( số nguyên)
            // page có thể có giá trị là null ( rỗng) và kiểu int.

            // 2. Nếu page = null thì đặt lại là 1.
            if (page == null) page = 1;

            // 3. Tạo truy vấn sql, lưu ý phải sắp xếp theo trường nào đó, ví dụ OrderBy
            // theo Masp mới có thể phân trang.
            var sp = db.Sanphams.OrderBy(x => x.Masp);

            // 4. Tạo kích thước trang (pageSize) hay là số sản phẩm hiển thị trên 1 trang
            int pageSize = 5;

            // 4.1 Toán tử ?? trong C# mô tả nếu page khác null thì lấy giá trị page, còn
            // nếu page = null thì lấy giá trị 1 cho biến pageNumber.
            int pageNumber = (page ?? 1);

            // 5. Trả về các sản phẩm được phân trang theo kích thước và số trang.
            return View(sp.ToPagedList(pageNumber, pageSize));

        }

        // Xem chi tiết người dùng GET: Admin/Home/Details/5 
        public ActionResult Details(int id)
        {
            var dt = db.Sanphams.Find(id);
            return View(dt);
        }

        // Tạo sản phẩm mới phương thức GET: Admin/Home/Create
        public ActionResult Create()
        {
            ViewBag.Mahang = new SelectList(db.Hangsanxuats, "Mahang", "Tenhang");
            ViewBag.Mahdh = new SelectList(db.Hedieuhanhs, "Mahdh", "Tenhdh");
            return View();
        }

        // POST: Admin/Sanphams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Masp,Tensp,Giatien,Soluong,Mota,Thesim,Bonhotrong,Sanphammoi,Ram,Anhbia,Mahang,Mahdh")] Sanpham sanpham)
        {
            if (ModelState.IsValid)
            {
                db.Sanphams.Add(sanpham);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Mahang = new SelectList(db.Hangsanxuats, "Mahang", "Tenhang", sanpham.Mahang);
            ViewBag.Mahdh = new SelectList(db.Hedieuhanhs, "Mahdh", "Tenhdh", sanpham.Mahdh);
            return View(sanpham);
        }


        // Sửa sản phẩm GET lấy ra ID sản phẩm: Admin/Home/Edit/5
        public ActionResult Edit(int id)
        {
            // Hiển thị dropdownlist
            var dt = db.Sanphams.Find(id);
            var hangselected = new SelectList(db.Hangsanxuats, "Mahang", "Tenhang",dt.Mahang);
            ViewBag.Mahang = hangselected;
            var hdhselected = new SelectList(db.Hedieuhanhs, "Mahdh", "Tenhdh",dt.Mahdh);
            ViewBag.Mahdh = hdhselected;
           // 
            return View(dt);
        }

        // POST: Admin/Home/Edit/5
        [HttpPost]
        public ActionResult Edit(Sanpham sanpham)
        {
            try
            {
                var oldItem = db.Sanphams.Find(sanpham.Masp);

                // Sử dụng Builder để cập nhật dữ liệu
                var builder = new SanphamBuilder()
         .SetTensp(sanpham.Tensp)
         .SetGiatien(sanpham.Giatien ?? 0) // Chuyển đổi giá trị nullable thành không nullable
         .SetSoluong(sanpham.Soluong ?? 0) // Chuyển đổi giá trị nullable thành không nullable
         .SetMota(sanpham.Mota)
         .SetAnhbia(sanpham.Anhbia)
         .SetBonhotrong(sanpham.Bonhotrong ?? 0) // Chuyển đổi giá trị nullable thành không nullable
         .SetRam(sanpham.Ram ?? 0) // Chuyển đổi giá trị nullable thành không nullable
         .SetThesim(sanpham.Thesim ?? 0) // Chuyển đổi giá trị nullable thành không nullable
         .SetMahang(sanpham.Mahang ?? 0) // Chuyển đổi giá trị nullable thành không nullable
         .SetMahdh(sanpham.Mahdh ?? 0); // Chuyển đổi giá trị nullable thành không nullable

                var updatedSanpham = builder.Build();

                // Sửa sản phẩm
                db.Entry(oldItem).CurrentValues.SetValues(updatedSanpham);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        
        // Xoá sản phẩm phương thức GET: Admin/Home/Delete/5
        public ActionResult Delete(int id)
        {
            var dt = db.Sanphams.Find(id);
            return View(dt);
        }

        // Xoá sản phẩm phương thức POST: Admin/Home/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                //Lấy được thông tin sản phẩm theo ID(mã sản phẩm)
                var dt = db.Sanphams.Find(id);
                // Xoá
                db.Sanphams.Remove(dt);
                // Lưu lại
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}