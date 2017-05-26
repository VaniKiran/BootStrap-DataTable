using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BootStrap_DataTable.Models
{
    public class AppInitializer : System.Data.Entity.CreateDatabaseIfNotExists<AppContext>
    {
        protected override void Seed(AppContext context)
        {
            //var employees = new List<Employee>
            //{
            //    new Employee { FirstName="Stacey",LastName="K", AddressLineOne="12345 Hartwick", City="Boston", State="MA", Email="StaceyK@nothing.com", ContactNumber="1234567890", Zip="12345" },
            //    new Employee { FirstName="Julie",LastName="R", AddressLineOne="34567 Green Rd", City="Troy", State="MI", Email="JulieR@none.com", ContactNumber="0123456789", Zip="34567" },
            //    new Employee { FirstName="Amelia",LastName="P", AddressLineOne="01289 Farmington", City="Quincy", State="AL", Email="AmeliaP@nothing.com", ContactNumber="7834567890", Zip="45345" }
            //};
            //employees.ForEach(a => context.Employees.Add(a));
            //// update database
            //context.SaveChanges();
            base.Seed(context);
        }
    }
}