using APIJWT.ViewModel;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIJWT.Model
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<ProductsModel> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Gender> Genders { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Clothes" }
                );
            builder.Entity<Category>().HasData(
               new Category { Id = 2, Name = "Electronics" }
               );
            builder.Entity<Gender>().HasData(
               new Category { Id = 1, Name = "Male" }
               );
            builder.Entity<Gender>().HasData(
               new Category { Id = 2, Name = "Female" }
               );
            //builder.Entity<ProductsModel>().HasOne(a => a.Categories).WithMany(p => p.Products).OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(builder);

        }
    }
}
