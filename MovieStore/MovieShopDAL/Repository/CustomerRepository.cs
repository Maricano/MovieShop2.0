using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieShopDAL.Repository
{
    public class CustomerRepository : ICrudRepository<Customer>, ISearch<Customer>
    {
        public void Create(Customer Customer)
        {
            using (var Context = new ContextMovieStore())
            {
                Context.Set<Customer>().Add(Customer);
                Context.SaveChanges();
            }
        }

        public void Delete(int Id)
        {
            using (var Context = new ContextMovieStore())
            {
                Customer Customer = Context.Set<Customer>().Where(c => c.CustomerId == Id).FirstOrDefault();
                if(Customer != null)
                {
                    Context.Set<Customer>().Remove(Customer);
                }
                Context.SaveChanges();
            }
        }

        public Customer Read(int Id)
        {
            Customer Customer = null;
            using (var Context = new ContextMovieStore())
            {
                Customer = Context.Set<Customer>().Where(c => c.CustomerId == Id).FirstOrDefault();
                if(Customer != null)
                {
                    return Customer;
                }
                else
                {
                    throw new Exception("There is no customer with this ID ");
                }
            }
        }

        public List<Customer> ReadAll()
        {
            using (var Context = new ContextMovieStore())
            {
                List<Customer> CustomerList = Context.Set<Customer>().ToList();
                return CustomerList;
            }
        }

        public Customer search(string email)
        {
            using (var Context = new ContextMovieStore())
            {
                return Context.Customer.Include("Orders").SingleOrDefault(c => c.Email == email);
            }
        }

        public void Update(Customer customer)
        {
            using (var Context = new ContextMovieStore())
            {
                Customer Customer = Context.Set<Customer>().Include("Orders").Where(c => c.CustomerId == customer.CustomerId).FirstOrDefault();
                if(Customer != null)
                {
                    Customer.Country = customer.Country;
                    Customer.Email = customer.Email;
                    Customer.FirstName = customer.FirstName;
                    Customer.HouseNumber = customer.HouseNumber;
                    Customer.StreetName = customer.StreetName;
                    Customer.Zipcode = customer.Zipcode;
                    Customer.LastName = customer.LastName;
                }
                Context.SaveChanges();
            }
        }
    }
}
