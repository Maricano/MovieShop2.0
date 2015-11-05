using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieShopUI.Models
{
    public class OrderViewModel
    {
        public MovieShopDAL.Orders Order { get; set; }
        public List<MovieShopDAL.Customer> CustomerList { get; set; }
        public List<MovieShopDAL.Movie> MovieList { get; set; }
    }
}