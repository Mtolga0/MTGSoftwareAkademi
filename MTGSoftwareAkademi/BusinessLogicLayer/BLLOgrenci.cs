using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccesLayer;
using EntityLayer;

namespace  BusinessLogicLayer
{
    public class BLLOgrenci
    {
        public static int OgrenciEkleBLL(EntityOgrenci p)
        {
            if (p.Ad != null && p.Soyad != null && p.Sıfre != null && p.Numara != null)
            {
                return DALOgrenci.OgrenciEkle(p);
            }
            return -1;
        }
        public static List<EntityOgrenci> BllListele()
        {
            return DALOgrenci.OgrenciListesi();
        }
        public static bool OgrenciSilBll(int p)
        {
            if (p >=0)
            {
                return DALOgrenci.OgrenciSil(p);
            }
            return false;
        }
        public static List<EntityOgrenci> BllDetay(int id)
        {
            return DALOgrenci.OgrenciDetay(id);
        }
        public static bool OgrenciGuncelle(EntityOgrenci p) 
        {
            if (p.Ad != null&&p.Ad!=" " && p.Soyad != null && p.Soyad != " " && p.Sıfre != null && p.Sıfre != " " && p.Numara != null && p.Numara != " "  && p.Id>0)
            {
                return DALOgrenci.OgrenciGuncelle(p);
            }
            return false;

        }

    }
}
