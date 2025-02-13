using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using EntityLayer;
using DataAcces;
using System.Web;

namespace DataAccesLayer
{
    public class DALOgrenci
    {
        public static int OgrenciEkle(EntityOgrenci parametre)
        {
            //sql komutlarını tanımlıyoruz 
            SqlCommand komut1 = new SqlCommand("insert into TBLOGRENCILER" +
                "(OgrAD,OGRSOYAD,OGRNUMARA,OGRSIFRE) VALUES (@P1,@P2,@P3,@P4)", Connection.bgl);
            //bağlantı açık değilse aç
            if (komut1.Connection.State != ConnectionState.Open)
            {
                komut1.Connection.Open();
            }
            string newpass = Hash.getHashSha256(parametre.Sıfre);
            //değerleri al
            komut1.Parameters.AddWithValue("@p1", parametre.Ad);
            komut1.Parameters.AddWithValue("@p2", parametre.Soyad);
            komut1.Parameters.AddWithValue("@p3", parametre.Numara);
            
            komut1.Parameters.AddWithValue("@p4", newpass);
            return komut1.ExecuteNonQuery();

        }
        //verileri veri tabanından çekmek için kullanılacak komut
        public static List<EntityOgrenci> OgrenciListesi()
        {
            //entity değerleri listeye ekleyebilmek için
            List<EntityOgrenci> degerler = new List<EntityOgrenci>();
            //yeni sql komutu tanımla
            SqlCommand komut2 = new SqlCommand("Select*from TBLOGRENCILER ", Connection.bgl);
            //AÇIK DEPİLSE AÇ
            if (komut2.Connection.State != ConnectionState.Open)
            {
                komut2.Connection.Open();
            }
            //okuyucu komutu tanımla
            SqlDataReader dr = komut2.ExecuteReader();
            while (dr.Read())
            {
                EntityOgrenci ent = new EntityOgrenci();
                ent.Id = Convert.ToInt32((dr["OGRID"]).ToString());
                ent.Ad = dr["OGRAD"].ToString();
                ent.Soyad = dr["OGRSOYAD"].ToString();
                ent.Numara = dr["OGRNUMARA"].ToString();
     
                ent.Sıfre = dr["OGRSIFRE"].ToString();
   
                //entdeki değerleri değerler listesine ekle
                degerler.Add(ent);

            }
            dr.Close();
            return degerler;
        }
        public static bool OgrenciSil(int parametre)
        {
            //sql komutu oluştur
            SqlCommand sil = new SqlCommand("delete from TBLOGRENCILER WHERE OGRID=@P1", Connection.bgl);
            //bağlantı açık değilse aç
            if (sil.Connection.State != ConnectionState.Open)
            {
                sil.Connection.Open();
            }
            sil.Parameters.AddWithValue("@P1", parametre);
            return sil.ExecuteNonQuery() > 0;
        }
        public static List<EntityOgrenci> OgrenciDetay(int ıd)
        {
            //entity değerleri listeye ekleyebilmek için
            List<EntityOgrenci> degerler = new List<EntityOgrenci>();
            //yeni sql komutu tanımla
            SqlCommand komut4 = new SqlCommand("Select*from TBLOGRENCILER where OGRID=@P1 ", Connection.bgl);
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
                EntityOgrenci ent = new EntityOgrenci();

                ent.Ad = dr["OGRAD"].ToString();
                ent.Soyad = dr["OGRSOYAD"].ToString();
                ent.Numara = dr["OGRNUMARA"].ToString();
              
                ent.Sıfre = dr["OGRSIFRE"].ToString();
              
                //entdeki değerleri değerler listesine ekle
                degerler.Add(ent);

            }
            dr.Close();
            return degerler;
        }
        public static bool OgrenciGuncelle(EntityOgrenci deger)
        {

            //sql komutunu tanıtmlayıp güncelleme yap
            SqlCommand komut5 = new SqlCommand("Update TBLOGRENCILER SET OGRAD=@P1,OGRSOYAD=@P2,OGRNUMARA=@P3," +
                "OGRSIFRE=@P5 WHERE OGRID=@P6", Connection.bgl); 
            //bağlantı açık değilse aç
            if (komut5.Connection.State != ConnectionState.Open)
            {
                komut5.Connection.Open();
            }
            komut5.Parameters.AddWithValue("@p1", deger.Ad);
            komut5.Parameters.AddWithValue("@p2", deger.Soyad);
            komut5.Parameters.AddWithValue("@p3", deger.Numara);
           
            komut5.Parameters.AddWithValue("@p5", deger.Sıfre);
            komut5.Parameters.AddWithValue("@p6", deger.Id);
            return komut5.ExecuteNonQuery()>0;
        }
        public static int OgrenciKontrol(EntityOgrenci parametre)
        {
            //sql komutlarını tanımlıyoruz 
            SqlCommand login = new SqlCommand("select * from TBLOGRENCİLER where ogrnumara=@p1 and ogrsifre=@p2",Connection.bgl);
            //bağlantı açık değilse aç
            if (login.Connection.State != ConnectionState.Open)
            {
               login.Connection.Open();
            }
            string newpass = Hash.getHashSha256(parametre.Sıfre);
            //değerleri al
          
            login.Parameters.AddWithValue("@p3", parametre.Numara);

            login.Parameters.AddWithValue("@p4", newpass);
            return login.ExecuteNonQuery();

        }
     
    }
}
