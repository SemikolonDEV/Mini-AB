using AB.Contracts;
using AB.Domain.Entities;
using AB.Domain.Exceptions;
using AB.Domain.Repositories;
using AB.Services;

namespace AB.Tests
{
    public class CustomerTests
    {

        private readonly Mock<IUnitOfWork> _unitOfWorkMock = new Mock<IUnitOfWork>();

        private readonly Mock<ICustomerRepository> _customerRepositoryMock = new Mock<ICustomerRepository>();

        [Fact]
        public async void TestCreateCustomer_Sucess()
        {
            var customerService = new CustomerService(_customerRepositoryMock.Object, _unitOfWorkMock.Object);

            var customerForCreationDto = new CustomerForCreationDto
            {
                Salutaion = "Firma",
                Name1 = "Arik Meyer",
                Email = "test@test.de",
                PhoneNumber = "1234567890",
                Iban = "DE12345890",
            };

            var customerDto = await customerService.CreateAsync(customerForCreationDto);

            customerDto.Salutaion.Should().Be(customerForCreationDto.Salutaion);
            customerDto.Name1.Should().Be(customerForCreationDto.Name1);
            customerDto.Email.Should().Be(customerForCreationDto.Email);
            customerDto.PhoneNumber.Should().Be(customerForCreationDto.PhoneNumber);
            customerDto.Iban.Should().Be(customerForCreationDto.Iban);
        }

        [Fact]
        private async void TestGetCustomers_Sucess()
        {
            CancellationToken cancellationToken = default;

            var customerList = new List<Customer> 
            {
                new Customer
                {
                    CustomerId = Guid.NewGuid(),
                    Salutation = "Herr",
                },
                new Customer
                {
                    CustomerId = Guid.NewGuid(),
                    Name1 = "Peter Sprudel"
                }

            };

            _customerRepositoryMock.Setup(repo => repo.GetAllAsync(cancellationToken)).ReturnsAsync(customerList);

            var customerService = new CustomerService(_customerRepositoryMock.Object, _unitOfWorkMock.Object);

            var dtoList = await customerService.GetAllAsync(cancellationToken);

            dtoList.Should().NotBeNullOrEmpty();

            dtoList.ElementAt(0).Salutaion.Should().Be(customerList[0].Salutation);
            dtoList.ElementAt(0).Id.Should().Be(customerList[0].CustomerId);

            dtoList.ElementAt(1).Name1.Should().Be(customerList[1].Name1);
            dtoList.ElementAt(1).Id.Should().Be(customerList[1].CustomerId);
        }

        [Fact]
        private async void TestGetCustomerById_Exception()
        {
            var id = Guid.NewGuid();
            CancellationToken cancellationToken = default;
            _customerRepositoryMock.Setup(repo => repo.GetByIdAsync(id, cancellationToken)).ThrowsAsync(new BusinessPartnerNotFoundException(id));

            var customerService = new CustomerService(_customerRepositoryMock.Object, _unitOfWorkMock.Object);

            var exec = () =>  customerService.GetByIdAsync(id, cancellationToken);

            await exec.Should().ThrowExactlyAsync<BusinessPartnerNotFoundException>();

        }

        [Fact]
        private async void TestGetCustomerById_Sucess()
        {
            var id = Guid.NewGuid();
            CancellationToken cancellationToken = default;
            var customer = new Customer { CustomerId = id };
            _customerRepositoryMock.Setup(repo => repo.GetByIdAsync(id, cancellationToken)).ReturnsAsync(customer);

            var customerService = new CustomerService(_customerRepositoryMock.Object, _unitOfWorkMock.Object);

            var dto = await customerService.GetByIdAsync(id, cancellationToken);

            dto.Should().NotBeNull();
            dto.Id.Should().Be(id);
        }
    }
}