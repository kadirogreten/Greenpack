using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Models.Entities;

namespace DataAccessLayer.Context
{
    public class GreenpackDbContext : IdentityDbContext<GreenpackUser>
    {
        public GreenpackDbContext() : base("DefaultConnection")
        {

        }
        public static GreenpackDbContext Create()
        {
            return new GreenpackDbContext();
        }

        public DbSet<KurumsalMenu> KurumsalMenu { get; set; }
        public DbSet<HizmetlerimizMenu> HizmetlerimizMenu { get; set; }
        public DbSet<Resim> Resim { get; set; }
        public DbSet<Galeri> Galeri { get; set; }
        public DbSet<Slider> Slider { get; set; }
        public DbSet<GaleriFilter> GaleriFilter { get; set; }
        public DbSet<Iletisim> Iletisim { get; set; }
    }
}
