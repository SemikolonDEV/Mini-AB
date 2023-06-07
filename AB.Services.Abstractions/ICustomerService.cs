using AB.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AB.Services.Abstractions;

public interface ICustomerService
{
    Task<CustomerDto> CreateAsync(CustomerForCreationDto customerForCreation, CancellationToken cancellationToken = default);
    Task DeleteAsync(Guid customerId, CancellationToken cancellationToken);
    Task<IEnumerable<CustomerDto>> GetAllAsync(CancellationToken cancellationToken);
    Task<CustomerDto> GetByIdAsync(Guid customerId, CancellationToken cancellationToken);
}
