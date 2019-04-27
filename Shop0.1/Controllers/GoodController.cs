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
        private GoodRepository repository;
        public int PageSize = 2;        public GoodController(GoodRepository goodRepository)
        {
            this.repository = goodRepository;
        }
        //public ViewResult List()
        //{
        //    return View(repository.GetAll());
        //}
        public ViewResult List(int page = 1)
        {
            return View(repository.GetAll()
            .OrderBy(p => p.GoodId)
            .Skip((page - 1) * PageSize)
            .Take(PageSize));
        }
    }
}