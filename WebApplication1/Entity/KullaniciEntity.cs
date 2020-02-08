using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Entity
{
    public class KullaniciEntity
    {
        Globals.SQL sql = new Globals.SQL();
        public Models.Kullanici Login(Models.Kullanici kullanici)
        {
            sql.con.Open();
            sql.cmd = new MySql.Data.MySqlClient.MySqlCommand("select * from kullanici where kullanici_id='" + kullanici.kullanici_id + "' and kullanici_sifre='" + kullanici.kullanici_sifre + "'", sql.con);
            var rd = sql.cmd.ExecuteReader();
            if (rd.Read())
            {
                kullanici.kullanici_adi = rd.GetString("kullanici_adi");
                kullanici.kullanici_soyadi = rd.GetString("kullanici_soyadi");
                rd.Close();
                sql.con.Close();
                return kullanici;
            }
            else
            {
                rd.Close();
                sql.con.Close();
                return kullanici;
            }
        }
        public string KullaniciKontrol(string kullanici_id)
        {
            sql.con.Open();
            sql.cmd = new MySql.Data.MySqlClient.MySqlCommand("select * from kullanici where kullanici_id='" + kullanici_id + "'", sql.con);
            var rd = sql.cmd.ExecuteReader();
            if (rd.Read())
            {
                sql.con.Close();
                return "bulundu";
            }
            else
            {
                sql.con.Close();
                return "bulunamadi";
            }
        }
        public void KullaniciKayit(Models.Kullanici kullanici)
        {
            sql.con.Open();
            sql.cmd = new MySql.Data.MySqlClient.MySqlCommand("insert into `kullanici`(`kullanici_id`,`kullanici_adi`,`kullanici_soyadi`,`kullanici_sifre`)values('" + kullanici.kullanici_id + "', '" + kullanici.kullanici_adi + "', '" + kullanici.kullanici_soyadi + "', '" + kullanici.kullanici_sifre + "') ", sql.con);
            sql.cmd.ExecuteNonQuery();
            sql.con.Close();
        }
        public void KullaniciDuzenle(Models.Kullanici kullanici, string id)
        {
            sql.con.Open();
            sql.cmd = new MySql.Data.MySqlClient.MySqlCommand("update `kullanici` set `kullanici_id`='"+kullanici.kullanici_id+"', `kullanici_adi`='"+kullanici.kullanici_soyadi+"', `kullanici_soyadi`='"+kullanici.kullanici_soyadi+"', `kullanici_sifre`='"+kullanici.kullanici_sifre+"' where kullanici_id='"+id+"'",sql.con);
            sql.cmd.ExecuteNonQuery();
            sql.con.Close();
        }
    }
}