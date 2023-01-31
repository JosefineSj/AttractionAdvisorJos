using AttractionAdvisor.Interfaces;
using AttractionAdvisor.Models;
using Microsoft.AspNetCore.Mvc;

namespace AttractionAdvisor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AggregationController : ControllerBase
    {
        private readonly IAttractionRepository _attractionRepository;

        public AggregationController(IAttractionRepository attractionRepository)
        {
            _attractionRepository = attractionRepository;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Attraction>>> GetAggregatedAttractions()
        {
            try
            {
                return Ok(await _attractionRepository.GetAggregatedAttractions());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    ex.Message);
            }
        }
        
        
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Attraction>> GetAggregatedAttraction(int id)
        {
            if (id <= 0)
                return BadRequest();
            try
            {
                var result = await _attractionRepository.GetAggregatedAttractionsByUserId(id);

                if (result == null)
                    return NotFound();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(
                        StatusCodes.Status500InternalServerError,
                        ex.Message);
            }
        }
    }
}