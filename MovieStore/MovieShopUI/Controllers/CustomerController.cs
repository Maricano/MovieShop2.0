using MovieShopDAL;
using MovieShopUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MovieShopUI.Controllers
{
    
    public class CustomerController : Controller
    {
        Facade Facade = new MovieShopDAL.Facade();
        // GET: Customer
        public ActionResult Index()
        {
            return View(Facade.GetCustomerRepository().ReadAll());
        }

        public ActionResult Details(int id)
        {
            return View(Facade.GetCustomerRepository().Read(id));
        }

        public ActionResult Create()
        {
            CreateEditCustomerViewModel view = new CreateEditCustomerViewModel();
            return View(view);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer Customer)
        {
            if (ModelState.IsValid)
            {
                Facade.GetCustomerRepository().Create(Customer);
                return RedirectToAction("Index");
            }

            CreateEditCustomerViewModel view = new CreateEditCustomerViewModel();
            return View(view);
        }

        public ActionResult Delete(int id)
        {
            return View(Facade.GetCustomerRepository().Read(id));
        }

        [HttpPost]
        public ActionResult Delete(int id, MovieShopDAL.Customer newCustomer)
        {
            try
            {
                Facade.GetCustomerRepository().Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {

                CreateEditCustomerViewModel view = new CreateEditCustomerViewModel();
                Customer Customer = Facade.GetCustomerRepository().Read((int)id);

                view.CustomerId = Customer.CustomerId;
                view.FirstName = Customer.FirstName;
                view.LastName = Customer.LastName;
                view.StreetName = Customer.StreetName;
                view.HouseNumber = Customer.HouseNumber;
                view.Zipcode = Customer.Zipcode;
                view.Email = Customer.Email;
                view.Country = Customer.Country;
                view.ConfirmEmail = Customer.Email;

                return View(view);
            }
        }

        [HttpPost]
        public ActionResult Edit(MovieShopDAL.Customer Customer)
        {
            if (ModelState.IsValid)
            {
                Facade.GetCustomerRepository().Update(Customer);
                return RedirectToAction("Index");
            }

            CreateEditCustomerViewModel view = new CreateEditCustomerViewModel();

            view.FirstName = Customer.FirstName;
            view.LastName = Customer.LastName;
            view.StreetName = Customer.StreetName;
            view.HouseNumber = Customer.HouseNumber;
            view.Zipcode = Customer.Zipcode;
            view.ConfirmEmail = Customer.Email;
            view.Email = Customer.Email;
            view.Country = Customer.Country;
            

            return View(view);
        }
    }
}