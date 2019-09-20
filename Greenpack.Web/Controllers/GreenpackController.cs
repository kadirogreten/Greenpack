using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Greenpack.Web.Controllers
{
    public class GreenpackController : Controller
    {
        // GET: Greenpack
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Kurumsal()
        {
            return View();
        }

        public ActionResult Hizmetlerimiz()
        {
            return View();
        }

        public ActionResult Galeri()
        {
            return View();
        }

        public ActionResult Iletisim()
        {
            return View();
        }

    }
}