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
    public class DepartmanController : Controller
    {
        IDepartmanService departmanServis;
        IPersonelService personelServis;

        public DepartmanController()
        {
            departmanServis = InstanceFactory.GetInstance<IDepartmanService>();
            personelServis = InstanceFactory.GetInstance<IPersonelService>();
        }
        
        public ActionResult Index()
        {
            return View(departmanServis.List(null));
        }
        
        [HttpGet]
        [Route("Detay")]
        public ActionResult Detay(int id)
        {
            ViewBag.DepartmanAdi = departmanServis.Get(c => c.Id == id).DepartmanAd;
            return View(personelServis.List(c=>c.DepartmanId== id));
        }

        [HttpGet]
        public ActionResult Ekle()
        {
            return View(new Departman());
        }

        [HttpPost]
        public ActionResult Ekle(Departman entity)
        {
            try
            {
                departmanServis.Add(entity);
                return RedirectToAction("Index", departmanServis.List(null));
            }
            catch (Exception e)
            {
                ViewBag.errorMessages = e.Message.ToString().Substring(22, e.Message.Length - 22);
                return View("Ekle", entity);
            }
        }

        [HttpGet]
        public ActionResult Sil(int id)
        {
            try
            {
                departmanServis.Delete(departmanServis.Get(c => c.Id == id));
                return RedirectToAction("Index", departmanServis.List(null));
            }
            catch (Exception e)
            {
                ViewBag.errorMessages = e.Message.ToString().Substring(22, e.Message.Length - 22);
                return RedirectToAction("Index", departmanServis.List(null));
            }
        }

        [HttpGet]
        public ActionResult Guncelle(int id)
        {
            return View(departmanServis.Get(c => c.Id == id));
        }

        [HttpPost]
        public ActionResult Guncelle(Departman entity)
        {
            try
            {
                departmanServis.Update(entity);
                return RedirectToAction("Index", departmanServis.List(null));
            }
            catch (Exception e)
            {
                ViewBag.errorMessages = e.Message.ToString().Substring(22, e.Message.Length - 22);
                return RedirectToAction("Guncelle", entity);
            }
        }
    }
}