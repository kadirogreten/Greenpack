using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Greenpack.Web.Areas.AbatPanel.Models
{
    public class DashboardViewModel
    {
        public IEnumerable<Galeri> Galeri { get; set; }
        public IEnumerable<KurumsalMenu> KurumsalMenu { get; set; }
        public IEnumerable<HizmetlerimizMenu> HizmetlerimizMenu { get; set; }
        public IEnumerable<Slider> Sliders { get; set; }
    }
}