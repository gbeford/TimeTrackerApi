using System;
using Microsoft.EntityFrameworkCore;




namespace TimeTrackerAPI.Models
{
    public class TimeTrackerDbContext : DbContext
    {
        public TimeTrackerDbContext(DbContextOptions<TimeTrackerDbContext> options)
           : base(options)
        { }

        public DbSet<Student> Students { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Message> Messages { get; set; }
       // public DbSet<User> Users { get; set; }
        public DbSet<StudentTime> StudentTimes { get; set; }
        public DbSet<AppUser> LoginUsers { get; set; }
        public DbSet<AppUserClaim> ClaimTypes { get; set; }
        public DbSet<Apparel> Apparels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentTime>()
                        .Property(p => p.TotalHrs)
                        .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<StudentMessage>()
                .HasKey(t => new { t.StudentId, t.MessageId });

            modelBuilder.Entity<StudentMessage>()
                .HasOne(sm => sm.Student)
                .WithMany(m => m.StudentMessages);

            modelBuilder.Entity<StudentMessage>()
                .HasOne(sm => sm.Message)
                .WithMany(m => m.StudentMessages);
        }

    }

}
