using DataAcces;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer
{
    public class DALBasvuru
    {
        public static List<EntityBasvuru> BasvuruListesi()
        {
            //değerleri ekleyebilmek için liste
            List<EntityBasvuru> degerler = new List<EntityBasvuru>();
            //sql komutunu tanımlıyoruz
            SqlCommand komut1 = new SqlCommand("Select * from BASVURU", Connection.bgl);
            //AÇIK DEPİLSE AÇ
            if (komut1.Connection.State != ConnectionState.Open)
            {
                komut1.Connection.Open();
            }
            SqlDataReader dr = komut1.ExecuteReader();
            while (dr.Read())
            {
                EntityBasvuru ent = new EntityBasvuru();
                ent.BasvuruId = Convert.ToInt32(dr["BASVURUID"].ToString());
                ent.DersId = Convert.ToInt32(dr["DERSID"].ToString());
                ent.OgrenciId = Convert.ToInt32(dr["OGRID"].ToString());
                ent.OnayRed = Convert.ToBoolean(dr["OnayRed"].ToString());
                degerler.Add(ent);
            }
            dr.Close();
            return degerler;

        }
        public static int BasvuruEkle(EntityBasvuru entityBasvuru)
        {
            SqlCommand komut1 = new SqlCommand("Insert into BASVURU(OGRID,DERSID) VALUES(@P1,@P2)", Connection.bgl);
            if (komut1.Connection.State != ConnectionState.Open)
            {
                komut1.Connection.Open();
            }
            komut1.Parameters.AddWithValue("@P1", entityBasvuru.OgrenciId);
            komut1.Parameters.AddWithValue("@P2", entityBasvuru.DersId);
            return komut1.ExecuteNonQuery();
        }
        public static int TalepOnayla(int id)
        {
            SqlCommand komut = new SqlCommand("Update Basvuru Set OnayRed=1 where BasvuruId=@P1 ", Connection.bgl);
            if (komut.Connection.State != ConnectionState.Open)
            {
                komut.Connection.Open();
            }
            komut.Parameters.AddWithValue("@P1", id);
            return komut.ExecuteNonQuery();
        }
        public static int TalepSil(int id)
        {
            SqlCommand komut = new SqlCommand("Delete From Basvuru where BasvuruId=@P1", Connection.bgl);
            if (komut.Connection.State != ConnectionState.Open)
            {
                komut.Connection.Open();
            }
            komut.Parameters.AddWithValue("@P1", id);
            return komut.ExecuteNonQuery();
        }
    }
}
