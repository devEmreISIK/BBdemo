using AutoMapper;
using BBdemo.Application.Features.Products.Commands.Create;
using BBdemo.Application.Features.Products.Commands.Update;
using BBdemo.Application.Features.Products.Queries.GetAllByCategoryId;
using BBdemo.Application.Features.Products.Queries.GetAllByNameContains;
using BBdemo.Application.Features.Products.Queries.GetById;
using BBdemo.Application.Features.Products.Queries.GetDetails;
using BBdemo.Application.Features.Products.Queries.GetList;
using BBdemo.Application.Features.Products.Queries.GetListPriceRange;
using BBdemo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBdemo.Application.Features.Products.Profiles;

public class ProductsMapper : Profile
{
    public ProductsMapper()
    {
        CreateMap<ProductAddCommand, Product>();
        CreateMap<Product, GetListProductResponseDto>();
        CreateMap<Product, GetDetailsProductResponseDto>();
        CreateMap<Product, GetByIdProductResponseDto>();
        CreateMap<ProductUpdateCommand, Product>();
        CreateMap<Product, GetAllByCategoryIdProductResponseDto>();
        CreateMap<Product, GetListProductPriceRangeResponseDto>();
        CreateMap<Product, GetListProductNameContainResponseDto>();
    }
}
