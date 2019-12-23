using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class Galeri
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public short Sira { get; set; }
        [StringLength(100, ErrorMessage = "{1} karakterden fazla {2} karakterden az olamaz!", MinimumLength = 4)]
        [Display(Name = "Açıklama")]
        [Required(ErrorMessage = "Boş geçilemez!")]
        public string Aciklama { get; set; }
        public virtual int? GaleriFilterId { get; set; }
        public virtual GaleriFilter GaleriFilter { get; set; }
    }
}
