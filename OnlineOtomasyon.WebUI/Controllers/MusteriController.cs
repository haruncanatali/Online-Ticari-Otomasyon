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
    public class MusteriController : Controller
    {
        IMusteriService musteriServis;

        public MusteriController()
        {
            musteriServis = InstanceFactory.GetInstance<IMusteriService>();
        }

        public ActionResult Index()
        {
            return View(musteriServis.List(null));
        }

        [HttpGet]
        public ActionResult Ekle()
        {
            return View(new Musteri());
        }

        [HttpPost]
        public ActionResult Ekle(Musteri entity)
        {
            try
            {
                musteriServis.Add(entity);
                return RedirectToAction("Index", musteriServis.List(null));
            }
            catch (Exception e)
            {
                ViewBag.errorMessages = e.Message.ToString().Substring(22, e.Message.Length - 22);
                return View("Ekle", entity);
            }
        }

        [HttpGet]
        public ActionResult Guncelle(int id)
        {
            return View(musteriServis.Get(c=>c.Id == id));
        }

        [HttpPost]
        public ActionResult Guncelle(Musteri entity)
        {
            try
            {
                musteriServis.Update(entity);
                return RedirectToAction("Index", musteriServis.List(null));
            }
            catch (Exception e)
            {
                ViewBag.errorMessages = e.Message.ToString().Substring(22, e.Message.Length - 22);
                return View("Guncelle", entity);
            }
        }

        [HttpGet]
        public ActionResult Sil(int id)
        {
            try
            {
                musteriServis.Delete(musteriServis.Get(c=>c.Id == id));
                return RedirectToAction("Index", musteriServis.List(null));
            }
            catch (Exception)
            {
                return RedirectToAction("Index", musteriServis.List(null));
            }
        }
    }
}