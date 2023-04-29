using FoodAppAPI.Models;
using MongoDB.Driver;

namespace FoodAppAPI.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IMongoCollection<ReviewModel> _reviews;

        public ReviewService(IDatabaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _reviews = database.GetCollection<ReviewModel>(settings.ReviewCollectionName);
        }

        public ReviewModel Create(ReviewModel review)
        {
            _reviews.InsertOne(review);
            return review;
        }

        public void Delete(string id)
        {
            _reviews.DeleteOne(x => x.Id == id);
        }

        public List<ReviewModel> Get()
        {
            return _reviews.Find(x => true).ToList();
        }

        public ReviewModel Get(string id)
        {
            return _reviews.Find(x => x.Id == id).FirstOrDefault();
        }

        public ReviewModel Update(string id, ReviewModel review)
        {
            _reviews.ReplaceOne(x => x.Id == id, review);
            return review;
        }
    }
}
