using AttractionAdvisor.Interfaces;
using AttractionAdvisor.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AttractionAdvisor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepository _commentRepository;

        public CommentController(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Comment>>> GetComments()
        {
            try
            {
                return (await _commentRepository.GetComments()).ToList();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Comment>> GetComment(int id)
        {
            try
            {
                var result = await _commentRepository.GetComment(id);
               
                if(result == null)
                 return NotFound();
                
                return result;
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retriving data from the database");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Comment>> AddComment(Comment comment)
        {
            try
            {
                if (comment == null)
                    return BadRequest();

                var createdComment = await _commentRepository.AddComment(comment);
                return CreatedAtAction(nameof(GetComment),
                    new { id = createdComment.Id }, createdComment);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error adding new comment record");
            }
        }

        [HttpPut("{id}")]
        
        public async Task<ActionResult<Comment>> UpdateComment(int id, Comment comment)
        {
            try
            {
                if (id != comment.Id)
                    return BadRequest("Comment Id mismatch");
                var commentToUpdate = await _commentRepository.GetComment(id);
                if (commentToUpdate == null)
                    return NotFound($"Comment with Id = {id} not found");

                return await _commentRepository.UpdateComment(comment);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating data");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Comment>> DeleteComment(int id)
        {
            try
            {
                var commentToDelete = await _commentRepository.GetComment(id);

                if (commentToDelete == null)
                { 
                    return NotFound($"Comment with Id = {id} not found"); 
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
