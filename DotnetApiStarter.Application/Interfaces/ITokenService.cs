using DotnetApiStarter.Domain.Entities;

namespace DotnetApiStarter.Application.Interfaces;

public interface ITokenService
{
    string CreateToken(User user);
}