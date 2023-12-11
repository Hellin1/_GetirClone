using GetirClone.Application.Features.CQRS.Commands;
using GetirClone.Application.Features.CQRS.Commands.PaymentCard;
using GetirClone.Application.Features.CQRS.Queries;
using GetirClone.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GetirClone.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentCardController : BaseController
    {
        private readonly ITransactionManager _transactionManager;

        public PaymentCardController(ITransactionManager transactionManager)
        {
            _transactionManager = transactionManager;
        }


        [Route("Get")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _transactionManager.SendQuery(new GetPaymentCardQuery(CustomerId));
            return Ok(result);
        }


        [Route("GetList")]
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var result = await _transactionManager.SendQuery(new GetPaymentCardsQuery(CustomerId));
            return Ok(result);
        }


        [Route("CreatePaymentCard")]
        [HttpPost]
        public async Task<IActionResult> CreatePaymentCard(CreatePaymentCardCommand command)
        {
            command.CustomerId = CustomerId;

            var result = await _transactionManager.SendCommand(command);
            return Created("", result);
        }


        [Route("ChangeActiveCard")]
        [HttpPost]
        public async Task<IActionResult> ChangeActiveCard(ChangeActiveCardCommand command)
        {
            command.CustomerId = CustomerId;
            await _transactionManager.SendCommand(command);
            return Ok();
        }


        [Route("RemoveCard")]
        [HttpDelete]
        public async Task<IActionResult> RemoveCard(int cartId)
        {
            var command = new RemovePaymentCardCommand(cartId);
            await _transactionManager.SendCommand(command);
            return Ok();
        }
    }
}
