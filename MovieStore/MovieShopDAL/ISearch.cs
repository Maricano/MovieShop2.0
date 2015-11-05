using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieShopDAL
{
    public interface ISearch<Entity>
    {
        Entity search(string value);
    }
}
