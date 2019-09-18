using DAL;
using DAL.Abstract;
using DAL.Entities;
using Shop0._1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop0._1.Controllers
{
    public class CartController : Controller
    {
        private IGoodRepository repository;
        private IOrderProcessor orderProcessor;
        public CartController(IGoodRepository repo, IOrderProcessor proc)
        {
            repository = repo;
            orderProcessor = proc;
        }
        public ViewResult Index(Cart cart ,string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = cart,
                ReturnUrl = returnUrl
            });
        }
        public RedirectToRouteResult AddToCart(Cart cart, int goodId, string returnUrl)
        {

            Good good = repository.GetAll()
                                  .FirstOrDefault(p => p.GoodId == goodId);
            if (good != null)
            {
                cart.AddItem(good, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
        public RedirectToRouteResult RemoveFromCart(Cart cart, int? goodId, string returnUrl)
        {
            Good good = repository.GetAll()
                                  .FirstOrDefault(p => p.GoodId == goodId);
            if (good != null)
            {
                cart.RemoveLine(good);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
        public PartialViewResult Summary(Cart cart)
        {
            return PartialView(cart);
        }
        [HttpPost]
        public ViewResult Checkout(Cart cart, ShippingDetails shippingDetails)
        {
            if (cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your cart is empty!");
            }
            else
            {
                orderProcessor.ProcessOrder(cart, shippingDetails);
                cart.Clear();
                return View("Completed");
            }
            return View(shippingDetails);
            
        }
        public ViewResult Checkout()
        {
            return View(new ShippingDetails());
        }
    }
}






#region
//public ViewResult Index(string returnUrl)
//{
//    return View(new CartIndexViewModel
//    {
//        Cart = GetCart(),
//        ReturnUrl = returnUrl
//    });
//}

////first try of method AddToCart
////public ViewResult AddToCart(int? goodId, string returnUrl)
////{
////    Good good = repository.GetAll()
////                             .FirstOrDefault(p => p.GoodId == goodId);
////    Cart cl = GetCart();
////    if (good != null)
////    {
////        cl.AddItem(good, 1);
////    }
////    return View("Index", cl.Lines.First());
////}
//public RedirectToRouteResult AddToCart(int goodId, string returnUrl)
//{

//    Good good = repository.GetAll()
//                          .FirstOrDefault(p => p.GoodId == goodId);
//    if (good != null)
//    {
//        GetCart().AddItem(good, 1);
//    }
//    return RedirectToAction("Index", new { returnUrl });
//}
//public RedirectToRouteResult RemoveFromCart(int? goodId, string returnUrl)
//{
//    Good good = repository.GetAll()
//                          .FirstOrDefault(p => p.GoodId == goodId);
//    if (good != null)
//    {
//        GetCart().RemoveLine(good);
//    }
//    return RedirectToAction("Index", new { returnUrl });
//}
//private Cart GetCart()
//{
//    Cart cart = (Cart)Session["Cart"];
//    if (cart == null)
//    {
//        cart = new Cart();
//        Session["Cart"] = cart;
//    }
//    return cart;
//}
//    }
#endregion