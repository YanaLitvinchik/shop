using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Shop0._1.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        private IGoodRepository repository;
        public int PageSize = 8;
        public AdminController(IGoodRepository repo)
        {
            this.repository = repo;
        }
        public ViewResult Index(int id = 1)
        {
            Session["LastPage"] = id;
            int countofpages = (int)Math.Ceiling((double)(repository.GetAll().ToList().Count) / PageSize);
            ViewBag.Goods = repository.GetAll()
                                      .OrderBy(p => p.GoodId)
                                      .Skip((id - 1) * PageSize)
                                      .Take(PageSize);
            ViewBag.CountOfPages = countofpages;
            return View();
        }
        public ActionResult NewGood(int id = 0)
        {
            return View(repository.Get(id));
        }
        public ActionResult Edit(int id = 0)
        {
            return View(repository.Get(id));
        }
        [HttpPost]
        public ActionResult NewGood(Good newGood)
        {
            repository.CreateOrUpdate(newGood);
            repository.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            repository.Remove(repository.Get(id));
            repository.SaveChanges();

            int redirectPage = (int)Session["LastPage"];

            return RedirectToAction("Index", new { id = redirectPage });
        }
    }
}

