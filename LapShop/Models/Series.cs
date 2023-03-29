namespace LapShop.Models
{
    public class Series
    {
        public int SeriesID { get; set; }
        public string SeriesName { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }

    }
}
