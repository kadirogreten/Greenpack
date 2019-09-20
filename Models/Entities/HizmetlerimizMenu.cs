using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class HizmetlerimizMenu
    {
        public int Id { get; set; }
        public string HizmetAdi { get; set; }
        public string HizmetAciklama { get; set; }
        public byte Sira { get; set; }
        public ICollection<Resim> Resimler { get; set; }

    }
}
