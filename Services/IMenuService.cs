using FoodAppAPI.Models;
using FoodAppAPI.Models.Responses;

namespace FoodAppAPI.Services
{
    public interface IMenuService
    {
        public Menu Create(Menu menu);
        public List<Menu> Get();
        public Menu Get(string id);
        public Menu Update(string id, Menu menu);
        public void Delete(string id);
        List<CanteenRestaurantDTO> GetCanteenRestaurant();
        List<Menu> GetMenuByRestaurantId(string id);
    }
}
