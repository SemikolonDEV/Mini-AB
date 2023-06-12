using AB.Contracts;
using AB.Services.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AB.API.Controllers.BusinessPartner;

[ApiController]
[Route("api/customers")]
[Produces("application/json")]
public class CustomerController : ControllerBase
{

    private readonly ICustomerService _customerService;

    public CustomerController(ICustomerService customerService)
    {
            _customerService = customerService;
    }

    /// <summary>
    /// Abrufen aller Kunden 
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns>Eine Liste aller Kunden</returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CustomerDto>>> GetCustomers(CancellationToken cancellationToken)
    {
        var customers = await _customerService.GetAllAsync(cancellationToken);

        return Ok(customers);
    }

    /// <summary>
    /// Abrufen eines Kunden anhand seiner Id
    /// </summary>
    /// <param name="customerId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>Den Kunden mit der angegeben Id</returns>
    [HttpGet("{customerId:guid}")]
    public async Task<ActionResult<CustomerDto>> GetCustomerById(Guid customerId, CancellationToken cancellationToken)
    {
        var customer = await _customerService.GetByIdAsync(customerId, cancellationToken);

        return Ok(customer);
    }

    /// <summary>
    /// Anlegen eines neuen Kunden
    /// </summary>
    /// <param name="customerForCreation"></param>
    /// <returns>Einen neu erstellten Kunden</returns>
    /// <response code="201">Kunde wurde erstellt</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<CreatedAtActionResult> CreateCustomer([FromBody] CustomerForCreationDto customerForCreation)
    {
        var customerDto = await _customerService.CreateAsync(customerForCreation);

        return CreatedAtAction(nameof(CreateCustomer), new { customerId = customerDto.Id }, customerDto);
    }

    /// <summary>
    /// Löschen eines vorhandenen Kunden
    /// </summary>
    /// <param name="customerId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <response code="204">Kunde wurde gelöscht</response>
    /// <response code="404">Kunde wurde nicht gefunden</response>
    [HttpDelete("{customerId:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<NoContentResult> DeleteCustomer(Guid customerId, CancellationToken cancellationToken)
    {
        await _customerService.DeleteAsync(customerId, cancellationToken);

        return NoContent();
    }

    /// <summary>
    /// Bearbeiten eines vorhanden Kunden
    /// </summary>
    /// <param name="customerId"></param>
    /// <param name="customerForUpdate"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>Den veränderten Kunden
    /// </returns>
    /// <response code="200">Kunde wurde bearbeitet</response>
    /// <response code="404">Kunde wurde nicht gefunden</response>
    [HttpPut("{customerId:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CustomerDto>> UpdateCustomer(Guid customerId, CustomerForUpdateDto customerForUpdate, CancellationToken cancellationToken)
    {
        var customerDto = await _customerService.UpdateAsync(customerId, customerForUpdate, cancellationToken);


        return Ok(customerDto);
    }

}
