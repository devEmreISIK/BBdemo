using AutoMapper;
using BBdemo.Application.Services.Repositories;
using BBdemo.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBdemo.Application.Features.Categories.Commands.Update;

public class CategoryUpdateCommand : IRequest<string>
{
    public int Id { get; set; }
    public string Name { get; set; }

    public class CategoryUpdateCommandHandler : IRequestHandler<CategoryUpdateCommand, string>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryUpdateCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<string> Handle(CategoryUpdateCommand request, CancellationToken cancellationToken)
        {
            Category category = _mapper.Map<Category>(request);

            await _categoryRepository.UpdateAsync(category);

            return "Category Updated.";
        }
    }
}
