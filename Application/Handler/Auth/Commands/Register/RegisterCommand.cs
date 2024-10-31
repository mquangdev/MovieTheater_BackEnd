using Core.Entities;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Application.Handler.Auth.Commands.Register
{
    public class RegisterCommand : IRequest<Account>
    {
        public string FullName { get; set; }
        public string Username { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string Password { get; set; }
        public string PhoneNumber { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        public string Address { get; set; }
        public string IdentityCard { get; set; }
        public string Gender { get; set; }
    }
}