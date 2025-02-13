using DataAcces;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer
{
    public class DALOgretmen
    {
        public static int OgretmenEkle(EntityOgretmen parametre)
        {
            //sql komutlarını tanımlıyoruz 
            SqlCommand komut1 = new SqlCommand("insert into TBLOGRETMEN" +
                "(OGRTADSOYAD,OGRTNO,OGRTSIFRE) VALUES (@P1,@P2,@P3)", Connection.bgl);
            //bağlantı açık değilse aç
            if (komut1.Connection.State != ConnectionState.Open)
            {
                komut1.Connection.Open();
            }
            string newpass = Hash.getHashSha256(parametre.OGRSIFRE);
            //değerleri al
            komut1.Parameters.AddWithValue("@p1", parametre.OGRTAdsoyad);
            komut1.Parameters.AddWithValue("@p2", parametre.OGRTNO);
            

            komut1.Parameters.AddWithValue("@p3", newpass);
            return komut1.ExecuteNonQuery();

        }
        //verileri veri tabanından çekmek için kullanılacak komut
        public static List<EntityOgretmen> ÖgretmenListesi()
        {
            //entity değerleri listeye ekleyebilmek için
            List<EntityOgretmen> degerler = new List<EntityOgretmen>();
            //yeni sql komutu tanımla
            SqlCommand komut2 = new SqlCommand("Select*from TBLOGRETMEN ", Connection.bgl);
            //AÇIK DEPİLSE AÇ
            if (komut2.Connection.State != ConnectionState.Open)
            {
                komut2.Connection.Open();
            }
            //okuyucu komutu tanımla
            SqlDataReader dr = komut2.ExecuteReader();
            while (dr.Read())
            {
                EntityOgretmen ent = new EntityOgretmen();
                ent.OGRTId = Convert.ToInt32((dr["OGRTID"]).ToString());
                ent.OGRTAdsoyad = dr["OGRTADSOYAD"].ToString();
                
                ent.OGRTNO = dr["OGRTNO"].ToString();

                ent.OGRSIFRE = dr["OGRTSIFRE"].ToString();

                //entdeki değerleri değerler listesine ekle
                degerler.Add(ent);

            }
            dr.Close();
            return degerler;
        }
        public static bool OgrentmenSil(int parametre)
        {
            //sql komutu oluştur
            SqlCommand sil = new SqlCommand("delete from TBLOGRETMEN WHERE OGRTID=@P1", Connection.bgl);
            //bağlantı açık değilse aç
            if (sil.Connection.State != ConnectionState.Open)
            {
                sil.Connection.Open();
            }
            sil.Parameters.AddWithValue("@P1", parametre);
            return sil.ExecuteNonQuery() > 0;
        }
        public static List<EntityOgretmen> OgretmenDetay(int ıd)
        {
            //entity değerleri listeye ekleyebilmek için
            List<EntityOgretmen> degerler = new List<EntityOgretmen>();
            //yeni sql komutu tanımla
            SqlCommand komut4 = new SqlCommand("Select*from TBLOGRETMEN where OGRTID=@P1 ", Connection.bgl);
            komut4.Parameters.AddWithValue("@P1", ıd);
            //AÇIK DEPİLSE AÇ
            if (komut4.Connection.State != ConnectionState.Open)
            {
                komut4.Connection.Open();
            }
            //okuyucu komutu tanımla
            SqlDataReader dr = komut4.ExecuteReader();
            while (dr.Read())
            {
                EntityOgretmen ent = new EntityOgretmen();

                ent.OGRTAdsoyad = dr["OGRTADSOYAD"].ToString();
                
                ent.OGRTNO = dr["OGRTNO"].ToString();

                ent.OGRSIFRE = dr["OGRTSIFRE"].ToString();

                //entdeki değerleri değerler listesine ekle
                degerler.Add(ent);

            }
            dr.Close();
            return degerler;
        }
        public static bool OgretmenGuncelle(EntityOgretmen deger)
        {

            //sql komutunu tanıtmlayıp güncelleme yap
            SqlCommand komut5 = new SqlCommand("Update TBLOGRETMEN SET OGRTADSOYAD=@P1,OGRTNO=@P3," +
                "OGRTSIFRE=@P5 WHERE OGRTID=@P6", Connection.bgl);
            //bağlantı açık değilse aç
            if (komut5.Connection.State != ConnectionState.Open)
            {
                komut5.Connection.Open();
            }
            komut5.Parameters.AddWithValue("@p1", deger.OGRTAdsoyad);
            
            komut5.Parameters.AddWithValue("@p3", deger.OGRTNO);

            komut5.Parameters.AddWithValue("@p5", deger.OGRSIFRE);
            komut5.Parameters.AddWithValue("@p6", deger.OGRTId);
            return komut5.ExecuteNonQuery() > 0;
        }
    }
}
