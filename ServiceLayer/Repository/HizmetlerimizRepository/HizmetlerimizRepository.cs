using DataAccessLayer.Context;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Linq.Expressions;

namespace ServiceLayer.Repository.HizmetlerimizRepository
{
    public class HizmetlerimizRepository : GenericRepository<HizmetlerimizMenu>, IHizmetlerRepository
    {
        public HizmetlerimizRepository(GreenpackDbContext context)
            : base(context)
        {

        }

        public GreenpackDbContext context { get { return _context as GreenpackDbContext; } }

        public IEnumerable<HizmetlerimizMenu> GetAllWithInclude()
        {
            return context.HizmetlerimizMenu.Include(a => a.Resimler);
        }

        public IEnumerable<HizmetlerimizMenu> WhereWithInclude(Expression<Func<HizmetlerimizMenu, bool>> predicate)
        {
            return context.HizmetlerimizMenu.Include(a => a.Resimler).Where(predicate);
        }
    }
}
