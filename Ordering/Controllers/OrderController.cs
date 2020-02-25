using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ordering.Domain;
using Ordering.Repository;

namespace Ordering.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [HttpPost("{id}/jobs")]
        public async Task<IActionResult> AddJobToOrder()
        {
            var order = await _orderRepository.Find(1);
            var job = new Job();
            order.AddJob(job);

            await _orderRepository.Complete();
            
            return Created("someroute", job);
        }
    }
}
