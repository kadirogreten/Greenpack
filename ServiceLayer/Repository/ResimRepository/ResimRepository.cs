using DataAccessLayer.Context;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Repository.ResimRepository
{
    public class ResimRepository : GenericRepository<Resim>, IResimRepository
    {
        public ResimRepository(GreenpackDbContext context)
            : base(context)
        {

        }

        public GreenpackDbContext context { get { return _context as GreenpackDbContext; } }
    }
}
