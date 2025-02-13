using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using EntityLayer;
using DataAcces;
using System.Security.Cryptography.X509Certificates;

namespace DataAccesLayer
{
    public class DALDersler
    {
        public static List<EntityDers> DersListesi()
        {
            //entity değerleri listeye ekleyebilmek için
            List<EntityDers> degerler = new List<EntityDers>();
            //yeni sql komutu tanımla
            SqlCommand komut2 = new SqlCommand("Select * from TBLDERSLER ", Connection.bgl);
            //AÇIK DEPİLSE AÇ
            if (komut2.Connection.State != ConnectionState.Open)
            {
                komut2.Connection.Open();
            }
            //okuyucu komutu tanımla
            SqlDataReader dr = komut2.ExecuteReader();
            while (dr.Read())
            {
                EntityDers ent = new EntityDers();
                ent.Id = Convert.ToInt32((dr["DERSID"]).ToString());
                ent.DERSAD = dr["DERSAD"].ToString();
                ent.OGRTID = Convert.ToInt32((dr["OGRTID"]).ToString());


                //entdeki değerleri değerler listesine ekle
                degerler.Add(ent);

            }
            dr.Close();
            return degerler;
            komut2.Connection.Close(); // Bağlantıyı kapatmayı unutmayın
        }
        public static int TalepEkle(EntityBasvuru Parametre)
        {
            SqlCommand komut2 = new SqlCommand("insert into BASVURU (OGRID,DERSID,ONAYRED) VALUES(@P1,@P2,@P3)", Connection.bgl);
            bool onay = true;
            komut2.Parameters.AddWithValue("@P1", Parametre.OgrenciId);
            komut2.Parameters.AddWithValue("@P2", Parametre.DersId);
            komut2.Parameters.AddWithValue("@P3", onay);
            if (komut2.Connection.State != ConnectionState.Open) { komut2.Connection.Open(); }
            return komut2.ExecuteNonQuery();
        }
        public static int DersEkle(EntityDers parametre) 
        {
            SqlCommand ders = new SqlCommand("INSERT INTO TBLDERSLER (DERSAD,OGRTID) VALUES(@P1,@P2)", Connection.bgl);
            if (ders.Connection.State != ConnectionState.Open)
            {
                ders.Connection.Open();
            }
            ders.Parameters.AddWithValue("@P1",parametre.DERSAD);
            ders.Parameters.AddWithValue("@P2",parametre.OGRTID);
            return ders.ExecuteNonQuery();  


        }
    }
}
