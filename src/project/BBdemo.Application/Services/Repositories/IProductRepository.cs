using BBdemo.Domain.Entities;
using Cores.Persistance.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBdemo.Application.Services.Repositories;

public interface IProductRepository : IAsyncRepository<Product, int>, IRepository<Product, int>
{

}
