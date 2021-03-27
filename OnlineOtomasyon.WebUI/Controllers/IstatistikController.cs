using OnlineOtomasyon.Business.Abstract;
using OnlineOtomasyon.Business.Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineOtomasyon.WebUI.Controllers
{
    public class IstatistikController : Controller
    {
        
        IPersonelService personelServis;
        IMusteriService musteriServis;
        IUrunService urunServis;
        IKategoriService kategoriServis;
        IFaturaService faturaServis;
        IAdminService adminServis;

        public IstatistikController()
        {
            personelServis = InstanceFactory.GetInstance<IPersonelService>();
            musteriServis = InstanceFactory.GetInstance<IMusteriService>();
            urunServis = InstanceFactory.GetInstance<IUrunService>();
            kategoriServis = InstanceFactory.GetInstance<IKategoriService>();
            faturaServis = InstanceFactory.GetInstance<IFaturaService>();
            adminServis = InstanceFactory.GetInstance<IAdminService>();

            ViewBag.personelSayisi = personelServis.List(null).Count();
            ViewBag.musteriSayisi = musteriServis.List(null).Count();
            ViewBag.urunSayisi = urunServis.List(null).Count();
            ViewBag.kategoriSayisi = kategoriServis.List(null).Count();
            ViewBag.faturaSayisi = faturaServis.List(null).Count();
            ViewBag.enYuksek = urunServis.List(null).Max(c => c.SatisFiyat);
            ViewBag.enDusuk = urunServis.List(null).Min(c => c.SatisFiyat);
            ViewBag.adminSayisi = adminServis.List(null).Count();

        }

        public ActionResult Index()
        {
            return View();
        }
    }
}