using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using IsDomasna.IsDomasna.Domain.Models;

namespace IsDomasna.IsDomasna.Repository.Data
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
