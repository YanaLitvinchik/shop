﻿using DAL;
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
        public CartController(IGoodRepository repo)
        {
            repository = repo;
        }
        public RedirectToRouteResult AddToCart(int? goodId, string returnUrl)
        {
            Good good = repository.GetAll()
                                     .FirstOrDefault(p => p.GoodId == goodId);
            if (good != null)
            {
                GetCart().AddItem(good, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
        public RedirectToRouteResult RemoveFromCart(int? goodId, string returnUrl)
        {
            Good good = repository.GetAll()
                                  .FirstOrDefault(p => p.GoodId == goodId);
            if (good != null)
            {
                GetCart().RemoveLine(good);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
        private Cart GetCart()
        {
            Cart cart = (Cart)Session["Cart"];
            if (cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }
    }
}