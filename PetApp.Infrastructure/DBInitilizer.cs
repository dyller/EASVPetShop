using System;
using System.Collections.Generic;
using System.Text;

namespace PetApp.Infrastructure
{
   public class DBInitilizer
    {
        public static void SeedDB(PetShopAppContext ctx)
        {
            ctx.Database.EnsureCreated();
            ctx.SaveChanges();

        }
    }
}
