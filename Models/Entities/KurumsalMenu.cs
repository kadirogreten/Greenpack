using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class KurumsalMenu
    {
        public int Id { get; set; }
        [StringLength(50, ErrorMessage = "{1} karakterden fazla {2} az olamaz!", MinimumLength = 4)]
        [Display(Name = "Menü Adı")]
        [Required(ErrorMessage = "Boş geçilemez!")]
        public string MenuAdi { get; set; }
        [StringLength(75, ErrorMessage = "{1} karakterden fazla {2} az olamaz!", MinimumLength = 4)]
        [Display(Name = "Menü Başlık")]
        [Required(ErrorMessage = "Boş geçilemez!")]
        public string Baslik { get; set; }
        [StringLength(100, ErrorMessage = "{1} karakterden fazla {2} az olamaz!", MinimumLength = 4)]
        [Display(Name = "Menü Alt Başlık")]
        [Required(ErrorMessage = "Boş geçilemez!")]
        public string AltBaslik { get; set; }        
        [Display(Name = "Detay")]
        [Required(ErrorMessage = "Boş geçilemez!")]
        public string Detay { get; set; }        
        [Display(Name = "Sıra")]
        [Required(ErrorMessage = "Boş geçilemez!")]
        public byte Sira { get; set; }
    }
}
