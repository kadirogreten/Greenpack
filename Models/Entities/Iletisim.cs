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
        [StringLength(50, ErrorMessage = "{1} karakterden fazla {2} karakterden az olamaz!", MinimumLength = 4)]
        [Display(Name = "Adı Soyadı")]
        [Required(ErrorMessage = "Boş geçilemez!")]
        public string AdiSoyadi { get; set; }
        [EmailAddress]
        [StringLength(150, ErrorMessage = "{1} karakterden fazla {2} karakterden az olamaz!", MinimumLength = 4)]
        [Display(Name = "E-Posta")]
        [Required(ErrorMessage = "Boş geçilemez!")]
        public string Eposta { get; set; }
        [StringLength(180, ErrorMessage = "{1} karakterden fazla {2} karakterden az olamaz!", MinimumLength = 10)]
        [Display(Name = "Adı Soyadı")]
        [Required(ErrorMessage = "Boş geçilemez!")]
        public string Mesaj { get; set; }

        public bool OkunduMu { get; set; } = false;

        public DateTime CreatedDate { get; set; }

    }
}
