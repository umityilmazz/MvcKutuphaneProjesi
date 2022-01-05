using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphaneProjesi.Models.Entity;
namespace MvcKutuphaneProjesi.Controllers
{
    public class VitrinController : Controller
    {
        // GET: Vitrin
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        [HttpGet]
        public ActionResult Index()
        {

            var degerler = db.TBLKITAPs.ToList();
            return View(degerler);
        }
        [HttpPost]
        public ActionResult Index(TBLİLETİSİM i)
        {
            db.TBLİLETİSİM.Add(i);
            db.SaveChanges();           
            return RedirectToAction("Index");
        }
    }
}