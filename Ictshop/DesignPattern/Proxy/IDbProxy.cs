using Ictshop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ictshop.DesignPattern.Proxy
{
    public interface IDbProxy
    {
        void AddUser(Nguoidung nguoidung);
        void SaveChanges();
    }
}