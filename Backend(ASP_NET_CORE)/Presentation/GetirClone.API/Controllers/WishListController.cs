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
    public class WishListController : BaseController
    {
        private readonly ITransactionManager _transactionManager;

        public WishListController(ITransactionManager transactionManager)
        {
            _transactionManager = transactionManager;
        }


        [Route("List")]
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var result = await _transactionManager.SendQuery(new GetWishlistsQueryRequest(CustomerId));
            return Ok(result);
        }


        [Route("GetById")]
        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _transactionManager.SendQuery(new GetWishlistQueryRequest(id, CustomerId));
            return Ok(result);
        }


        [Route("Create")]
        [HttpPost]
        public async Task<IActionResult> Create(CreateWishlistCommand request)
        {
            var result = await _transactionManager.SendCommand(request);
            return Created("", result);
        }

        [Route("Update")]
        [HttpPut]
        public async Task<IActionResult> Update(UpdateWishlistCommand request)
        {
            await _transactionManager.SendCommand(request);
            return NoContent();
        }


        [Route("Add")]
        [HttpPut]

        public async Task<IActionResult> Add(AddProductToWishlistCommand request)
        {
            await _transactionManager.SendCommand(request);
            return Ok();
        }


        [Route("RemoveProductFromWishList")]
        [HttpDelete]
        public async Task<IActionResult> RemoveProductFromWishList(RemoveProductFromWishlistCommand request)
        {
            await _transactionManager.SendCommand(new RemoveProductFromWishlistCommand(request.WishlistId, request.ProductId));
            return Ok();
        }
    }
}
