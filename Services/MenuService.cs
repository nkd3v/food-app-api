using FoodAppAPI.Models;
using FoodAppAPI.Models.Responses;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Text;
using System.Security.Cryptography;
using System.Text;

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

        public List<CanteenRestaurantDTO> GetCanteenRestaurant()
        {
            List<CanteenRestaurantDTO> result = new List<CanteenRestaurantDTO>();
            var distinctRestaurants = _menus.Distinct<string>("restaurant", new BsonDocument()).ToList();

            foreach (var restaurant in distinctRestaurants)
            {
                var restaurantAddress = _menus.Find(x => x.Restaurant == restaurant)
                    .FirstOrDefault().RestaurantAddress;

                Console.WriteLine($"{restaurant} - {restaurantAddress}");
                result.Add(new CanteenRestaurantDTO
                {
                    Canteen = restaurantAddress,
                    Restaurant = restaurant
                });
            }

            return result;
        }

        private string CalculateSHA256Hash(string input)
        {
            Console.WriteLine(input);
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = sha256.ComputeHash(inputBytes);
                var result = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
                Console.WriteLine(result);
                return result;
            }
        }

        public List<Menu> GetMenuByRestaurantId(string id)
        {
            List<Menu> menus = Get().Where(x => CalculateSHA256Hash(x.Restaurant) == id).ToList();
            return menus;
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
