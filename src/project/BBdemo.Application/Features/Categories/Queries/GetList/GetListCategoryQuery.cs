using BBdemo.Application.Services.Repositories;
using BBdemo.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBdemo.Application.Features.Categories.Queries.GetList;

public class GetListCategoryQuery : IRequest<List<Category>>
{
    public class GetListCategoryQueryHandler : IRequestHandler<GetListCategoryQuery, List<Category>>
    {
        private readonly ICategoryRepository _categoryRepository;

        public GetListCategoryQueryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<List<Category>> Handle(GetListCategoryQuery request, CancellationToken cancellationToken)
        {
            List<Category> categories = await _categoryRepository.GetAllAsync(cancellationToken: cancellationToken);

            return categories;
        }
    }
}
