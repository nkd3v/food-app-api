using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace FoodAppAPI.Models
{
    public class OrderModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = ObjectId.GenerateNewId().ToString();

        [BsonElement("user")]
        public UserModel User { get; set; } = null!;
        [BsonElement("rider")]
        public UserModel? Rider { get; set; } = null;

        [BsonElement("orderItems")]
        public List<OrderItemModel>? OrderItems { get; set; } = null;

        [BsonElement("detail")]
        public string Detail { get; set; } = String.Empty;
        public string RestaurantName { get; set; } = String.Empty;
        public string RestaurantAddress { get; set; } = String.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime ModifedAt { get; set; } = DateTime.UtcNow;

        [BsonElement("status")]
        public int Status { get; set; } = 0;
    }
}
