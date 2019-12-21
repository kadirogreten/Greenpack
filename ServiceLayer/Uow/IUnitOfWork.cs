using ServiceLayer.Repository.GaleriFilterRepository;
using ServiceLayer.Repository.GaleriRepository;
using ServiceLayer.Repository.HizmetlerimizRepository;
using ServiceLayer.Repository.IletisimRepository;
using ServiceLayer.Repository.KurumsalRepository;
using ServiceLayer.Repository.ResimRepository;
using ServiceLayer.Repository.SliderRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ServiceLayer.Uow
{
    public interface IUnitOfWork : IDisposable
    {

        IGaleriRepository Galeri { get; }
        IHizmetlerRepository Hizmetlerimiz { get; }
        IKurumsalRepository Kurumsal { get; }
        ISliderRepository Slider { get; }
        IResimRepository Resim { get; }
        IGaleriFilterRepository GaleriFilter { get; }
        IIletisimRepository Iletisim { get; }


        int Complete();
    }
}
