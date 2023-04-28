namespace FoodAppAPI.Models
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string MenuCollectionName { get; set; } = String.Empty;
        public string OrderCollectionName { get; set; } = String.Empty;
        public string UserCollectionName { get; set; } = String.Empty;
        public string ConnectionString { get; set; } = String.Empty;
        public string DatabaseName { get; set; } = String.Empty;
    }
}
