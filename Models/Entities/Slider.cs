using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class Slider
    {
        public int Id { get; set; }
        public string Path { get; set; }
        [Display(Name = "Sıra")]
        [Required(ErrorMessage = "Boş geçilemez!")]
        public short Sira { get; set; }
        [StringLength(100, ErrorMessage = "{1} karakterden fazla {2} karakterden az olamaz!", MinimumLength = 4)]
        [Display(Name = "İlk Açıklama")]
        [Required(ErrorMessage = "Boş geçilemez!")]
        public string Aciklama1 { get; set; }
        [StringLength(100, ErrorMessage = "{1} karakterden fazla {2} karakterden az olamaz!", MinimumLength = 4)]
        [Display(Name = "İkinci Açıklama")]
        [Required(ErrorMessage = "Boş geçilemez!")]
        public string Aciklama2 { get; set; }
        [StringLength(100, ErrorMessage = "{1} karakterden fazla {2} karakterden az olamaz!", MinimumLength = 4)]
        [Display(Name = "Son Açıklama")]
        [Required(ErrorMessage = "Boş geçilemez!")]
        public string Aciklama3 { get; set; }
    }
}
