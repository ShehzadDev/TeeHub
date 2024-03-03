using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TeeHub.Api.Models.Domain;
using TeeHub.Api.Data;

namespace TeeHub.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private readonly TeeHubDBContext _dbContext;

        public OrderDetailsController(TeeHubDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/OrderDetails
        [HttpGet]
        public IActionResult Get()
        {
            var orderDetails = _dbContext.OrderDetails.ToList();
            return Ok(orderDetails);
        }

        // GET: api/OrderDetails/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var orderDetail = _dbContext.OrderDetails.FirstOrDefault(od => od.OrderDetailID == id);
            if (orderDetail == null)
            {
                return NotFound();
            }
            return Ok(orderDetail);
        }

        // POST: api/OrderDetails
        [HttpPost]
        public IActionResult Post([FromBody] OrderDetail orderDetail)
        {
            if (orderDetail == null)
            {
                return BadRequest();
            }
            _dbContext.OrderDetails.Add(orderDetail);
            _dbContext.SaveChanges();
            return CreatedAtAction(nameof(Get), new { id = orderDetail.OrderDetailID }, orderDetail);
        }

        // PUT: api/OrderDetails/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] OrderDetail orderDetail)
        {
            if (orderDetail == null || id != orderDetail.OrderDetailID)
            {
                return BadRequest();
            }
            var existingOrderDetail = _dbContext.OrderDetails.FirstOrDefault(od => od.OrderDetailID == id);
            if (existingOrderDetail == null)
            {
                return NotFound();
            }
            _dbContext.OrderDetails.Update(orderDetail);
            _dbContext.SaveChanges();
            return NoContent();
        }

        // DELETE: api/OrderDetails/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var orderDetail = _dbContext.OrderDetails.FirstOrDefault(od => od.OrderDetailID == id);
            if (orderDetail == null)
            {
                return NotFound();
            }
            _dbContext.OrderDetails.Remove(orderDetail);
            _dbContext.SaveChanges();
            return NoContent();
        }
    }
}
