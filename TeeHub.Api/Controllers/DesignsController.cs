using Microsoft.AspNetCore.Mvc;
using TeeHub.Api.Models.Domain;
using TeeHub.Api.Repositories;

namespace TeeHub.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DesignsController : ControllerBase
    {
        private readonly IDesignRepository _designRepository;

        public DesignsController(IDesignRepository designRepository)
        {
            _designRepository = designRepository;
        }

        // GET: api/Designs
        [HttpGet]
        public IActionResult Get()
        {
            var designs = _designRepository.GetAllDesigns();
            return Ok(designs);
        }

        // GET: api/Designs/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var design = _designRepository.GetDesignById(id);
            if (design == null)
            {
                return NotFound();
            }
            return Ok(design);
        }

        // POST: api/Designs
        [HttpPost]
        public IActionResult Post([FromBody] Design design)
        {
            if (design == null)
            {
                return BadRequest("Design data is missing.");
            }
            _designRepository.AddDesign(design);
            return CreatedAtAction(nameof(Get), new { id = design.Id }, design);
        }

        // PUT: api/Designs/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] Design design)
        {
            if (design == null || id != design.Id)
            {
                return BadRequest("Invalid design data.");
            }
            var existingDesign = _designRepository.GetDesignById(id);
            if (existingDesign == null)
            {
                return NotFound("Design not found.");
            }
            _designRepository.UpdateDesign(design);
            return NoContent();
        }

        // DELETE: api/Designs/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var design = _designRepository.GetDesignById(id);
            if (design == null)
            {
                return NotFound("Design not found.");
            }
            _designRepository.DeleteDesign(id);
            return NoContent();
        }
    }
}
