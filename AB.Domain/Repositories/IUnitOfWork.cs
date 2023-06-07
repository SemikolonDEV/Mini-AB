namespace AB.Domain.Repositories;

public interface IUnitOfWork
{
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
