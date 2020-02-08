using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        Service.Service servis = new Service.Service();
        // GET: Home
        public ActionResult Index()
        {
            if (Session["adet"] == null) Session["adet"] = "0";
            if (Session["silinenadet"] == null) Session["silinenadet"] = "0";
            if (Session["toplamadet"] == null) Session["toplamadet"] = "0";
            if (Session["toplamadet"] !=null) Session["toplamadet"] = Convert.ToInt32(Session["adet"]) - Convert.ToInt32(Session["silinenadet"]);
            return View();
        }
        public ActionResult GirisYap()
        {
            return View();
        }
        public JsonResult Login(Models.Kullanici kullanici)
        {
            if (kullanici.kullanici_id == "" && kullanici.kullanici_sifre == "") return Json("");
            else if (kullanici.kullanici_id == "root" && kullanici.kullanici_sifre == "admin") return Json("admin");
            else
            {
                var rd = (servis.Login(kullanici));
                if (rd.kullanici_adi == null) return Json("basarisiz");
                else
                {
                    Session["kullanici_id"] = kullanici.kullanici_id;
                    Session["kullanici_adi"] = kullanici.kullanici_adi;
                    Session["kullanici_sifre"] = kullanici.kullanici_sifre;
                    Session["kullanici_soyadi"] = kullanici.kullanici_soyadi;
                    return Json("basarili");
                }
            }
        }
        public ActionResult UrunIncele()
        {
            return View();
        }
        public JsonResult sepeteekle(int id)
        {

            int adet = (Convert.ToInt32(Session["adet"])+1);
            for(int i = 1; i <= adet; i++)
            {
                if (Convert.ToInt32(Session["eklenenurun"+i.ToString()]) == id)
                {
                    return Json("ekli");
                }

            }
                Session["eklenenurun"+adet.ToString()] = id;
                Session["adet"] = adet;
                if (Session["toplamadet"] != null) Session["toplamadet"] = Convert.ToInt32(Session["adet"]) - Convert.ToInt32(Session["silinenadet"]);
                return Json(Session["toplamadet"]);
        }
        public ActionResult AlisverisSepeti()
        {
            return View();
        }
        public ActionResult AlisverisSepetiAdres()
        {
            return View();
        }
        public JsonResult IncelenecekUrunId(int id)
        {
            Session["urun_id"]=id;
            return Json("");
        }
        public JsonResult SepettekiUrunuSil(string id)
        {
            Session["silinenadet"]= (Convert.ToInt32(Session["silinenadet"])+1);
            string silinecekurun = "eklenenurun" + id;
            Session.Remove(silinecekurun.ToString());
            if (Session["toplamadet"] != null) Session["toplamadet"] = Convert.ToInt32(Session["adet"]) - Convert.ToInt32(Session["silinenadet"]);
            return Json(id);
        }
        public ActionResult UrunKarsilastir()
        {
            if (Session["karsilastir1"] == null) Session["karsilastir1"] = "null";
            if (Session["karsilastir2"] == null) Session["karsilastir2"] = "null";
            if (Session["karsilastir3"] == null) Session["karsilastir3"] = "null";
            if (Session["karsilastir4"] == null) Session["karsilastir4"] = "null";
            if (Session["karsilastiradet"] == null) Session["karsilastiradet"] = "0";
            return View();
        }
        public JsonResult Karsilastir(string id)
        {
            if (Session["karsilastiradet"] == null) Session["karsilastiradet"] = "0";
            if (Session["karsilastir1"] == null) Session["karsilastir1"] = "null";
            if (Session["karsilastir2"] == null) Session["karsilastir2"] = "null";
            if (Session["karsilastir3"] == null) Session["karsilastir3"] = "null";
            if (Session["karsilastir4"] == null) Session["karsilastir4"] = "null";
            if ((Session["karsilastir1"]).ToString()==id || (Session["karsilastir2"]).ToString() == id || (Session["karsilastir3"]).ToString() == id || (Session["karsilastir4"]).ToString() == id)
            {
                return Json("ekli");
            }
            else
            {
                int adet = Convert.ToInt16(Session["karsilastiradet"]) + 1;
                if (adet <= 4)
                {
                    for (int i = 1; i <= adet; i++)
                    {
                        if (Session["karsilastir" + i] == "null")
                        {
                            Session["karsilastir" + adet] = id;
                            Session["karsilastiradet"] = adet;
                            break;
                        }
                    }
                    return Json(id);
                }
                else
                {
                    return Json("dolu");
                }
            }
        }
        public JsonResult KarsilastirmaSilme(string id)
        {
            Session["karsilastir" + id] = "null";
            Session["karsilastiradet"] = Convert.ToInt16(Session["karsilastiradet"]) - 1;
            return Json(id);
        }
        public ActionResult UyeOl()
        {
            return View();
        }
        public JsonResult KullaniciKayit(Models.Kullanici kullanici)
        {
            if (servis.KullaniciKontrol(kullanici.kullanici_id) == "bulunamadi")
            {
                servis.KullaniciKayit(kullanici);
                return Json("bulunamadi");
            }
            else
            {
                return Json("bulundu");
            }
        }
        public ActionResult Hesabim()
        {
            return View();
        }
        public JsonResult KullaniciDuzenle(Models.Kullanici kullanici,string id)
        {
            servis.KullaniciDuzenle(kullanici,id);
            return Json("");
        }
        public ActionResult Laptop()
        {
            return View();
        }
        public ActionResult Siparislerim()
        {
            return View();
        }
        public JsonResult SiparisUrunleriCagir(int id)
        {
            return Json(servis.SiparisUrunlerim(id));
        }
        public JsonResult AlisverisiTamamla()
        {
            string kullanici_id = "user";
            if(Session["kullanici_id"] != null)
            {
                kullanici_id = Session["kullanici_id"].ToString();
            }
            List<int> urun_id = new List<int>();
            int n = Convert.ToInt16(Session["adet"]);
            for (int i =1; i <= n; i++)
            {
                if (Session["eklenenurun" + i] != null)
                {
                    urun_id.Add(Convert.ToInt16(Session["eklenenurun"+i]));
                }
            }
            Globals.SQL sql = new Globals.SQL();
            sql.con.Open();
            sql.cmd = new MySql.Data.MySqlClient.MySqlCommand("insert into `siparis`(`kullanici_id`,`kullanici_siparisdurumu`)values('" + kullanici_id + "', 'siparişte'); ", sql.con);
            sql.cmd.ExecuteNonQuery();
            sql.con.Close();
            string id = "";
            foreach (var item in urun_id)
            {
                id=servis.AlisverisiTamamla(item,kullanici_id);
            }
            return Json(id);
        }
        public JsonResult HesapCikis()
        {
            Session["kullanici_id"] = null;
            return Json("");
        }
        public JsonResult Yildizla(int id,int urun_id)
        {
            servis.Yildizla(id, urun_id);
            return Json("");
        }
    }
}