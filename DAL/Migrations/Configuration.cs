namespace DAL.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.SwiftSaleContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DAL.SwiftSaleContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            /*Random random = new Random();
           try
           {
               for (int i = 1; i < 11; i++)
               {
                   context.Sellers.AddOrUpdate(new Models.SignUp.Seller
                   {
                       Id = i,
                       Seller_Name = "User-" + i,
                       Shop_Name = Guid.NewGuid().ToString().Substring(0, 10),
                       Seller_Address = "Address-" + i,
                       Seller_Email = "Email-" + i,
                       Seller_JoinDate = DateTime.Now,
                       Seller_Password = Guid.NewGuid().ToString().Substring(0, 8),
                       Seller_Phone = "0178342845" + i,
                       Seller_Picture = Guid.NewGuid().ToString().Substring(0, 15)
                   });
               }
           }
           catch (Exception ex)
           {
               // Handle the exception here
               if (ex.InnerException != null)
               {
                   Console.WriteLine("Inner exception: " + ex.InnerException.Message);
               }
           }
           try
           {
               for (int i = 1; i < 6; i++)
               {
                   context.Categories.AddOrUpdate(new Models.Category
                   {
                       Id = i,
                       Category_Name = "Category-" + i
                   });
               }
           }
           catch (Exception ex)
           {
               // Handle the exception here
               if (ex.InnerException != null)
               {
                   Console.WriteLine("Inner exception: " + ex.InnerException.Message);
               }
           }

           try
           {
               for (int i = 1; i < 51; i++)
               {
                   context.Products.AddOrUpdate(new Models.Product
                   {
                       Id = i,
                       Name = Guid.NewGuid().ToString().Substring(0, 5),
                       Description = Guid.NewGuid().ToString().Substring(0, 20),
                       Price = "500" + i,
                       Image = Guid.NewGuid().ToString().Substring(0, 15),
                       C_Id = random.Next(1, 5),
                       SellBy = random.Next(1, 10)

                   });
               }
           }
           catch (Exception ex)
           {
               // Handle the exception here
               if (ex.InnerException != null)
               {
                   Console.WriteLine("Inner exception: " + ex.InnerException.Message);
               }
           }*/
        }
    }
}
