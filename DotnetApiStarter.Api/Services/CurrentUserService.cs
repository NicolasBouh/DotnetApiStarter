using System.Security.Claims;
using DotnetApiStarter.Application.Interfaces;

namespace DotnetApiStarter.Api.Services;

public class CurrentUserService : ICurrentUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CurrentUserService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public int? UserId()
    {
        int? userId = null;
        
        var userIdIdentifier = _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);

        if (userIdIdentifier != null)
            userId = int.Parse(userIdIdentifier);

        return userId;
    }
}