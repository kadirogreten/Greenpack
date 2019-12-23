using DataAccessLayer.Context;
using Greenpack.Web.Models;
using Models.Entities;
using ServiceLayer.Uow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Greenpack.Web.Controllers
{
    public class GreenpackController : Controller
    {
        // GET: Greenpack
        public ActionResult Index()
        {

            var uow = new UnitOfWork(new GreenpackDbContext());


            var hizmetler = uow.Hizmetlerimiz.GetAllWithInclude();
            var slider = uow.Slider.GetAll();



            HomeViewModel model = new HomeViewModel
            {
                Sliders = slider,
                HizmetlerimizMenu = hizmetler
            };


            return View(model);


        }

        [Route("greenpack/{title}")]
        public ActionResult Kurumsal(string title)
        {


            if (title == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var uow = new UnitOfWork(new GreenpackDbContext());
            var kurumsal = uow.Kurumsal.Where(a=>a.MenuAdi.Replace(" ", "-").Replace(".", "").Replace("İ", "i").Replace("I", "i").Replace("&", "-") == title.Replace(" ", "-").Replace(".", "").Replace("İ", "i").Replace("I", "i").Replace("&", "-")).FirstOrDefault();

            if (kurumsal == null)
            {
                return HttpNotFound();
            }

            return View(kurumsal);


        }
        [Route("hizmetlerimiz/{title}")]
        public ActionResult Hizmetlerimiz(string title)
        {
            if (title == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var uow = new UnitOfWork(new GreenpackDbContext());
            var hizmetler = uow.Hizmetlerimiz.WhereWithInclude(a => a.HizmetAdi.Replace(" ", "-").Replace(".", "").Replace("İ", "i").Replace("I", "i").Replace("&", "-") == title.Replace(" ", "-").Replace(".", "").Replace("İ", "i").Replace("I", "i").Replace("&", "-")).FirstOrDefault();

            if (hizmetler == null)
            {
                return HttpNotFound();
            }

            return View(hizmetler);
        }

        [Route("greenpack/galeri")]
        public ActionResult Galeri()
        {
            var uow = new UnitOfWork(new GreenpackDbContext());
            var galeri = uow.Galeri.GetAllWithInclude();
            return View(galeri);
        }

        [Route("greenpack/iletisim")]
        public ActionResult Iletisim(MessageId? message)
        {
            ViewBag.StatusMessage =
                message == MessageId.SendMessageSuccess ? "Mesajınız başarılı bir şekilde gönderildi!"
                : message == MessageId.ErrorMessage ? "Beklenmedik bir hata gerçekleşti. Lütfen zorunlu alanları doldurunuz!"
                : message == MessageId.Error ? "Lütfen yöneticinize başvurunuz!"
                : "";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("greenpack/iletisim")]
        public ActionResult Iletisim([Bind(Include = "Id,AdiSoyadi,Eposta,Mesaj,OkunduMu")] Iletisim iletisim)
        {
            MessageId? message;
            if (ModelState.IsValid)
            {

                using (var uow = new UnitOfWork(new GreenpackDbContext()))
                {

                    uow.Iletisim.Insert(new Iletisim
                    {
                        AdiSoyadi = iletisim.AdiSoyadi,
                        Eposta = iletisim.Eposta,
                        Mesaj = iletisim.Mesaj,
                        OkunduMu = iletisim.OkunduMu,
                        CreatedDate = DateTime.Now
                    });

                    try
                    {
                        uow.Complete();
                        message = MessageId.SendMessageSuccess;
                        return RedirectToAction("iletisim", new { Message = message });
                    }
                    catch (Exception)
                    {
                        message = MessageId.Error;
                        return RedirectToAction("iletisim", new { Message = message });
                    }
                   
                }


            }
            else
            {
                message = MessageId.SendMessageSuccess;
                return View(iletisim);
            }
        }

    }
}