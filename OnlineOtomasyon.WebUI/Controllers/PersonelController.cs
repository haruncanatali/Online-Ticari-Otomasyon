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
    public class PersonelController : Controller
    {
        IPersonelService personelServis;
        IDepartmanService departmanServis;
        List<SelectListItem> departmanListesi;

        public PersonelController()
        {
            personelServis = InstanceFactory.GetInstance<IPersonelService>();
            departmanServis = InstanceFactory.GetInstance<IDepartmanService>();

            departmanListesi = (from x in departmanServis.List(null)
                               select new SelectListItem
                               {
                                   Text = x.DepartmanAd,
                                   Value = x.Id.ToString()
                               }).ToList();
        }

        public ActionResult Index(int sayfa = 1)
        {
            return View(personelServis.List(null).ToPagedList(sayfa,5));
        }

        [HttpGet]
        public ActionResult Ekle()
        {
            ViewBag.DepartmanListesi = departmanListesi;
            return View(new Personel());
        }

        [HttpPost]
        public ActionResult Ekle(Personel entity,HttpPostedFileBase dosya)
        {
            if (dosya!=null && dosya.ContentLength>0)
            {
                dosya.SaveAs(Server.MapPath("~/Content/Img/" + dosya.FileName));
                entity.Gorsel = dosya.FileName;
            }
            try
            {
                personelServis.Add(entity);
                return RedirectToAction("Index", personelServis.List(null));
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
            ViewBag.DepartmanListesi = departmanListesi;
            return View(personelServis.Get(c => c.Id == id));
        }

        [HttpPost]
        public ActionResult Guncelle(Personel entity,HttpPostedFileBase dosya,string yol)
        {
            if (dosya!=null && dosya.ContentLength>0)
            {
                dosya.SaveAs(Server.MapPath("~/Content/Img/" + dosya.FileName));
                entity.Gorsel = dosya.FileName;
            }
            else
            {
                entity.Gorsel = yol;
            }

            try
            {
                personelServis.Update(entity);
                return RedirectToAction("Index", personelServis.List(null));
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
                personelServis.Delete(personelServis.Get(c => c.Id == id));
                return RedirectToAction("Index", personelServis.List(null));
            }
            catch (Exception ex)
            {
                ViewBag.errorMessages = ex.Message.ToString().Substring(22, ex.Message.Length - 22);
                return View("Index", personelServis.List(null));
            }
        }
    }
}