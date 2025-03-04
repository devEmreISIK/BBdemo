using AutoMapper;
using BBdemo.Application.Services.Repositories;
using BBdemo.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBdemo.Application.Features.Products.Commands.Update;

public class ProductUpdateCommand : IRequest<string>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public int Stock { get; set; }
    public int CategoryId { get; set; }

    public class ProductUpdateCommandHandler : IRequestHandler<ProductUpdateCommand, string>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductUpdateCommandHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<string> Handle(ProductUpdateCommand request, CancellationToken cancellationToken)
        {
            Product product = _mapper.Map<Product>(request);

            await _productRepository.UpdateAsync(product, cancellationToken);

            return "Product updated.";
        }
    }
}
