using Ambev.DeveloperEvaluation.Domain.Enums;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Users.UpdateUser
{
    public class UpdateUserCommand : IRequest<UpdateUserResult>
    {
        public Guid Id { get; set; }
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Password { get; set; } = null!;
        public UserRole Role { get; set; }
        public UserStatus Status { get; set; }

        public UpdateUserCommand(Guid id, string username, string email, string phone, string password, UserRole role, UserStatus status)
        {
            Id = id;
            Username = username;
            Email = email;
            Phone = phone;
            Password = password;
            Role = role;
            Status = status;
        }

        public UpdateUserCommand() { }
    }
}
