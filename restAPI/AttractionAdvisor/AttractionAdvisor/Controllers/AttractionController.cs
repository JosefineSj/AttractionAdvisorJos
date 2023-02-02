using AttractionAdvisor.Interfaces;
using AttractionAdvisor.Models;
using Microsoft.AspNetCore.Mvc;

namespace AttractionAdvisor.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AttractionController : ControllerBase
{
    private readonly IAttractionRepository _attractionRepository;

    public AttractionController(IAttractionRepository attractionRepository)
    {
        
        _attractionRepository = attractionRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AttractionDto>>> GetAttractions()
    {
        try
        {
            return Ok(await _attractionRepository.GetAllAttractionDto());
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                ex.Message);
        }
    }
        
    [HttpGet]
    [Route("User/{userId:int}")]
    public async Task<ActionResult<IEnumerable<AttractionDto>>> GetAttractionsByUserId(int userId)
    {
        if (userId <= 0)
            return BadRequest();
        try
        {
            var result = await _attractionRepository.GetAllAttractionDtoByUserId(
                userId);

            if (result.Count < 1)
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

    [HttpGet("{id:int}")]
    public async Task<ActionResult<AttractionDto>> GetAttraction(int id)
    {
        if (id <= 0)
            return BadRequest();
        try
        {
            var result = await _attractionRepository.GetAttractionDto(id);

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
    public async Task<ActionResult<int>> CreateAttraction(Attraction attraction)
    {
        try
        {
            var createdAttraction = await _attractionRepository.AddAttraction(attraction);

            return Ok(createdAttraction.Id);
        }
        catch (Exception ex)
        {
            return StatusCode(
                StatusCodes.Status500InternalServerError,
                ex.Message);
        }
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<int>> UpdateAttraction(Attraction attraction, int id)
    {
        if (id <= 0)
            return BadRequest();

        try
        {
            var attractionToUpdate = await _attractionRepository.GetAttraction(id);
            if (attractionToUpdate == null)
                return NotFound();

            attraction.Id = id;

            var updatedAttraction = await _attractionRepository.UpdateAttraction(attraction);
            if (updatedAttraction == null)
                return BadRequest();

            return Ok(updatedAttraction.Id);
        }
        catch (Exception ex)
        {
            return StatusCode(
                StatusCodes.Status500InternalServerError,
                ex.Message);
        }
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteAttraction(int id)
    {
        try
        {
            if (!await _attractionRepository.DeleteAttraction(id))
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