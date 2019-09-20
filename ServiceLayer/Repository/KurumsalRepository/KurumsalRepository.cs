using DataAccessLayer.Context;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Repository.KurumsalRepository
{
    public class KurumsalRepository : GenericRepository<KurumsalMenu>, IKurumsalRepository
    {
        public KurumsalRepository(GreenpackDbContext context)
            : base(context)
        {

        }

        public GreenpackDbContext context { get { return _context as GreenpackDbContext; } }


    }
}
