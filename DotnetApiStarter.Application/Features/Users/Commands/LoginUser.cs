using System.Security.Cryptography;
using System.Text;
using DotnetApiStarter.Application.Core.Exceptions;
using DotnetApiStarter.Application.Interfaces;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DotnetApiStarter.Application.Features.Users.Commands;

public class LoginUser
{
    public class Command : IRequest<Response>
    {
        public string Email { get; init; } = default!;
        public string Password { get; init; } = default!;
    }

    public class Validator : AbstractValidator<Command>
    {
        public Validator()
        {
            RuleFor(x => x.Email).NotNull().Length(2, 100);
            RuleFor(x => x.Password).NotNull().Length(8, 100);
        }
    }

    public class Handler : IRequestHandler<Command, Response>
    {
        private readonly IAppDbContext _db;
        private readonly ITokenService _tokenService;

        public Handler(IAppDbContext db, ITokenService tokenService)
        {
            _db = db;
            _tokenService = tokenService;
        }

        public async Task<Response> Handle(Command command, CancellationToken cancellationToken)
        {
            var user = await _db.Users
                .FirstOrDefaultAsync(x => x.Email == command.Email, cancellationToken);

            if (user is null)
                throw new AppException("An user already not exit for this email",
                    AppExceptionCode.LoginInvalidCredentials);

            using var hmac = new HMACSHA512(user.PasswordSalt!);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(command.Password!));

            for (var i = 0; i < computedHash.Length; i++)
                if (computedHash[i] != user.PasswordHash![i])
                    throw new AppException("An user already not exit for this email",
                        AppExceptionCode.LoginInvalidCredentials);

            var token = _tokenService.CreateToken(user);

            return new Response {Token = token};
        }
    }

    public class Response
    {
        public string Token { get; set; } = null!;
    }
}