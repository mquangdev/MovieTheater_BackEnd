using Core.Entities;
using Infrastructure.Data.FluentAPI;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class MovieTheaterContext : DbContext
    {
        public MovieTheaterContext()
        {
            
        }
        public MovieTheaterContext(DbContextOptions<MovieTheaterContext> options) : base(options) { }
        // DbSet properties for each entity
        public DbSet<Account> Accounts { get; set; }
        public DbSet<CinemaRoom> CinemaRooms { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieShowDate> MovieShowDates { get; set; }
        public DbSet<MovieType> MovieTypes { get; set; }
        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<ScheduleSeat> ScheduleSeats { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<ShowDate> ShowDates { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<TypeEntity> Types { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Config.ApplyConfigurations(modelBuilder);
            base.OnModelCreating(modelBuilder);
            DatabaseSeeder.Seed(modelBuilder);
        }
    }
}