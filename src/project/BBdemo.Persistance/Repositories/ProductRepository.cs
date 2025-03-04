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

public class ProductRepository : EfRepositoryBase<Product, int, BaseDbContext>, IProductRepository
{
    public ProductRepository(BaseDbContext context) : base(context)
    {
    }
}
