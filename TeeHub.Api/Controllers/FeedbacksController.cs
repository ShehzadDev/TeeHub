using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TeeHub.Api.Models.Domain;
using TeeHub.Api.Data;

namespace TeeHub.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbacksController : ControllerBase
    {
        private readonly TeeHubDBContext _dbContext;

        public FeedbacksController(TeeHubDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/Feedbacks
        [HttpGet]
        public IActionResult Get()
        {
            var feedbacks = _dbContext.Feedbacks.ToList();
            return Ok(feedbacks);
        }

        // GET: api/Feedbacks/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var feedback = _dbContext.Feedbacks.FirstOrDefault(f => f.FeedbackID == id);
            if (feedback == null)
            {
                return NotFound();
            }
            return Ok(feedback);
        }

        // POST: api/Feedbacks
        [HttpPost]
        public IActionResult Post([FromBody] Feedback feedback)
        {
            if (feedback == null)
            {
                return BadRequest();
            }
            _dbContext.Feedbacks.Add(feedback);
            _dbContext.SaveChanges();
            return CreatedAtAction(nameof(Get), new { id = feedback.FeedbackID }, feedback);
        }

        // PUT: api/Feedbacks/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] Feedback feedback)
        {
            if (feedback == null || id != feedback.FeedbackID)
            {
                return BadRequest();
            }
            var existingFeedback = _dbContext.Feedbacks.FirstOrDefault(f => f.FeedbackID == id);
            if (existingFeedback == null)
            {
                return NotFound();
            }
            _dbContext.Feedbacks.Update(feedback);
            _dbContext.SaveChanges();
            return NoContent();
        }

        // DELETE: api/Feedbacks/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var feedback = _dbContext.Feedbacks.FirstOrDefault(f => f.FeedbackID == id);
            if (feedback == null)
            {
                return NotFound();
            }
            _dbContext.Feedbacks.Remove(feedback);
            _dbContext.SaveChanges();
            return NoContent();
        }
    }
}
