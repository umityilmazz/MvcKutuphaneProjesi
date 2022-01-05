using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphaneProjesi.Models.Entity;

namespace MvcKutuphaneProjesi.Controllers
{
    public class KitapController : Controller
    {
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        // GET: Kitap
        public ActionResult Index()
        {
            var degerler = db.TBLKITAPs.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult KitapEkle()
        {
            List<SelectListItem> deger1 = (from i in db.TBLKATEGORIs.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.kategori_ad,
                                               Value = i.kategori_id.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            List<SelectListItem> deger2 = (from a in db.TBLYAZARs.ToList()
                                           select new SelectListItem
                                           {
                                               Text = a.yazar_ad,
                                               Value=a.yazar_id.ToString()
                                                
                                           }).ToList();
            ViewBag.dgr2=deger2;
            return View();
        }
        [HttpPost]
        public ActionResult KitapEkle(TBLKITAP k)
        {
            var ktg = db.TBLKATEGORIs.Where(x => x.kategori_id == k.TBLKATEGORI.kategori_id).FirstOrDefault();
            var yzr = db.TBLYAZARs.Where(x => x.yazar_id == k.TBLYAZAR.yazar_id).FirstOrDefault();
            k.TBLKATEGORI = ktg;
            k.TBLYAZAR = yzr;
            db.TBLKITAPs.Add(k);
            db.SaveChanges();
            return RedirectToAction("Index");
            
        }

        public ActionResult KitapSil(int id)
        {
            var silinecek_kitap = db.TBLKITAPs.Find(id);
            db.TBLKITAPs.Remove(silinecek_kitap);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KitapGetir(int id)
        {
            var getirilecek_kitap = db.TBLKITAPs.Find(id);
            return View("KitapGetir", getirilecek_kitap);
        }
        public ActionResult KitapGuncelle(TBLKITAP k)
        {
            var kitap = db.TBLKITAPs.Find(k.kitap_id);
            kitap.kitap_ad = k.kitap_ad;
            kitap.BASIMYILI = k.BASIMYILI;
            kitap.kitap_sayfa = k.kitap_sayfa;
            kitap.kitap_durum = k.kitap_durum;
            kitap.kitap_yayınevi = k.kitap_yayınevi;
            var ktg = db.TBLKATEGORIs.Where(x => x.kategori_id == k.kategori_id).FirstOrDefault();
            var yzr = db.TBLYAZARs.Where(x => x.yazar_id == k.yazar_id).FirstOrDefault();
            kitap.kategori_id = ktg.kategori_id;
            kitap.yazar_id = yzr.yazar_id;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}