using AB.Contracts;

namespace AB.Services.Abstractions;

public interface ISupplierService
{
    public Task<SupplierDto> CreateAsync(SupplierForCreationDto supplierForCreation, CancellationToken cancellationToken);
    public Task DeleteAsync(Guid supplierId, CancellationToken cancellationToken);
    public Task<IEnumerable<SupplierDto>> GetAllAsync(CancellationToken cancellationToken);
    public Task<SupplierDto> GetSupplierByIdAsync(Guid supplierId, CancellationToken cancellationToken);
}
