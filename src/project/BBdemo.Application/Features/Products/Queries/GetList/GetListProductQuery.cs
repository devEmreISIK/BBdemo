using AutoMapper;
using BBdemo.Application.Services.RedisServices;
using BBdemo.Application.Services.Repositories;
using BBdemo.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBdemo.Application.Features.Products.Queries.GetList;

public class GetListProductQuery : IRequest<List<GetListProductResponseDto>>
{
    public class GetListProductQueryHandler : IRequestHandler<GetListProductQuery, List<GetListProductResponseDto>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly IRedisService _redisService;

        public GetListProductQueryHandler(IProductRepository productRepository, IMapper mapper, IRedisService redisService)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _redisService = redisService;
        }

        public async Task<List<GetListProductResponseDto>> Handle(GetListProductQuery request, CancellationToken cancellationToken)
        {
            var cachedData = await _redisService.GetDataAsync<List<GetListProductResponseDto>>("products");
            if (cachedData is not null)
            {
                return cachedData;
            }

            List<Product> products = await _productRepository.GetAllAsync(enableTracking:false);

            var responses = _mapper.Map<List<GetListProductResponseDto>>(products);

            await _redisService.AddDataAsync("products", responses);

            return responses;
        }
    }
}
