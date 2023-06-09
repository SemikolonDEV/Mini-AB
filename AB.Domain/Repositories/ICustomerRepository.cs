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
    public Task<Customer> GetByIdAsync(Guid customerId, CancellationToken cancellationToken);
    public void Insert(Customer customer);
    public void Remove(Customer customer);
}
