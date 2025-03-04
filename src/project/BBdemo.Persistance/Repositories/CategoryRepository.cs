using BBdemo.Application.Services.Repositories;
using BBdemo.Domain.Entities;
using BBdemo.Persistance.Context;
using Cores.Persistance.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBdemo.Persistance.Repositories;

public sealed class CategoryRepository : EfRepositoryBase<Category, int, BaseDbContext>, ICategoryRepository
{
    public CategoryRepository(BaseDbContext context) : base(context)
    {
    }
}
