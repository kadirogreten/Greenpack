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
    public class GaleriFilterController : Controller
    {
        private GreenpackDbContext db = new GreenpackDbContext();

        // GET: AbatPanel/GaleriFilter
        public async Task<ActionResult> Index()
        {
            using (var uow = new UnitOfWork(new GreenpackDbContext()))
            {

                var list = uow.GaleriFilter.GetAll().ToList();

                return View(await Task.FromResult(list));
            }
        }

        // GET: AbatPanel/GaleriFilter/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            using (var uow = new UnitOfWork(new GreenpackDbContext()))
            {
                GaleriFilter filter = await Task.FromResult(uow.GaleriFilter.Where(a => a.Id == id).FirstOrDefault());
                if (filter == null)
                {
                    return HttpNotFound();
                }
                return View(filter);
            }
        }

        // GET: AbatPanel/GaleriFilter/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AbatPanel/GaleriFilter/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,FilterName")] GaleriFilter galeriFilter)
        {
            if (ModelState.IsValid)
            {
                using (var uow = new UnitOfWork(new GreenpackDbContext()))
                {

                    uow.GaleriFilter.Insert(new GaleriFilter
                    {
                        FilterName = galeriFilter.FilterName
                        
                    });


                    await Task.FromResult(uow.Complete());
                    ViewBag.Mesaj = "Ekleme Başarılı.";
                    ViewBag.Status = "success";
                    ViewBag.Baslik = "Harika";

                    return View(galeriFilter);
                }


            }
            else
            {
                ViewBag.Mesaj = "Hata";
                ViewBag.Status = "error";
                ViewBag.Baslik = "Oops!";
                return View(galeriFilter);
            }
        }

        // GET: AbatPanel/GaleriFilter/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            using (var uow = new UnitOfWork(new GreenpackDbContext()))
            {
                GaleriFilter filter = await Task.FromResult(uow.GaleriFilter.Where(a => a.Id == id).FirstOrDefault());
                if (filter == null)
                {
                    return HttpNotFound();
                }
                return View(filter);
            }
        }

        // POST: AbatPanel/GaleriFilter/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,FilterName")] GaleriFilter galeriFilter)
        {
            if (ModelState.IsValid)
            {
                using (var uow = new UnitOfWork(new GreenpackDbContext()))
                {
                    uow.GaleriFilter.Update(galeriFilter);
                    await Task.FromResult(uow.Complete());

                    string mesaj = "<script language='javascript' type='text/javascript'>alert('Düzenleme İşlemi Başarıyla Gerçekleşmiştir!');window.location.href = '/abatpanel/GaleriFilter/edit/" + galeriFilter.Id + "';</script>";
                    return Content(mesaj);
                }
            }
            return View(galeriFilter);
        }

        // GET: AbatPanel/GaleriFilter/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            using (var uow = new UnitOfWork(new GreenpackDbContext()))
            {
                GaleriFilter filter = await Task.FromResult(uow.GaleriFilter.Where(a => a.Id == id).FirstOrDefault());
                if (filter == null)
                {
                    return HttpNotFound();
                }
                return View(filter);
            }
        }

        // POST: AbatPanel/GaleriFilter/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            using (var uow = new UnitOfWork(new GreenpackDbContext()))
            {
                GaleriFilter filter = await Task.FromResult(uow.GaleriFilter.Where(a => a.Id == id).FirstOrDefault());

                uow.GaleriFilter.Delete(filter);

                await Task.FromResult(uow.Complete());

                string mesaj = "<script language='javascript' type='text/javascript'>alert('Silme İşlemi Başarıyla Gerçekleşmiştir!');window.location.href = '/abatpanel/GaleriFilter/index';</script>";
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
