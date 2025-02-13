using DataAccesLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class BLLBasvuru
    {
        public static List<EntityBasvuru> ListeleBll()
        {
            return DALBasvuru.BasvuruListesi();
        }
        public static int BasvuruEkle(EntityBasvuru entityBasvuru)
        {
            if (entityBasvuru.OgrenciId > 0 && entityBasvuru.DersId > 0)
            {
                return DALBasvuru.BasvuruEkle(entityBasvuru);
            }
            return 0;
        }
        public static int TalepOnayla(int id)
        {
            if (id > 0) { DALBasvuru.TalepOnayla(id); }
            return 0;
        }
        public static int TalepSil(int id)
        {
            if (id > 0) { DALBasvuru.TalepSil(id); }
            return 0;
        }
    }
}
