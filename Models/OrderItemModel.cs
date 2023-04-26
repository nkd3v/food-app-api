using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace FoodAppAPI.Models
{
    public class OrderItemModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = ObjectId.GenerateNewId().ToString();
        [BsonElement("menuId")]
        public string MenuId { get; set; } = String.Empty;
        [BsonElement("quantity")]
        public int Quantity { get; set; } = 1;
    }
}
