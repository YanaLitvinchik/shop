using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop0._1.Controllers
{
    public class GoodController : Controller
    {
        private IGoodRepository repository;
        public int PageSize = 6;
        public GoodController(IGoodRepository goodRepository)
        {
            this.repository = goodRepository;
        }
        public ViewResult AllGood(int id = 1)
        {
            int countofpages = (int)Math.Ceiling((double)(repository.GetAll().ToList().Count) / PageSize);
            ViewBag.Goods = repository.GetAll()
                                      .OrderBy(p=> p.GoodId)
                                      .Skip((id-1)* PageSize)
                                      .Take(PageSize);
            ViewBag.CountOfPages = countofpages;
            return View();
        }
        public ActionResult Cameras()
        {
            ViewBag.Goods = repository.GetAll().Where(p => p.CategoryId == 1).ToList();
            return View();
        }
        public ActionResult Lenses()
        {
            ViewBag.Goods = repository.GetAll().Where(p => p.CategoryId == 2).ToList();
            return View();
        }
        public ActionResult Camcoders()
        {
            ViewBag.Goods = repository.GetAll().Where(p => p.CategoryId == 3).ToList();
            return View();
        }
    }
}