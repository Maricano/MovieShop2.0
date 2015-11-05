using MovieShopDAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieShopDAL.Repository
{
    interface IManyToMany
    {
        void AddManytoMany(int Id1,int Id2);
        void DeleteManyToMany(int Id1, int Id2);
    }
}
