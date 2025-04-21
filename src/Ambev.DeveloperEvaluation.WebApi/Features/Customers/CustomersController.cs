using Ambev.DeveloperEvaluation.Application.Customers.CreateCustomer;
using Ambev.DeveloperEvaluation.Application.Customers.DeleteCustomer;
using Ambev.DeveloperEvaluation.Application.Customers.GetAllCustomer;
using Ambev.DeveloperEvaluation.Application.Customers.GetCustomer;
using Ambev.DeveloperEvaluation.Application.Customers.UpdateCustomer;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.Customers.CreateCustomer;
using Ambev.DeveloperEvaluation.WebApi.Features.Customers.DeleteCustomer;
using Ambev.DeveloperEvaluation.WebApi.Features.Customers.GetAllCustomer;
using Ambev.DeveloperEvaluation.WebApi.Features.Customers.GetCustomer;
using Ambev.DeveloperEvaluation.WebApi.Features.Customers.UpdateCustomer;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Customers
{
    /// <summary>
    /// Controller for managing customer operations
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of CustomersController
        /// </summary>
        /// <param name="mediator">The mediator instance</param>
        /// <param name="mapper">The AutoMapper instance</param>
        public CustomersController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        /// <summary>
        /// Retrieves a customer by its ID
        /// </summary>
        /// <param name="id">The unique identifier of the customer</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The customer details if found</returns>
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,Manager")]
        [ProducesResponseType(typeof(ApiResponseWithData<GetCustomerResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCustomer([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var request = new GetCustomerRequest { Id = id };
            var validationResult = await new GetCustomerRequestValidator().ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var command = _mapper.Map<GetCustomerCommand>(request.Id);
            var response = await _mediator.Send(command, cancellationToken);

            return Ok(new ApiResponseWithData<GetCustomerResponse>
            {
                Success = true,
                Message = "Customer retrieved successfully",
                Data = _mapper.Map<GetCustomerResponse>(response)
            });
        }

        /// <summary>
        /// Creates a new customer
        /// </summary>
        /// <param name="request">The customer creation request</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The created customer details</returns>
        [HttpPost]
        [Authorize(Roles = "Admin,Manager")]
        [ProducesResponseType(typeof(ApiResponseWithData<CreateCustomerResponse>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerRequest request, CancellationToken cancellationToken)
        {
            var validationResult = await new CreateCustomerRequestValidator().ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var command = _mapper.Map<CreateCustomerCommand>(request);
            var response = await _mediator.Send(command, cancellationToken);

            return Created(string.Empty, new ApiResponseWithData<CreateCustomerResponse>
            {
                Success = true,
                Message = "Customer created successfully",
                Data = _mapper.Map<CreateCustomerResponse>(response)
            });
        }

        /// <summary>
        /// Deletes a customer by its ID
        /// </summary>
        /// <param name="id">The unique identifier of the customer to delete</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Success response if the customer was deleted</returns>
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin,Manager")]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteCustomer([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var request = new DeleteCustomerRequest { Id = id };
            var validationResult = await new DeleteCustomerRequestValidator().ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var command = _mapper.Map<DeleteCustomerCommand>(request.Id);
            await _mediator.Send(command, cancellationToken);

            return Ok(new ApiResponse
            {
                Success = true,
                Message = "Customer deleted successfully"
            });
        }

        /// <summary>
        /// Retrieves all customer in the system.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The customer list with details if found</returns>
        [HttpGet("getAll")]
        [Authorize(Roles = "Admin,Manager")]
        [ProducesResponseType(typeof(ApiResponseWithData<GetCustomerResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllCustomer(CancellationToken cancellationToken)
        {
            var request = new GetAllCustomerRequest();
            var validationResult = await new GetAllCustomerRequestValidator().ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var command = _mapper.Map<GetAllCustomerCommand>(request);
            var response = await _mediator.Send(command, cancellationToken);

            var mapedResult = _mapper.Map<List<GetAllCustomerResult>>(response);
            var reponseWithData = new ApiResponseWithData<List<GetAllCustomerResult>>
            {
                Success = true,
                Message = "Customers retrieved successfully",
                Data = mapedResult
            };

            return Ok(reponseWithData);
        }

        /// <summary>
        /// Updates an existing customer
        /// </summary>
        /// <param name="id">The unique identifier of the customer to update</param>
        /// <param name="request">The customer update request</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The updated customer details</returns>
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,Manager")]
        [ProducesResponseType(typeof(ApiResponseWithData<CreateCustomerResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateCustomer([FromRoute] Guid id, [FromBody] UpdateCustomerRequest request, CancellationToken cancellationToken)
        {
            request.Id = id;

            var validationResult = await new UpdateCustomerRequestValidator().ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var command = _mapper.Map<UpdateCustomerCommand>(request);
            var response = await _mediator.Send(command, cancellationToken);

            return Ok(new ApiResponseWithData<UpdateCustomerResponse>
            {
                Success = true,
                Message = "Customer updated successfully",
                Data = _mapper.Map<UpdateCustomerResponse>(response)
            });
        }

    }
}