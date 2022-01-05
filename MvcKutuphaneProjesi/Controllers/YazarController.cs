using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphaneProjesi.Models.Entity;

namespace MvcKutuphaneProjesi.Controllers
{
    public class YazarController : Controller
    {
        // GET: Yazar
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        public ActionResult Index()
        {
            var degerler = db.TBLYAZARs.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YazarEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YazarEkle(TBLYAZAR y)
        {
            db.TBLYAZARs.Add(y);
            db.SaveChanges();
            return View();
        }
        public ActionResult YazarSil(int id)
        {
            var yazar = db.TBLYAZARs.Find(id);
            db.TBLYAZARs.Remove(yazar);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult YazarGetir(int id)
        {
            var getirilecek_yazar = db.TBLYAZARs.Find(id);
            return View("YazarGetir", getirilecek_yazar);
        }
        public ActionResult YazarGuncelle(TBLYAZAR y)
        {
            var yazar = db.TBLYAZARs.Find(y.yazar_id);
            yazar.yazar_ad = y.yazar_ad;
            yazar.yazar_soyad = y.yazar_soyad;
            yazar.yazar_detay = y.yazar_detay;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}