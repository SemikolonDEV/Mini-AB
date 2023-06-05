using AB.Contracts;
using AB.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AB.API.Controllers
{
    [ApiController]
    [Route("api/customers")]
    public class CustomerController : ControllerBase
    {

        private readonly ICustomerService _customerService;


        [HttpGet]
        public async Task<IActionResult> GetCustomers(CancellationToken cancellationToken)
        {
            var customers = await _customerService.GetAllAsync(cancellationToken);

            return Ok(customers);
        }

        [HttpGet("{customerId:guid}")]
        public async Task<IActionResult> GetCustomerById(Guid customerId, CancellationToken cancellationToken)
        {
            var customer = await _customerService.GetByIdAsync(customerId, cancellationToken);

            return Ok(customer);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromBody] CustomerForCreationDto customerForCreation)
        {
            var customerDto = await _customerService.CreateAsync(customerForCreation);
            
            return CreatedAtAction(nameof(CreateCustomer), new {customerId = customerDto.Id}, customerDto);
        }

        [HttpDelete("{customerId:guid}")]
        public async Task<IActionResult> DeleteCustomer(Guid customerId, CancellationToken cancellationToken)
        {
            await _customerService.DeleteAsync(customerId, cancellationToken);

            return NoContent();
        }

    }
}
