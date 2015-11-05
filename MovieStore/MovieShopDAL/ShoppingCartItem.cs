using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MovieShopDAL;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieShopDAL
{
    public class ShoppingCartItem
    {        
        [Key, Column(Order = 0)]
        [ForeignKey("Movie")]
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        public int Quantity { get; set; }
        [Key, Column(Order = 1)]
        [ForeignKey("Orders")]
        public int OrdersId { get; set; }
        public virtual Orders Orders { get; set; }
    }
}