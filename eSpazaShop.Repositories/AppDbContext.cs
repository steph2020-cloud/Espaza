using eSpazaShop.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace eSpazaShop.Repositories
{
    public class AppDbContext : IdentityDbContext<User, Role,int>
    {
        //Needed for migration purposes/development
        public AppDbContext()
        {

        }
        /// <summary>
        /// Perform IOC int constructor 
        /// </summary>
        /// below code is need for production code and will call the connection string in the app json file
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }

        //access to the database tables 
        public DbSet<Category>Categories { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<ItemType> ItemTypes { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<PaymentDetails> PaymentDetails { get; set; }

        //create a connection string
        //this connection is needed for migration purposes
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
    
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"data source=(localdb)\MSSQLLocalDB; initial catalog=eSpazaShop;persist security info=True;user id=sa;password=live0741954628;",
                        builder => builder.EnableRetryOnFailure());
            }
            base.OnConfiguring(optionsBuilder);
        }
    }

}
