using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GetirClone.API.Controllers
{
    public class BaseController : ControllerBase
    {
        protected Guid CustomerId
        {
            get
            {
                if (User is not null && User.Identity.IsAuthenticated)
                {
                    var customerIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
                    if (customerIdClaim != null && Guid.TryParse(customerIdClaim.Value, out var customerId))
                    {
                        return customerId;
                    }
                }

                return Guid.Empty;
            }
        }
    }
}
