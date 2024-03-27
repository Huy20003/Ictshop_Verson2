using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ictshop.DesignPattern.Prototype
{
    public class ConcreteSanphamPrototype : SanphamPrototype
    {
        private List<Sanpham> sanphams;
        private List<Models.Sanpham> ip;

        public ConcreteSanphamPrototype(List<Sanpham> list)
        {
            sanphams = list;
        }

        public ConcreteSanphamPrototype(List<Models.Sanpham> ip)
        {
            this.ip = ip;
        }

        public override List<Sanpham> Clone()
        {
            return sanphams.Select(sp => new Sanpham { Masp = sp.Masp, TenSp = sp.TenSp, Mahang = sp.Mahang }).ToList();
        }
    }
}