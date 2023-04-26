using FoodAppAPI.Models;
using MongoDB.Driver;

namespace FoodAppAPI.Services
{
    public class OrderService : IOrderService
    {
        private readonly IMongoCollection<OrderModel> _orders;

        public OrderService(IDatabaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _orders = database.GetCollection<OrderModel>(settings.OrderCollectionName);
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

        public OrderModel Get(string id)
        {
            return _orders.Find(x => x.Id == id).FirstOrDefault();
        }

        public OrderModel Update(string id, OrderModel order)
        {
            _orders.ReplaceOne(x => x.Id == id, order);
            return order;
        }
    }
}
