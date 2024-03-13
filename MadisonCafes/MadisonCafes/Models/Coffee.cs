namespace MadisonCafes.Models
{
    public class Coffee
    {
        public int CoffeeID { get; set; }
        public string Cafe { get; set; }
        public string Location { get; set; }
        public string Late_Night_Spots { get; set; }
        public double Starting_Price { get; set; }
        public string Ambience { get; set; }
        public string Wifi { get; set; }
        public string Tipping { get; set; }
        public string Featured_Cafe { get; set; }
        public IEnumerable<FeaturedCafe> FeaturedCafe { get; set; }






    }
}
