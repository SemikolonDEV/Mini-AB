using AB.Contracts;
using AB.Domain.Entities;
using AB.Domain.Exceptions;
using AB.Domain.Repositories;
using AB.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AB.Services
{
    public class SupplierService : ISupplierService
    {

        private readonly ISupplierRepository _supplierRepository;

        private readonly IUnitOfWork _unitOfWork;

        public SupplierService(ISupplierRepository supplierRepository, IUnitOfWork unitOfWork)
        {
            _supplierRepository = supplierRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<SupplierDto> CreateAsync(SupplierForCreationDto supplierForCreation, CancellationToken cancellationToken)
        {
            var supplier = new Supplier
            {

            };

            _supplierRepository.Insert(supplier);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var supplierDto = ConvertToSupplierDto(supplier);

            return supplierDto;
        }

        public async Task DeleteAsync(Guid supplierId, CancellationToken cancellationToken)
        {
            var supplier = await _supplierRepository.GetByIdAsync(supplierId, cancellationToken);

            if (supplier is null)
            {
                throw new BusinessPartnerNotFoundException(supplierId);
            }

            _supplierRepository.Remove(supplier);

            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<SupplierDto>> GetAllAsync(CancellationToken cancellationToken)
        {
            var supplierList = await _supplierRepository.GetAllAsync(cancellationToken);

            var supplierDtoList = supplierList.Select(supplier =>
            {
                return ConvertToSupplierDto(supplier);
            });

            return supplierDtoList;
        }

        public async Task<SupplierDto> GetSupplierByIdAsync(Guid supplierId, CancellationToken cancellationToken)
        {
            var supplier = await _supplierRepository.GetByIdAsync(supplierId, cancellationToken);

            var supplierDto = ConvertToSupplierDto(supplier);

            return supplierDto;
        }

        private SupplierDto ConvertToSupplierDto(Supplier supplier)
        {
            var supplierDto = new SupplierDto
            {
                Id = supplier.SupplierId,
            };
            return supplierDto;
        }
    }
}
