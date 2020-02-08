using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Linq;
namespace WebApplication1.Entity
{
    public class UrunEntity
    {
        Globals.SQL sql = new Globals.SQL();
        public Dictionary<Models.Urun,Models.Urun_star> UrunListesi()
        {
            Dictionary<Models.Urun,Models.Urun_star> urunlistesi = new Dictionary<Models.Urun, Models.Urun_star>();
            sql.con.Open();
            sql.cmd = new MySql.Data.MySqlClient.MySqlCommand("urun_sorgula",sql.con);
            sql.cmd.CommandType = CommandType.StoredProcedure;
            var rd = sql.cmd.ExecuteReader(CommandBehavior.CloseConnection);
            while (rd.Read())
            {
                Models.Urun_star star = new Models.Urun_star();
                Models.Urun urun = new Models.Urun();
                urun.urun_id = rd.GetInt32("urun_id");
                urun.urun_adi = rd.GetString("urun_adi");
                urun.urun_markaadi = rd.GetString("urun_markaadi");
                urun.urun_indirimfiyati = rd.GetString("urun_indirimfiyati");
                urun.urun_fiyati = rd.GetDouble("urun_fiyati");
                urun.urun_modeladi = rd.GetString("urun_modeladi");
                urun.urun_resim = rd.GetString("urun_resim");
                star.urun_id = rd.GetInt32("urun_id");
                star.star1 = rd.GetInt32("star1");
                star.star2 = rd.GetInt32("star2");
                star.star3 = rd.GetInt32("star3");
                star.star4 = rd.GetInt32("star4");
                star.star5 = rd.GetInt32("star5");
                if(star.star1 == 0 && star.star2 ==0 && star.star3 ==0 && star.star4 ==0 && star.star5 ==0)
                {
                    star.ortalama = 0;
                }
                else
                {
                    double ortalama = (double)(star.star5 * 5 + star.star4 * 4 + star.star3 * 3 + star.star2 * 2 + star.star1 * 1) / (star.star1 + star.star2 + star.star3 + star.star4 + star.star5);
                    star.ortalama = ortalama;
                }
                urunlistesi.Add(urun,star);
            }
            sql.con.Close();
            return urunlistesi;
        }
        public Dictionary<Models.Urun, Models.Urun_star> TumUrunler()
        {
            Dictionary<Models.Urun, Models.Urun_star> urunlistesi = new Dictionary<Models.Urun, Models.Urun_star>();
            sql.con.Open();
            sql.cmd = new MySql.Data.MySqlClient.MySqlCommand("Tum_Urunler", sql.con);
            sql.cmd.CommandType = CommandType.StoredProcedure;
            var rd = sql.cmd.ExecuteReader(CommandBehavior.CloseConnection);
            while (rd.Read())
            {
                Models.Urun_star star = new Models.Urun_star();
                Models.Urun urun = new Models.Urun();
                urun.urun_id = rd.GetInt32("urun_id");
                urun.urun_adi = rd.GetString("urun_adi");
                urun.urun_markaadi = rd.GetString("urun_markaadi");
                urun.urun_indirimfiyati = rd.GetString("urun_indirimfiyati");
                urun.urun_fiyati = rd.GetDouble("urun_fiyati");
                urun.urun_modeladi = rd.GetString("urun_modeladi");
                urun.urun_resim = rd.GetString("urun_resim");
                star.urun_id = rd.GetInt32("urun_id");
                star.star1 = rd.GetInt32("star1");
                star.star2 = rd.GetInt32("star2");
                star.star3 = rd.GetInt32("star3");
                star.star4 = rd.GetInt32("star4");
                star.star5 = rd.GetInt32("star5");
                if (star.star1 == 0 && star.star2 == 0 && star.star3 == 0 && star.star4 == 0 && star.star5 == 0)
                {
                    star.ortalama = 0;
                }
                else
                {
                    double ortalama = (double)(star.star5 * 5 + star.star4 * 4 + star.star3 * 3 + star.star2 * 2 + star.star1 * 1) / (star.star1 + star.star2 + star.star3 + star.star4 + star.star5);
                    star.ortalama = ortalama;
                }
                urunlistesi.Add(urun, star);
            }
            sql.con.Close();
            return urunlistesi;
        }
        public List<Models.Satilan_Urun> SatilanUrunlerListesi()
        {
            List<Models.Satilan_Urun> satilanurunlistesi = new List<Models.Satilan_Urun>();
            sql.con.Open();
            sql.cmd = new MySql.Data.MySqlClient.MySqlCommand("satilan_urun_sorgula",sql.con);
            sql.cmd.CommandType = CommandType.StoredProcedure;
            var rd = sql.cmd.ExecuteReader(CommandBehavior.CloseConnection);
            while (rd.Read())
            {
                Models.Satilan_Urun urun = new Models.Satilan_Urun();
                urun.satilan_miktar = rd.GetInt32("satilan_miktar");
                urun.satilan_urunid = rd.GetInt32("satilan_urunid");
                urun.urun_id = rd.GetInt32("urun_id");
                satilanurunlistesi.Add(urun);
            }
            sql.con.Close();
            return satilanurunlistesi;
        }
        public List<Models.Urun_Marka> MarkaListele()
        {
            List<Models.Urun_Marka> markalistesi = new List<Models.Urun_Marka>();
            sql.con.Open();
            sql.cmd = new MySql.Data.MySqlClient.MySqlCommand("urun_marka_sorgula", sql.con);
            sql.cmd.CommandType = CommandType.StoredProcedure;
            var rd = sql.cmd.ExecuteReader(CommandBehavior.CloseConnection);
            while (rd.Read())
            {
                Models.Urun_Marka marka = new Models.Urun_Marka();
                marka.urun_adi = rd.GetString("urun_adi");
                marka.urun_markaadi = rd.GetString("urun_markaadi");
                marka.urun_markaid = rd.GetInt32("urun_markaid");
                markalistesi.Add(marka);
            }
            sql.con.Close();
            return markalistesi;
        }
        public void UrunEkle(Models.Urun urun)
        {
            sql.con.Open();
            sql.cmd = new MySql.Data.MySqlClient.MySqlCommand("insert into `urun`(`urun_adi`,`urun_markaid`,`urun_modeladi`,`urun_fiyati`,`urun_indirimfiyati`,`urun_resim`)values('" + urun.urun_adi+"', '"+urun.urun_markaadi+"', '"+urun.urun_modeladi+"', '"+urun.urun_fiyati+"','"+urun.urun_indirimfiyati+"' ,'"+urun.urun_resim+"') ",sql.con);
            sql.cmd.ExecuteNonQuery();
            sql.con.Close();
            sql.con.Open();
            sql.cmd = new MySql.Data.MySqlClient.MySqlCommand("insert into urun_star(urun_id, star1, star2, star3, star4, star5) values((select max(urun_id) from urun), 0, 0, 0, 0, 0);",sql.con);
            sql.cmd.ExecuteNonQuery();
            sql.con.Close();
            sql.con.Open();
            sql.cmd = new MySql.Data.MySqlClient.MySqlCommand("insert into `satilan_urunler`(`urun_id`,`satilan_miktar`)values((select max(urun_id) from urun), '0'); ", sql.con);
            sql.cmd.ExecuteNonQuery();
            sql.con.Close();
        }
        public void UrunSil(int urun_id)
        {
            sql.con.Open();
            sql.cmd = new MySql.Data.MySqlClient.MySqlCommand("delete from urun where urun_id='" + urun_id + "'", sql.con);
            sql.cmd.ExecuteNonQuery();
            sql.con.Close();
        }
        public Dictionary<Models.Urun, Models.Urun_star> UrunAra(int urun_id)
        {
            Dictionary<Models.Urun, Models.Urun_star> urunlistesi = new Dictionary<Models.Urun, Models.Urun_star>();
            sql.con.Open();
            sql.cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT urun.urun_id,urun.urun_adi,urun_marka.urun_markaadi,urun.urun_modeladi,urun.urun_fiyati,urun.urun_indirimfiyati,urun.urun_resim,urun_star.star1,urun_star.star2,urun_star.star3,urun_star.star4,urun_star.star5 FROM urun inner join urun_marka on urun_marka.urun_markaid = urun.urun_markaid inner join urun_star on urun_star.urun_id = urun.urun_id and urun.urun_id = '"+urun_id+"' order by urun_id desc ;",sql.con);
            var rd = sql.cmd.ExecuteReader(CommandBehavior.CloseConnection);
            while (rd.Read())
            {
                Models.Urun_star star = new Models.Urun_star();
                Models.Urun urun = new Models.Urun();
                urun.urun_id = rd.GetInt32("urun_id");
                urun.urun_adi = rd.GetString("urun_adi");
                urun.urun_markaadi = rd.GetString("urun_markaadi");
                urun.urun_indirimfiyati = rd.GetString("urun_indirimfiyati");
                urun.urun_fiyati = rd.GetDouble("urun_fiyati");
                urun.urun_modeladi = rd.GetString("urun_modeladi");
                urun.urun_resim = rd.GetString("urun_resim");
                star.urun_id = rd.GetInt32("urun_id");
                star.star1 = rd.GetInt32("star1");
                star.star2 = rd.GetInt32("star2");
                star.star3 = rd.GetInt32("star3");
                star.star4 = rd.GetInt32("star4");
                star.star5 = rd.GetInt32("star5");
                if (star.star1 == 0 && star.star2 == 0 && star.star3 == 0 && star.star4 == 0 && star.star5 == 0)
                {
                    star.ortalama = 0;
                }
                else
                {
                    double ortalama = (double)(star.star5 * 5 + star.star4 * 4 + star.star3 * 3 + star.star2 * 2 + star.star1 * 1) / (star.star1 + star.star2 + star.star3 + star.star4 + star.star5);
                    star.ortalama = ortalama;
                }
                urunlistesi.Add(urun, star);
            }
            sql.con.Close();
            return urunlistesi;
        }
        public Models.Urun UrunAra2(int urun_id)
        {
            Models.Urun urun = new Models.Urun();
            sql.con.Open();
            sql.cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT urun.urun_id,urun.urun_adi,urun_marka.urun_markaadi,urun.urun_modeladi,urun.urun_fiyati,urun.urun_indirimfiyati,urun.urun_resim,urun_star.star1,urun_star.star2,urun_star.star3,urun_star.star4,urun_star.star5 FROM urun inner join urun_marka on urun_marka.urun_markaid = urun.urun_markaid inner join urun_star on urun_star.urun_id = urun.urun_id and urun.urun_id = '" + urun_id + "' order by urun_id desc ;", sql.con);
            var rd = sql.cmd.ExecuteReader(CommandBehavior.CloseConnection);
            while (rd.Read())
            {
                urun.urun_id = rd.GetInt32("urun_id");
                urun.urun_adi = rd.GetString("urun_adi");
                urun.urun_markaadi = rd.GetString("urun_markaadi");
                urun.urun_indirimfiyati = rd.GetString("urun_indirimfiyati");
                urun.urun_fiyati = rd.GetDouble("urun_fiyati");
                urun.urun_modeladi = rd.GetString("urun_modeladi");
                urun.urun_resim = rd.GetString("urun_resim");
            }
            sql.con.Close();
            return urun;
        }
        public List<Models.Urun_Ozellikleri> UrunOzellikListesi(int urun_id)
        {
            List<Models.Urun_Ozellikleri> ozelliklistesi = new List<Models.Urun_Ozellikleri>();
            sql.con.Open();
            sql.cmd = new MySql.Data.MySqlClient.MySqlCommand("select * from urun_ozellik where urun_id = "+urun_id+" ",sql.con);
            var rd= sql.cmd.ExecuteReader(CommandBehavior.CloseConnection);
            while (rd.Read())
            {
                Models.Urun_Ozellikleri ozellik = new Models.Urun_Ozellikleri();
                ozellik.urun_id = rd.GetInt32("urun_id");
                ozellik.urun_ozellik = rd.GetString("urun_ozellik");
                ozellik.urun_ozellikadi = rd.GetString("urun_ozellikadi");
                ozellik.urun_ozellikid = rd.GetInt32("urun_ozellikid");
                ozelliklistesi.Add(ozellik);
            }
            sql.con.Close();
            return ozelliklistesi;
        }
        public List<Models.Urun_Ozellikleri> OzellikListesi()
        {
            List<Models.Urun_Ozellikleri> ozelliklist = new List<Models.Urun_Ozellikleri>();
            sql.con.Open();
            sql.cmd = new MySql.Data.MySqlClient.MySqlCommand("select urun_ozellikadi from urun_ozellik group by urun_ozellikadi desc;", sql.con);
            var rd = sql.cmd.ExecuteReader(CommandBehavior.CloseConnection);
            while (rd.Read())
            {
                Models.Urun_Ozellikleri ozellik = new Models.Urun_Ozellikleri();
                ozellik.urun_ozellikadi = rd.GetString("urun_ozellikadi");
                ozelliklist.Add(ozellik);
            }
            sql.con.Close();
            return ozelliklist;
        }
        public void UrunOzellikEkle(Models.Urun_Ozellikleri ozellik)
        {
            sql.con.Open();
            sql.cmd = new MySql.Data.MySqlClient.MySqlCommand("insert into `urun_ozellik`(`urun_id`,`urun_ozellikadi`,`urun_ozellik`)values('" + ozellik.urun_id + "', '" + ozellik.urun_ozellikadi + "', '" + ozellik.urun_ozellik + "'); ",sql.con);
            sql.cmd.ExecuteNonQuery();
            sql.con.Close();
        }
        public int UrunOzellikSil(int urun_ozellikid)
        {
            sql.con.Open();
            sql.cmd = new MySql.Data.MySqlClient.MySqlCommand("delete from urun_ozellik where urun_ozellikid='" + urun_ozellikid + "'", sql.con);
            sql.cmd.ExecuteNonQuery();
            sql.con.Close();
            return urun_ozellikid;
        }
        public List<Models.Urun_Ozellikleri> UrunOzellikAra(int urun_id)
        {
            List<Models.Urun_Ozellikleri> ozelliklist= new List<Models.Urun_Ozellikleri>();
            sql.con.Open();
            sql.cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT * FROM urun_ozellik where urun.urun_id = '" + urun_id + "'; ", sql.con);
            var rd = sql.cmd.ExecuteReader(CommandBehavior.CloseConnection);
            while (rd.Read())
            {
                Models.Urun_Ozellikleri ozellik = new Models.Urun_Ozellikleri();
                ozellik.urun_id = rd.GetInt32("urun_id");
                ozellik.urun_ozellik = rd.GetString("urun_ozellik");
                ozellik.urun_ozellikadi= rd.GetString("urun_ozellikadi");
                ozellik.urun_ozellikid= rd.GetInt32("urun_ozellikid");
                ozelliklist.Add(ozellik);
            }
            sql.con.Close();
            return ozelliklist;
        }
        public List<Models.Siparis> Siparislerim(string kullanici_id)
        {
            List<Models.Siparis> siparislist = new List<Models.Siparis>();
            sql.con.Open();
            if(kullanici_id=="user") sql.cmd = new MySql.Data.MySqlClient.MySqlCommand("select * from siparis",sql.con);
            else sql.cmd = new MySql.Data.MySqlClient.MySqlCommand("select * from siparis where kullanici_id='"+kullanici_id+"'", sql.con); 
            var rd = sql.cmd.ExecuteReader(CommandBehavior.CloseConnection);
            while (rd.Read())
            {
                Models.Siparis siparis = new Models.Siparis();
                siparis.siparis_id = rd.GetInt16("siparis_id");
                siparis.kullanici_id = rd.GetString("kullanici_id");
                siparis.kullanici_siparisdurumu = rd.GetString("kullanici_siparisdurumu");
                siparislist.Add(siparis);
            }
            sql.con.Close();
            return siparislist;
        }
        public List<Models.Urun> SiparisUrunlerim(int siparis_id)
        {
            List<Models.Urun> urunlist= new List<Models.Urun>();
            sql.con.Open();
            sql.cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT urun.urun_id,urun.urun_adi,urun_marka.urun_markaadi,urun.urun_modeladi,urun.urun_fiyati,urun.urun_indirimfiyati,urun.urun_resim FROM urun inner join urun_marka on urun_marka.urun_markaid = urun.urun_markaid inner join siparis_urunleri on siparis_urunleri.kullanici_siparisurunid = urun.urun_id where siparis_id='"+siparis_id+"'", sql.con);
            var rd = sql.cmd.ExecuteReader(CommandBehavior.CloseConnection);
            while (rd.Read())
            {
                Models.Urun urun= new Models.Urun();
                urun.urun_id = rd.GetInt32("urun_id");
                urun.urun_adi = rd.GetString("urun_adi");
                urun.urun_markaadi = rd.GetString("urun_markaadi");
                urun.urun_indirimfiyati = rd.GetString("urun_indirimfiyati");
                urun.urun_fiyati = rd.GetDouble("urun_fiyati");
                urun.urun_modeladi = rd.GetString("urun_modeladi");
                urun.urun_resim = rd.GetString("urun_resim");
                urunlist.Add(urun);
            }
            sql.con.Close();
            return urunlist;
        }
        public string AlisverisiTamamla(int urun_id,string kullanici_id)
        {
            string siparis_id="";
            sql.con.Open();
            sql.cmd = new MySql.Data.MySqlClient.MySqlCommand("update satilan_urunler set satilan_miktar=satilan_miktar+1 where urun_id='"+urun_id+"'",sql.con);
            sql.cmd.ExecuteNonQuery();
            sql.con.Close();
            sql.con.Open();
            sql.cmd = new MySql.Data.MySqlClient.MySqlCommand("insert into `siparis_urunleri`(`siparis_id`,`kullanici_siparisurunid`)values((select max(siparis_id) from siparis), '"+urun_id+"'); ", sql.con);
            sql.cmd.ExecuteNonQuery();
            sql.con.Close();
            sql.con.Open();
            sql.cmd = new MySql.Data.MySqlClient.MySqlCommand("select max(siparis_id) from siparis",sql.con);
            var rd = sql.cmd.ExecuteReader();
            if (rd.Read())
            {
                siparis_id = rd.GetString("max(siparis_id)");
            }
            return siparis_id;
        }
        public void Yildizla(int id, int urun_id)
        {
            sql.con.Open();
            string starid = "star" + id;
            sql.cmd = new MySql.Data.MySqlClient.MySqlCommand("update urun_star set "+starid+"="+starid+"+1 where urun_id='"+urun_id+"'",sql.con);
            sql.cmd.ExecuteNonQuery();
            sql.con.Close();
        }
        
    }
}