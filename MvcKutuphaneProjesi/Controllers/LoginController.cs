using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphaneProjesi.Models.Entity;
using System.Web.Security;

namespace MvcKutuphaneProjesi.Controllers
{
    public class LoginController : Controller
    {
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        // GET: Login
        [HttpGet]
        public ActionResult GirisYap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GirisYap(TBLUYELER p)
        {
            var bilgiler = db.TBLUYELERs.FirstOrDefault(x => x.uye_mail == p.uye_mail && x.uye_sifre == p.uye_sifre);
            if (bilgiler != null)
            {

                //bilgiler uyşuyorsa tempdata ile bu verileri taşı kullanıcı panelindeki Index kısmına 
                FormsAuthentication.SetAuthCookie(bilgiler.uye_mail, false);
                Session["mail"] = bilgiler.uye_mail.ToString();
                TempData["ad"] = bilgiler.uye_ad.ToString();
                TempData["soyad"] = bilgiler.uye_soyad.ToString();
                TempData["kullanıcıadı"] = bilgiler.uye_kullaniciadi.ToString();
                TempData["sifre"] = bilgiler.uye_sifre.ToString();
                TempData["foto"] = bilgiler.uye_fotograf.ToString();
                TempData["okul"] = bilgiler.uye_okul.ToString();
                return RedirectToAction("Index", "PanelOgrenci");

            }
            else
            {
                return View();
            }


        }
    }
}