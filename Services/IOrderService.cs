using FoodAppAPI.Models;

namespace FoodAppAPI.Services
{
    public interface IOrderService
    {
        public OrderModel Create(OrderModel order);
        public List<OrderModel> Get();
        public OrderModel Get(string id);
        public OrderModel Update(string id, OrderModel order);
        public void Delete(string id);
        public OrderModel? UpdateStatus(string id, int status);
        List<OrderModel> GetUnassignedOrder();
        OrderModel AssignedOrder(string id, string riderId);
    }
}
