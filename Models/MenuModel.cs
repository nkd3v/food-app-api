using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace FoodAppAPI.Models
{
    [BsonIgnoreExtraElements]
    public class Menu
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = ObjectId.GenerateNewId().ToString();
        [BsonElement("restaurant")]
        public string Restaurant { get; set; } = String.Empty;
        [BsonElement("foodname")]
        public string FoodName { get; set; } = String.Empty;
        [BsonElement("category")]
        public string Category { get; set; } = String.Empty;
        [BsonElement("price")]
        public double Price { get; set; } = 0;
        [BsonElement("image")]
        public string Image { get; set; } = String.Empty;
    }
}
