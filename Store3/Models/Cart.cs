using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Store3.Models
{
    public class CartItem
    {
        public Sach sach { get; set; }
        public int SoLuong { get; set; }
    }
    public class Cart
    {
        List<CartItem> items = new List<CartItem>();
        public IEnumerable<CartItem> Items
        {
            get { return items; }
        }
        public void Add(Sach pro, int SL = 1)
        {
            var item = items.FirstOrDefault(s => s.sach.MaSach == pro.MaSach);
            if (item == null)
            {
                items.Add(new CartItem
                {
                    sach = pro,
                    SoLuong = SL
                });
            }   
            else
            {
                item.SoLuong += SL;
            }
            
        }
        public void Update_SL(int id, int sl)
        {
            var item = items.Find(s => s.sach.MaSach == id);
            if(item != null)
            {
                item.SoLuong = sl;
            }
        }
      
    }
}