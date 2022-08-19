using CRMSharp.Models;
using CRMSharp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRMSharp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;

        public OrdersController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [HttpGet]
        public IAsyncEnumerable<Order> GetAll()
        {
            return _orderRepository.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var order = await _orderRepository.GetById(id);
            if (order is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(order);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Order order)
        {
            await _orderRepository.Create(order);
            return CreatedAtAction(nameof(GetById),new {id = order.Id}, order);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _orderRepository.TryRemove(id))
            {
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Delete(int id, [FromBody] Order order)
        {
            if (id == order.Id)
            {
                await _orderRepository.Update(order);
                return NoContent();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
