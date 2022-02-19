using DotnetApiStarter.Application.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DotnetApiStarter.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class BaseApiController : ControllerBase
{
    protected readonly IMediator Mediator;
    protected readonly ICurrentUserService UserService;

    public BaseApiController(IMediator mediator, ICurrentUserService userService)
    {
        Mediator = mediator;
        UserService = userService;
    }
}