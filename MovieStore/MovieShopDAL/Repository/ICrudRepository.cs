using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieShopDAL.Repository
{
    public interface ICrudRepository<Entity>
    {
        void Create(Entity Entity);
        Entity Read(int Id);
        List<Entity> ReadAll();
        void Update(Entity Entity);
        void Delete(int Id);
    }
}
