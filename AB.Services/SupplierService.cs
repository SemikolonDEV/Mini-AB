using AB.Contracts;
using AB.Domain.Entities;
using AB.Domain.Exceptions;
using AB.Domain.Repositories;
using AB.Services.Abstractions;
using AB.Services.Converter;

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
                Salutation = supplierForCreation.Salutation,
                Name1 = supplierForCreation.Name1,
                Name2 = supplierForCreation.Name2,
                Email = supplierForCreation.Email,
                PhoneNumber = supplierForCreation.PhoneNumber,
                TaxId = supplierForCreation.TaxId,
                PreferredCommunication = CommunicationTypeConverter.ConvertToBusinessValue(supplierForCreation.PreferredCommunication),
                ContactPersons = supplierForCreation.ContactPersons.ConvertToContactPersonList(),
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
                Salutation = supplier.Salutation,
                Name1 = supplier.Name1,
                Name2 = supplier.Name2,
                Email = supplier.Email,
                PhoneNumber = supplier.PhoneNumber,
                TaxId = supplier.TaxId,
                PreferredCommunication = CommunicationTypeConverter.ConvertFromBusinessValue(supplier.PreferredCommunication),
                ContactPersons = supplier.ContactPersons.ConvertToContactPersonDtoList(),
            };
            return supplierDto;
        }


    }
}
