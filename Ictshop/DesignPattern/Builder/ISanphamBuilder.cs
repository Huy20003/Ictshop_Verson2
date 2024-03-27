
using Ictshop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ictshop.DesignPattern.Builder
{
    public interface ISanphamBuilder
    {
        ISanphamBuilder SetTensp(string tensp);
        ISanphamBuilder SetGiatien(decimal giatien);
        ISanphamBuilder SetSoluong(int soluong);
        ISanphamBuilder SetMota(string mota);
        ISanphamBuilder SetAnhbia(string anhbia);
        ISanphamBuilder SetBonhotrong(int bonhotrong);
        ISanphamBuilder SetRam(int ram);
        ISanphamBuilder SetThesim(int thesim);
        ISanphamBuilder SetMahang(int mahang);
        ISanphamBuilder SetMahdh(int mahdh);
        Sanpham Build();
    }
}