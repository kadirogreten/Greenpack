using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Repository.GaleriRepository
{
    public interface IGaleriRepository : IRepository<Galeri>
    {
        IEnumerable<Galeri> GetAllWithInclude();
       
        IEnumerable<Galeri> WhereWithInclude(Expression<Func<Galeri, bool>> predicate);
    }
}
