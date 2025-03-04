using AutoMapper;
using BBdemo.Application.Features.Categories.Commands.Create;
using BBdemo.Application.Features.Categories.Commands.Update;
using BBdemo.Application.Features.Categories.Queries.GetById;
using BBdemo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBdemo.Application.Features.Categories.Profiles;

public class CategoriesMapper : Profile
{
    public CategoriesMapper()
    {
        CreateMap<CategoryAddCommand, Category>();
        CreateMap<CategoryUpdateCommand, Category>();
        CreateMap<Category, GetByIdCategoryResponseDto>();
    }
}
