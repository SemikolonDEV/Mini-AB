using AB.Contracts;
using AB.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace AB.API.Controllers.BusinessPartner;

[ApiController]
[Route("api/suppliers")]
public class SupplierController : ControllerBase
{

    public readonly ISupplierService _supplierService;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<SupplierDto>>> GetSupplieres(CancellationToken cancellationToken)
    {
        var suppliers = await _supplierService.GetAllAsync(cancellationToken);

        return Ok(suppliers);
    }

    [HttpGet("{supplierId:guid}")]
    public async Task<ActionResult<SupplierDto>> GetSupplierById(Guid supplierId, CancellationToken cancellationToken)
    {
        var supplierDto = await _supplierService.GetSupplierByIdAsync(supplierId, cancellationToken);

        return Ok(supplierDto);
    }

    [HttpPost]
    public async Task<CreatedAtActionResult> CreateSupplier([FromBody] SupplierForCreationDto supplierForCreation)
    {
        var supplierDto = await _supplierService.CreateAsync(supplierForCreation);

        return CreatedAtAction(nameof(CreateSupplier), new { id = supplierDto.Id }, supplierDto);
    }

    [HttpDelete("{supplierId:guid}")]
    public async Task<NoContentResult> DeleteSupplier(Guid supplierId, CancellationToken cancellationToken)
    {
        await _supplierService.DeleteAsync(supplierId, cancellationToken);

        return NoContent();
    }



}
