using AB.Contracts;
using AB.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace AB.API.Controllers.BusinessPartner;

[ApiController]
[Route("api/customers")]
public class CustomerController : ControllerBase
{

    private readonly ICustomerService _customerService;

    public CustomerController(ICustomerService customerService)
    {
            _customerService = customerService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CustomerDto>>> GetCustomers(CancellationToken cancellationToken)
    {
        var customers = await _customerService.GetAllAsync(cancellationToken);

        return Ok(customers);
    }

    [HttpGet("{customerId:guid}")]
    public async Task<ActionResult<CustomerDto>> GetCustomerById(Guid customerId, CancellationToken cancellationToken)
    {
        var customer = await _customerService.GetByIdAsync(customerId, cancellationToken);

        return Ok(customer);
    }

    [HttpPost]
    public async Task<CreatedAtActionResult> CreateCustomer([FromBody] CustomerForCreationDto customerForCreation)
    {
        var customerDto = await _customerService.CreateAsync(customerForCreation);

        return CreatedAtAction(nameof(CreateCustomer), new { customerId = customerDto.Id }, customerDto);
    }

    [HttpDelete("{customerId:guid}")]
    public async Task<NoContentResult> DeleteCustomer(Guid customerId, CancellationToken cancellationToken)
    {
        await _customerService.DeleteAsync(customerId, cancellationToken);

        return NoContent();
    }

}
