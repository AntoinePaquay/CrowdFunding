using CrowdFunding.BLL.Interfaces;
using CrowdFunding.API.Mappers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CrowdFunding.API.Models;

namespace CrowdFunding.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private ICommentService _commentService;

        public CommentController( ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_commentService.GetAll().Select(x => x.ToModel()));
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_commentService.GetById(id).ToModel());
        }

        [HttpPost]
        public IActionResult Insert([FromBody] CommentForm cf)
        {
            try
            {
                _commentService.Insert(cf.ToBLL());
                return Ok();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromBody] CommentForm cf)
        {
            if (!ModelState.IsValid) return BadRequest();
            try
            {
                if (_commentService.Update(cf.ToBLL()))
                {
                    return Ok();
                }
                else
                {
                    return Forbid();
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_commentService.Delete(id))
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
