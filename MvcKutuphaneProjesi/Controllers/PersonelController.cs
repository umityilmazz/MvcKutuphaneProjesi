using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphaneProjesi.Models.Entity;

namespace MvcKutuphaneProjesi.Controllers
{
    public class PersonelController : Controller
    {
        // GET: Personel
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        public ActionResult Index()
        {
            var degerler = db.TBLPERSONELs.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult PersonelEkle()
        {
            return View();
        }


        [HttpPost]
        public ActionResult PersonelEkle(TBLPERSONEL prs)
        {
            if(!ModelState.IsValid)
            {
                return View("PersonelEkle");
            }
            db.TBLPERSONELs.Add(prs);
            db.SaveChanges();
            return View();
        }
        public ActionResult PersonelSil(int id)
        {
            var silinecek_personel = db.TBLPERSONELs.Find(id);
            db.TBLPERSONELs.Remove(silinecek_personel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult PersonelGetir(int id)
        {
            var getirilecek_id = db.TBLPERSONELs.Find(id);

            db.SaveChanges();
            return View("PersonelGetir", getirilecek_id);
        }

        public ActionResult PersonelGuncelle(TBLPERSONEL p)
        {
            var ktg = db.TBLPERSONELs.Find(p.personel_id);
            ktg.personel_bilgi = p.personel_bilgi;


            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}