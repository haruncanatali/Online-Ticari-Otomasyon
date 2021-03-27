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
    public class FaturaController : Controller
    {

        IFaturaService faturaServis;
        IPersonelService personelServis;
        IMusteriService musteriServis;
        IFaturaKalemService faturaKalemServis;
        IUrunService urunServis;

        List<SelectListItem> personelDegerleri;
        List<SelectListItem> musteriDegerleri;
        List<SelectListItem> urunDegerleri;

        public FaturaController()
        {
            faturaServis = InstanceFactory.GetInstance<IFaturaService>();
            faturaKalemServis = InstanceFactory.GetInstance<IFaturaKalemService>();
            personelServis = InstanceFactory.GetInstance<IPersonelService>();
            musteriServis = InstanceFactory.GetInstance<IMusteriService>();
            urunServis = InstanceFactory.GetInstance<IUrunService>();

            personelDegerleri = (from x in personelServis.List(null).OrderBy(c => c.Ad)
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
            urunDegerleri = (from x in urunServis.List(null).OrderBy(c => c.Ad)
                             select new SelectListItem
                             {
                                 Text = x.Ad,
                                 Value = x.Id.ToString()
                             }).ToList();


            ViewBag.personelDegerleri = this.personelDegerleri;
            ViewBag.musteriDegerleri = this.musteriDegerleri;
            ViewBag.urunDegerleri = this.urunDegerleri;

        }

        public ActionResult Index()
        {
            return View(faturaServis.List(null));
        }

        [HttpGet]
        public ActionResult Ekle()
        {
            return View(new Fatura());
        }

        [HttpPost]
        public ActionResult Ekle(Fatura entity)
        {
            try
            {
                entity.Tarih = DateTime.Now;
                faturaServis.Add(entity);
                return RedirectToAction("Index", faturaServis.List(null));
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
            return View(faturaServis.Get(c => c.Id == id));
        }

        [HttpPost]
        public ActionResult Guncelle(Fatura entity)
        {
            try
            {
                faturaServis.Update(entity);
                return RedirectToAction("Index", faturaServis.List(null));
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
                faturaServis.Delete(faturaServis.Get(c => c.Id == id));
                return RedirectToAction("Index", faturaServis.List(null));
            }
            catch (Exception)
            {
                return RedirectToAction("Index", faturaServis.List(null));
            }
        }

        [HttpGet]
        public ActionResult Detay(int id)
        {
            ViewBag.IdDegeri = id;
            return View(faturaKalemServis.List(c => c.FaturaId == id));
        }

        [HttpGet]
        public ActionResult DetayEkle(int id)
        {
            return View(new FaturaKalem { FaturaId=id});
        }

        [HttpPost]
        public ActionResult DetayEkle(FaturaKalem entity)
        {
            try
            {
                faturaKalemServis.Add(entity);
                return RedirectToAction("Detay"+"/"+entity.FaturaId.ToString());
            }
            catch (Exception ex)
            {
                ViewBag.errorMessages = ex.Message.ToString().Substring(22, ex.Message.Length - 22);
                return View("DetayEkle", entity);
            }
        }

        [HttpGet]
        public ActionResult DetayGuncelle(int id)
        {
            return View(faturaKalemServis.Get(c => c.Id == id));
        }

        [HttpPost]
        public ActionResult DetayGuncelle(FaturaKalem entity)
        {
            try
            {
                faturaKalemServis.Update(entity);
                return RedirectToAction("Detay" + "/" + entity.FaturaId.ToString());
            }
            catch (Exception ex)
            {
                ViewBag.errorMessages = ex.Message.ToString().Substring(22, ex.Message.Length - 22);
                return View("DetayGuncelle", entity);
            }
        }

        [HttpGet]
        public ActionResult DetaySil(int id)
        {
            try
            {
                var entity = faturaKalemServis.Get(c => c.Id == id);
                faturaKalemServis.Delete(entity);
                return RedirectToAction("Detay" + "/" + entity.FaturaId.ToString());
            }
            catch (Exception)
            {
                return RedirectToAction("Detay" + "/" + faturaKalemServis.Get(c => c.Id == id).FaturaId.ToString());
            }
        }
    }
}