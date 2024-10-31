using Core.Contants;
using Core.Entities;
using Infrastructure.DAO.Interfaces;
using MediatR;

namespace Application.Handler.Auth.Commands.Register
{
    public class RegisterCommandHandler : BaseHandler, IRequestHandler<RegisterCommand, Account>
    {
        public RegisterCommandHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<Account> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            // Check username and password duplicate
            var accountExistWithSameUsername = UnitOfWork.AccountDao.GetQuery(x => x.Username == request.Username);
            if(accountExistWithSameUsername is not null)
            {
                throw new Exception("Username is existed");
            }

            var accountExistWithSameEmail = UnitOfWork.AccountDao.GetQuery(x => x.Email == request.Email);
            if (accountExistWithSameEmail is not null)
            {
                throw new Exception("Email is existed");
            }
            var newAccount = new Account
            {
                Address = request.Address,
                DateOfBirth = request.DateOfBirth,
                Email = request.Email,
                FullName = request.FullName,
                Gender = request.Gender,
                IdentityCard = request.IdentityCard,
                Password = request.Password,
                PhoneNumber = request.PhoneNumber,
                RegisterDate = DateTime.Now,
                Username = request.Username,
                RoleId = RoleContants.memberId,
            };
            var result = UnitOfWork.AccountDao.Add(newAccount);
            await UnitOfWork.SaveChangesAsync();
            return result;
        }
    }
}