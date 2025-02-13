using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class EntityOgrDers
    {
        public int OgrDersId { get; set; }
        public int OgrId {  get; set; }
        public int DersId {  get; set; }
        public int? Sınav1 {  get; set; }//sınav notları null olabilmesi için
        public int? Sınav2 {  get; set; }
        public double? ortalama {  get; set; }
      
    }
}
