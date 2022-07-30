using CrowdFunding.API.Mappers;
using CrowdFunding.API.Models;
using CrowdFunding.BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrowdFunding.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_projectService.GetAll().Select(x => x.ToModel()));
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_projectService.GetById(id).ToModel());
        }

        [HttpPost]
        public IActionResult Insert([FromBody] ProjectForm pf)
        {
            try
            {
                _projectService.Insert(pf.ToBLL());
                return Ok();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromBody] ProjectForm pf)
        {
            if (!ModelState.IsValid) return BadRequest();
            try
            {
                if (_projectService.Update(pf.ToBLL()))
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
            if (_projectService.Delete(id))
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
