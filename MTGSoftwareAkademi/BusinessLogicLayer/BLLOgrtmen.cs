using DataAcces;
using DataAccesLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class BLLOgrtmen
    {
        public static int OgretmenEkleBLL(EntityOgretmen p)
        {
            if (p.OGRTAdsoyad != null &&  p.OGRSIFRE != null && p.OGRTNO != null)
            {
                return DALOgretmen.OgretmenEkle(p);
            }
            return -1;

        }
        public static List<EntityOgretmen> BllListele()
        {
            return DALOgretmen.ÖgretmenListesi();
        }
        public static bool OgretmenSilBll(int p)
        {
            if (p >= 0)
            {
                return DALOgretmen.OgrentmenSil(p);
            }
            return false;
        }
        public static  List<EntityOgretmen> BllDetay(int p)
        {
            return DALOgretmen.OgretmenDetay(p);
        }
        public static bool OgretmenGuncelle(EntityOgretmen değer)
        {
            if (değer.OGRTAdsoyad != null && değer.OGRTAdsoyad != " " && değer.OGRSIFRE != null && değer.OGRSIFRE != " " && değer.OGRTNO != null && değer.OGRTNO != " " && değer.OGRTId > 0)
            {
                return DALOgretmen.OgretmenGuncelle(değer);
            }
            return false;
        }
    }
}
