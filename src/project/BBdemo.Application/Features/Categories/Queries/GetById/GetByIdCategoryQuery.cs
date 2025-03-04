using AutoMapper;
using BBdemo.Application.Services.Repositories;
using BBdemo.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBdemo.Application.Features.Categories.Queries.GetById;

public class GetByIdCategoryQuery : IRequest<GetByIdCategoryResponseDto>
{
    public int Id { get; set; }

    public class GetByIdCategoryQueryHandler(ICategoryRepository categoryRepository, IMapper mapper) : IRequestHandler<GetByIdCategoryQuery, GetByIdCategoryResponseDto>
    {
        public async Task<GetByIdCategoryResponseDto> Handle(GetByIdCategoryQuery request, CancellationToken cancellationToken)
        {
            Category? category = await categoryRepository.GetAsync(x=>x.Id == request.Id);

            var response = mapper.Map<GetByIdCategoryResponseDto>(category);
            return response;
        }
    }
}
