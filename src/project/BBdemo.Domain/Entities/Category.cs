﻿using Cores.Persistance.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBdemo.Domain.Entities;

public class Category : Entity<int>
{
    public string Name { get; set; }

    public List<Product> Products { get; set; }
}
