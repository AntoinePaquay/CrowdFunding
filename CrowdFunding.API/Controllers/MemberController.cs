using CrowdFunding.API.Mappers;
using CrowdFunding.API.Models;
using CrowdFunding.BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrowdFunding.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private IMemberService _memberService;

        public MemberController(IMemberService memberService)
        {
            _memberService = memberService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_memberService.GetAll().Select(x => x.ToModel()));
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_memberService.GetById(id).ToModel());
        }

        [HttpPost]
        public IActionResult Insert([FromBody] MemberForm cf)
        {
            try
            {
                _memberService.Insert(cf.ToBLL());
                return Ok();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromBody] MemberForm mf)
        {
            if (!ModelState.IsValid) return BadRequest();
            try
            {
                if (_memberService.Update(mf.ToBLL()))
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
            if (_memberService.Delete(id))
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