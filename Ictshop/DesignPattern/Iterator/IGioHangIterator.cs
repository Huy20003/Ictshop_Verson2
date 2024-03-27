using Ictshop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ictshop.DesignPattern.Iterator
{
    public interface IGioHangIterator
    {

        bool HasNext();
        ShoppingCartItem Next();
        void Reset();
    }
}