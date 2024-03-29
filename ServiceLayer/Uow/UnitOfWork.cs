﻿using DataAccessLayer.Context;
using ServiceLayer.Repository.GaleriFilterRepository;
using ServiceLayer.Repository.GaleriRepository;
using ServiceLayer.Repository.HizmetlerimizRepository;
using ServiceLayer.Repository.IletisimRepository;
using ServiceLayer.Repository.KurumsalRepository;
using ServiceLayer.Repository.ResimRepository;
using ServiceLayer.Repository.SliderRepository;

namespace ServiceLayer.Uow
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly GreenpackDbContext _context;

        public UnitOfWork(GreenpackDbContext context)
        {
            _context = context;
            Galeri = new GaleriRepository(_context);
            Hizmetlerimiz = new HizmetlerimizRepository(_context);
            Kurumsal = new KurumsalRepository(_context);
            Resim = new ResimRepository(_context);
            Slider = new SliderRepository(_context);
            GaleriFilter = new GaleriFilterRepository(_context);
            Iletisim = new IletisimRepository(_context);

        }

        
        public IGaleriRepository Galeri { get; private set; }
        public IHizmetlerRepository Hizmetlerimiz { get; private set; }
        public IKurumsalRepository Kurumsal { get; private set; }
        public ISliderRepository Slider { get; private set; }
        public IResimRepository Resim { get; private set; }
        public IGaleriFilterRepository GaleriFilter { get; private set; }
        public IIletisimRepository Iletisim { get; private set; }


        public int Complete()
        {
            return  _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}