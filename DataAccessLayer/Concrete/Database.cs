using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Database : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder data)
        {
            data.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\yagiz\\Desktop\\DBs\\EcommerceApp.mdf;Integrated Security=True;Connect Timeout=30");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(entity =>
           entity.HasMany(p => p.comments).
           WithOne(p => p.user).HasForeignKey(p => p.UserId));
            
            modelBuilder.Entity<Product>(entity =>
           entity.HasMany(p => p.Comments).
           WithOne(p => p.Product).HasForeignKey(p => p.ProductId));

            //modelBuilder.Entity<Student>(entity =>
            //entity.HasMany(p => p.suchedules).
            //WithOne(p => p.Students).HasForeignKey(p => p.StudentId));

           




        }





        public DbSet<Comments> comments { get; set; }
        public DbSet<Orders> orders { get; set; }
        public DbSet<ProductBasket> productBaskets { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<ProductMan> productMen { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<OrderDetail> details { get; set; }



    }
}
