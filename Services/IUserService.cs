using FoodAppAPI.Models;
using FoodAppAPI.Models.Requests;

namespace FoodAppAPI.Services
{
    public interface IUserService
    {
        public UserModel Create(UserModel user);
        public List<UserModel> Get();
        public UserModel Get(string id);
        public UserModel Update(string id, UserModel user);
        public void Delete(string id);
        UserModel? GetByUsername(string username);
        UserModel? UpdateDeliveryInfo(string id, UserDeliveryInfoDTO userDeliveryInfo);
    }
}
