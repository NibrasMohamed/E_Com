namespace LapShop.Models
{
    public class ModelConfigurationItem
    {
        public int ModelConfigurationItemID { get; set; }
        public int ModelID { get; set; }
        public int ConfigurationItemID { get; set; }
        public Model Model { get; set; }
        public ConfigurationItem ConfigurationItem { get; set; }
    }
}
