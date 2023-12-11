using GetirClone.Application.Features.CQRS.Commands;
using GetirClone.Application.Features.CQRS.Queries;
using GetirClone.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GetirClone.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ITransactionManager _transactionManager;

        public CategoriesController(ITransactionManager transactionManager)
        {
            _transactionManager = transactionManager;
        }


        [Route("List")]
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var categories = await _transactionManager.SendQuery(new GetCategoriesQueryRequest());
            return Ok(categories);
        }


        [Route("GetById")]
        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var category = await _transactionManager.SendQuery(new GetCategoryByIdQueryRequest(id));
            return Ok(category);
        }


        [Route("Create")]
        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryCommand request)
        {
            var result = await _transactionManager.SendCommand(request);
            return Created("", result);
        }


        [Route("Update")]
        [HttpPut]
        public async Task<IActionResult> Update(UpdateCategoryCommand request)
        {
            await _transactionManager.SendCommand(request);
            return NoContent();
        }


        [Route("Remove")]
        [HttpDelete]
        public async Task<IActionResult> Remove(int id)
        {
            await _transactionManager.SendCommand(new RemoveCategoryCommand(id));
            return Ok();
        }
    }
}
