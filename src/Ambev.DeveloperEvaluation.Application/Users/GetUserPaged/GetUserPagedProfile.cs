using Ambev.DeveloperEvaluation.Domain.Repositories.Pagination;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Users.GetUserPaged
{
    /// <summary>
    /// Defines the mapping profiles for paged product retrieval operations.
    /// </summary>
    public class GetUserPagedProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the class
        /// and defines mappings between data transfer objects, commands, and response models.
        /// </summary>
        public GetUserPagedProfile()
        {
            CreateMap<PaginationRequestDTO, GetUserPagedCommand>();
        }
    }
}
