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
            int countofpages = (int)Math.Ceiling((double)(repository.GetAll().ToList().Count) / PageSize);
            ViewBag.Goods = repository.GetAll()
                                      .OrderBy(p => p.GoodId)
                                      .Skip((id - 1) * PageSize)
                                      .Take(PageSize);
            ViewBag.CountOfPages = countofpages;
            return View();
        }
        public ViewResult Edit(int goodId)// have not done in index
        {
            Good good = new Good();
            good = repository.GetAll().FirstOrDefault(p => p.GoodId == goodId);
            return View(good);
        }
    }
}



//static List<Car> cars;
//public HomeController()
//{
//    cars = cars ?? Car.GetCars();
//}
//public ActionResult AddCar()
//{
//    return View();
//}
//[HttpPost]
//public ActionResult AddCar(Car newCar)
//{
//    if (ModelState.IsValid)
//        cars.Add(newCar);
//    return RedirectToAction("Index");
//}
//// GET: Home
//public ActionResult Index()
//{
//    ViewBag.AllCars = cars;
//    return View();
//}
//public ActionResult Delete(int id)
//{
//    cars.Remove(cars.Find(x => x.Id == id));
//    return RedirectToAction("Index");
//}