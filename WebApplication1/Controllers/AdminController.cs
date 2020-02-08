using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Service;
namespace WebApplication1.Controllers
{
    public class AdminController : Controller
    {
        Service.Service servis = new Service.Service();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult UrunEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UrunEkle(Models.Urun urun, HttpPostedFileBase urun_resim)
        {
            var FileName = Path.GetFileName(urun_resim.FileName);
            var path = Path.Combine(Server.MapPath("~/img/urunimg"), FileName);
            urun_resim.SaveAs(path);
            urun.urun_resim = "~/img/urunimg/" + FileName;
            urun.urun_indirimfiyati = "null";
            servis.UrunEkle(urun);
            ViewBag.Message="Ürün Eklendi";
            return View();
        }
        public ActionResult UrunCikar()
        {
            return View();
        }
        public JsonResult UrunSil(int id)
        {
            servis.UrunSil(id);
            return Json(id);
        }
        public ActionResult UrunOzellikEkle()
        {
            return View();
        }
        public JsonResult UrunOzellikleriCagir(int id)
        {
            return Json(servis.UrunOzellikAra(id));
        }
        public JsonResult UrunOzelligiEkle(Models.Urun_Ozellikleri ozellik)
        {
            servis.UrunOzellikEkle(ozellik);
            return Json("");
        }
        public JsonResult UrunOzellikSil(int id)
        {
            servis.UrunOzellikSil(id);
            return Json(id);
        }
    }
}