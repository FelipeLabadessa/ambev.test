using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Users.UpdateUser
{
    public class UpdateUserResponse
    {
        public Guid Id { get; set; }
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public UserRole Role { get; set; }
        public UserStatus Status { get; set; }
    }
}
