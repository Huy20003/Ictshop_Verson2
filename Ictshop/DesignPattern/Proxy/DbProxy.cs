using Ictshop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ictshop.DesignPattern.Proxy
{
    public class DbProxy : IDbProxy
    {
        private Model1 db;

        public DbProxy()
        {
            // Khởi tạo đối tượng cơ sở dữ liệu
            db = new Model1();
        }

        public void AddUser(Nguoidung nguoidung)
        {
            // Thêm người dùng mới vào cơ sở dữ liệu
            db.Nguoidungs.Add(nguoidung);
        }

        public void SaveChanges()
        {
            // Lưu thay đổi vào cơ sở dữ liệu
            db.SaveChanges();
        }
    }
}