using OnlineOtomasyon.Business.Abstract;
using OnlineOtomasyon.Business.Ninject;
using OnlineOtomasyon.Entities.Concrete;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineOtomasyon.WebUI.Controllers
{
    public class UrunController : Controller
    {
        IUrunService urunServis;
        IKategoriService kategoriServis;
        List<SelectListItem> kategoriDegerleri;

        public UrunController()
        {
            urunServis = InstanceFactory.GetInstance<IUrunService>();
            kategoriServis = InstanceFactory.GetInstance<IKategoriService>();

            kategoriDegerleri = (from x in kategoriServis.List(null)
                                 select new SelectListItem
                                 {
                                     Text = x.KategoriAdi,
                                     Value = x.Id.ToString()
                                 }).ToList();
            ViewBag.kategoriDegerleri = this.kategoriDegerleri;
        }

        public ActionResult Index(int sayfa=1)
        {
            return View(urunServis.List(null).ToPagedList(sayfa,5));
        }

        [HttpGet]
        public ActionResult Guncelle(int id)
        {
            var entity = urunServis.Get(c => c.Id == id);
            return View(entity);
        }

        [HttpPost]
        public ActionResult Guncelle(Urun entity, HttpPostedFileBase dosya,string gorselYolu)
        {
            if (dosya != null && dosya.ContentLength > 0)
            {
                dosya.SaveAs(Server.MapPath("~/Content/Img/" + dosya.FileName));
                entity.Gorsel = dosya.FileName;
            }
            else
            {
                entity.Gorsel = gorselYolu;
            }
            try
            {
                entity.Durum = entity.Stok > 0 ? true : false;
                urunServis.Update(entity);
                return RedirectToAction("Index", urunServis.List(null));
            }
            catch (Exception ex)
            {
                ViewBag.errorMessages = ex.Message.ToString().Substring(22, ex.Message.Length - 22);
                return View("Index", urunServis.List(null));
            }
        }

        [HttpGet]
        public ActionResult Ekle()
        {
            return View(new Urun());
        }
        [HttpPost]
        public ActionResult Ekle(Urun entity,HttpPostedFileBase dosya)
        {

            if(dosya!=null && dosya.ContentLength > 0)
            {
                dosya.SaveAs(Server.MapPath("~/Content/Img/" + dosya.FileName));
                entity.Gorsel = dosya.FileName;
            }
            try
            {
                entity.Durum = entity.Stok > 0 ? true : false;
                urunServis.Add(entity);
                return RedirectToAction("Index", urunServis.List(null));
            }
            catch (Exception ex)
            {
                ViewBag.errorMessages = ex.Message.ToString().Substring(22, ex.Message.Length - 22);
                return View("Index", urunServis.List(null));
            }
        }
        [HttpGet]
        public ActionResult Sil(int id)
        {
            try
            {
                urunServis.Delete(urunServis.Get(c => c.Id == id));
                return RedirectToAction("Index", urunServis.List(null));
            }
            catch (Exception)
            {
                return View("Index", urunServis.List(null));
            }
        }
    }
}