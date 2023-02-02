using AttractionAdvisor.Interfaces;
using AttractionAdvisor.Models;
using Microsoft.AspNetCore.Mvc;

namespace AttractionAdvisor.Controllers;

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
            return Ok(await _ratingRepository.GetRatings());
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                ex.Message);
        }
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Rating>> GetRating(int id)
    {
        if (id <= 0)
            return BadRequest();
            
        try
        {
            var result = await _ratingRepository.GetRating(id);
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

    [HttpPost]
    public async Task<ActionResult<Rating>> CreateRating(Rating rating)
    {
        try
        {
            var createdRating = await _ratingRepository.AddRating(rating);
                
            return Ok(createdRating.Id);
        }
        catch (Exception ex)
        {
            return StatusCode(
                StatusCodes.Status500InternalServerError,
                ex.Message);
        }
    }

    [HttpPut]
    public async Task<ActionResult<Rating>> UpdateRating(Rating rating)
    {
        if (rating.Id <= 0)
            return BadRequest();

        try
        {
            var ratingToUpdate = await _ratingRepository.GetRating(rating.Id);
            if (ratingToUpdate == null)
                return NotFound();

            var updatedRating = await _ratingRepository.UpdateRating(rating);
            if (updatedRating == null)
                return BadRequest();

            return Ok(updatedRating.Id);
        }
        catch (Exception ex)
        {
            return StatusCode(
                StatusCodes.Status500InternalServerError,
                ex.Message);
        }
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<bool>> DeleteRating(int id)
    {
        try
        {
            if (!await _ratingRepository.DeleteRating(id))
                return NotFound();

            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                ex.Message);
        }
    }
}