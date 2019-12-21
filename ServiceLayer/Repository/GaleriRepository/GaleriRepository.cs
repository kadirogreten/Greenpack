using DataAccessLayer.Context;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ServiceLayer.Repository.GaleriRepository
{
    public class GaleriRepository : GenericRepository<Galeri>, IGaleriRepository
    {
        public GaleriRepository(GreenpackDbContext context)
            : base(context)
        {

        }

        public GreenpackDbContext context { get { return _context as GreenpackDbContext; } }

        public IEnumerable<Galeri> GetAllWithInclude()
        {
            return context.Galeri.Include(a => a.GaleriFilter);
        }

        public IEnumerable<Galeri> WhereWithInclude(Expression<Func<Galeri, bool>> predicate)
        {
            return context.Galeri.Include(a => a.GaleriFilter).Where(predicate);
        }
    }
}
