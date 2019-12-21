using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Greenpack.Web.Models
{
    public class HomeViewModel
    {
        public IEnumerable<Slider> Sliders { get; set; }
        public IEnumerable<HizmetlerimizMenu> HizmetlerimizMenu { get; set; }
    }
}