using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TeeHub.Api.Models.Domain;
using TeeHub.Api.Data;

namespace TeeHub.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly TeeHubDBContext _dbContext;

        public UsersController(TeeHubDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/Users
        [HttpGet]
        public IActionResult Get()
        {
            var users = _dbContext.Users.ToList();
            return Ok(users);
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        // POST: api/Users
        [HttpPost("signup")]
        public IActionResult SignUp([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest();
            }

            var existingUser = _dbContext.Users.FirstOrDefault(u => u.userName == user.userName);
            if (existingUser != null)
            {
                return Conflict("User already exists.");
            }

            // Ensure a new Guid is generated for each new user
            user.Id = Guid.NewGuid();

            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
            return CreatedAtAction(nameof(Get), new { id = user.Id }, user);
        }


        // POST: api/Users/login
        [HttpPost("login")]
        public IActionResult Login([FromBody] User credentials)
        {
            if (credentials == null || string.IsNullOrEmpty(credentials.userName) || string.IsNullOrEmpty(credentials.Password))
            {
                return BadRequest("Invalid credentials.");
            }

            var user = _dbContext.Users.FirstOrDefault(u => u.userName == credentials.userName);
            if (user == null)
            {
                return NotFound("User not found.");
            }

            if (user.Password != credentials.Password)
            {
                return BadRequest("Invalid password.");
            }

            // You can return additional data or token here for authentication

            return Ok("Login successful.");
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] User user)
        {
            if (user == null || id != user.Id)
            {
                return BadRequest();
            }
            var existingUser = _dbContext.Users.FirstOrDefault(u => u.Id == id);
            if (existingUser == null)
            {
                return NotFound();
            }
            existingUser.userName = user.userName; // Update other properties as needed
            _dbContext.SaveChanges();
            return NoContent();
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            _dbContext.Users.Remove(user);
            _dbContext.SaveChanges();
            return NoContent();
        }
    }
}
