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
    public class DALUsers
    {
        public static int KullanıcıEkle(EntityUsers parametre)
        {
            //sql komutlarını tanımlıyoruz 
            SqlCommand komut1 = new SqlCommand("insert into Users" +
                "(NUMARA,PASSWORD,NAME,SURNAME,ROLE,DEPARTMENT) VALUES (@P1,@P2,@P3,@P4,P5,P6)", Connection.bgl);
            //bağlantı açık değilse aç
            if (komut1.Connection.State != ConnectionState.Open)
            {
                komut1.Connection.Open();
            }
            string newpass = Hash.getHashSha256(parametre.PassWord);
            //değerleri al
            komut1.Parameters.AddWithValue("@p4", parametre.Firstname);
            komut1.Parameters.AddWithValue("@p3", parametre.SurName);
            komut1.Parameters.AddWithValue("@p1", parametre.No);
            komut1.Parameters.AddWithValue("@p2", newpass);
            komut1.Parameters.AddWithValue("@p5", parametre.Role);
            komut1.Parameters.AddWithValue("@p6", parametre.Department);

            return komut1.ExecuteNonQuery();

        }
    }
}
