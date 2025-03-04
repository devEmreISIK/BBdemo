using AutoMapper;
using BBdemo.Application.Services.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBdemo.Application.Features.Products.Queries.GetDetails;

public class GetDetailsProductQuery : IRequest<List<GetDetailsProductResponseDto>>
{
    public class GetDetailsProductQueryHandler : IRequestHandler<GetDetailsProductQuery, List<GetDetailsProductResponseDto>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetDetailsProductQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<List<GetDetailsProductResponseDto>> Handle(GetDetailsProductQuery request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetAllAsync(enableTracking:false);

            var response = _mapper.Map<List<GetDetailsProductResponseDto>>(products);
            
            return response;
        }
    }
}
