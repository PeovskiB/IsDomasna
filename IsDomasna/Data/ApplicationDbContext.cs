using IsDomasna.Models;
using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using IsDomasna.Models; // Update with the appropriate namespace for your models
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace IsDomasna.Data
{
    public class ApplicationDbContext : IdentityDbContext<CinemaUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Ticket> Tickets { get; set; } // Add DbSet for Ticket model
        public virtual DbSet<ShoppingCart> Carts { get; set; }
        public virtual DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            ////// Configure the Ticket entity
            //modelBuilder.Entity<Ticket>()
            //    .ToTable("Tickets"); // Update table name if needed

            modelBuilder.Entity<CinemaUser>()
                .HasOne(u => u.ShoppingCart)
                .WithOne(c => c.Owner)
                .HasForeignKey<ShoppingCart>(c => c.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ShoppingCartItem>()
                .HasKey(i => new { i.ShoppingCartItemId, i.ShoppingCartId, i.TicketId });

            modelBuilder.Entity<ShoppingCartItem>()
                .HasOne(i => i.ShoppingCart)
                .WithMany(c => c.ShoppingCartItems)
                .HasForeignKey(i => i.ShoppingCartId);

            modelBuilder.Entity<ShoppingCartItem>()
                .HasOne(i => i.Ticket)
                .WithMany(t => t.ShoppingCartItems)
                .HasForeignKey(i => i.TicketId);

            modelBuilder.Entity<OrderItem>()
               .HasKey(i => new { i.OrderItemId, i.OrderId, i.TicketId });

            modelBuilder.Entity<OrderItem>()
                .HasOne(i => i.Order)
                .WithMany(o => o.OrderItems)
                .HasForeignKey(i => i.OrderId);

            modelBuilder.Entity<OrderItem>()
                .HasOne(i => i.Ticket)
                .WithMany()
                .HasForeignKey(i => i.TicketId);

        }
    }

}
