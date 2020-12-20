using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Stackoverflow.Website.Services
{
    public class UserService : IUserService
    {
        public UserService(IHttpContextAccessor accesssor)
        {
            LoggedInUserId = accesssor?.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier) ?? string.Empty;
        }

        public string LoggedInUserId { get; }
    }
}
