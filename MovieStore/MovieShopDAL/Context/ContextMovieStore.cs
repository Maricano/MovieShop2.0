using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieShopDAL
{
    class ContextMovieStore : DbContext
    {
        private static string ConnectionString = "Server=.\\SQLExpress; Database=MovieStore; Trusted_Connection=Yes";
       


        public ContextMovieStore() : base(ConnectionString)
        {           
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }

        public System.Data.Entity.DbSet<MovieShopDAL.Movie> Movie { get; set; }
        public System.Data.Entity.DbSet<MovieShopDAL.Orders> Order { get; set; }
        public System.Data.Entity.DbSet<MovieShopDAL.Genres> Genre { get; set; }
        public System.Data.Entity.DbSet<MovieShopDAL.Customer> Customer { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public object Genres { get; internal set; }
        public object Orders { get; internal set; }
        public object Movies { get; internal set; }
        public object Customers { get; internal set; }
    }
}
