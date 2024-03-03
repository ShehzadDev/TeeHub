using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TeeHub.Api.Models.Domain;
using TeeHub.Api.Data;

namespace TeeHub.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderStatusHistoryController : ControllerBase
    {
        private readonly TeeHubDBContext _dbContext;

        public OrderStatusHistoryController(TeeHubDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/OrderStatusHistory
        [HttpGet]
        public IActionResult Get()
        {
            var orderStatusHistories = _dbContext.OrderStatusHistories.ToList();
            return Ok(orderStatusHistories);
        }

        // GET: api/OrderStatusHistory/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var orderStatusHistory = _dbContext.OrderStatusHistories.FirstOrDefault(osh => osh.StatusChangeID == id);
            if (orderStatusHistory == null)
            {
                return NotFound();
            }
            return Ok(orderStatusHistory);
        }

        // POST: api/OrderStatusHistory
        [HttpPost]
        public IActionResult Post([FromBody] OrderStatusHistory orderStatusHistory)
        {
            if (orderStatusHistory == null)
            {
                return BadRequest();
            }
            _dbContext.OrderStatusHistories.Add(orderStatusHistory);
            _dbContext.SaveChanges();
            return CreatedAtAction(nameof(Get), new { id = orderStatusHistory.StatusChangeID }, orderStatusHistory);
        }

        // PUT: api/OrderStatusHistory/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] OrderStatusHistory orderStatusHistory)
        {
            if (orderStatusHistory == null || id != orderStatusHistory.StatusChangeID)
            {
                return BadRequest();
            }
            var existingOrderStatusHistory = _dbContext.OrderStatusHistories.FirstOrDefault(osh => osh.StatusChangeID == id);
            if (existingOrderStatusHistory == null)
            {
                return NotFound();
            }
            _dbContext.OrderStatusHistories.Update(orderStatusHistory);
            _dbContext.SaveChanges();
            return NoContent();
        }

        // DELETE: api/OrderStatusHistory/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var orderStatusHistory = _dbContext.OrderStatusHistories.FirstOrDefault(osh => osh.StatusChangeID == id);
            if (orderStatusHistory == null)
            {
                return NotFound();
            }
            _dbContext.OrderStatusHistories.Remove(orderStatusHistory);
            _dbContext.SaveChanges();
            return NoContent();
        }
    }
}
