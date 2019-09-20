using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Repository.HizmetlerimizRepository
{
    public interface IHizmetlerRepository : IRepository<HizmetlerimizMenu>
    {
        IEnumerable<HizmetlerimizMenu> GetAllWithInclude();
        IEnumerable<HizmetlerimizMenu> WhereWithInclude(Expression<Func<HizmetlerimizMenu, bool>> predicate);
    }
}
