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

namespace BBdemo.Application.Features.Products.Queries.GetAllByCategoryId;

public class GetAllByCategoryIdProductQuery : IRequest<List<GetAllByCategoryIdProductResponseDto>>
{
    public int CategoryId { get; set; }

    public class GetAllByCategoryIdProductQueryHandler
        : IRequestHandler<GetAllByCategoryIdProductQuery, List<GetAllByCategoryIdProductResponseDto>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetAllByCategoryIdProductQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<List<GetAllByCategoryIdProductResponseDto>> Handle(GetAllByCategoryIdProductQuery request, CancellationToken cancellationToken)
        {
            List<Product> products = await _productRepository.GetAllAsync(filter: x=>x.CategoryId == request.CategoryId, enableTracking:false, cancellationToken:cancellationToken);

            //List<Product> products = await _context.Products
            //    .Where(x=>x.CategoryId == request.CategoryId)
            //    .Include(x=>x.Category)
            //    .ToListAsync();

            var response = _mapper.Map<List<GetAllByCategoryIdProductResponseDto>>(products);

            return response;
        }
    }
}
