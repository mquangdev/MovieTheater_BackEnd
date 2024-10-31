using Core.Entities;
using Infrastructure.DAO.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DAO.Implements
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MovieTheaterContext _dbContext;
        private readonly IUserIdentity _userIdentity;

        public MovieTheaterContext DbContext => _dbContext;

        public UnitOfWork(MovieTheaterContext dbContext, IUserIdentity userIdentity)
        {
            _dbContext = dbContext;
            _userIdentity = userIdentity;
        }

        private IGenericDao<Account> _accountDao;
        public IGenericDao<Account> AccountDao
        {
            get
            {
                if (_accountDao == null)
                {
                    _accountDao = new GenericDao<Account>(_dbContext, _userIdentity);
                }
                return _accountDao;
            }
        }

        private IGenericDao<CinemaRoom> _cinemaRoomDao;
        public IGenericDao<CinemaRoom> CinemaRoomDao
        {
            get
            {
                if (_cinemaRoomDao == null)
                {
                    _cinemaRoomDao = new GenericDao<CinemaRoom>(_dbContext, _userIdentity);
                }
                return _cinemaRoomDao;
            }
        }

        private IGenericDao<Employee> _employeeDao;
        public IGenericDao<Employee> EmployeeDao
        {
            get
            {
                if (_employeeDao == null)
                {
                    _employeeDao = new GenericDao<Employee>(_dbContext, _userIdentity);
                }
                return _employeeDao;
            }
        }

        private IGenericDao<Invoice> _invoiceDao;
        public IGenericDao<Invoice> InvoiceDao
        {
            get
            {
                if (_invoiceDao == null)
                {
                    _invoiceDao = new GenericDao<Invoice>(_dbContext, _userIdentity);
                }
                return _invoiceDao;
            }
        }

        private IGenericDao<Member> _memberDao;
        public IGenericDao<Member> MemberDao
        {
            get
            {
                if (_memberDao == null)
                {
                    _memberDao = new GenericDao<Member>(_dbContext, _userIdentity);
                }
                return _memberDao;
            }
        }

        private IGenericDao<MovieSchedule> _movieScheduleDao;
        public IGenericDao<MovieSchedule> MovieScheduleDao
        {
            get
            {
                if (_movieScheduleDao == null)
                {
                    _movieScheduleDao = new GenericDao<MovieSchedule>(_dbContext, _userIdentity);
                }
                return _movieScheduleDao;
            }
        }

        private IGenericDao<MovieShowDate> _movieShowDateDao;
        public IGenericDao<MovieShowDate> MovieShowDateDao
        {
            get
            {
                if (_movieShowDateDao == null)
                {
                    _movieShowDateDao = new GenericDao<MovieShowDate>(_dbContext, _userIdentity);
                }
                return _movieShowDateDao;
            }
        }

        private IGenericDao<MovieType> _movieTypeDao;
        public IGenericDao<MovieType> MovieTypeDao
        {
            get
            {
                if (_movieTypeDao == null)
                {
                    _movieTypeDao = new GenericDao<MovieType>(_dbContext, _userIdentity);
                }
                return _movieTypeDao;
            }
        }

        private IGenericDao<Promotion> _promotionDao;
        public IGenericDao<Promotion> PromotionDao
        {
            get
            {
                if (_promotionDao == null)
                {
                    _promotionDao = new GenericDao<Promotion>(_dbContext, _userIdentity);
                }
                return _promotionDao;
            }
        }

        private IGenericDao<Role> _roleDao;
        public IGenericDao<Role> RoleDao
        {
            get
            {
                if (_roleDao == null)
                {
                    _roleDao = new GenericDao<Role>(_dbContext, _userIdentity);
                }
                return _roleDao;
            }
        }

        private IGenericDao<Schedule> _scheduleDao;
        public IGenericDao<Schedule> ScheduleDao
        {
            get
            {
                if (_scheduleDao == null)
                {
                    _scheduleDao = new GenericDao<Schedule>(_dbContext, _userIdentity);
                }
                return _scheduleDao;
            }
        }

        private IGenericDao<ScheduleSeat> _scheduleSeatDao;
        public IGenericDao<ScheduleSeat> ScheduleSeatDao
        {
            get
            {
                if (_scheduleSeatDao == null)
                {
                    _scheduleSeatDao = new GenericDao<ScheduleSeat>(_dbContext, _userIdentity);
                }
                return _scheduleSeatDao;
            }
        }

        private IGenericDao<Seat> _seatDao;
        public IGenericDao<Seat> SeatDao
        {
            get
            {
                if (_seatDao == null)
                {
                    _seatDao = new GenericDao<Seat>(_dbContext, _userIdentity);
                }
                return _seatDao;
            }
        }

        private IGenericDao<ShowDate> _showDateDao;
        public IGenericDao<ShowDate> ShowDateDao
        {
            get
            {
                if (_showDateDao == null)
                {
                    _showDateDao = new GenericDao<ShowDate>(_dbContext, _userIdentity);
                }
                return _showDateDao;
            }
        }

        private IGenericDao<Ticket> _ticketDao;
        public IGenericDao<Ticket> TicketDao
        {
            get
            {
                if (_ticketDao == null)
                {
                    _ticketDao = new GenericDao<Ticket>(_dbContext, _userIdentity);
                }
                return _ticketDao;
            }
        }

        private IGenericDao<TypeEntity> _typeDao;
        public IGenericDao<TypeEntity> TypeDao
        {
            get
            {
                if (_typeDao == null)
                {
                    _typeDao = new GenericDao<TypeEntity>(_dbContext, _userIdentity);
                }
                return _typeDao;
            }
        }

        private IRefreshTokenDao _refreshTokenDao;

        public Task<int> SaveChangesAsync()
        {
            return _dbContext.SaveChangesAsync();
        }
    }

}