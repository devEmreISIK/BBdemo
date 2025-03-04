using AutoMapper;
using BBdemo.Application.Services.Repositories;
using BBdemo.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBdemo.Application.Features.Products.Commands.Delete;

public class ProductDeleteCommand : IRequest<string>
{
    public int Id { get; set; }

    public class ProductDeleteCommandHandler : IRequestHandler<ProductDeleteCommand, string>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductDeleteCommandHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<string> Handle(ProductDeleteCommand request, CancellationToken cancellationToken)
        {
            Product? product = await _productRepository.GetAsync(filter: x=>x.Id ==  request.Id, cancellationToken:cancellationToken);

            await _productRepository.DeleteAsync(product, cancellationToken);

            return "Product deleted.";
        }
    }
}
