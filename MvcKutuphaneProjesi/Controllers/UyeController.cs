using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphaneProjesi.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace MvcKutuphaneProjesi.Controllers
{
    public class UyeController : Controller
    {
        // GET: Uye
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();

        public ActionResult Index(int sayfa = 1)
        {
            var degerler = db.TBLUYELERs.ToList().ToPagedList(sayfa, 3);
            return View(degerler);
        }
        [HttpGet]
        public ActionResult UyeEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UyeEkle(TBLUYELER u)
        {
            db.TBLUYELERs.Add(u);
            db.SaveChanges();
            return View();
        }

        public ActionResult UyeSil(int id)
        {
            var silinecek_uye = db.TBLUYELERs.Find(id);
            db.TBLUYELERs.Remove(silinecek_uye);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UyeGetir(int id)
        {
            var getirilecek_id = db.TBLUYELERs.Find(id);
            return View("UyeGetir", getirilecek_id);
        }


        public ActionResult UyeGuncelle(TBLUYELER p)
        {
            var uye = db.TBLUYELERs.Find(p.uye_id);
            uye.uye_ad = p.uye_ad;
            uye.uye_soyad = p.uye_soyad;
            uye.uye_mail = p.uye_mail;
            uye.uye_kullaniciadi = p.uye_kullaniciadi;
            uye.uye_sifre = p.uye_sifre;
            uye.uye_telofon = p.uye_telofon;


            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }

}