using AutoMapper;
using BBdemo.Application.Services.Repositories;
using BBdemo.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBdemo.Application.Features.Products.Queries.GetById;

public class GetByIdProductQuery : IRequest<GetByIdProductResponseDto>
{
    public int Id { get; set; }

    public class GetByIdProductQueryHandler : IRequestHandler<GetByIdProductQuery, GetByIdProductResponseDto>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetByIdProductQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<GetByIdProductResponseDto> Handle(GetByIdProductQuery request, CancellationToken cancellationToken)
        {
            Product? product = await _productRepository.GetAsync(filter: x=>x.Id == request.Id, enableTracking:false);

            var response = _mapper.Map<GetByIdProductResponseDto>(product);

            return response;
        }
    }
}
