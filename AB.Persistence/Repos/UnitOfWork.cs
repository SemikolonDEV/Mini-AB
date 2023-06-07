using AB.Domain.Repositories;

namespace AB.Persistence.Repos;

public class UnitOfWork : IUnitOfWork
{

    private readonly RepoDbContext _dbContext;

    public UnitOfWork(RepoDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken)
    {
        return _dbContext.SaveChangesAsync(cancellationToken);
    }
}
