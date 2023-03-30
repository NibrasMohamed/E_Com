using System.ComponentModel.DataAnnotations.Schema;

namespace LapShop.Models
{
    [Table("series")]
    public class Series
    {
        public int SeriesID { get; set; }
        public string SeriesName { get; set; }
        public int CategoryID { get; set; }

        public int BrandId { get; set; }
        public Category Category { get; set; }

        public Brand Brand { get; set; }    
    }
}
