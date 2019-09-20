using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataAccessLayer.Context;
using Models.Entities;
using ServiceLayer.Uow;
using System.IO;

namespace Greenpack.Web.Areas.AbatPanel.Controllers
{
    public class SliderController : Controller
    {
        
        // GET: AbatPanel/Slider
        public async Task<ActionResult> Index()
        {
            using (var uow = new UnitOfWork(new GreenpackDbContext()))
            {

                var list = uow.Slider.GetAll().ToList();

                return View(await Task.FromResult(list));
            }
        }

        // GET: AbatPanel/Slider/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            using (var uow = new UnitOfWork(new GreenpackDbContext()))
            {
                Slider slider = await Task.FromResult(uow.Slider.Where(a => a.Id == id).FirstOrDefault());
                if (slider == null)
                {
                    return HttpNotFound();
                }
                return View(slider);
            }
        }

        // GET: AbatPanel/Slider/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AbatPanel/Slider/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Path,Sira,Aciklama1,Aciklama2,Aciklama3")] Slider slider, HttpPostedFileBase sliderResim)
        {
            if (ModelState.IsValid)
            {

                string fileName = string.Empty;

                using (var uow = new UnitOfWork(new GreenpackDbContext()))
                {

                    if (sliderResim != null && sliderResim.ContentLength > 0 && sliderResim.ContentLength < 2 * 1024 * 1024)
                    {
                        fileName = Guid.NewGuid() + Path.GetExtension(sliderResim.FileName);
                        sliderResim.SaveAs(Path.Combine(Server.MapPath("/Assets/slider/"), fileName));
                        uow.Slider.Insert(new Slider
                        {
                            Path = "/Assets/slider/" + fileName,
                            Sira = slider.Sira,
                            Aciklama1 = slider.Aciklama1,
                            Aciklama2 = slider.Aciklama2,
                            Aciklama3 = slider.Aciklama3
                        });
                        //db.Entry(new ProjeResim { Path = "/images/Projeler/" + fileName, Sira = sira, ProjeId = proje.Id }).State = EntityState.Modified;

                    }
                    else
                    {
                        ViewBag.Mesaj = "Dosya seçmeden işleminize devam etmektesiniz. Lütfen 1 Adet Resim Dosyası Seçiniz!";
                        ViewBag.Status = "error";
                        ViewBag.Baslik = "Oops!";

                        return View(slider);
                    }



                    await Task.FromResult(uow.Complete());
                    ViewBag.Mesaj = "Ekleme Başarılı.";
                    ViewBag.Status = "success";
                    ViewBag.Baslik = "Harika";

                    return View(slider);
                }


            }
            else
            {
                ViewBag.Mesaj = "Hata";
                ViewBag.Status = "error";
                ViewBag.Baslik = "Oops!";
                return View(slider);
            }
        }

        // GET: AbatPanel/Slider/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            using (var uow = new UnitOfWork(new GreenpackDbContext()))
            {
                Slider slider = await Task.FromResult(uow.Slider.Where(a => a.Id == id).FirstOrDefault());
                if (slider == null)
                {
                    return HttpNotFound();
                }
                return View(slider);
            }
        }

        // POST: AbatPanel/Slider/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Path,Sira,Aciklama1,Aciklama2,Aciklama3")] Slider slider, HttpPostedFileBase sliderResim)
        {
            string fileName = string.Empty;

            if (ModelState.IsValid)
            {

                if (sliderResim != null && sliderResim.ContentLength > 0)
                {
                    fileName = Guid.NewGuid() + Path.GetExtension(sliderResim.FileName);

                    sliderResim.SaveAs(Path.Combine(Server.MapPath("/Assets/slider/"), fileName));

                    slider.Path = "/Assets/slider/" + fileName;
                    //db.Entry(new ProjeResim { Path = "/images/Projeler/" + fileName, Sira = sira, ProjeId = proje.Id }).State = EntityState.Modified;

                }
                else
                {

                }
                using (var uow = new UnitOfWork(new GreenpackDbContext()))
                {
                    uow.Slider.Update(slider);
                    await Task.FromResult(uow.Complete());

                    string mesaj = "<script language='javascript' type='text/javascript'>alert('Düzenleme İşlemi Başarıyla Gerçekleşmiştir!');window.location.href = '/abatpanel/slider/edit/" + slider.Id + "';</script>";
                    return Content(mesaj);
                }


            }
            else
            {
                return View(slider);
            }
        }

        // GET: AbatPanel/Slider/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            using (var uow = new UnitOfWork(new GreenpackDbContext()))
            {
                Slider slider = await Task.FromResult(uow.Slider.Where(a => a.Id == id).FirstOrDefault());
                if (slider == null)
                {
                    return HttpNotFound();
                }
                return View(slider);
            }
        }

        // POST: AbatPanel/Slider/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            using (var uow = new UnitOfWork(new GreenpackDbContext()))
            {
                Slider slider = await Task.FromResult(uow.Slider.Where(a => a.Id == id).FirstOrDefault());

                uow.Slider.Delete(slider);

                await Task.FromResult(uow.Complete());

                string mesaj = "<script language='javascript' type='text/javascript'>alert('Silme İşlemi Başarıyla Gerçekleşmiştir!');window.location.href = '/abatpanel/slider/index';</script>";
                return Content(mesaj);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                using (var uow = new UnitOfWork(new GreenpackDbContext()))
                {
                    uow.Dispose();
                }
            }
            base.Dispose(disposing);
        }
    }
}
