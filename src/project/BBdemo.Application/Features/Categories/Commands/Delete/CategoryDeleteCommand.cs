using BBdemo.Application.Services.Repositories;
using BBdemo.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBdemo.Application.Features.Categories.Commands.Delete;

public class CategoryDeleteCommand : IRequest<string>
{
    public int Id { get; set; }

    public class CategoryDeleteCommandHandler(ICategoryRepository categoryRepository) : IRequestHandler<CategoryDeleteCommand, string>
    {
        public async Task<string> Handle(CategoryDeleteCommand request, CancellationToken cancellationToken)
        {
            Category? category = await categoryRepository.GetAsync(filter: x=>x.Id == request.Id, cancellationToken: cancellationToken);

            await categoryRepository.DeleteAsync(category, cancellationToken);

            return "Category deleted.";
        }
    }
}
