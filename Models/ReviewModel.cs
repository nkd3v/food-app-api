using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace FoodAppAPI.Models
{
    public class ReviewModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = ObjectId.GenerateNewId().ToString();
        public UserModel User { get; set; } = null!;
        public string Restaurant { get; set; } = string.Empty;
        public int Score { get; set; } = 0;
        public string Comment { get; set; } = string.Empty;
    }
}
