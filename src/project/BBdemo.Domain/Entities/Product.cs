using Cores.Persistance.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBdemo.Domain.Entities;

public class Product : Entity<int>
{
    //public int Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public int Stock { get; set; }

    public int CategoryId { get; set; }
    public Category Category { get; set; }
}
