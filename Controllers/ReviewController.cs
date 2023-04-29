using FoodAppAPI.Models;
using FoodAppAPI.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FoodAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _reviewService;

        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        // GET: api/<ReviewController>
        [HttpGet]
        public ActionResult<List<ReviewModel>> Get()
        {
            return _reviewService.Get();
        }

        // GET api/<ReviewController>/5
        [HttpGet("{id}")]
        public ActionResult<ReviewModel> Get(string id)
        {
            return _reviewService.Get(id);
        }

        // POST api/<ReviewController>
        [HttpPost]
        public ActionResult<ReviewModel> Post([FromBody] ReviewModel review)
        {
            return _reviewService.Create(review);
        }

        // DELETE api/<ReviewController>/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            _reviewService.Delete(id);
        }
    }
}
