using System.Reflection;
using DotnetApiStarter.Application.Core.Security;
using DotnetApiStarter.Application.Interfaces;
using MediatR;

namespace DotnetApiStarter.Application.Core.Behaviors;

public class AuthorizationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    private readonly ICurrentUserService _currentUserService;

    public AuthorizationBehaviour(ICurrentUserService currentUserService)
    {
        _currentUserService = currentUserService;
    }

    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken,
        RequestHandlerDelegate<TResponse> next)
    {
        var authorizeAttributes = request.GetType().GetCustomAttributes<AuthorizeAttribute>();

        if (authorizeAttributes.Any())
        {
            // Must be authenticated user
            if (_currentUserService.UserId() == null)
            {
                throw new UnauthorizedAccessException();
            }
        }
        
        return await next();
    }
}