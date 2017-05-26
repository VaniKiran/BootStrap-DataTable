namespace BootStrap_DataTable.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BootStrap_DataTable.Models.AppContext>
    {
        public Configuration()
        {
            //AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BootStrap_DataTable.Models.AppContext context)
        {
            //  This method will be called after migrating to the latest version.

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
            var employees = new List<Employee>
            {
                new Employee { FirstName="Stacey",LastName="K", AddressLineOne="12345 Hartwick", City="Boston", State="MA", Email="StaceyK@nothing.com", ContactNumber="1234567890", Zip="12345" },
                new Employee { FirstName="Julie",LastName="R", AddressLineOne="34567 Green Rd", City="Troy", State="MI", Email="JulieR@none.com", ContactNumber="0123456789", Zip="34567" },
                new Employee { FirstName="Amelia",LastName="P", AddressLineOne="01289 Farmington", City="Quincy", State="AL", Email="AmeliaP@nothing.com", ContactNumber="7834567890", Zip="45345" }
            };
            employees.ForEach(a => context.Employees.AddOrUpdate(a));
            // update database
           // context.SaveChanges();
        }
    }
}
