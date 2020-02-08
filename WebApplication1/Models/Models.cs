using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Urun
    {
        public int urun_id { get; set; }
        public string urun_adi { get; set; }
        public string urun_markaadi { get; set; }
        public string urun_modeladi { get; set; }
        public double urun_fiyati { get; set; }
        public string urun_indirimfiyati { get; set; }
        public string urun_resim { get; set; }
    }
    public class Urun_star
    {
        public int urun_id { get; set; }
        public int star1 { get; set; }
        public int star2 { get; set; }
        public int star3 { get; set; }
        public int star4 { get; set; }
        public int star5 { get; set; }
        public double ortalama { get; set; }
    }
    public class Urun_Marka
    {
        public int urun_markaid { get; set; }
        public string urun_adi { get; set; }
        public string urun_markaadi { get; set; }
    }
    public class Urun_Ozellikleri
    {
        public int urun_ozellikid { get; set; }
        public int urun_id { get; set; }
        public string urun_ozellikadi { get; set; }
        public string urun_ozellik { get; set; }
    }
    public class Satilan_Urun
    {
        public int satilan_urunid { get; set; }
        public int urun_id { get; set; }
        public int satilan_miktar { get; set; }
    }
    public class Kullanici
    {
        public string kullanici_id { get; set; }
        public string kullanici_adi { get; set; }
        public string kullanici_soyadi { get; set; }
        public string kullanici_sifre { get; set; }
    }
    public class Siparis
    {
        public int siparis_id { get; set; }
        public string kullanici_id { get; set; }
        public string kullanici_siparisdurumu { get; set; }
    }
    public class SiparisUrunleri
    {
        public int siparis_urun_id { get; set; }
        public int siparis_id { get; set; }
        public int kullanici_siparisurunid { get; set; }
    }
}