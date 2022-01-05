using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphaneProjesi.Models.Entity;

namespace MvcKutuphaneProjesi.Controllers
{
    public class OduncController : Controller
    {
        // GET: Odunc
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        public ActionResult Index()
        {
            var degerler = db.TBLHAREKETs.Where(x=>x.TBLKITAP.kitap_durum==false).ToList();

            return View(degerler);
        }
        [HttpGet]
        public ActionResult OduncVer()
        {
            return View();
        }
        [HttpPost]
        public ActionResult OduncVer(TBLHAREKET p)
        {
            db.TBLHAREKETs.Add(p);
            db.SaveChanges();
            return View();
        }

      
        
        public ActionResult Odunciade(int id)
        {
            var odn = db.TBLHAREKETs.Find(id);
            return View("Odunciade", odn);
        }

        public ActionResult OduncGuncelle(TBLHAREKET h)
        {
            var odn = db.TBLHAREKETs.Find(h.hareket_id);
            odn.hareket_uyeningetirdigitarih = h.hareket_uyeningetirdigitarih;
            odn.TBLKITAP.kitap_durum = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}