using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class EntityOgretmen
    {
        private int Ogrtid;
        private string Ogrtadsoyad ;
        public string OGRTNO {  get; set; }
       public string OGRSIFRE {  get; set; }

        public int OGRTId { get => Ogrtid; set => Ogrtid = value; }
        public string OGRTAdsoyad { get => Ogrtadsoyad; set => Ogrtadsoyad = value; }

    }
}
