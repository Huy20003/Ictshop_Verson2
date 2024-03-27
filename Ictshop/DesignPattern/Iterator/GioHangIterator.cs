using Ictshop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ictshop.DesignPattern.Iterator
{
    public class GioHangIterator: IGioHangIterator
    {
        private readonly List<ShoppingCartItem> _items;
        private int _currentIndex = 0;

        public GioHangIterator(List<ShoppingCartItem> items)
        {
            _items = items;
        }

        public bool HasNext()
        {
            return _currentIndex < _items.Count;
        }

        public ShoppingCartItem Next()
        {
            if (HasNext())
            {
                return _items[_currentIndex++];
            }
            else
            {
                return null; // Hoặc có thể throw một exception tùy thuộc vào thiết kế.
            }
        }

        public void Reset()
        {
            _currentIndex = 0;
        }
    }
}