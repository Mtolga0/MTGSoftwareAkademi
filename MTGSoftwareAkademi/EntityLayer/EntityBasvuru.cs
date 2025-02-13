using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class EntityBasvuru
    {
        //Basvuru tableının entityleri
        public int BasvuruId{get;set;}
        public int OgrenciId { get;set;}
        public int DersId  {get;set;}
        public bool OnayRed { get;set;}
    }
}
