using AB.Contracts;

namespace AB.Services.Abstractions;

public interface ISupplierService
{
    Task<SupplierDto> CreateAsync(SupplierForCreationDto supplierForCreation);
    Task DeleteAsync(Guid supplierId, CancellationToken cancellationToken);
    Task<IEnumerable<SupplierDto>> GetAllAsync(CancellationToken cancellationToken);
    Task<SupplierDto> GetSupplierByIdAsync(Guid supplierId, CancellationToken cancellationToken);
}
