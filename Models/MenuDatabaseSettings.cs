using FoodAppAPI.Models.Interfaces;

namespace FoodAppAPI.Models
{
    public class MenuDatabaseSettings : IMenuDatabaseSettings
    {
        public string MenuCollectionName { get; set; } = String.Empty;
        public string ConnectionString { get; set; } = String.Empty;
        public string DatabaseName { get; set; } = String.Empty;
    }
}
