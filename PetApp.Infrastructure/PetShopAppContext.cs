using Microsoft.EntityFrameworkCore;
using petShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetApp.Infrastructure
{
    public class PetShopAppContext: DbContext
    {
        public PetShopAppContext(DbContextOptions<PetShopAppContext> opt): base(opt)
            {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pet>().
                            HasOne(o => o.PreviousOwner)
                            .WithMany( c=> c.pets)
                .OnDelete(DeleteBehavior.SetNull);
        }
        public DbSet<Owner> Owner { get; set; }
        public DbSet<Pet> Pet { get; set; }
    }
}
