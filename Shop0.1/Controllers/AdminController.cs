using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop0._1.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        private IGoodRepository repository;
        public AdminController(IGoodRepository repo)
        {
            repository = repo;
        }
        public ViewResult Index()
        {
            return View(repository.GetAll());
        }
    }
}