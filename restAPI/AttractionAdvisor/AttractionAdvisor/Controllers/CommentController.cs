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
                return Ok(await _commentRepository.GetComments());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Comment>> GetComment(int id)
        {
            if (id <= 0)
                return BadRequest();

            try
            {
                var result = await _commentRepository.GetComment(id);
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
        public async Task<ActionResult<Comment>> AddComment(Comment comment)
        {
            try
            {
                var createdComment = await _commentRepository.AddComment(comment);
                return Ok(CreatedAtAction(nameof(GetComment),
                    new { id = createdComment.Id }, createdComment));
            }
            catch (Exception ex)
            {
                return StatusCode(
                        StatusCodes.Status500InternalServerError,
                        ex.Message);
            }
        }

        [HttpPut]
        
        public async Task<ActionResult<Comment>> UpdateComment(Comment comment)
        {
            if (comment.Id <= 0)
                return BadRequest();

            try
            {
                var commentToUpdate = await _commentRepository.GetComment(
                    comment.Id);
                if (commentToUpdate == null)
                    return NotFound();

                var updatedComment = await _commentRepository.UpdateComment(
                    comment);
                if (updatedComment == null)
                    BadRequest();


                return Ok(updatedComment);
            }
            catch (Exception ex)
            {
                return StatusCode(
                        StatusCodes.Status500InternalServerError,
                        ex.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<bool>> DeleteComment(int id)
        {
            try
            {
                var commentToDelete = await _commentRepository.GetComment(id);
                if (commentToDelete == null)
                    return NotFound();
                
                return Ok(await _commentRepository.DeleteComment(id));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                   ex.Message);
            }
        }
    }
}
