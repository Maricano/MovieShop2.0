using MovieShopDAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieShopDAL
{
    public class Facade
    {
        static ICrudRepository<Customer> CustomerRepo;
        static ICrudRepository<Genres> GenreRepo;
        static ICrudRepository<Movie> MovieRepo;
        static ICrudRepository<Orders> OrderRepo;
        
        public static ICrudRepository<Customer> GetCustomerRepository()
        {
            if (CustomerRepo == null)
            {
                CustomerRepo = new CustomerRepository();
            }
            return CustomerRepo;
        }

        public static ICrudRepository<Genres> GetGenreRepository()
        {
            if(GenreRepo == null)
            {
                GenreRepo = new GenreRepository();
            }
            return GenreRepo;
        }

        public static ICrudRepository<Movie> GetMovieRepository()
        {
            if (MovieRepo == null)
            {
                MovieRepo = new MovieRepository();
            }
            return MovieRepo;
        }

        public static ICrudRepository<Orders> GetOrderRepository()
        {
            if (OrderRepo == null)
            {
                OrderRepo = new OrderRepository();
            }
            return OrderRepo;
        }

        public static ISearch<Customer> GetCustomerSearch()
        {
            if(CustomerRepo == null)
            {
                CustomerRepo = new CustomerRepository();
            }
            return (ISearch<Customer>)CustomerRepo;
        }
        public static IGenreSearch<Movie> GetGenreSearch()
        {
            if (MovieRepo == null)
            {
                MovieRepo = new MovieRepository();
            }
            return (IGenreSearch<Movie>)MovieRepo;
        }
    }
}
