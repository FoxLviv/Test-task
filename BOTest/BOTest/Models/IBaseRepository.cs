using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DB.Entities;

namespace BOTest.Models
{
    public interface IBaseRepository
    {
        IEnumerable<BaseEntity> BaseEntities { get; }
    }
}
