using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;
using System.Text;
using DotnetApiStarter.Application.Core.Exceptions;
using DotnetApiStarter.Application.Interfaces;
using DotnetApiStarter.Domain.Entities;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DotnetApiStarter.Application.Features.Users.Commands;

public static class CreateUser
{
    public class Command : IRequest<Response>
    {
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string  Password { get; set; } = default!;
    }

    public class Validator : AbstractValidator<Command>
    {
        private readonly IAppDbContext _db;

        public Validator(IAppDbContext db)
        {
            _db = db;
            RuleFor(x => x.FirstName)
                .NotEmpty().MinimumLength(2).MaximumLength(50);
            RuleFor(x => x.LastName)
                .NotEmpty().MinimumLength(2).MaximumLength(50);
            RuleFor(x => x.Email)
                .NotEmpty().EmailAddress()
                .MustAsync(BeUniqueEmail).WithMessage("An account already exist with this email");
            RuleFor(x => x.Password)
                .NotEmpty().MinimumLength(8).MaximumLength(80);
        }
        
        private async Task<bool> BeUniqueEmail(string email, CancellationToken cancellationToken)
            => await _db.Users.AllAsync(x => x.Email != email, cancellationToken);
    }

    public class Handler : IRequestHandler<Command, Response>
    {
        private readonly IAppDbContext _db;

        public Handler(IAppDbContext db)
        {
            _db = db;
        }

        public async Task<Response> Handle(Command command, CancellationToken cancellationToken)
        {
            using var hmac = new HMACSHA512();

            var user = new User
            {
                FirstName = command.FirstName!,
                LastName = command.LastName!,
                Email = command.Email!,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(command.Password!)),
                PasswordSalt = hmac.Key
            };

            _db.Users.Add(user);
            await _db.SaveChangesAsync(cancellationToken);

            return new Response {Id = user.Id};
        }
    }

    public class Response
    {
        public int Id { get; set; }
    }
}