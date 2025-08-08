using Microsoft.EntityFrameworkCore;
using SimpleHotelRoomManagementProject.Models;

namespace SimpleHotelRoomManagementProject
{
    public class HotelDbContext : DbContext
    {
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Review> Reviews { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=DESKTOP-4BE574Q;Database=HotelDB;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // ROOM
            modelBuilder.Entity<Room>(entity =>
            {
                entity.HasKey(r => r.RoomId);
                entity.Property(r => r.RoomNumber).IsRequired().HasMaxLength(10);
                entity.Property(r => r.Type).IsRequired().HasMaxLength(30);
                entity.Property(r => r.PricePerNight).HasColumnType("decimal(10,2)");
                entity.Property(r => r.IsAvailable).HasDefaultValue(true);
                entity.Property(r => r.Description).HasMaxLength(200);
            });

            // GUEST
            modelBuilder.Entity<Guest>(entity =>
            {
                entity.HasKey(g => g.GuestId);
                entity.Property(g => g.Name).IsRequired().HasMaxLength(50);
                entity.Property(g => g.Email).HasMaxLength(50);
                entity.Property(g => g.PhoneNumber).HasMaxLength(20);
                entity.Property(g => g.CheckInDate).IsRequired();
                entity.Property(g => g.CheckOutDate).IsRequired();
            });

            // BOOKING
            modelBuilder.Entity<Booking>(entity =>
            {
                entity.HasKey(b => b.BookingId);
                entity.Property(b => b.TotalAmount).HasColumnType("decimal(10,2)");
                entity.Property(b => b.Status).HasMaxLength(20);

                entity.HasOne<Guest>()
                    .WithMany()
                    .HasForeignKey(b => b.GuestId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne<Room>()
                    .WithMany()
                    .HasForeignKey(b => b.RoomId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // REVIEW
            modelBuilder.Entity<Review>(entity =>
            {
                entity.HasKey(r => r.ReviewId);
                entity.Property(r => r.ReviewerName).HasMaxLength(50);
                entity.Property(r => r.Comment).HasMaxLength(300);
                entity.Property(r => r.Rating).IsRequired();

                entity.HasOne<Guest>()
                    .WithMany()
                    .HasForeignKey(r => r.GuestId)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne<Room>()
                    .WithMany()
                    .HasForeignKey(r => r.RoomId)
                    .OnDelete(DeleteBehavior.SetNull);
            });
        }
    }
}
