using DataAccessLayer.Context;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Repository.SliderRepository
{
    public class SliderRepository : GenericRepository<Slider>, ISliderRepository
    {
        public SliderRepository(GreenpackDbContext context)
            : base(context)
        {

        }

        public GreenpackDbContext context { get { return _context as GreenpackDbContext; } }
    }
}
