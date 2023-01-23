using AttractionAdvisor.Interfaces;
using AttractionAdvisor.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AttractionAdvisor.Repository
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingController : ControllerBase
    {
        private readonly IRatingRepository _ratingRepository;

        public RatingController(IRatingRepository ratingRepository)
        {
            _ratingRepository = ratingRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rating>>> GetRatings()
        {
            try
            {
                return (await _ratingRepository.GetRatings()).ToList();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Rating>> GetRating(int id)
        {
            try
            {
                var result = await _ratingRepository.GetRating(id);

                if (result == null)
                    return NotFound();

                return result;
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retriving data from the database");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Rating>> AddRating(Rating rating)
        {
            try
            {
                if (rating == null)
                    return BadRequest();

                var createdRating = await _ratingRepository.AddRating(rating);
                return CreatedAtAction(nameof(GetRating),
                    new { id = createdRating.Id }, createdRating);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error adding new rating record");
            }
        }

        [HttpPut("{id}")]

        public async Task<ActionResult<Rating>> UpdateRating(int id, Rating rating)
        {
            try
            {
                if (id != rating.Id)
                    return BadRequest("Rating Id mismatch");
                var ratingToUpdate = await _ratingRepository.GetRating(id);
                if (ratingToUpdate == null)
                    return NotFound($"Rating with Id = {id} not found");

                return await _ratingRepository.UpdateRating(rating);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating data");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Rating>> DeleteRating(int id)
        {
            try
            {
                var ratingToDelete = await _ratingRepository.GetRating(id);

                if (ratingToDelete == null)
                {
                    return NotFound($"Rating with Id = {id} not found");
                }

                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Error deleting data");
            }
        }
    }
}

