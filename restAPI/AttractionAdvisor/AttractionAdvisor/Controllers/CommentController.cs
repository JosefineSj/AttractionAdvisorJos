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
        private readonly IAttractionRepository _attractionRepository;
        private readonly IUserRepository _userRepository;

        public CommentController(ICommentRepository commentRepository, IAttractionRepository _attractionRepository, IUserRepository _userRepository)
        {
            _commentRepository = commentRepository;
            _attractionRepository = _attractionRepository;
            _userRepository = _userRepository;
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
            
                var attraction = await _attractionRepository.GetAttraction(comment.AttractionId);
                var user = await _userRepository.GetUser(comment.UserId);

                if (attraction == null || user == null)
                {
                    return BadRequest("Attraction or user does not exist.");
                }
            
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
                if (!await _commentRepository.DeleteComment(id))
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
}
