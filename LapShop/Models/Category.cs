using System.ComponentModel.DataAnnotations.Schema;

namespace LapShop.Models
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public virtual ICollection<Series> Series { get; set; }
        
    }
}
