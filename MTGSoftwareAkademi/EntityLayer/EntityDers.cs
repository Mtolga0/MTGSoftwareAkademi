using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class EntityDers
    {
        private string DersAd;
        private int id;
        public int OGRTID {  get; set; }
    

        public string DERSAD { get => DersAd; set => DersAd = value; }
      
     
        public int Id { get => id; set => id = value; }
    }
}
