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

namespace Greenpack.Web.Areas.AbatPanel.Controllers
{
    public class IletisimController : Controller
    {
        private GreenpackDbContext db = new GreenpackDbContext();

        // GET: AbatPanel/Iletisim
        public async Task<ActionResult> Index()
        {
            using (var uow = new UnitOfWork(new GreenpackDbContext()))
            {

                var list = uow.Iletisim.Where(a=>a.OkunduMu == false).ToList();

                return View(await Task.FromResult(list));
            }
        }

        public async Task<ActionResult> OkunanMesajlar()
        {
            using (var uow = new UnitOfWork(new GreenpackDbContext()))
            {

                var list = uow.Iletisim.Where(a => a.OkunduMu == true).ToList();

                return View(await Task.FromResult(list));
            }
        }

        // GET: AbatPanel/Iletisim/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            using (var uow = new UnitOfWork(new GreenpackDbContext()))
            {
                Iletisim iletisim = await Task.FromResult(uow.Iletisim.Where(a => a.Id == id).FirstOrDefault());
                iletisim.OkunduMu = true;
                await Task.FromResult(uow.Complete());
                if (iletisim == null)
                {
                    return HttpNotFound();
                }
                return View(iletisim);
            }
        }

        // GET: AbatPanel/Iletisim/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AbatPanel/Iletisim/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,AdiSoyadi,Eposta,Mesaj,OkunduMu")] Iletisim iletisim)
        {
            if (ModelState.IsValid)
            {
                using (var uow = new UnitOfWork(new GreenpackDbContext()))
                {

                    uow.Iletisim.Insert(new Iletisim
                    {
                        AdiSoyadi = iletisim.AdiSoyadi,
                        Eposta = iletisim.Eposta,
                        Mesaj = iletisim.Mesaj,
                        OkunduMu = iletisim.OkunduMu
                    });


                    await Task.FromResult(uow.Complete());
                    ViewBag.Mesaj = "Ekleme Başarılı.";
                    ViewBag.Status = "success";
                    ViewBag.Baslik = "Harika";

                    return View(iletisim);
                }


            }
            else
            {
                ViewBag.Mesaj = "Hata";
                ViewBag.Status = "error";
                ViewBag.Baslik = "Oops!";
                return View(iletisim);
            }
        }

        // GET: AbatPanel/Iletisim/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            using (var uow = new UnitOfWork(new GreenpackDbContext()))
            {
                Iletisim iletisim = await Task.FromResult(uow.Iletisim.Where(a => a.Id == id).FirstOrDefault());
                if (iletisim == null)
                {
                    return HttpNotFound();
                }
                return View(iletisim);
            }
        }

        // POST: AbatPanel/Iletisim/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,AdiSoyadi,Eposta,Mesaj,OkunduMu")] Iletisim iletisim)
        {
            if (ModelState.IsValid)
            {
                using (var uow = new UnitOfWork(new GreenpackDbContext()))
                {
                    uow.Iletisim.Update(iletisim);
                    await Task.FromResult(uow.Complete());

                    string mesaj = "<script language='javascript' type='text/javascript'>alert('Düzenleme İşlemi Başarıyla Gerçekleşmiştir!');window.location.href = '/abatpanel/iletisim/edit/" + iletisim.Id + "';</script>";
                    return Content(mesaj);
                }
            }
            return View(iletisim);
        }

        // GET: AbatPanel/Iletisim/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            using (var uow = new UnitOfWork(new GreenpackDbContext()))
            {
                Iletisim iletisim = await Task.FromResult(uow.Iletisim.Where(a => a.Id == id).FirstOrDefault());
                if (iletisim == null)
                {
                    return HttpNotFound();
                }
                return View(iletisim);
            }
        }

        // POST: AbatPanel/Iletisim/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            using (var uow = new UnitOfWork(new GreenpackDbContext()))
            {
                Iletisim iletisim = await Task.FromResult(uow.Iletisim.Where(a => a.Id == id).FirstOrDefault());

                uow.Iletisim.Delete(iletisim);

                await Task.FromResult(uow.Complete());

                string mesaj = "<script language='javascript' type='text/javascript'>alert('Silme İşlemi Başarıyla Gerçekleşmiştir!');window.location.href = '/abatpanel/KurumsalMenu/index';</script>";
                return Content(mesaj);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
