using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class GaleriFilter
    {
        public int Id { get; set; }
        public string FilterName { get; set; }

        public ICollection<Galeri> Galeri { get; set; }

    }
}
