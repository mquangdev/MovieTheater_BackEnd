using Infrastructure.DAO.Interfaces;

namespace Application.Handler
{
    public class BaseHandler
    {
        protected readonly IUnitOfWork UnitOfWork;
        public BaseHandler(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
    }
}