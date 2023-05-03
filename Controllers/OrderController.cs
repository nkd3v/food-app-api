using FoodAppAPI.Models;
using FoodAppAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FoodAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        // GET: api/<OrderController>
        [HttpGet]
        public ActionResult<List<OrderModel>> Get()
        {
            return _orderService.Get();
        }

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public ActionResult<OrderModel> Get(string id)
        {
            return _orderService.Get(id);
        }

        // POST api/<OrderController>
        [HttpPost]
        public ActionResult<OrderModel> Post([FromBody] OrderModel order)
        {
            return _orderService.Create(order);
        }

        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            _orderService.Delete(id);
        }

        [HttpPatch("status/{id}")]
        public ActionResult<OrderModel> UpdateStatus(string id, [FromBody] int orderStatus)
        {
            var updatedOrder = _orderService.UpdateStatus(id, orderStatus);
            if (updatedOrder == null)
            {
                return NotFound();
            }
            return Ok(updatedOrder);
        }

        // get unassigned order
        [HttpGet("unassigned")]
        public ActionResult<List<OrderModel>> GetUnassignedOrder()
        {
            return _orderService.GetUnassignedOrder();
        }

        // assign an order with rider id
        [HttpPatch("assign/{id}")]
        public ActionResult<OrderModel> PutAssignOrder(string id, [FromBody] string riderId)
        {
            var updatedOrder = _orderService.AssignedOrder(id, riderId);
            if (updatedOrder == null)
            {
                return NotFound();
            }
            return Ok(updatedOrder);
        }

        // get order by rider id
        [HttpGet("rider/{id}")]
        public ActionResult<List<OrderModel>> GetOrderByRiderId(string id)
        {
            return _orderService.GetOrderByRiderId(id);
        }

        // get order by user id
        [HttpGet("customer/{id}")]
        public ActionResult<List<OrderModel>> GetOrderByCustomerId(string id)
        {
            return _orderService.GetOrderByCustomerId(id);
        }
    }
}
