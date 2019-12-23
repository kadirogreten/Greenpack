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
    [RequireHttps]
    [Authorize(Roles = "Admin,Greenpack")]
    public class HomeController : Controller
    {
        // GET: AbatPanel/Home
        public ActionResult Index()
        {
            //var uow = new UnitOfWork(new GreenpackDbContext());


            //DashboardViewModel model = new DashboardViewModel()
            //{

            //    Sliders = uow.Slider.GetAll(),
            //    Galeri = uow.Galeri.GetAll(),
            //    HizmetlerimizMenu = uow.Hizmetlerimiz.GetAllWithInclude(),
            //    KurumsalMenu = uow.Kurumsal.GetAll()
            //};


            return View();



        }
    }
}