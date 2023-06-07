using AB.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AB.Domain.Repositories;

public interface ICustomerRepository
{
    public Task<IEnumerable<Customer>> GetAllAsync(CancellationToken cancellationToken);
    Task<Customer> GetByIdAsync(Guid customerId, CancellationToken cancellationToken);
    void Insert(Customer customer);
    void Remove(Customer customer);
}
