using Core.Entities;
using Infrastructure.Data;

namespace Infrastructure.DAO.Interfaces
{
    public interface IUnitOfWork
    {
        public MovieTheaterContext DbContext { get; }
        public Task<int> SaveChangesAsync();
        public IGenericDao<Account> AccountDao { get; }
        public IGenericDao<CinemaRoom> CinemaRoomDao { get; }
        public IGenericDao<Employee> EmployeeDao { get; }
        public IGenericDao<Invoice> InvoiceDao { get; }
        public IGenericDao<Member> MemberDao { get; }
        public IGenericDao<MovieSchedule> MovieScheduleDao { get; }
        public IGenericDao<MovieShowDate> MovieShowDateDao { get; }
        public IGenericDao<MovieType> MovieTypeDao { get; }
        public IGenericDao<Promotion> PromotionDao { get; }
        public IGenericDao<Role> RoleDao { get; }
        public IGenericDao<Schedule> ScheduleDao { get; }
        public IGenericDao<ScheduleSeat> ScheduleSeatDao { get; }
        public IGenericDao<Seat> SeatDao { get; }
        public IGenericDao<ShowDate> ShowDateDao { get; }
        public IGenericDao<Ticket> TicketDao { get; }
        public IGenericDao<TypeEntity> TypeDao { get; }
    }
}