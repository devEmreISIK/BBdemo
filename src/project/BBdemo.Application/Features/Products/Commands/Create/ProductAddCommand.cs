using AutoMapper;
using BBdemo.Application.Services.RedisServices;
using BBdemo.Application.Services.Repositories;
using BBdemo.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBdemo.Application.Features.Products.Commands.Create;

public class ProductAddCommand : IRequest<string>
{
    public string Name { get; set; }
    public double Price { get; set; }
    public int Stock { get; set; }
    public int CategoryId { get; set; }

    public class ProductAddCommandHandler : IRequestHandler<ProductAddCommand, string>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly IRedisService _redisService;

        public ProductAddCommandHandler(IProductRepository productRepository, IMapper mapper, IRedisService redisService)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _redisService = redisService;
        }

        public async Task<string> Handle(ProductAddCommand request, CancellationToken cancellationToken)
        {
            Product product = _mapper.Map<Product>(request);
           
            await _productRepository.AddAsync(product, cancellationToken);

            await _redisService.RemoveDataAsync("products");

            return "Product added.";

        }
    }
}
