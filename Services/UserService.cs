using FoodAppAPI.Models;
using FoodAppAPI.Models.Requests;
using MongoDB.Driver;
using System.Text.Json;

namespace FoodAppAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IMongoCollection<UserModel> _users;

        public UserService(IDatabaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _users = database.GetCollection<UserModel>(settings.UserCollectionName);
        }

        public UserModel Create(UserModel user)
        {
            _users.InsertOne(user);
            return user;
        }

        public void Delete(string id)
        {
            _users.DeleteOne(x => x.Id == id);
        }

        public List<UserModel> Get()
        {
            return _users.Find(x => true).ToList();
        }

        public UserModel Get(string id)
        {
            return _users.Find(x => x.Id == id).FirstOrDefault();
        }

        public UserModel Update(string id, UserModel user)
        {
            _users.ReplaceOne(x => x.Id == id, user);
            return user;
        }

        public UserModel? UpdateDeliveryInfo(string id, UserDeliveryInfoDTO userDeliveryInfo)
        {
            Console.WriteLine(JsonSerializer.Serialize(userDeliveryInfo));
            var user = _users.Find(x => x.Id == id).FirstOrDefault();
            Console.WriteLine(id);
            user.FirstName = userDeliveryInfo.FirstName;
            user.PhoneNumber = userDeliveryInfo.PhoneNumber;
            user.Address = userDeliveryInfo.Address;

            var result = _users.ReplaceOne(x => x.Id == id, user);

            if (result == null || !result.IsAcknowledged)
            {
                return null;
            }

            return user;
        }

        public UserModel? GetByUsername(string username)
        {
            return _users.Find(x => x.Username == username).FirstOrDefault();
        }
    }
}
