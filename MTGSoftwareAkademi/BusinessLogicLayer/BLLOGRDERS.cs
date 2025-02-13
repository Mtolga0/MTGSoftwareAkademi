using DataAccesLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class BLLOGRDERS
    {
        public static List<EntityOgrDers> BllListele()
        {
            return DALOgrDers.NotListesi();
        }
        public static bool NotGuncelle(EntityOgrDers parametre)
        {
            if (parametre == null) { 
            return false;
            }
            return DALOgrDers.NotGuncelle(parametre);
        }
        public static int OgrenciEkle(EntityBasvuru parametre) 
        {
        if (parametre.DersId > 0 && parametre.OgrenciId > 0)
            {
                return DALOgrDers.OgrenciEkle(parametre);

            }
            return -1;
        }
    }
}
