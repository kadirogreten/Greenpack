using DataAccessLayer.Context;
using Greenpack.Web.Areas.AbatPanel.Models;
using ServiceLayer.Uow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Greenpack.Web.Areas.AbatPanel.Controllers
{
    public class HomeController : Controller
    {
        // GET: AbatPanel/Home
        public ActionResult Index()
        {
            //using (var uow = new UnitOfWork(new GreenpackDbContext()))
            //{
            //    DashboardViewModel model = new DashboardViewModel()
            //    {

            //        Sliders = uow.Slider.GetAll(),
            //        Galeri = uow.Galeri.GetAll(),
            //        HizmetlerimizMenu = uow.Hizmetlerimiz.GetAllWithInclude(),
            //        KurumsalMenu = uow.Kurumsal.GetAll()
            //    };


            //    return View(model);
            //}

            return View();

            //string response = JsonConvert.SerializeObject(model.Urunlerimiz.Select(a=> new { UrunAdi = a.UrunAdi}).ToList(), Formatting.Indented, new JsonSerializerSettings()
            //{
            //    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            //});


        }
    }
}