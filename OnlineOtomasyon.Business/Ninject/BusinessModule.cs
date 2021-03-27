using Ninject.Modules;
using OnlineOtomasyon.Business.Abstract;
using OnlineOtomasyon.Business.Concrete;
using OnlineOtomasyon.DataAccess.Abstract;
using OnlineOtomasyon.DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineOtomasyon.Business.Ninject
{
    public class BusinessModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IAdminService>().To<AdminManager>().InTransientScope();
            Bind<IAdminDal>().To<AdminDal>().InTransientScope();

            Bind<IDepartmanService>().To<DepartmanManager>().InTransientScope();
            Bind<IDepartmanDal>().To<DepartmanDal>().InTransientScope();

            Bind<IFaturaKalemService>().To<FaturaKalemManager>().InTransientScope();
            Bind<IFaturaKalemDal>().To<FaturaKalemDal>().InTransientScope();

            Bind<IFaturaService>().To<FaturaManager>().InTransientScope();
            Bind<IFaturaDal>().To<FaturaDal>().InTransientScope();

            Bind<IGiderService>().To<GiderManager>().InTransientScope();
            Bind<IGiderDal>().To<GiderDal>().InTransientScope();

            Bind<IKategoriService>().To<KategoriManager>().InTransientScope();
            Bind<IKategoriDal>().To<KategoriDal>().InTransientScope();

            Bind<IMusteriService>().To<MusteriManager>().InTransientScope();
            Bind<IMusteriDal>().To<MusteriDal>().InTransientScope();

            Bind<IPersonelService>().To<PersonelManager>().InTransientScope();
            Bind<IPersonelDal>().To<PersonelDal>().InTransientScope();

            Bind<ISatisHareketService>().To<SatisHareketManager>().InTransientScope();
            Bind<ISatisHareketDal>().To<SatisHareketDal>().InTransientScope();

            Bind<IUrunService>().To<UrunManager>().InTransientScope();
            Bind<IUrunDal>().To<UrunDal>().InTransientScope();
        }
    }
}
