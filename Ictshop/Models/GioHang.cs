using Ictshop.DesignPattern.Iterator;
using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    namespace Ictshop.Models
    {
        public class GioHang 
    {
            public List<ShoppingCartItem> Items { get; set; }


            public GioHang()
            {
                this.Items = new List<ShoppingCartItem>();
            }
        public IGioHangIterator CreateIterator()
        {
            return new GioHangIterator(this.Items);
        }
        public void AddToCart(Sanpham _pro, int _quantity=1)
            {
                var checkExits = Items.FirstOrDefault(x => x._spProduct.Masp == _pro.Masp);
                if (checkExits == null)
                {
                   Items.Add(new ShoppingCartItem
                   {
                       _spProduct= _pro, 
                       _spQuantity = _quantity
                   });
                }    
                else
                {
                    checkExits._spQuantity+=_quantity;
                }    


        
            }

            public void Remove(int id)
            {
                var checkExits = Items.SingleOrDefault(x => x._spProduct.Masp== id);
                if (checkExits != null)
                {
                    Items.Remove(checkExits);
                }
            }

            public void UpdateQuantity(int id, int _quantity)
            {
                var checkExits = Items.Find(s => s._spProduct.Masp == id);
                if (checkExits != null)
                {
                    checkExits._spQuantity=_quantity;
             
                }
            }

            public decimal GetTotalPrice()
            {
                var total = Items.Sum(s => s._spProduct.Giatien * s._spQuantity);
                return (decimal)total;
            }
            public decimal GetTotalPriceUSD()
            {
                var total = Items.Sum(s =>Math.Round((decimal)(s._spProduct.Giatien / 23500), 2) * s._spQuantity);
                return total;
            }
            public int GetTotalQuantity()
            {
                return Items.Sum(x => x._spQuantity);
            }
            public void ClearCart()
            {
                Items.Clear();
            }

        }
        public class ShoppingCartItem
        {
            public Sanpham _spProduct { get; set; }
            public int _spQuantity { get; set; }

       
      
       
        }

                    

    
}