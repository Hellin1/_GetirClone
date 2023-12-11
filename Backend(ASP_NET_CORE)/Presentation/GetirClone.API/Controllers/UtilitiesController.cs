using GetirClone.Application.Enums;
using GetirClone.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GetirClone.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UtilitiesController : BaseController
    {
        private readonly ITransactionManager _transactionManager;

        public UtilitiesController(ITransactionManager trManager)
        {
            _transactionManager = trManager;
        }

        [Route("GetEnums")]
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var enumValues = Enum.GetValues(typeof(SignInResultType))
            .Cast<SignInResultType>()
            .Select(e => new { Key = e.ToString(), Value = (int)e })
            .ToList();
            return Ok(enumValues);
        }
    }
}
