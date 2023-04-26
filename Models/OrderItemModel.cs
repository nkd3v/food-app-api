using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace FoodAppAPI.Models
{
    public class OrderItemModel
    {
        [BsonElement("menuId")]
        public Menu menu { get; set; } = null!;
        [BsonElement("quantity")]
        public int Quantity { get; set; } = 1;
    }
}
