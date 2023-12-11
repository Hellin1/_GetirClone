using GetirClone.Application.Features.CQRS.Commands;
using GetirClone.Application.Features.CQRS.Queries;
using GetirClone.Application.Features.CQRS.Queries.Address;
using GetirClone.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GetirClone.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : BaseController
    {
        private readonly ITransactionManager _transactionManager;

        public AddressController(ITransactionManager trManager)
        {
            _transactionManager = trManager;
        }

        [Route("List")]
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var addresses = await _transactionManager.SendQuery(new GetAddressesQueryRequest(CustomerId));
            return Ok(addresses);
        }

        [Route("GetById")]
        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var address = await _transactionManager.SendQuery(new GetAddressQueryRequest(id));
            return Ok(address);
        }

        [Route("GetActiveAddress")]
        [HttpGet]
        public async Task<IActionResult> GetActiveAddress()
        {
            var address = await _transactionManager.SendQuery(new GetCurrentAddressQuery(CustomerId));
            return Ok(address);
        }

        [Route("CreateAddress")]
        [HttpPost]
        public async Task<IActionResult> CreateAddress(CreateAddressCommand request)
        {
            var result = await _transactionManager.SendCommand(request);

            return Created("", result);
        }

        [Route("Update")]
        [HttpPut]
        public async Task<IActionResult> Update(ToggleIsPrimaryAddressCommand request)
        {
            await _transactionManager.SendCommand(request);
            return NoContent();
        }

        [Route("Remove")]
        [HttpDelete]
        public async Task<IActionResult> Remove(int id)
        {
            await _transactionManager.SendCommand(new RemoveAddressCommand(id, CustomerId));
            return Ok();
        }

        [Route("CreateAddressImage")]
        [HttpPost]
        public async Task<IActionResult> CreateAddressImage(CreateAddressImageCommand request)
        {
            await _transactionManager.SendCommand(request);
            return Ok();
        }

    }
}



