using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBdemo.Application.Features.Products.Queries.GetList;

public class GetListProductResponseDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public int Stock { get; set; }
}
