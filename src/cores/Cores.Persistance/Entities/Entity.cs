using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cores.Persistance.Entities;

public abstract class Entity<TId>
{
    public TId Id { get; set; } = default(TId); // Id nin tipi neyse onun default değerini al. Null exeption hatası almamak için.
    public DateTime CreatedTime { get; set; }
    public DateTime? UpdateTime { get; set; }
}
