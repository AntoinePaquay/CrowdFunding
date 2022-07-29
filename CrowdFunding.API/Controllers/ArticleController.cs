using CrowdFunding.API.Mappers;
using CrowdFunding.API.Models;
using CrowdFunding.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CrowdFunding.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private IArticleService _articleService;

        public ArticleController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        // GET: api/<ArticleController>
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_articleService.GetAll().Select(x => x.ToModel()));
        }

        // GET api/<ArticleController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_articleService.GetById(id).ToModel());
        }

        // POST api/<ArticleController>
        [HttpPost]
        public IActionResult Insert([FromBody] ArticleForm af)
        {
            try
            {
                _articleService.Insert(af.ToBLL());
                return Ok();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        // PUT api/<ArticleController>/5
        [HttpPut("{id}")]
        public IActionResult Update([FromBody] ArticleForm articleForm)
        {
            if (!ModelState.IsValid) return BadRequest();
            try
            {
                if (_articleService.Update(articleForm.ToBLL()))
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

        // DELETE api/<ArticleController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_articleService.Delete(id))
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
