namespace EntityLayer
{
    public class EntityOgrenci
    {
        private string ad;
        private string soyad;
        private int id;
        private string numara;

        private string sıfre;

        public string Ad { get => ad; set => ad = value; }
        public string Soyad { get => soyad; set => soyad = value; }
        public int Id { get => id; set => id = value; }
        public string Numara { get => numara; set => numara = value; }
        public string AdSoyad { get  { return ad + " " + soyad; } }

        public string Sıfre { get => sıfre; set => sıfre = value; }
    }
}
