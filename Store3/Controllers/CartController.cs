using Store3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Store3.Controllers
{
    public class CartController : Controller
    {
        DbStore db = new DbStore();
        // GET: Cart
        public Cart GetCart()
        {
            Cart cart = Session["Cart"] as Cart;
            if(cart == null || Session["Cart"] == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }
        public ActionResult AddtoCard(int id)
        {
            var pro = db.Saches.SingleOrDefault(s => s.MaSach == id);
            if (pro != null)
            {
                GetCart().Add(pro);
            }
            return RedirectToAction("ShowToCard", "Cart");
        }
        public ActionResult ShowToCard()
        {
            if (Session["Cart"] == null)
                return RedirectToAction("ShowToCard", "Cart");
            Cart cart = Session["Cart"] as Cart;
            return View(cart);
        }
    }
}