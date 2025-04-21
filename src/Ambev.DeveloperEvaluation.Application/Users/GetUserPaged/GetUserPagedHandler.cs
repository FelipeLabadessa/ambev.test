using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Users.GetUserPaged
{
    /// <summary>
    /// Handler for processing GetProductPagedPagedCommand requests.
    /// </summary>
    public class GetUserPagedHandler : IRequestHandler<GetUserPagedCommand, GetUserPagedResult>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of GetProductPagedHandler.
        /// </summary>
        /// <param name="productRepository">The product repository.</param>
        /// <param name="mapper">The AutoMapper instance.</param>
        public GetUserPagedHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Handles the GetProductPagedPagedCommand request.
        /// </summary>
        /// <param name="request">The GetProductPaged command.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>The product details if found.</returns>
        public async Task<GetUserPagedResult> Handle(GetUserPagedCommand request, CancellationToken cancellationToken)
        {
            var validator = new GetUserPagedValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid) throw new ValidationException(validationResult.Errors);

            var totalRecords = await _userRepository.GetTotalRecordsAsync();
            var products = await _userRepository.GetAllAsync(request.PageNumber, request.PageSize, cancellationToken);
            if (products == null) throw new KeyNotFoundException($"No users registered in the system yet.");

            var result = new GetUserPagedResult(request, totalRecords, products.ToList());
            return result;
        }
    }
}
