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
    [RequireHttps]
    [Authorize(Roles = "Admin,Greenpack")]
    public class HizmetlerimizMenuController : Controller
    {
        private GreenpackDbContext db = new GreenpackDbContext();

        // GET: AbatPanel/HizmetlerimizMenu
        public async Task<ActionResult> Index()
        {
            using (var uow = new UnitOfWork(new GreenpackDbContext()))
            {

                var list = uow.Hizmetlerimiz.GetAllWithInclude().ToList();

                return View(await Task.FromResult(list));
            }
        }

        // GET: AbatPanel/HizmetlerimizMenu/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            using (var uow = new UnitOfWork(new GreenpackDbContext()))
            {
                HizmetlerimizMenu hizmetlerimiz = await Task.FromResult(uow.Hizmetlerimiz.WhereWithInclude(a => a.Id == id).FirstOrDefault());
                if (hizmetlerimiz == null)
                {
                    return HttpNotFound();
                }
                return View(hizmetlerimiz);
            }
        }

        // GET: AbatPanel/HizmetlerimizMenu/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AbatPanel/HizmetlerimizMenu/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,HizmetAdi,HizmetAciklama,Sira")] HizmetlerimizMenu hizmetlerimizMenu, IEnumerable<HttpPostedFileBase> files)
        {
            string fileName = string.Empty;
            short sira = 1;
            if (ModelState.IsValid)
            {

                using (var uow = new UnitOfWork(new GreenpackDbContext()))
                {


                    foreach (var file in files)
                    {
                        if (file != null && file.ContentLength > 0)
                        {
                            fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
                            file.SaveAs(Path.Combine(Server.MapPath("/Assets/hizmetler/"), fileName));
                            uow.Resim.Insert(new Resim { Path = "/Assets/hizmetler/" + fileName, Sira = sira, HizmetlerimizMenuId = hizmetlerimizMenu.Id });
                            //db.Entry(new ProjeResim { Path = "/images/Projeler/" + fileName, Sira = sira, ProjeId = proje.Id }).State = EntityState.Modified;
                            sira++;
                        }
                        else
                        {
                            ViewBag.Mesaj = "Dosya seçmeden işleminize devam etmektesiniz. Lütfen en az 1 Adet Resim Dosyası Seçiniz!";
                            ViewBag.Status = "error";
                            ViewBag.Baslik = "Oops!";
                            return View(hizmetlerimizMenu);
                        }

                    }


                    uow.Hizmetlerimiz.Insert(hizmetlerimizMenu);

                    await Task.FromResult(uow.Complete());

                    ViewBag.Mesaj = "Ekleme Başarılı.";
                    ViewBag.Status = "success";
                    ViewBag.Baslik = "Harika";



                    return View(hizmetlerimizMenu);

                }

            }

            ViewBag.Mesaj = "Hata";
            ViewBag.Status = "error";
            ViewBag.Baslik = "Oops!";

            return View(hizmetlerimizMenu);
        }

        // GET: AbatPanel/HizmetlerimizMenu/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            using (var uow = new UnitOfWork(new GreenpackDbContext()))
            {
                HizmetlerimizMenu hizmetlerimiz = await Task.FromResult(uow.Hizmetlerimiz.WhereWithInclude(a => a.Id == id).FirstOrDefault());
                if (hizmetlerimiz == null)
                {
                    return HttpNotFound();
                }
                return View(hizmetlerimiz);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ResimSil(int? id)
        {
            using (var uow = new UnitOfWork(new GreenpackDbContext()))
            {
                Resim resim = uow.Resim.Where(a => a.Id == id).FirstOrDefault();

                uow.Resim.Delete(resim);

                await Task.FromResult(uow.Complete());

                string mesaj = "<script language='javascript' type='text/javascript'>alert('Düzenleme İşlemi Başarıyla Gerçekleşmiştir!');window.location.href = '/hizmetlerimizmenu/edit/" + resim.HizmetlerimizMenuId + "';</script>";
                return Content(mesaj);
            }

        }


        // POST: AbatPanel/HizmetlerimizMenu/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,HizmetAdi,HizmetAciklama,Sira")] HizmetlerimizMenu hizmetlerimizMenu, ICollection<HttpPostedFileBase> files)
        {
            string fileName = string.Empty;
            short sira = 1;


            if (ModelState.IsValid)
            {
                using (var uow = new UnitOfWork(new GreenpackDbContext()))
                {
                    foreach (var file in files)
                    {
                        if (file != null && file.ContentLength > 0)
                        {
                            fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);

                            file.SaveAs(Path.Combine(Server.MapPath("/Assets/hizmetler/"), fileName));
                            uow.Resim.Insert(new Resim { Path = "/Assets/hizmetler/" + fileName, Sira = sira, HizmetlerimizMenuId = hizmetlerimizMenu.Id });
                            //db.Entry(new ProjeResim { Path = "/images/Projeler/" + fileName, Sira = sira, ProjeId = proje.Id }).State = EntityState.Modified;
                            sira++;
                        }
                        else
                        {

                        }

                    }

                    uow.Hizmetlerimiz.Insert(hizmetlerimizMenu);
                    ViewBag.Mesaj = "Ekleme Başarılı.";
                    ViewBag.Status = "success";
                    ViewBag.Baslik = "Harika";
                    uow.Hizmetlerimiz.Update(hizmetlerimizMenu);
                    await Task.FromResult(uow.Complete());
                    string mesaj = "<script language='javascript' type='text/javascript'>alert('Düzenleme İşlemi Başarıyla Gerçekleşmiştir!');window.location.href = '/hizmetlerimizmenu/edit/" + hizmetlerimizMenu.Id + "';</script>";
                    return Content(mesaj);
                }

            }
            ViewBag.Mesaj = "Hata";
            ViewBag.Status = "error";
            ViewBag.Baslik = "Oops!";

            return View(hizmetlerimizMenu);

        }

        // GET: AbatPanel/HizmetlerimizMenu/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            using (var uow = new UnitOfWork(new GreenpackDbContext()))
            {
                HizmetlerimizMenu hizmetlerimiz = await Task.FromResult(uow.Hizmetlerimiz.WhereWithInclude(a => a.Id == id).FirstOrDefault());
                if (hizmetlerimiz == null)
                {
                    return HttpNotFound();
                }
                return View(hizmetlerimiz);
            }
        }

        // POST: AbatPanel/HizmetlerimizMenu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            using (var uow = new UnitOfWork(new GreenpackDbContext()))
            {
                HizmetlerimizMenu hizmetlerimiz = await Task.FromResult(uow.Hizmetlerimiz.WhereWithInclude(a => a.Id == id).FirstOrDefault());

                uow.Hizmetlerimiz.Delete(hizmetlerimiz);
                await Task.FromResult(uow.Complete());
                string mesaj = "<script language='javascript' type='text/javascript'>alert('Silme İşlemi Başarıyla Gerçekleşmiştir!');window.location.href = '/abatpanel/hizmetlerimizmenu/index';</script>";
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
