using AB.Domain.Entities;
using AB.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AB.Persistence.Repos;

public class CustomerRepository : ICustomerRepository
{

    private readonly RepoDbContext _dbContext;

    public CustomerRepository(RepoDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Customer>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _dbContext.Customers.ToListAsync(cancellationToken);
    }

    public async Task<Customer> GetByIdAsync(Guid customerId, CancellationToken cancellationToken)
    {
        return await _dbContext.Customers.FirstOrDefaultAsync(x => x.CustomerId == customerId, cancellationToken);
    }

    public void Insert(Customer customer)
    {
        _dbContext.Customers.Add(customer);
    }

    public void Remove(Customer customer)
    {
        _dbContext.Customers.Remove(customer);
    }
}
