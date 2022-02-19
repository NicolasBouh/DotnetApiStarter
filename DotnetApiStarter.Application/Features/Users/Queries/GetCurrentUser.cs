using AutoMapper;
using DotnetApiStarter.Application.Core.Exceptions;
using DotnetApiStarter.Application.Core.Security;
using DotnetApiStarter.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DotnetApiStarter.Application.Features.Users.Queries;

[Authorize()]
public static class GetCurrentUser
{
    public class Query : IRequest<Response>
    {
    }

    public class Handler : IRequestHandler<Query, Response>
    {
        private readonly IAppDbContext _db;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;

        public Handler(IAppDbContext db, IMapper mapper, ICurrentUserService currentUserService)
        {
            _db = db;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }

        public async Task<Response> Handle(Query query, CancellationToken cancellationToken)
        {
            var user = await _db.Users
                .FirstOrDefaultAsync(x => x.Id == _currentUserService.UserId(), cancellationToken);

            if (user is null)
                throw new AppException("User not exist", AppExceptionCode.GetUserUserNotExist);

            return new Response {User = _mapper.Map<UserResponse>(user)};
        }
    }

    public class Response
    {
        public UserResponse User { get; init; } = null!;
    }
}