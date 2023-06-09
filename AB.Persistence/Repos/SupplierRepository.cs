using AB.Domain.Entities;
using AB.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AB.Persistence.Repos;

public class SupplierRepository : ISupplierRepository
{
    private readonly RepoDbContext _dbContext;

    public SupplierRepository(RepoDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Supplier>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _dbContext.Suppliers.ToListAsync(cancellationToken);
    }

    public async Task<Supplier> GetByIdAsync(Guid supplierId, CancellationToken cancellationToken)
    {
        return await _dbContext.Suppliers.FirstOrDefaultAsync(x => x.SupplierId == supplierId, cancellationToken);
    }

    public void Insert(Supplier supplier)
    {
        _dbContext.Add(supplier);
    }

    public void Remove(Supplier supplier)
    {
        
        _dbContext.Suppliers.Remove(supplier);
    }
}
