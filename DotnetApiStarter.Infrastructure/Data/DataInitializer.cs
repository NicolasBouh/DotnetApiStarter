
using DotnetApiStarter.Application.Interfaces;

namespace DotnetApiStarter.Infrastructure.Data;

public class DataInitializer : IDataInitializer
{
    private readonly AppDbContext _db;

    public DataInitializer(AppDbContext context)
    {
        _db = context;
    }

    public void Initialize()
    {

    }
}