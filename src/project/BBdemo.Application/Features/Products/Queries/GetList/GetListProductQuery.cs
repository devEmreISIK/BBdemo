using AutoMapper;
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

        public GetListProductQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<List<GetListProductResponseDto>> Handle(GetListProductQuery request, CancellationToken cancellationToken)
        {
            List<Product> products = await _productRepository.GetAllAsync(enableTracking:false);

            var responses = _mapper.Map<List<GetListProductResponseDto>>(products); 

            return responses;
        }
    }
}
