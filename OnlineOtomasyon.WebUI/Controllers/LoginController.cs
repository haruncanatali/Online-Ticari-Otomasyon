using OnlineOtomasyon.Business.Abstract;
using OnlineOtomasyon.Business.Ninject;
using OnlineOtomasyon.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace OnlineOtomasyon.WebUI.Controllers
{
    public class LoginController : Controller
    {

        IAdminService adminServis;

        public LoginController()
        {
            adminServis = InstanceFactory.GetInstance<IAdminService>();
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View(new Admin());
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult GirisYap(Admin admin)
        {
            var entity = adminServis.Get(c => c.KullaniciAdi == admin.KullaniciAdi && c.Sifre == admin.Sifre);
            if (entity!=null)
            {
                FormsAuthentication.SetAuthCookie(admin.KullaniciAdi, false); // ikinci parametre beni hatırla olması lazım
                Session["durum"] = "tamam";
                return Redirect("/Home/Index");
            }
            else
            {
                ViewBag.errorMessages = "Kullanıcı adı veya parola hatalı!";
                return View("Index", admin);
            }
        }

        [HttpGet]
        public ActionResult CikisYap()
        {
            FormsAuthentication.SignOut();
            Session.RemoveAll();
            return RedirectToAction("Index");
        }
    }
}