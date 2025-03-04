using BBdemo.Application.Services.Repositories;
using BBdemo.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBdemo.Application.Features.Categories.Commands.Create;

public class CategoryAddCommand : IRequest<Category>
{
    public string Name { get; set; }

    public class CategoryAddCommandHandler : IRequestHandler<CategoryAddCommand, Category>
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryAddCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Category> Handle(CategoryAddCommand request, CancellationToken cancellationToken)
        {
            Category category = new Category
            {
                Name = request.Name,
            };

            await _categoryRepository.AddAsync(category, cancellationToken);
            return category;
        }
    }
}
