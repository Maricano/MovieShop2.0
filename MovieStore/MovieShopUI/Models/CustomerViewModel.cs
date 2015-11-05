using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieShopUI.Models
{
    public class CustomerViewModel
    {
        public MovieShopDAL.Customer Customer { get; set; }
        public List<MovieShopDAL.Orders> OrderList { get; set; }

    }
}