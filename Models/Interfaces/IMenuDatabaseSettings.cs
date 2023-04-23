namespace FoodAppAPI.Models.Interfaces
{
    public interface IMenuDatabaseSettings
    {
        string MenuCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
