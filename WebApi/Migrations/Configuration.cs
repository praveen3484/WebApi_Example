namespace WebApi.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models;

    internal sealed class Configuration : DbMigrationsConfiguration<WebApi.Models.CarContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WebApi.Models.CarContext context)
        {
            //  This method will be called after migrating to the latest version.
            context.CarStock.AddOrUpdate(
                p => p.Id,
                
                    new CarStock{ Id = 1, CarName = "Maruti", CarModel = "Swift DZire", CarColor = "White", CarPrice = 600000 },
                     new CarStock { Id = 2, CarName = "Ford", CarModel = "Figo", CarColor = "Apple Green", CarPrice = 800000 },
                     new CarStock { Id = 3, CarName = "Audi", CarModel = "Q7", CarColor = "Black", CarPrice = 2500000 },
                     new CarStock { Id = 4, CarName = "Audi", CarModel = "A3", CarColor = "White", CarPrice = 2000000 }

                
                );
            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
