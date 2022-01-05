using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphaneProjesi.Models.Entity;
using System.Web.Security;

namespace MvcKutuphaneProjesi.Controllers
{
    public class PanelOgrenciController : Controller
    {
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        // GET: PanelOgrenci
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Guncelle()
        {
        var uyemail=(string)Session["mail"];
            var degerler = db.TBLUYELERs.FirstOrDefault(p => p.uye_mail == uyemail);

            return View(degerler);
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("GirisYap", "Login");
        }
    }
}