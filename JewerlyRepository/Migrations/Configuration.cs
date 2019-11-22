namespace JewerlyRepository.Migrations
{
    using JewerlyRepository.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<JewerlyRepository.JewStoreContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(JewerlyRepository.JewStoreContext context)
        {
            //uncomment lines bellow for Initial Create Migration

            //List<Product> products = new List<Product>
            //    {
            //        new Product { Name = "Ring with two gems",Type="Ring",Price=100 },
            //        new Product { Name = "Earrings with one gem",Type="Earrings",Price=120 },
            //        new Product { Name = "Ring with three gems",Type="Ring",Price=150 },
            //        new Product { Name = "Bracelet, no gems",Type="Bracelet",Price=80  },
            //        new Product { Name = "Earrings with ten gems",Type="Earrings",Price=320 },
            //    };
            //foreach (var item in products)
            //{
            //    context.Products.Add(item);
            //}
            //context.SaveChanges();
        }
    }
}
