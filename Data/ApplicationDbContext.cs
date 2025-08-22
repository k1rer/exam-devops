using ExamAspNet_WebMarket.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExamAspNet_WebMarket.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; } 
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Location> Locations { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>()
                        .HasIndex(e => e.Email)
                        .IsUnique();

            modelBuilder.Entity<User>()
                        .HasIndex(p => p.Phone)
                        .IsUnique();

            modelBuilder.Entity<User>()
                        .Property(u => u.CreatedAt)
                        .HasDefaultValueSql("GETDATE()");


            modelBuilder.Entity<Product>()
                        .Property(u => u.CreatedAt)
                        .HasDefaultValueSql("GETDATE()");


            modelBuilder.Entity<Review>()
                        .HasOne(r => r.Author)
                        .WithMany()
                        .HasForeignKey(r => r.AuthorId)
                        .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Review>()
                        .HasOne(r => r.UserTarget)
                        .WithMany()
                        .HasForeignKey(r => r.UserTargetId)
                        .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Review>()
                        .Property(u => u.CreatedAt)
                        .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Review>()
                        .HasOne(r => r.UserTarget)
                        .WithMany(u => u.Reviews)
                        .HasForeignKey(r => r.UserTargetId)
                        .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Location>()
                        .Property(u => u.CreatedAt)
                        .HasDefaultValueSql("GETDATE()");



            //modelBuilder.Entity<User>()
            //            .Property(n => n.Name)
            //            .HasMaxLength(64);

            //modelBuilder.Entity<User>()
            //            .Property(l => l.LastName)
            //            .HasMaxLength(64);

            //modelBuilder.Entity<User>()
            //            .Property(e => e.Email)
            //            .HasMaxLength(128);

            //modelBuilder.Entity<User>()
            //            .Property(p => p.Phone)
            //            .HasMaxLength(15);

            //modelBuilder.Entity<User>()
            //            .Property(p => p.Password)
            //            .HasMaxLength(64);

            //modelBuilder.Entity<Product>()
            //            .Property(p => p.Name)
            //            .HasMaxLength(64);

            //modelBuilder.Entity<Product>()
            //            .Property(p => p.Price)
            //            .HasPrecision(10, 2);


        }
    }
}
