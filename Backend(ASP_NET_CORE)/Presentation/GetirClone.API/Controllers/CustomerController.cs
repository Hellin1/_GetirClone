using GetirClone.Application.Features.CQRS.Commands;
using GetirClone.Application.Features.CQRS.Queries;
using GetirClone.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GetirClone.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ITransactionManager _transactionManager;

        public CustomerController(ITransactionManager context)
        {
            _transactionManager = context;
        }

        [Route("GetById")]
        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _transactionManager.SendQuery(new GetCustomerQueryRequest(id));
            return Ok(result);
        }


        [Route("Create")]
        [HttpPost]
        public async Task<IActionResult> Create(CreateCustomerCommand request)
        {
            var result = await _transactionManager.SendCommand(request);
            return Created("", result);
        }


        [Route("Update")]
        [HttpPut]
        public async Task<IActionResult> Update(UpdateCustomerCommand request)
        {
            await _transactionManager.SendCommand(request);
            return NoContent();
        }


        [Route("Remove")]
        [HttpDelete]
        public async Task<IActionResult> Remove(int id)
        {
            await _transactionManager.SendCommand(new RemoveCustomerCommand(id));
            return Ok();
        }
    }
}
