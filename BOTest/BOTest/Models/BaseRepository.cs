using DB;
using DB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BOTest.Models
{
    public class BaseRepository: IBaseRepository
    {
        private readonly BODbContext _bODbContext;

        public BaseRepository(BODbContext bODbContext)
        {
            _bODbContext = bODbContext;
        }

        public IEnumerable<BaseEntity> BaseEntities
        {
            get
            {
                return _bODbContext.Bases;
            }
        }
    }
}
