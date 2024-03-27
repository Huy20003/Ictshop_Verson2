using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ictshop.DesignPattern.Prototype
{
    public abstract class SanphamPrototype
    {
        public abstract List<Sanpham> Clone();
    }
}