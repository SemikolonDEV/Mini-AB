using AB.Domain.Entities;

namespace AB.Domain.Repositories;

public interface ISupplierRepository
{
    public Task<IEnumerable<Supplier>> GetAllAsync(CancellationToken cancellationToken);
    public Task<Supplier> GetByIdAsync(Guid supplierId, CancellationToken cancellationToken);
    public void Insert(Supplier supplier);
    public void Remove(Supplier supplier);
}
