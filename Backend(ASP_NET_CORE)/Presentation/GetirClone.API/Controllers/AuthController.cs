using GetirClone.Application.Features.CQRS.Commands;
using GetirClone.Application.Features.CQRS.Queries.Customer;
using GetirClone.Application.Interfaces;
using GetirClone.Application.Tools;
using Microsoft.AspNetCore.Mvc;

namespace GetirClone.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ITransactionManager _transactionManager;

        public AuthController(ITransactionManager transactionManager)
        {
            _transactionManager = transactionManager;
        }

        [Route("ApproveLogin")]
        [HttpPost]
        public async Task<IActionResult> ApproveLogin(ApproveLoginQuery cmd)
        {
            var user = await _transactionManager.SendQuery(cmd);
            if (user.Result.IsExist)
            {
                if (user.Result.SignInResult == Application.Enums.SignInResultType.WrongCode)
                {
                    return Ok(new { IsCodeFailed = true });
                }
                var token = JwtTokenGenerator.GenerateToken(user.Result);
                return Created("", token);
            }
            return Unauthorized("Invalid username or password");
        }



        [Route("RequestLogin")]
        [HttpPost]
        public async Task<IActionResult> RequestLogin(RequestLoginQuery cmd)
        {
            var user = await _transactionManager.SendQuery(cmd);
            if (user.Result.IsExist)
            {
                return Ok();
            }
            return Unauthorized("Invalid username or password");
        }

        [Route("Register")]
        [HttpPost]
        public async Task<IActionResult> Register(CreateCustomerCommand cmd)
        {
            var res = await _transactionManager.SendCommand(cmd);
            if (res.IsSuccessful)
            {
                var token = JwtTokenGenerator.GenerateToken(res.Result);
                return Created("", token);
            }
            return NotFound();
        }
    }
}
