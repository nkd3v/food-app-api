using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace FoodAppAPI.Models
{
    public class OrderModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = ObjectId.GenerateNewId().ToString();

        [BsonElement("userId")]
        public string UserId { get; set; } = String.Empty;

        [BsonElement("orderItems")]
        public List<OrderItemModel>? OrderItems { get; set; } = null;

        [BsonElement("detail")]
        public string Detail { get; set; } = String.Empty;

        [BsonElement("status")]
        public string Status { get; set; } = String.Empty;
    }
}
