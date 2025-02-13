using DataAccesLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class BLLDers
    {
        public static List<EntityDers> BllListele()
        {
            return DALDersler.DersListesi();
       }
        public static int TalepEkleBll(EntityBasvuru p)
        {
            if (p.DersId>0 && p.OgrenciId>0 )
            { return DALDersler.TalepEkle(p); }
            return -1;
        }
        public static int DersEkleBll(EntityDers p)
        {
            if (p.DERSAD != null && p.OGRTID>0)
            { return DALDersler.DersEkle(p); }
            return -1;
        }

    }
}