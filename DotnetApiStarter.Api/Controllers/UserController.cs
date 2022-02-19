using DotnetApiStarter.Application.Features.Users.Commands;
using DotnetApiStarter.Application.Features.Users.Queries;
using DotnetApiStarter.Application.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DotnetApiStarter.Api.Controllers;

public class UserController : BaseApiController
{
    public UserController(IMediator mediator, ICurrentUserService currentUserService) : base(mediator, currentUserService)
    {
    }

    [HttpPost("register")]
    public async Task<CreateUser.Response> CreateUser(CreateUser.Command command)
    {
        return await Mediator.Send(command);
    }
    
    [HttpPost("login")]
    public async Task<LoginUser.Response> LoginUser(LoginUser.Command command)
    {
        return await Mediator.Send(command);
    }
    
    [HttpGet]
    public async Task<GetCurrentUser.Response> GetCurrentUser()
    {

        return await Mediator.Send(new GetCurrentUser.Query());
    }
}