using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace MovieShopDAL.Repository
{
    public class OrderRepository : ICrudRepository<Orders>
    {
        public void Create(Orders Order)
        {
            using (var Context = new ContextMovieStore())
            {
                Orders order = new Orders();
                if (Order.Customer.CustomerId != 0)
                {
                    order.Customer = Context.Customer.Single(c => c.CustomerId == Order.Customer.CustomerId);
                }
                else
                {
                    order.Customer = Order.Customer;
                }
                order.OrderTime = Order.OrderTime;
                order.ShoppingCartItems = new List<ShoppingCartItem>();
                foreach (ShoppingCartItem item in Order.ShoppingCartItems)
                {
                    order.ShoppingCartItems.Add(new ShoppingCartItem()
                    {
                        Movie = Context.Movie.Single(m => m.MovieId == item.Movie.MovieId),
                        Quantity = item.Quantity,
                    });
                }
                Context.Set<Orders>().Add(order);
                Context.SaveChanges();
            }
        }

        public void Delete(int Id)
        {
            using (var Context = new ContextMovieStore())
            {
                Orders Order = Context.Set<Orders>().Include(o => o.ShoppingCartItems).Where(o => o.OrderId == Id).FirstOrDefault();
               
                Context.ShoppingCartItems.RemoveRange(Context.ShoppingCartItems.Where(s => s.OrdersId == Id));

                if(Order != null)
                {
                    Context.Set<Orders>().Remove(Order);
                }
                Context.SaveChanges();
            }
        }

        public Orders Read(int Id)
        {
            Orders Order = null;
            using (var Context = new ContextMovieStore())
            {
                Order = Context.Set<Orders>().Include(c => c.Customer).Include(c => c.ShoppingCartItems).Include(c => c.ShoppingCartItems.Select(s => s.Movie)).FirstOrDefault(o => o.OrderId == Id);
                if(Order != null)
                {
                    return Order;
                }
                else
                {
                    throw new Exception("There is no order with this ID ");
                }
            }
        }

        public List<Orders> ReadAll()
        {
            using (var Context = new ContextMovieStore())
            {
                List<Orders> OrderList = Context.Set<Orders>().Include(c => c.Customer).Include(c => c.ShoppingCartItems).ToList();
                return OrderList;
            }
        }

        public void Update(Orders order)
        {
            using (var Context = new ContextMovieStore())
            {
                Orders Order = Context.Set<Orders>().Where(o => o.OrderId == order.OrderId).FirstOrDefault();
                if (Order != null)
                {
                    Order.OrderTime = order.OrderTime;
                }
                Context.SaveChanges();
            }
        }
    }
}
