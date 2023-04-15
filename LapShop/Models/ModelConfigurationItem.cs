using System.ComponentModel.DataAnnotations.Schema;

namespace LapShop.Models
{
    public class ModelConfigurationItem
    {
        public int ModelConfigurationItemID { get; set; }
        public int ModelID { get; set; }
        [ForeignKey("ModelID")]
        public int ConfigurationItemID { get; set; }
        [ForeignKey("ConfigurationItemID")]
        public Model Model { get; set; }
        public ConfigurationItem ConfigurationItem { get; set; }
    }
}
