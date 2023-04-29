using FoodAppAPI.Models;

namespace FoodAppAPI.Services
{
    public interface IReviewService
    {
        public ReviewModel Create(ReviewModel review);
        public List<ReviewModel> Get();
        public ReviewModel Get(string id);
        public ReviewModel Update(string id, ReviewModel review);
        public void Delete(string id);
    }
}
