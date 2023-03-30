using System.Diagnostics.CodeAnalysis;

namespace LapShop.Models
{
    public class Model
    {
        public int ModelID { get; set; }
        public string ModelName { get; set; }

        public string? Image{ get; set; }
        public int SeriesID { get; set; }
        public decimal BasePrice { get; set; }
        public Series Series { get; set; }
    }
}
