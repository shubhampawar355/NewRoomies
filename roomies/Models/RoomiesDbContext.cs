using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace roomies.Models
{
    public class RoomiesDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Filter> Filters { get; set; }
        public DbSet<UserRoom> UserRooms { get; set; }
        public RoomiesDbContext(DbContextOptions<RoomiesDbContext> options): base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRoom>().HasKey(c => new {c.UserId,c.RoomId });

            modelBuilder.Entity<User>().HasMany(u => u.Rooms).WithOne(r => r.Owner).IsRequired();

        }
    }
}
