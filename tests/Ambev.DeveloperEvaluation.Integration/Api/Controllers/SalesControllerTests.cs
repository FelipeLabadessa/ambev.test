using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Application.Sales.DeleteSale;
using Ambev.DeveloperEvaluation.Application.Sales.GetSale;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.DeleteSale;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSale;
using AutoMapper;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using Xunit;

namespace Ambev.DeveloperEvaluation.Integration.Api.Controllers
{
    public class SalesControllerTests
    {
        private readonly IMediator _mediatorSubstitute;
        private readonly IMapper _mapperSubstitute;
        private readonly SalesController _controller;

        public SalesControllerTests()
        {
            _mediatorSubstitute = Substitute.For<IMediator>();
            _mapperSubstitute = Substitute.For<IMapper>();
            _controller = new SalesController(_mediatorSubstitute, _mapperSubstitute);
        }

        /// <summary>
        /// Tests the GetSale method with a valid ID.
        /// </summary>
        [Fact(DisplayName = "Should return Ok (200) when GetSale is called with a valid ID")]
        public async Task Given_ValidId_When_GetSaleIsCalled_Then_ReturnsOk()
        {
            // Arrange
            var id = Guid.NewGuid();
            var request = new GetSaleRequest(id);
            var command = new GetSaleCommand(id);
            var result = new GetSaleResult
            {
                Id = id,
                TotalAmount = 500
            };
            var response = new ApiResponseWithData<GetSaleResponse>
            {
                Success = true,
                Message = "Sale retrieved successfully",
                Data = new GetSaleResponse
                {
                    Id = id,
                    TotalAmount = 500
                }
            };

            _mapperSubstitute.Map<GetSaleCommand>(request.Id).Returns(command);
            _mediatorSubstitute.Send(command, Arg.Any<CancellationToken>()).Returns(result);
            _mapperSubstitute.Map<GetSaleResponse>(result).Returns(response.Data);

            // Act
            var actualResult = await _controller.GetSale(id, CancellationToken.None);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(actualResult); 
            var apiResponse = Assert.IsType<ApiResponseWithData<ApiResponseWithData<GetSaleResponse>>>(okResult.Value);
            Assert.True(apiResponse.Success); 
            Assert.NotNull(apiResponse.Data); 
        }

        /// <summary>
        /// Tests the CreateSale method with a valid request.
        /// </summary>
        [Fact(DisplayName = "Should return Created (201) when CreateSale is called with a valid request")]
        public async Task Given_ValidCreateSaleRequest_When_CreateSaleIsCalled_Then_ReturnsCreated()
        {
            // Arrange
            var request = new CreateSaleRequest
            {
                CustomerID = Guid.NewGuid(),
                BranchId = Guid.NewGuid(),
                Products = new List<SaleProductRequest>() { new SaleProductRequest()
                {
                    Id = Guid.NewGuid(),
                    Name = "TestProduct",
                    Amount = 10,
                    UnitPrice = 10.95m,
                } }
            };
            var command = new CreateSaleCommand {
                CustomerID = Guid.NewGuid(),
                BranchId = Guid.NewGuid(),
                Products = new List<SaleProductCommand>() { new SaleProductCommand()
                {
                    Id = Guid.NewGuid(),
                    Name = "TestProduct",
                    Amount = 10,
                    UnitPrice = 10.95m,
                } }
            };
            var response = new CreateSaleResponse { };
            var result = new CreateSaleResult { };

            _mapperSubstitute.Map<CreateSaleCommand>(request).Returns(command);
            _mediatorSubstitute.Send(command, Arg.Any<CancellationToken>()).Returns(result);
            _mapperSubstitute.Map<CreateSaleResponse>(result).Returns(response);

            // Act
            var opResult = await _controller.CreateSale(request, CancellationToken.None);

            // Assert
            var createdResult = Assert.IsType<CreatedResult>(opResult);
            var apiResponse = Assert.IsType<ApiResponseWithData<CreateSaleResponse>>(createdResult.Value);
            Assert.True(apiResponse.Success);
            Assert.Equal("Sale created successfully", apiResponse.Message);
            Assert.Equal(response, apiResponse.Data);
        }

        /// <summary>
        /// Tests the DeleteSale method with a valid ID.
        /// </summary>
        [Fact(DisplayName = "Should return Ok (200) when DeleteSale is called with a valid ID")]
        public async Task Given_ValidId_When_DeleteSaleIsCalled_Then_ReturnsOk()
        {
            // Arrange
            var id = Guid.NewGuid();
            var request = new DeleteSaleRequest(id);
            var command = new DeleteSaleCommand(id);

            _mapperSubstitute.Map<DeleteSaleCommand>(request.Id).Returns(command);

            // Act
            var result = await _controller.DeleteSale(id, CancellationToken.None);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var apiResponse = Assert.IsType<ApiResponseWithData<ApiResponse>>(okResult.Value);
            Assert.True(apiResponse.Success);
        }
       
        /// <summary>
        /// Tests the CreateSale method when the request validation fails.
        /// </summary>
        [Fact(DisplayName = "Should return BadRequest (400) when CreateSale validation fails")]
        public async Task Given_InvalidCreateSaleRequest_When_CreateSaleIsCalled_Then_ReturnsBadRequest()
        {
            // Arrange
            var request = new CreateSaleRequest
            {
                CustomerID = Guid.Empty, 
                BranchId = Guid.Empty,  
                Products = new List<SaleProductRequest>()
            };

            var validationErrors = new List<FluentValidation.Results.ValidationFailure>
            {
                new FluentValidation.Results.ValidationFailure("CustomerID", string.Empty),
                new FluentValidation.Results.ValidationFailure("BranchId", string.Empty),
                new FluentValidation.Results.ValidationFailure("Products", string.Empty)
            };

            var validationResult = new FluentValidation.Results.ValidationResult(validationErrors);

            var validator = Substitute.For<CreateSaleRequestValidator>();
            validator.ValidateAsync(request, Arg.Any<CancellationToken>()).Returns(Task.FromResult(validationResult));

            // Act
            var result = await _controller.CreateSale(request, CancellationToken.None);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            var errors = Assert.IsType<List<ValidationFailure>>(badRequestResult.Value);
            Assert.Equal(3, errors.Count);
        }

        /// <summary>
        /// Tests the DeleteSale method when the request validation fails.
        /// </summary>
        [Fact(DisplayName = "Should return BadRequest (400) when DeleteSale validation fails")]
        public async Task Given_InvalidId_When_DeleteSaleIsCalled_Then_ReturnsBadRequest()
        {
            // Arrange
            var invalidId = Guid.Empty; // ID inválido
            var request = new DeleteSaleRequest(invalidId);

            var validationErrors = new List<FluentValidation.Results.ValidationFailure>
            {
                new FluentValidation.Results.ValidationFailure("Id", string.Empty)
            };

            var validationResult = new FluentValidation.Results.ValidationResult(validationErrors);

            var validator = Substitute.For<DeleteSaleRequestValidator>();
            validator.ValidateAsync(request, Arg.Any<CancellationToken>()).Returns(Task.FromResult(validationResult));

            // Act
            var result = await _controller.DeleteSale(invalidId, CancellationToken.None);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            var errors = Assert.IsType<List<ValidationFailure>>(badRequestResult.Value);
            Assert.Single(errors); // Verifica que há apenas 1 erro de validação
        }

       


    }
}
