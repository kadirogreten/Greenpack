using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class Iletisim
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string AdiSoyadi { get; set; }
        [EmailAddress]
        public string Eposta { get; set; }
        [StringLength(180)]
        public string Mesaj { get; set; }

        public bool OkunduMu { get; set; } = false;

        public DateTime CreatedDate { get; set; }

    }
}
