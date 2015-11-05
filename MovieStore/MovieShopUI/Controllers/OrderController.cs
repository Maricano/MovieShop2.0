using MovieShopDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieShopUI.Controllers
{
    public class OrderController : Controller
    {
        Facade Facade = new MovieShopDAL.Facade();
        // GET: Order
        public ActionResult Index()
        {
            return View(Facade.GetOrderRepository().ReadAll());
        }

        public ActionResult Details(int id)
        {
            return View(Facade.GetOrderRepository().Read(id));
        }

        public ActionResult Delete(int id)
        {
            return View(Facade.GetOrderRepository().Read(id));
        }

        [HttpPost]
        public ActionResult Delete(int id, MovieShopDAL.Orders Order)
        {
                Facade.GetOrderRepository().Delete(id);
                return RedirectToAction("Index");
        }
    }
}