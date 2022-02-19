using DotnetApiStarter.Domain.Entities;

namespace DotnetApiStarter.Application.Interfaces;

public interface ICurrentUserService
{
    int? UserId();
}