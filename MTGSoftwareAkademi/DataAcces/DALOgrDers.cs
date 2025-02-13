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
    public class DALOgrDers
    {
        public static List<EntityOgrDers> NotListesi()
        {
            //entity değerleri listeye ekleyebilmek için
            List<EntityOgrDers> degerler = new List<EntityOgrDers>();
            //yeni sql komutu tanımla
            SqlCommand komut2 = new SqlCommand("Select*from TBLALINANDERSLER ", Connection.bgl);
            //AÇIK DEPİLSE AÇ
            if (komut2.Connection.State != ConnectionState.Open)
            {
                komut2.Connection.Open();
            }
            //okuyucu komutu tanımla
            SqlDataReader dr = komut2.ExecuteReader();
            while (dr.Read())
            {
                EntityOgrDers ent = new EntityOgrDers();
                ent.OgrDersId = Convert.ToInt32((dr["OGRDERSID"]).ToString());
                ent.OgrId = Convert.ToInt32((dr["OGRENCID"]).ToString());
                
                ent.DersId = Convert.ToInt32((dr["DERSID"]).ToString());
                if (dr["SINAV1"] != DBNull.Value)
                {
                    ent.Sınav1 = Convert.ToInt32(dr["SINAV1"]);
                }
                else
                {
                    ent.Sınav1 = null; // Burada null kullanıyorsunuz
                }
                if (dr["SINAV2"] != DBNull.Value)
                {
                    ent.Sınav2 = Convert.ToInt32(dr["SINAV2"]);
                }
                else
                {
                    ent.Sınav2 = null; // Burada null kullanıyorsunuz
                }
                if (dr["Ortalama"] != DBNull.Value)
                {
                    ent.ortalama = Convert.ToInt32(dr["ortalama"]);
                }
                else
                {
                    ent.ortalama = null; // Burada null kullanıyorsunuz
                }

               

                //entdeki değerleri değerler listesine ekle
                degerler.Add(ent);

            }
            dr.Close();
            return degerler;
        }
        //public static List<EntityOgrDers> DersDetay(int ıd)
        //{
        //    //entity değerleri listeye ekleyebilmek için
        //    List<EntityOgrDers> degerler = new List<EntityOgrDers>();
        //    //yeni sql komutu tanımla
        //    SqlCommand komut4 = new SqlCommand("Select*from TBLALINANDERSLER where DERSID=@P1 ", Connection.bgl);
        //    komut4.Parameters.AddWithValue("@P1", ıd);
        //    //AÇIK DEPİLSE AÇ
        //    if (komut4.Connection.State != ConnectionState.Open)
        //    {
        //        komut4.Connection.Open();
        //    }
        //    //okuyucu komutu tanımla
        //    SqlDataReader dr = komut4.ExecuteReader();
        //    while (dr.Read())
        //    {
        //        EntityOgrenci ent = new EntityOgrenci();

        //        ent.Ad = dr["OGRAD"].ToString();
        //        ent.Soyad = dr["OGRSOYAD"].ToString();
        //        ent.Numara = dr["OGRNUMARA"].ToString();

        //        ent.Sıfre = dr["OGRSIFRE"].ToString();

        //        //entdeki değerleri değerler listesine ekle
        //        degerler.Add(ent);

        //    }
        //    dr.Close();
        //    return degerler;
        //}
        public static bool NotGuncelle(EntityOgrDers parametre)
        {
            SqlCommand komut = new SqlCommand("UPDATE TBLALINANDERSLER SET SINAV1=@P1, SINAV2=@P2, ORTALAMA=@P3 WHERE DERSID=@P4 AND OGRENCID=@P5", Connection.bgl);

            // Bağlantı açık değilse aç
            if (komut.Connection.State != ConnectionState.Open)
            {
                komut.Connection.Open();
            }

            komut.Parameters.AddWithValue("@P1", parametre.Sınav1);
            komut.Parameters.AddWithValue("@P2", parametre.Sınav2);
            komut.Parameters.AddWithValue("@P3", parametre.ortalama);
            komut.Parameters.AddWithValue("@P4", parametre.DersId); // DersID
            komut.Parameters.AddWithValue("@P5", parametre.OgrId); // OgrenciID

            return komut.ExecuteNonQuery() > 0;
        }
        public static int OgrenciEkle(EntityBasvuru parametre) 
        {
        SqlCommand komut=new SqlCommand("INSERT INTO TBLALINANDERSLER(OGRENCID,DERSID) VALUES(@P1,@P2)",Connection.bgl);
            // Bağlantı açık değilse aç
            if (komut.Connection.State != ConnectionState.Open)
            {
                komut.Connection.Open();
            }
            komut.Parameters.AddWithValue("@P1", parametre.OgrenciId);
            komut.Parameters.AddWithValue("@P2", parametre.DersId);
            return komut.ExecuteNonQuery();


        }

    }
}
