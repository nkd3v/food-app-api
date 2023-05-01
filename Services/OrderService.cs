using FoodAppAPI.Models;
using MongoDB.Driver;

namespace FoodAppAPI.Services
{
    public class OrderService : IOrderService
    {
        private readonly IMongoCollection<OrderModel> _orders;
        private readonly IMongoCollection<UserModel> _users;

        public OrderService(IDatabaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _orders = database.GetCollection<OrderModel>(settings.OrderCollectionName);
            _users = database.GetCollection<UserModel>(settings.UserCollectionName);
        }

        public OrderModel Create(OrderModel order)
        {
            _orders.InsertOne(order);
            return order;
        }

        public void Delete(string id)
        {
            _orders.DeleteOne(x => x.Id == id);
        }

        public List<OrderModel> Get()
        {
            return _orders.Find(x => true).ToList();
        }

        public List<OrderModel> GetUnassignedOrder()
        {
            return _orders.Find(x => x.Status == 0).ToList();
        }

        public OrderModel Get(string id)
        {
            return _orders.Find(x => x.Id == id).FirstOrDefault();
        }

        public OrderModel Update(string id, OrderModel order)
        {
            _orders.ReplaceOne(x => x.Id == id, order);
            return order;
        }

        public OrderModel? UpdateStatus(string id, int status)
        {
            var order = _orders.Find(x => x.Id == id).FirstOrDefault();

            if (order == null)
            {
                return null;
            }

            order.Status = status;
            _orders.ReplaceOne(o => o.Id == id, order);
            return order;
        }

        public OrderModel? AssignedOrder(string id, string riderId)
        {
            var order = _orders.Find(x => x.Id == id).FirstOrDefault();

            if (order == null)
            {
                return null;
            }

            order.Rider = _users.Find(x => x.Id == riderId).FirstOrDefault();
            order.Status = 25;
            _orders.ReplaceOne(o => o.Id == id, order);
            return order;
        }

        public List<OrderModel> GetOrderByRiderId(string riderId)
        {
            var orders = _orders.Find(x => x.Rider != null && x.Rider.Id == riderId).ToList();
            return orders;
        }

        public List<OrderModel> GetOrderByCustomerId(string customerId)
        {
            var orders = _orders.Find(x => x.User != null && x.User.Id == customerId).ToList();
            return orders;
        }
    }
}
