using JewerlyRepository.Migrations;
using JewerlyRepository.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewerlyRepository
{
    public class JewStoreContext : DbContext
    {
        public JewStoreContext() : base(@"Data Source =.\IPSQLSERVER; Initial Catalog = JewStore; Integrated Security = True")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<JewStoreContext, Configuration>());

            //doesnt work. Why?
            //Database.SetInitializer<JewStoreContext>(new InitialInitializer());
            Configuration.LazyLoadingEnabled = false;
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<JewType> JewTypes { get; set; }
    }
    // I tried use this class to initialize DB for Initial Create configuration, but it doesnt work
    public class InitialInitializer : DropCreateDatabaseIfModelChanges<JewStoreContext>
    {
        protected override void Seed(JewStoreContext context)
        {
            //List<Product> products = new List<Product>
            //{
            //    new Product { Name = "Ring with two gems",Type="Ring",Price=100 },
            //    new Product { Name = "Earrings with one gem",Type="Earrings",Price=120 },
            //    new Product { Name = "Ring with three gems",Type="Ring",Price=150 },
            //    new Product { Name = "Bracelet, no gems",Type="Bracelet",Price=80  },
            //    new Product { Name = "Earrings with ten gems",Type="Earrings",Price=320 },
            //};
            //foreach (var item in products)
            //{
            //    context.Products.Add(item);
            //}
            //context.SaveChanges();
            //base.Seed(context);
        }
    }
}
