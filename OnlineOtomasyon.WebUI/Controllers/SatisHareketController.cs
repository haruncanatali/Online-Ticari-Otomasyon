using OnlineOtomasyon.Business.Abstract;
using OnlineOtomasyon.Business.Ninject;
using OnlineOtomasyon.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineOtomasyon.WebUI.Controllers
{
    public class SatisHareketController : Controller
    {
        
        ISatisHareketService satisHareketServis;
        IUrunService urunServis;
        IPersonelService personelServis;
        IMusteriService musteriServis;

        List<SelectListItem> urunDegerleri;
        List<SelectListItem> personelDegerleri;
        List<SelectListItem> musteriDegerleri;

        public SatisHareketController()
        {
            satisHareketServis = InstanceFactory.GetInstance<ISatisHareketService>();
            urunServis = InstanceFactory.GetInstance<IUrunService>();
            personelServis = InstanceFactory.GetInstance<IPersonelService>();
            musteriServis = InstanceFactory.GetInstance<IMusteriService>();

            urunDegerleri = (from x in urunServis.List(null).OrderBy(c => c.Ad)
                             select new SelectListItem
                             {
                                
                                 Text = x.Ad,
                                 Value = x.Id.ToString()

                             }).ToList();
            personelDegerleri = (from x in personelServis.List(null).OrderBy(c=>c.Ad)
                             select new SelectListItem
                             {

                                 Text = x.Ad+" "+x.Soyad,
                                 Value = x.Id.ToString()

                             }).ToList();
            musteriDegerleri = (from x in musteriServis.List(null).OrderBy(c => c.Ad)
                                select new SelectListItem
                                 {

                                     Text = x.Ad + " " + x.Soyad,
                                     Value = x.Id.ToString()

                                 }).ToList();

            ViewBag.urunDegerleri = this.urunDegerleri;
            ViewBag.personelDegerleri = this.personelDegerleri;
            ViewBag.musteriDegerleri = this.musteriDegerleri;
        }

        public ActionResult Index()
        {
            return View(satisHareketServis.List(null));
        }

        [HttpGet]
        public ActionResult Ekle()
        {
            return View(new SatisHareket());
        }

        [HttpPost]
        public ActionResult Ekle(SatisHareket entity)
        {
            try
            {
                entity.Tarih = DateTime.Now;
                satisHareketServis.Add(entity);
                return RedirectToAction("Index", satisHareketServis.List(null));
            }
            catch (Exception ex)
            {
                ViewBag.errorMessages = ex.Message.ToString().Substring(22, ex.Message.Length - 22);
                return View("Ekle", entity);
            }
        }

        [HttpGet]
        public ActionResult Guncelle(int id)
        {
            return View(satisHareketServis.Get(c => c.Id == id));
        }
        [HttpPost]
        public ActionResult Guncelle(SatisHareket entity)
        {
            try
            {
                satisHareketServis.Update(entity);
                return RedirectToAction("Index", satisHareketServis.List(null));
            }
            catch (Exception ex)
            {
                ViewBag.errorMessages = ex.Message.ToString().Substring(22, ex.Message.Length - 22);
                return View("Guncelle", entity);
            }
        }
        [HttpGet]
        public ActionResult Sil(int id)
        {
            try
            {
                satisHareketServis.Delete(satisHareketServis.Get(c => c.Id == id));
                return RedirectToAction("Index", satisHareketServis.List(null));
            }
            catch (Exception)
            {
                return RedirectToAction("Index", satisHareketServis.List(null));
            }
        }

        [HttpGet]
        public ActionResult PersonelDetay(int id)
        {
            return View("Index", satisHareketServis.List(c => c.PersonelId == id));
        }

        [HttpGet]
        public ActionResult MusteriDetay(int id)
        {
            return View("Index", satisHareketServis.List(c => c.MusteriId == id));
        }
    }
}