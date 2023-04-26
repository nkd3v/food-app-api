using FoodAppAPI.Models;
using MongoDB.Driver;

namespace FoodAppAPI.Services
{
    public class MenuService : IMenuService
    {
        private readonly IMongoCollection<Menu> _menus;

        public MenuService(IMenuDatabaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _menus = database.GetCollection<Menu>(settings.MenuCollectionName);
        }

        public Menu Create(Menu menu)
        {
            _menus.InsertOne(menu);
            return menu;
        }

        public void Delete(string id)
        {
            _menus.DeleteOne(x => x.Id == id);
        }

        public List<Menu> Get()
        {
            return _menus.Find(x => true).ToList();
        }

        public Menu Get(string id)
        {
            return _menus.Find(x => x.Id == id).FirstOrDefault();
        }

        public Menu Update(string id, Menu menu)
        {
            _menus.ReplaceOne(x => x.Id == id, menu);
            return menu;
        }
    }
}
