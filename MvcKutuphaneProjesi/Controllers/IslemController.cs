using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphaneProjesi.Models.Entity;
namespace MvcKutuphaneProjesi.Controllers
{
    public class IslemController : Controller
    {
        // GET: Islem
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        public ActionResult Index()
        {
            var degerler = db.TBLHAREKETs.Where(x => x.TBLKITAP.kitap_durum == true).ToList();
            return View(degerler);
        }
    }
}