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
    public class OrderController : BaseController
    {
        private readonly ITransactionManager _transactionManager;

        public OrderController(ITransactionManager transactionManager)
        {
            _transactionManager = transactionManager;
        }



        [Route("List")]
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var result = await _transactionManager.SendQuery(new GetOrdersQueryRequest(CustomerId));
            return Ok(result);

        }
        [Route("CreateOrder")]
        [HttpPost]
        public async Task<IActionResult> CreateOrder(CreateOrderCommand command)
        {
            command.CustomerId = CustomerId;
            var result = await _transactionManager.SendCommand(command);

            return Created("", result);
        }
    }
}
