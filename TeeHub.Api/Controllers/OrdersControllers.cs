using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TeeHub.Api.Models.Domain;
using TeeHub.Api.Data;

namespace TeeHub.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly TeeHubDBContext _dbContext;

        public OrdersController(TeeHubDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/Orders
        [HttpGet]
        public IActionResult Get()
        {
            var orders = _dbContext.Orders.ToList();
            return Ok(orders);
        }

        // GET: api/Orders/5
        [HttpGet("{OrderID}")]
        public IActionResult Get(Guid OrderID)
        {
            var order = _dbContext.Orders.FirstOrDefault(o => o.OrderID == OrderID);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        // POST: api/Orders
        [HttpPost]
        public IActionResult Post([FromBody] Order order)
        {
            if (order == null)
            {
                return BadRequest();
            }
            _dbContext.Orders.Add(order);
            _dbContext.SaveChanges();
            return CreatedAtAction(nameof(Get), new { OrderID = order.OrderID }, order);
        }

        // PUT: api/Orders/5
        [HttpPut("{OrderID}")]
        public IActionResult Put(Guid OrderID, [FromBody] Order order)
        {
            if (order == null || OrderID != order.OrderID)
            {
                return BadRequest();
            }
            var existingOrder = _dbContext.Orders.FirstOrDefault(o => o.OrderID == OrderID);
            if (existingOrder == null)
            {
                return NotFound();
            }
            _dbContext.Orders.Update(order);
            _dbContext.SaveChanges();
            return NoContent();
        }

        // DELETE: api/Orders/5
        [HttpDelete("{OrderID}")]
        public IActionResult Delete(Guid OrderID)
        {
            var order = _dbContext.Orders.FirstOrDefault(o => o.OrderID == OrderID);
            if (order == null)
            {
                return NotFound();
            }
            _dbContext.Orders.Remove(order);
            _dbContext.SaveChanges();
            return NoContent();
        }
    }
}
