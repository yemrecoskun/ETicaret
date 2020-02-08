using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Service
{
    public class Service
    {
        Entity.UrunEntity urunentity = new Entity.UrunEntity();
        Entity.KullaniciEntity kullanicientity = new Entity.KullaniciEntity();
        public Dictionary<Models.Urun,Models.Urun_star> Urun_Sorgula()
        {
            return urunentity.UrunListesi();
        }
        public Dictionary<Models.Urun, Models.Urun_star> TumUrunler()
        {
            return urunentity.TumUrunler();
        }
        public List<Models.Satilan_Urun> SatilanUrunListele()
        {
            return urunentity.SatilanUrunlerListesi();
        }
        public List<Models.Urun_Marka> MarkaListele()
        {
            return urunentity.MarkaListele();
        }
        public void UrunEkle(Models.Urun urun)
        {
           urunentity.UrunEkle(urun);
        } 
        public void UrunSil(int urun_id)
        {
            urunentity.UrunSil(urun_id);
        }
        public Dictionary<Models.Urun, Models.Urun_star> UrunAra(int urun_id)
        {
            return urunentity.UrunAra(urun_id);
        }
        public Models.Urun UrunAra2(int urun_id)
        {
            return urunentity.UrunAra2(urun_id);
        }
        public List<Models.Urun_Ozellikleri> UrunOzellikAra(int urun_id)
        {
            return urunentity.UrunOzellikListesi(urun_id);
        }
        public void UrunOzellikEkle(Models.Urun_Ozellikleri ozellik)
        {
            urunentity.UrunOzellikEkle(ozellik);
        }
        public int UrunOzellikSil(int urun_ozellikid)
        {
            return urunentity.UrunOzellikSil(urun_ozellikid);
        }
        public List<Models.Urun_Ozellikleri> OzellikListesi()
        {
            return urunentity.OzellikListesi();
        }
        public Models.Kullanici Login (Models.Kullanici kullanici)
        {
            return kullanicientity.Login(kullanici);
        }
        public string KullaniciKontrol(string kullanici_id)
        {
            return kullanicientity.KullaniciKontrol(kullanici_id);
        }
        public void KullaniciKayit(Models.Kullanici kullanici)
        {
            kullanicientity.KullaniciKayit(kullanici);
        }
        public void KullaniciDuzenle(Models.Kullanici kullanici,string id)
        {
            kullanicientity.KullaniciDuzenle(kullanici,id);
        }
        public List<Models.Siparis> Siparislerim(string kullanici_id)
        {
            return urunentity.Siparislerim(kullanici_id);
        }
        public List<Models.Urun> SiparisUrunlerim(int siparis_id)
        {
            return urunentity.SiparisUrunlerim(siparis_id);
        }
        public string AlisverisiTamamla(int urun_id, string kullanici_id)
        {
            return urunentity.AlisverisiTamamla(urun_id,kullanici_id);
        }
        public void Yildizla(int id, int urun_id)
        {
            urunentity.Yildizla(id, urun_id);
        }
    }
}