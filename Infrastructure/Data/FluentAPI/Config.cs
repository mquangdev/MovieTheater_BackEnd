using Core.Entities;
using Core.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection;

namespace Infrastructure.Data.FluentAPI
{
    public class Config
    {
       public static void ConfigInsertedByAndUpdatedBy<T>(EntityTypeBuilder<T> builder) where T : BaseEntity
        {
            builder.HasOne(x => x.InsertedBy)
                .WithMany()
                .HasForeignKey(x => x.InsertedById)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.InsertedBy)
               .WithMany()
               .HasForeignKey(x => x.InsertedById)
               .OnDelete(DeleteBehavior.Restrict);
        }
        public static void ApplyConfigurations(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<CustomAttributeData>();

            // Account - Role (One-to-Many)
            modelBuilder.Entity<Account>(
                builder =>
                {
                    builder.HasOne(a => a.Role)
                    .WithMany(r => r.Accounts)
                    .HasForeignKey(a => a.RoleId);

                    ConfigInsertedByAndUpdatedBy(builder);
                });


            // Employee - Account (One-to-One)
            modelBuilder.Entity<Employee>(
                builder =>
                {
                    builder.HasOne(e => e.Account)
                    .WithOne()
                    .HasForeignKey<Employee>(e => e.AccountId);

                    ConfigInsertedByAndUpdatedBy(builder);
                });


            // Member - Account (One-to-One)
            modelBuilder.Entity<Member>(
                builder =>
                {
                    builder.HasOne(m => m.Account)
                    .WithOne()
                    .HasForeignKey<Member>(m => m.AccountId);

                    ConfigInsertedByAndUpdatedBy(builder);
                });


            // CinemaRoom - Movie (One-to-Many)
            modelBuilder.Entity<CinemaRoom>(
                builder =>
                {
                    builder.HasOne(cr => cr.CurrentMovie)
                    .WithMany(m => m.CinemaRooms)
                    .HasForeignKey(cr => cr.CurrentMovieId)
                    .OnDelete(DeleteBehavior.Restrict);

                    ConfigInsertedByAndUpdatedBy(builder);
                });


            // CinemaRoom - Seat (One-to-Many)
            modelBuilder.Entity<Seat>(
                builder =>
                {
                    builder.HasOne(s => s.CinemaRoom)
                    .WithMany(cr => cr.Seats)
                    .HasForeignKey(s => s.CinemaRoomId)
                    .OnDelete(DeleteBehavior.Cascade);

                    ConfigInsertedByAndUpdatedBy(builder);
                });


            // Invoice - Account (One-to-Many)
            modelBuilder.Entity<Invoice>(
                builder =>
                {
                    builder.HasOne(i => i.Account)
                    .WithMany(a => a.Invoices)
                    .HasForeignKey(i => i.AccountId);

                    ConfigInsertedByAndUpdatedBy(builder);
                });


            // Invoice - Ticket (One-to-Many)
            modelBuilder.Entity<Ticket>(builder =>
            {
                builder.HasOne(t => t.Invoice)
                       .WithMany(i => i.Tickets)
                       .HasForeignKey(t => t.InvoiceId)
                       .OnDelete(DeleteBehavior.Cascade);

                ConfigInsertedByAndUpdatedBy(builder);
            });

            // Movie - ShowDate (Many-to-Many via Join Entity MovieShowDate)
            modelBuilder.Entity<MovieShowDate>(builder =>
            {
                builder.HasOne(mt => mt.Movie)
                       .WithMany(m => m.MovieShowDates)
                       .HasForeignKey(mt => mt.MovieId);

                builder.HasOne(mt => mt.ShowDate)
                       .WithMany(sd => sd.MovieShowDates)
                       .HasForeignKey(mt => mt.ShowDateId);

                ConfigInsertedByAndUpdatedBy(builder);
            });

            // Movie - Type (Many-to-Many via Join Entity MovieType)
            modelBuilder.Entity<MovieType>(builder =>
            {
                builder.HasOne(mt => mt.Movie)
                       .WithMany(m => m.MovieTypes)
                       .HasForeignKey(mt => mt.MovieId);

                builder.HasOne(mt => mt.TypeEntity)
                       .WithMany(t => t.MovieTypes)
                       .HasForeignKey(mt => mt.TypeId);

                ConfigInsertedByAndUpdatedBy(builder);
            });

            // Movie - Schedule (Many-to-Many via Join Entity MovieSchedule)
            modelBuilder.Entity<MovieSchedule>(builder =>
            {
                builder.HasOne(ms => ms.Movie)
                       .WithMany(m => m.MovieSchedules)
                       .HasForeignKey(ms => ms.MovieId);

                builder.HasOne(ms => ms.Schedule)
                       .WithMany(s => s.MovieSchedules)
                       .HasForeignKey(ms => ms.ScheduleId);

                ConfigInsertedByAndUpdatedBy(builder);
            });

            // Schedule - ScheduleSeat (One-to-Many)
            modelBuilder.Entity<ScheduleSeat>(builder =>
            {
                builder.HasOne(ss => ss.Schedule)
                       .WithMany(s => s.ScheduleSeats)
                       .HasForeignKey(ss => ss.ScheduleId)
                       .OnDelete(DeleteBehavior.Cascade);

                ConfigInsertedByAndUpdatedBy(builder);
            });

            // Movie - ScheduleSeat (One-to-Many)
            modelBuilder.Entity<ScheduleSeat>(builder =>
            {
                builder.HasOne(ss => ss.Movie)
                       .WithMany(m => m.ScheduleSeats)
                       .HasForeignKey(ss => ss.MovieId);

                ConfigInsertedByAndUpdatedBy(builder);
            });

            // Seat - ScheduleSeat (One-to-Many)
            modelBuilder.Entity<ScheduleSeat>(builder =>
            {
                builder.HasOne(ss => ss.Seat)
                       .WithMany(s => s.ScheduleSeats)
                       .HasForeignKey(ss => ss.SeatId)
                       .OnDelete(DeleteBehavior.Cascade);

                ConfigInsertedByAndUpdatedBy(builder);
            });

            // Movie - Type (Many-to-Many via Join Entity MovieType)
            modelBuilder.Entity<MovieType>(builder =>
            {
                builder.HasOne(mt => mt.Movie)
                       .WithMany(m => m.MovieTypes)
                       .HasForeignKey(mt => mt.MovieId);

                builder.HasOne(mt => mt.TypeEntity)
                       .WithMany(sd => sd.MovieTypes)
                       .HasForeignKey(mt => mt.TypeId);

                ConfigInsertedByAndUpdatedBy(builder);
            });
        }
    }
}