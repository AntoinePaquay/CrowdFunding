using CrowdFunding.API.Mappers;
using CrowdFunding.API.Models;
using CrowdFunding.BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrowdFunding.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrivateMessageController : ControllerBase
    {
        private IPrivateMessageService _privateMessageService;

        public PrivateMessageController(IPrivateMessageService privateMessageService)
        {
            _privateMessageService = privateMessageService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_privateMessageService.GetAll().Select(x => x.ToModel()));
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_privateMessageService.GetById(id).ToModel());
        }

        [HttpPost]
        public IActionResult Insert([FromBody] PrivateMessageForm pmf)
        {
            try
            {
                _privateMessageService.Insert(pmf.ToBLL());
                return Ok();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromBody] PrivateMessageForm pmf)
        {
            if (!ModelState.IsValid) return BadRequest();
            try
            {
                if (_privateMessageService.Update(pmf.ToBLL()))
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
            if (_privateMessageService.Delete(id))
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
