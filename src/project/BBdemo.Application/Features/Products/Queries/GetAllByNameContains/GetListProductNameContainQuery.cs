using AutoMapper;
using BBdemo.Application.Services.Repositories;
using BBdemo.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBdemo.Application.Features.Products.Queries.GetAllByNameContains;

public class GetListProductNameContainQuery : IRequest<List<GetListProductNameContainResponseDto>>
{
    public string Text { get; set; }

    public class GetListProductNameContainQueryHandler
        : IRequestHandler<GetListProductNameContainQuery, List<GetListProductNameContainResponseDto>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetListProductNameContainQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<List<GetListProductNameContainResponseDto>> Handle(GetListProductNameContainQuery request, CancellationToken cancellationToken)
        {
            List<Product> products = await _productRepository
                .GetAllAsync(filter: x=>x.Name.Contains(request.Text), enableTracking:false, cancellationToken:cancellationToken);

            var response = _mapper.Map<List<GetListProductNameContainResponseDto>>(products);

            return response;
        }
    }
}
