using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphaneProjesi.Models.Entity;

namespace MvcKutuphaneProjesi.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        public ActionResult Index()
        {
            var degerler = db.TBLKATEGORIs.ToList();

            return View(degerler);
        }
        [HttpGet]//Kategori ekleme yapmazsa bunu getir
        public ActionResult KategoriEkle()
        {
            return View();
        }
        [HttpPost]//kategori ekleme yaparsa bunu getir 
        public ActionResult KategoriEkle(TBLKATEGORI p)
        {
            db.TBLKATEGORIs.Add(p);//databasedeki kategori tablosuna ekleme yapmak için tanımladığımız p yi yolluyoruz
            db.SaveChanges();
            return View();
        }
        public ActionResult KategoriSil(int id)
        {
            var silinecek_kategori = db.TBLKATEGORIs.Find(id);
            db.TBLKATEGORIs.Remove(silinecek_kategori);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        
        public ActionResult KategoriGetir(int id)
        {
            var getirilecek_id = db.TBLKATEGORIs.Find(id);
            
            db.SaveChanges();
            return View("KategoriGetir",getirilecek_id);
        }
    
        public ActionResult KategoriGuncelle(TBLKATEGORI p)
        {
            var ktg = db.TBLKATEGORIs.Find(p.kategori_id);
            ktg.kategori_ad = p.kategori_ad;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}