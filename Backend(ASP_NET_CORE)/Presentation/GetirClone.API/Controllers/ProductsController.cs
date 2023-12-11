using GetirClone.Application.Features.CQRS.Commands;
using GetirClone.Application.Features.CQRS.Queries;
using GetirClone.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GetirClone.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ITransactionManager _transactionManager;

        public ProductsController(ITransactionManager transactionManager)
        {
            _transactionManager = transactionManager;
        }


        [Route("List")]
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var result = await _transactionManager.SendQuery(new GetProductsQueryRequest());

            return Ok(result);
        }


        [Route("ListWithCategories")]
        [HttpGet]
        public async Task<IActionResult> ListWithCategories(int parentCategoryId)
        {
            var result = await _transactionManager.SendQuery(new GetProductByCategoryQueryRequest(parentCategoryId));
            return Ok(result);
        }


        [Route("Search")]
        [HttpGet]
        public async Task<IActionResult> Search(string searchStr)
        {
            var result = await _transactionManager.SendQuery(new SearchProductsRequest(searchStr));
            return Ok(result);
        }


        [Route("GetById")]
        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _transactionManager.SendQuery(new GetProductByIdQueryRequest(id));

            return Ok(result);
        }


        [Route("Create")]
        [HttpPost]
        public async Task<IActionResult> Create(CreateProductCommand request)
        {
            var result = await _transactionManager.SendCommand(request);
            return Created("", result);
        }


        [Route("Update")]
        [HttpPut]
        public async Task<IActionResult> Update(UpdateProductCommand request)
        {
            await _transactionManager.SendCommand(request);
            return NoContent();
        }

        [Route("Remove")]
        [HttpDelete]
        public async Task<IActionResult> Remove(int id)
        {
            await _transactionManager.SendCommand(new RemoveProductCommand(id));
            return Ok();
        }
    }
}
