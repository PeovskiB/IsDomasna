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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //// Configure the Ticket entity
            //modelBuilder.Entity<Ticket>()
            //    .ToTable("Tickets"); // Update table name if needed
        }
    }
}
