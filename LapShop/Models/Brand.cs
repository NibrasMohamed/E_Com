namespace LapShop.Models
{
    public class Brand
    {
        public int BrandID { get; set; }
        public string BrandName { get; set; }

        public ICollection<Series> Series { get; set; }
    }
}
