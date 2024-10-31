using Core.Contants;
using Core.Entities;
using Core.Enums;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public static class DatabaseSeeder
    {
       
        public static void Seed(ModelBuilder modelBuilder)
        {
            #region Create roles
            var adminRole = new Role { Id = RoleContants.adminId, RoleName = "Admin" };
            var employeeRole = new Role { Id = RoleContants.employeeId, RoleName = "Employee" };
            var memberRole = new Role { Id = RoleContants.memberId, RoleName = "Member" };

            modelBuilder.Entity<Role>().HasData(adminRole, employeeRole, memberRole);
            #endregion

            #region Create accounts
            var adminAccount = new Account
            {
                Id = Guid.NewGuid(),
                FullName = "Admin User",
                Username = "admin",
                Email = "admin@example.com",
                Password = "admin123",
                RoleId = adminRole.Id,
                RegisterDate = DateTime.Now,
                InsertedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            var employeeAccount = new Account
            {
                Id = Guid.NewGuid(),
                FullName = "Employee User",
                Username = "employee",
                Email = "employee@example.com",
                Password = "employee123",
                RoleId = employeeRole.Id,
                RegisterDate = DateTime.Now,
                InsertedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            var memberAccount = new Account
            {
                Id = Guid.NewGuid(),
                FullName = "Member User",
                Username = "member",
                Email = "member@example.com",
                Password = "member123",
                RoleId = memberRole.Id,
                RegisterDate = DateTime.Now,
                InsertedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            modelBuilder.Entity<Account>().HasData(adminAccount, employeeAccount, memberAccount);
            #endregion

            #region Create Employee
            var employee1 = new Employee
            {
                Id = Guid.NewGuid(),
                AccountId = employeeAccount.Id,
                InsertedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            modelBuilder.Entity<Employee>().HasData(employee1);
            #endregion

            #region Create members
            var member1 = new Member
            {
                Id = Guid.NewGuid(),
                Score = 100,
                AccountId = memberAccount.Id,
                InsertedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            modelBuilder.Entity<Member>().HasData(member1);
            #endregion

            #region Create cinema rooms
            var cinemaRoom1 = new CinemaRoom
            {
                Id = Guid.NewGuid(),
                Name = "Room 1",
                SeatQuantity = 30, // Updated to 30 seats
                InsertedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            var cinemaRoom2 = new CinemaRoom
            {
                Id = Guid.NewGuid(),
                Name = "Room 2",
                SeatQuantity = 25, // Updated to 25 seats
                InsertedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            modelBuilder.Entity<CinemaRoom>().HasData(cinemaRoom1, cinemaRoom2);
            #endregion

            #region Create movies
            var movie1 = new Movie
            {
                Id = Guid.NewGuid(),
                Actor = "Actor 1",
                Director = "Director 1",
                Content = "Action packed movie.",
                Duration = TimeSpan.FromMinutes(120),
                FromDate = DateTime.Now.AddMonths(-1),
                ToDate = DateTime.Now.AddMonths(2),
                MovieNameEnglish = "Action Movie",
                MovieNameVN = "Phim Hành Động",
                LargeImage = "path/to/large/image1.jpg",
                SmallImage = "path/to/small/image1.jpg",
                InsertedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            var movie2 = new Movie
            {
                Id = Guid.NewGuid(),
                Actor = "Actor 2",
                Director = "Director 2",
                Content = "Romantic movie.",
                Duration = TimeSpan.FromMinutes(90),
                FromDate = DateTime.Now.AddMonths(-1),
                ToDate = DateTime.Now.AddMonths(1),
                MovieNameEnglish = "Romantic Movie",
                MovieNameVN = "Phim Tình Cảm",
                LargeImage = "path/to/large/image2.jpg",
                SmallImage = "path/to/small/image2.jpg",
                InsertedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            modelBuilder.Entity<Movie>().HasData(movie1, movie2);
            #endregion

            #region Create seats
            // Create seats for cinemaRoom1 (30 seats)
            for (int row = 1; row <= 5; row++) // Assuming 5 rows
            {
                for (char col = 'A'; col <= 'E'; col++) // Assuming 6 columns A to F
                {
                    if (row == 5 && col > 'C') break; // Limit to 30 seats
                    var seat = new Seat
                    {
                        Id = Guid.NewGuid(),
                        CinemaRoomId = cinemaRoom1.Id,
                        SeatRow = row,
                        SeatColumn = col.ToString(),
                        SeatStatus = (int)SeatStatus.Available, // Available
                        SeatType = (int)SeatType.Regular, // Regular
                        InsertedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    };

                    modelBuilder.Entity<Seat>().HasData(seat);
                }
            }

            // Create seats for cinemaRoom2 (25 seats)
            for (int row = 1; row <= 5; row++) // Assuming 5 rows
            {
                for (char col = 'A'; col <= 'E'; col++) // Assuming 5 columns A to E
                {
                    if (row == 5 && col > 'B') break; // Limit to 25 seats
                    var seat = new Seat
                    {
                        Id = Guid.NewGuid(),
                        CinemaRoomId = cinemaRoom2.Id,
                        SeatRow = row,
                        SeatColumn = col.ToString(),
                        SeatStatus = (int)SeatStatus.Available, // Available
                        SeatType = (int)SeatType.Regular, // Regular
                        InsertedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    };

                    modelBuilder.Entity<Seat>().HasData(seat);
                }
            }
            #endregion

            #region Create schedules
            var schedules = new List<Schedule>
            {
                new Schedule { Id = Guid.NewGuid(), ScheduleTime = TimeSpan.FromHours(8), InsertedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Schedule { Id = Guid.NewGuid(), ScheduleTime = TimeSpan.FromHours(9), InsertedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Schedule { Id = Guid.NewGuid(), ScheduleTime = TimeSpan.FromHours(10), InsertedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Schedule { Id = Guid.NewGuid(), ScheduleTime = TimeSpan.FromHours(11), InsertedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Schedule { Id = Guid.NewGuid(), ScheduleTime = TimeSpan.FromHours(12), InsertedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Schedule { Id = Guid.NewGuid(), ScheduleTime = TimeSpan.FromHours(13), InsertedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Schedule { Id = Guid.NewGuid(), ScheduleTime = TimeSpan.FromHours(14), InsertedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Schedule { Id = Guid.NewGuid(), ScheduleTime = TimeSpan.FromHours(15), InsertedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Schedule { Id = Guid.NewGuid(), ScheduleTime = TimeSpan.FromHours(16), InsertedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Schedule { Id = Guid.NewGuid(), ScheduleTime = TimeSpan.FromHours(17), InsertedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Schedule { Id = Guid.NewGuid(), ScheduleTime = TimeSpan.FromHours(18), InsertedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Schedule { Id = Guid.NewGuid(), ScheduleTime = TimeSpan.FromHours(19), InsertedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Schedule { Id = Guid.NewGuid(), ScheduleTime = TimeSpan.FromHours(20), InsertedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Schedule { Id = Guid.NewGuid(), ScheduleTime = TimeSpan.FromHours(21), InsertedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Schedule { Id = Guid.NewGuid(), ScheduleTime = TimeSpan.FromHours(22), InsertedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Schedule { Id = Guid.NewGuid(), ScheduleTime = TimeSpan.FromHours(23), InsertedAt = DateTime.Now, UpdatedAt = DateTime.Now }
            };

            // Seed the schedules
            modelBuilder.Entity<Schedule>().HasData(schedules);
            #endregion

            #region Create movie schedules
            var movieSchedule1 = new MovieSchedule
            {
                Id = Guid.NewGuid(),
                MovieId = movie1.Id,
                ScheduleId = schedules[0].Id,
                InsertedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            modelBuilder.Entity<MovieSchedule>().HasData(movieSchedule1);
            #endregion

            #region Create show dates
            var showDate1 = new ShowDate
            {
                Id = Guid.NewGuid(),
                DateShow = DateTime.Now.AddDays(1), // Tomorrow
                DateName = "Tomorrow",
                InsertedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            modelBuilder.Entity<ShowDate>().HasData(showDate1);
            #endregion

            #region Create movie show dates
            var movieShowDate1 = new MovieShowDate
            {
                Id = Guid.NewGuid(),
                MovieId = movie1.Id,
                ShowDateId = showDate1.Id,
                InsertedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            modelBuilder.Entity<MovieShowDate>().HasData(movieShowDate1);
            #endregion

            #region Create promotions
            var promotion1 = new Promotion
            {
                Id = Guid.NewGuid(),
                Title = "New Year Discount",
                Detail = "Get 20% off for all tickets.",
                DiscountLevel = 20,
                Image = "path/to/promotion/image.jpg",
                StartTime = DateTime.Now,
                EndTime = DateTime.Now.AddDays(30), // Active for 30 days
                InsertedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            modelBuilder.Entity<Promotion>().HasData(promotion1);
            #endregion

            #region Create invoices
            var invoice1 = new Invoice
            {
                Id = Guid.NewGuid(),
                AddScore = 10,
                BookingDate = DateTime.Now,
                MovieName = "Action Movie",
                ScheduleShow = DateOnly.FromDateTime(DateTime.Now.AddDays(1)), // Show tomorrow
                ScheduleShowTime = "18:00",
                Status = 1, // Paid
                TotalMoney = 150.00m,
                UseScore = 0,
                Seat = "1A, 1B", // Booked seats
                AccountId = memberAccount.Id,
                InsertedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            modelBuilder.Entity<Invoice>().HasData(invoice1);
            #endregion

            #region Create tickets
            var ticket1 = new Ticket
            {
                Id = Guid.NewGuid(),
                Price = 75.00m, // Price per ticket
                TicketType = 0, // Regular
                InvoiceId = invoice1.Id,
                InsertedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            modelBuilder.Entity<Ticket>().HasData(ticket1);
            #endregion

            #region Create types
            var type1 = new TypeEntity
            {
                Id = Guid.NewGuid(),
                Name = "Action",
                InsertedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            var type2 = new TypeEntity
            {
                Id = Guid.NewGuid(),
                Name = "Romantic",
                InsertedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            modelBuilder.Entity<TypeEntity>().HasData(type1, type2);
            #endregion

            #region Create movie types
            var movieType1 = new MovieType
            {
                Id = Guid.NewGuid(),
                MovieId = movie1.Id,
                TypeId = type1.Id,
                InsertedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            var movieType2 = new MovieType
            {
                Id = Guid.NewGuid(),
                MovieId = movie2.Id,
                TypeId = type2.Id,
                InsertedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            modelBuilder.Entity<MovieType>().HasData(movieType1, movieType2);
            #endregion
        }
    }
}