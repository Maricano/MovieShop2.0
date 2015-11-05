using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieShopDAL
{
    public class Orders
    {
        [Key]
        public int OrderId { get; set; }
        public DateTime OrderTime { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual List<ShoppingCartItem> ShoppingCartItems { get; set; }

    }
}
