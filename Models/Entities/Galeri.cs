using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{

    public enum ResimTip
    {
        Kare, Dikdortgen
    }


    public class Galeri
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public short Sira { get; set; }
        public ResimTip ResimTip { get; set; }
        public string Aciklama { get; set; }
    }
}
