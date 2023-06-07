using AB.Contracts;
using AB.Domain.Entities;
using AB.Domain.Exceptions;
using AB.Domain.Repositories;
using AB.Services.Abstractions;

namespace AB.Services;

public class CustomerService : ICustomerService
{

    private readonly ICustomerRepository _customerRepository;

    private readonly IUnitOfWork _unitOfWork;

    public CustomerService(ICustomerRepository customerRepository, IUnitOfWork unitOfWork)
    {
        _customerRepository = customerRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<CustomerDto> CreateAsync(CustomerForCreationDto customerForCreation, CancellationToken cancellationToken = default)
    {


        var customer = new Customer
        {
            Salutation = customerForCreation.Salutaion,
            Name1 = customerForCreation.Name1,
            Name2 = (customerForCreation.Name2 is null) ? string.Empty : customerForCreation.Name2,
            Email = (customerForCreation.Email is null) ? string.Empty : customerForCreation.Email,
            PhoneNumber = (customerForCreation.PhoneNumber is null) ? string.Empty : customerForCreation.PhoneNumber,
            Iban = (customerForCreation.Iban is null) ? string.Empty : customerForCreation.Iban,
        };

        _customerRepository.Insert(customer);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        var customerDto = ConvertToCustomerDto(customer);

        return customerDto;
    }

    public async Task DeleteAsync(Guid customerId, CancellationToken cancellationToken)
    {
        var customer = await _customerRepository.GetByIdAsync(customerId, cancellationToken);

        if (customer == null)
        {
            throw new BusinessPartnerNotFoundException(customerId);
        }

        _customerRepository.Remove(customer);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task<IEnumerable<CustomerDto>> GetAllAsync(CancellationToken cancellationToken)
    {
        var customers = await _customerRepository.GetAllAsync(cancellationToken);

        var customerDtoList = customers.Select(customer =>
        {
            return ConvertToCustomerDto(customer);
        });

        return customerDtoList;
    }

    public async Task<CustomerDto> GetByIdAsync(Guid customerId, CancellationToken cancellationToken)
    {
        var customer = await _customerRepository.GetByIdAsync(customerId, cancellationToken);

        if (customer is null)
        {
            throw new BusinessPartnerNotFoundException(customerId);
        }

        var customerDto = ConvertToCustomerDto(customer);

        return customerDto;
    }

    private static CustomerDto ConvertToCustomerDto(Customer customer)
    {
        var customerDto = new CustomerDto
        {
            Id = customer.CustomerId,
            Salutaion = customer.Salutation,
            Name1 = customer.Name1,
            Name2 = customer.Name2,
            Email = customer.Email,
            PhoneNumber = customer.PhoneNumber,
            Iban = customer.Iban,
        };
        return customerDto;
    }
}
