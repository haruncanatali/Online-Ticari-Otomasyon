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
    public class KategoriController : Controller
    {
        IKategoriService kategoriServis;
        public KategoriController()
        {
            kategoriServis = InstanceFactory.GetInstance<IKategoriService>();
        }
        public ActionResult Index()
        {
            return View(kategoriServis.List(null));
        }

        [HttpGet]
        public ActionResult Guncelle(int id)
        {
            return View(kategoriServis.Get(c => c.Id == id));
        }
        [HttpGet]
        public ActionResult Ekle()
        {
            return View(new Kategori());
        }

        [HttpGet]
        public ActionResult Sil(int id)
        {
            try
            {
                kategoriServis.Delete(kategoriServis.Get(c => c.Id == id));
                return View("Index", kategoriServis.List(null));
            }
            catch (Exception)
            {
                return View("Index", kategoriServis.List(null));
            }
        }

        [HttpPost]
        public ActionResult Guncelle(Kategori entity)
        {
            try
            {
                kategoriServis.Update(entity);
                return View("Index", kategoriServis.List(null));
            }
            catch (Exception)
            {
                return View("Index", kategoriServis.List(null));
            }
        }

        [HttpPost]
        public ActionResult Ekle(Kategori entity)
        {
            try
            {
                kategoriServis.Add(entity);
                return View("Index", kategoriServis.List(null));
            }
            catch (Exception)
            {
                
                return View("Index", kategoriServis.List(null));
            }
        }
    }
}