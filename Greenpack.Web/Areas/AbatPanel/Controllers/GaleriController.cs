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
    public class GaleriController : Controller
    {


        // GET: AbatPanel/Galeri
        public async Task<ActionResult> Index()
        {

            using (var uow = new UnitOfWork(new GreenpackDbContext()))
            {

                var list = uow.Galeri.GetAllWithInclude().ToList();

                return View(await Task.FromResult(list));
            }

        }

        // GET: AbatPanel/Galeri/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            using (var uow = new UnitOfWork(new GreenpackDbContext()))
            {
                Galeri galeri = await Task.FromResult(uow.Galeri.WhereWithInclude(a => a.Id == id).FirstOrDefault());
                if (galeri == null)
                {
                    return HttpNotFound();
                }
                return View(galeri);
            }

        }

        // GET: AbatPanel/Galeri/Create
        public ActionResult Create()
        {
            var uow = new UnitOfWork(new GreenpackDbContext());
            ViewBag.GaleriFilterId = new SelectList(uow.GaleriFilter.GetAll(), "Id", "FilterName");
            return View();
        }

        // POST: AbatPanel/Galeri/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Path,Sira,ResimTip,Aciklama,GaleriFilterId")] Galeri galeri, HttpPostedFileBase file)
        {
            using (var uow = new UnitOfWork(new GreenpackDbContext()))
            {
                if (ModelState.IsValid)
                {

                    string fileName = string.Empty;



                    if (file != null && file.ContentLength > 0 && file.ContentLength < 2 * 1024 * 1024)
                    {
                        fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
                        file.SaveAs(Path.Combine(Server.MapPath("/Assets/galeri/"), fileName));
                        uow.Galeri.Insert(new Galeri
                        {
                            Path = "/Assets/galeri/" + fileName,
                            Sira = galeri.Sira,
                            Aciklama = galeri.Aciklama,
                            GaleriFilterId = galeri.GaleriFilterId

                        });
                        //db.Entry(new ProjeResim { Path = "/images/Projeler/" + fileName, Sira = sira, ProjeId = proje.Id }).State = EntityState.Modified;

                    }
                    else
                    {

                        ViewBag.GaleriFilterId = new SelectList(uow.GaleriFilter.GetAll(), "Id", "FilterName", galeri.GaleriFilterId);
                        ViewBag.Mesaj = "Dosya seçmeden işleminize devam etmektesiniz. Lütfen 1 Adet Resim Dosyası Seçiniz!";
                        ViewBag.Status = "error";
                        ViewBag.Baslik = "Oops!";

                        return View(galeri);
                    }


                    ViewBag.GaleriFilterId = new SelectList(uow.GaleriFilter.GetAll(), "Id", "FilterName", galeri.GaleriFilterId);
                    await Task.FromResult(uow.Complete());
                    ViewBag.Mesaj = "Ekleme Başarılı.";
                    ViewBag.Status = "success";
                    ViewBag.Baslik = "Harika";

                    return View(galeri);
                }
                else
                {
                    ViewBag.GaleriFilterId = new SelectList(uow.GaleriFilter.GetAll(), "Id", "FilterName", galeri.GaleriFilterId);
                    ViewBag.Mesaj = "Hata";
                    ViewBag.Status = "error";
                    ViewBag.Baslik = "Oops!";
                    return View(galeri);
                }
            }

        }

        // GET: AbatPanel/Galeri/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var uow = new UnitOfWork(new GreenpackDbContext());


            Galeri galeri = await Task.FromResult(uow.Galeri.WhereWithInclude(a => a.Id == id).FirstOrDefault());
            if (galeri == null)
            {
                return HttpNotFound();
            }
            ViewBag.GaleriFilterId = new SelectList(uow.GaleriFilter.GetAll().ToList(), "Id", "FilterName", galeri.GaleriFilterId);
            return View(galeri);

        }

        // POST: AbatPanel/Galeri/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Path,Sira,ResimTip,Aciklama,GaleriFilterId")] Galeri galeri, HttpPostedFileBase file)
        {
            string fileName = string.Empty;
            using (var uow = new UnitOfWork(new GreenpackDbContext()))
            {
                if (ModelState.IsValid)
                {

                    if (file != null && file.ContentLength > 0)
                    {
                        fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);

                        file.SaveAs(Path.Combine(Server.MapPath("/Assets/galeri/"), fileName));

                        galeri.Path = "/Assets/galeri/" + fileName;
                        //db.Entry(new ProjeResim { Path = "/images/Projeler/" + fileName, Sira = sira, ProjeId = proje.Id }).State = EntityState.Modified;

                    }
                    else
                    {

                    }

                    uow.Galeri.Update(galeri);
                    await Task.FromResult(uow.Complete());

                    ViewBag.GaleriFilterId = new SelectList(uow.GaleriFilter.GetAll(), "Id", "FilterName", galeri.GaleriFilterId);

                    string mesaj = "<script language='javascript' type='text/javascript'>alert('Düzenleme İşlemi Başarıyla Gerçekleşmiştir!');window.location.href = '/abatpanel/galeri/edit/" + galeri.Id + "';</script>";
                    return Content(mesaj);



                }
                else
                {
                    ViewBag.GaleriFilterId = new SelectList(uow.GaleriFilter.GetAll(), "Id", "FilterName", galeri.GaleriFilterId);
                    return View(galeri);
                }
            }


        }

        // GET: AbatPanel/Galeri/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            using (var uow = new UnitOfWork(new GreenpackDbContext()))
            {
                Galeri galeri = await Task.FromResult(uow.Galeri.WhereWithInclude(a => a.Id == id).FirstOrDefault());
                if (galeri == null)
                {
                    return HttpNotFound();
                }
                return View(galeri);
            }
        }

        // POST: AbatPanel/Galeri/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {

            using (var uow = new UnitOfWork(new GreenpackDbContext()))
            {
                Galeri galeri = await Task.FromResult(uow.Galeri.WhereWithInclude(a => a.Id == id).FirstOrDefault());

                uow.Galeri.Delete(galeri);

                await Task.FromResult(uow.Complete());

                string mesaj = "<script language='javascript' type='text/javascript'>alert('Silme İşlemi Başarıyla Gerçekleşmiştir!');window.location.href = '/abatpanel/galeri/index';</script>";
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
