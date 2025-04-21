using Ambev.DeveloperEvaluation.Common.Security;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Users.UpdateUser
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, UpdateUserResult>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;

        public UpdateUserHandler(IUserRepository userRepository, IPasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
        }

        public async Task<UpdateUserResult> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
        {
            var validator = new UpdateUserCommandValidator();
            var validationResult = await validator.ValidateAsync(command, cancellationToken);
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var existingUser = await _userRepository.GetByIdAsync(command.Id, cancellationToken);
            if (existingUser == null)
                throw new KeyNotFoundException("User not found");

            existingUser.Username = command.Username;
            existingUser.Email = command.Email;
            existingUser.Phone = command.Phone;
            existingUser.Password = _passwordHasher.HashPassword(command.Password);
            existingUser.Role = command.Role;
            existingUser.Status = command.Status;
            existingUser.UpdatedAt = DateTime.UtcNow;

            await _userRepository.UpdateAsync(existingUser, cancellationToken);

            return new UpdateUserResult
            {
                Id = existingUser.Id,
                Username = existingUser.Username,
                Email = existingUser.Email,
                Phone = existingUser.Phone,
                Role = existingUser.Role,
                Status = existingUser.Status,
                UpdatedAt = existingUser.UpdatedAt
            };
        }
    }
}
