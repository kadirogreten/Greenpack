using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class KurumsalMenu
    {
        public int Id { get; set; }
        public string MenuAdi { get; set; }
        public string Baslik { get; set; }
        public string AltBaslik { get; set; }
        public string Detay { get; set; }
        public byte Sira { get; set; }
    }
}
