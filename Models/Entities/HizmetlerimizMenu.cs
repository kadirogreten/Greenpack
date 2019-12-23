using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class HizmetlerimizMenu
    {
        public int Id { get; set; }
        [Display(Name = "Hizmet Adı")]
        [Required(ErrorMessage = "Boş geçilemez!")]
        [StringLength(100, ErrorMessage = "{1} karakterden fazla {2} karakterden az olamaz!", MinimumLength = 4)]
        public string HizmetAdi { get; set; }
        [Display(Name = "Hizmet Açıklama")]
        [Required(ErrorMessage = "Boş geçilemez!")]        
        public string HizmetAciklama { get; set; }
        [Display(Name = "Hizmet Sırası")]
        [Required(ErrorMessage = "Boş geçilemez!")]
        public byte Sira { get; set; }
        public ICollection<Resim> Resimler { get; set; }

    }
}
