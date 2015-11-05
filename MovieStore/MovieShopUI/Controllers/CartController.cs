using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieShopUI;
using MovieShopUI.Models;
using MovieShopDAL;

namespace MovieShopUI.Controllers
{
    public class CartController : Controller
    {
        Facade Facade = new Facade();

        // GET: Cart
        public ActionResult Index()
        {
            List<ShoppingCartItem> view = new List<ShoppingCartItem>();

            if(Session["Cart"] != null)
            {
                view = (List<ShoppingCartItem>)Session["Cart"];
            }

            return View(view);
        }

        public ActionResult Order(int id)
        {
            List<ShoppingCartItem> Cart = new List<ShoppingCartItem>();

            if (Session["Cart"] != null)
            {
                Cart = (List<ShoppingCartItem>)Session["Cart"];
            }

            if (Exist(id) == -1)
            {
                Cart.Add(new ShoppingCartItem() { Movie = Facade.GetMovieRepository().Read(id), Quantity = 1, });
            }
            else
            {
                Cart[Exist(id)].Quantity++;
            }
            
            Session["Cart"] = Cart;

            return RedirectToAction("Index");
        }

        public ActionResult Delete (int id)
        {
            List<ShoppingCartItem> Cart = (List<ShoppingCartItem>)Session["Cart"];
            int index = Exist(id);
            if(index != -1)
            {
                Cart.RemoveAt(index);
            }
            return RedirectToAction("Index");
        }

        public ActionResult DeleteOne(int id)
        {
            List<ShoppingCartItem> Cart = (List<ShoppingCartItem>)Session["Cart"];
            int index = Exist(id);
            if (index != -1)
            {
                if(Cart[index].Quantity > 1)
                {
                    Cart[index].Quantity--;
                }
                else
                {
                    Delete(id);
                }
            }
            return RedirectToAction("Index");
        }
        private int Exist (int id)
        {
            if(Session["Cart"] == null)
            {
                return -1;
            }
            List<ShoppingCartItem> Cart = (List<ShoppingCartItem>)Session["Cart"];
            for (int i = 0; i < Cart.Count; i++)
            {
                if(Cart[i].Movie.MovieId == id)
                {
                    return i;
                }
            }
            return -1;
        }

        public ActionResult FindCustomer()
        {
            if (Session["Cart"] == null)
            {
                return RedirectToAction("Index");
            }

            List<ShoppingCartItem> cart = (List<ShoppingCartItem>)Session["Cart"];
            if(cart.Count <= 0)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpPost]
        public ActionResult FindCustomer(Customer Customer, string LoginEmail)
        {
            if(Request.Form["SubmitLogin"] != null)
            {
                Customer = Facade.GetCustomerSearch().search(LoginEmail);
                if(Customer == null)
                {
                    ViewBag.LoginError = "Ingen kunde fundet på emailen.";
                    return View();
                }
                else
                {
                    return RedirectToAction("PlaceOrder", Customer);
                }
            }
            else if(Request.Form["SubmitCreate"] != null)
            {
                if (ModelState.IsValid)
                {

                    return RedirectToAction("PlaceOrder", Customer);
                }
                else
                {
                    return View();
                }
            }

            return View();
        }

        public ActionResult PlaceOrder(Customer Customer)
        {
            if(Session["Cart"] == null)
            {
                return RedirectToAction("Index");
            }
            Orders order = new Orders();
            order.Customer = Customer;
            order.OrderTime = DateTime.Now;
            order.ShoppingCartItems = (List<ShoppingCartItem>)Session["Cart"];

            Facade.GetOrderRepository().Create(order);

            Session["Cart"] = null;
            return View();
        }
    }
}