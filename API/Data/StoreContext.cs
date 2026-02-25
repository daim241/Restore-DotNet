using System;
using API.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class StoreContext(DbContextOptions options) : IdentityDbContext<User>(options)
{
     public required DbSet<Product> Products { get; set; }
     public required DbSet<Basket> Baskets { get; set; }

     protected override void OnModelCreating(ModelBuilder builder)
     {
          base.OnModelCreating(builder);

          builder.Entity<IdentityRole>()
             .HasData(
            new IdentityRole { Id = "58ec3e36-f60d-4806-9df5-4c81bf388c29", ConcurrencyStamp = "Member", Name = "Member", NormalizedName = "MEMBER" },
            new IdentityRole { Id = "c7aaf19c-0a61-4ea4-87fe-3785ae4e0df4", ConcurrencyStamp = "Admin", Name = "Admin", NormalizedName = "ADMIN" }
          );
     }
}
