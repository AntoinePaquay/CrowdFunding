using CrowdFunding.API.Mappers;
using CrowdFunding.API.Models;
using CrowdFunding.BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrowdFunding.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_transactionService.GetAll().Select(x => x.ToModel()));
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_transactionService.GetById(id).ToModel());
        }

        [HttpPost]
        public IActionResult Insert([FromBody] TransactionForm tf)
        {
            try
            {
                _transactionService.Insert(tf.ToBLL());
                return Ok();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromBody] TransactionForm tf)
        {
            if (!ModelState.IsValid) return BadRequest();
            try
            {
                if (_transactionService.Update(tf.ToBLL()))
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
            if (_transactionService.Delete(id))
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
