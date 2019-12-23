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
    [RequireHttps]
    [Authorize(Roles = "Admin,Greenpack")]
    public class KurumsalMenuController : Controller
    {
        // GET: AbatPanel/KurumsalMenu
        public async Task<ActionResult> Index()
        {
            using (var uow = new UnitOfWork(new GreenpackDbContext()))
            {

                var list = uow.Kurumsal.GetAll().ToList();

                return View(await Task.FromResult(list));
            }
        }

        // GET: AbatPanel/KurumsalMenu/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            using (var uow = new UnitOfWork(new GreenpackDbContext()))
            {
                KurumsalMenu kurumsal = await Task.FromResult(uow.Kurumsal.Where(a => a.Id == id).FirstOrDefault());
                if (kurumsal == null)
                {
                    return HttpNotFound();
                }
                return View(kurumsal);
            }
        }

        // GET: AbatPanel/KurumsalMenu/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AbatPanel/KurumsalMenu/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public async Task<ActionResult> Create([Bind(Include = "Id,MenuAdi,Baslik,AltBaslik,Detay,Sira")] KurumsalMenu kurumsalMenu)
        {
            if (ModelState.IsValid)
            {
                using (var uow = new UnitOfWork(new GreenpackDbContext()))
                {

                    uow.Kurumsal.Insert(new KurumsalMenu
                    {
                        MenuAdi = kurumsalMenu.MenuAdi,
                        Baslik = kurumsalMenu.Baslik,
                        AltBaslik = kurumsalMenu.AltBaslik,
                        Detay = kurumsalMenu.Detay,
                        Sira = kurumsalMenu.Sira
                    });


                    await Task.FromResult(uow.Complete());
                    ViewBag.Mesaj = "Ekleme Başarılı.";
                    ViewBag.Status = "success";
                    ViewBag.Baslik = "Harika";

                    return View(kurumsalMenu);
                }


            }
            else
            {
                ViewBag.Mesaj = "Hata";
                ViewBag.Status = "error";
                ViewBag.Baslik = "Oops!";
                return View(kurumsalMenu);
            }
        }

        // GET: AbatPanel/KurumsalMenu/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            using (var uow = new UnitOfWork(new GreenpackDbContext()))
            {
                KurumsalMenu kurumsal = await Task.FromResult(uow.Kurumsal.Where(a => a.Id == id).FirstOrDefault());
                if (kurumsal == null)
                {
                    return HttpNotFound();
                }
                return View(kurumsal);
            }
        }

        // POST: AbatPanel/KurumsalMenu/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public async Task<ActionResult> Edit([Bind(Include = "Id,MenuAdi,Baslik,AltBaslik,Detay,Sira")] KurumsalMenu kurumsalMenu)
        {
            if (ModelState.IsValid)
            {
                using (var uow = new UnitOfWork(new GreenpackDbContext()))
                {
                    uow.Kurumsal.Update(kurumsalMenu);
                    await Task.FromResult(uow.Complete());

                    string mesaj = "<script language='javascript' type='text/javascript'>alert('Düzenleme İşlemi Başarıyla Gerçekleşmiştir!');window.location.href = '/abatpanel/kurumsalmenu/edit/" + kurumsalMenu.Id + "';</script>";
                    return Content(mesaj);
                }
            }
            return View(kurumsalMenu);
        }

        // GET: AbatPanel/KurumsalMenu/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            using (var uow = new UnitOfWork(new GreenpackDbContext()))
            {
                KurumsalMenu kurumsal = await Task.FromResult(uow.Kurumsal.Where(a => a.Id == id).FirstOrDefault());
                if (kurumsal == null)
                {
                    return HttpNotFound();
                }
                return View(kurumsal);
            }
        }

        // POST: AbatPanel/KurumsalMenu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            using (var uow = new UnitOfWork(new GreenpackDbContext()))
            {
                KurumsalMenu kurumsal = await Task.FromResult(uow.Kurumsal.Where(a => a.Id == id).FirstOrDefault());

                uow.Kurumsal.Delete(kurumsal);

                await Task.FromResult(uow.Complete());

                string mesaj = "<script language='javascript' type='text/javascript'>alert('Silme İşlemi Başarıyla Gerçekleşmiştir!');window.location.href = '/abatpanel/KurumsalMenu/index';</script>";
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
