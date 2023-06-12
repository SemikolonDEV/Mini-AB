using AB.Contracts;
using AB.Services.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AB.API.Controllers.BusinessPartner;

[ApiController]
[Route("api/suppliers")]
[Produces("application/json")]
public class SupplierController : ControllerBase
{

    public readonly ISupplierService _supplierService;

    public SupplierController(ISupplierService supplierService)
    {
        _supplierService = supplierService;
    }

    /// <summary>
    /// Abrufen aller Lieferanten
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<SupplierDto>>> GetSupplieres(CancellationToken cancellationToken)
    {
        var suppliers = await _supplierService.GetAllAsync(cancellationToken);

        return Ok(suppliers);
    }

    /// <summary>
    /// Abrufen eines Lieferanten anhand seiner Id
    /// </summary>
    /// <param name="supplierId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <response code="404">Lieferant wurde nicht gefunden</response>
    [HttpGet("{supplierId:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<SupplierDto>> GetSupplierById(Guid supplierId, CancellationToken cancellationToken)
    {
        var supplierDto = await _supplierService.GetSupplierByIdAsync(supplierId, cancellationToken);

        return Ok(supplierDto);
    }

    /// <summary>
    /// Anlegen eines neuen Lieferanten
    /// </summary>
    /// <param name="supplierForCreation"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>Einen neu erstellen Kunden</returns>
    /// <response code="201">Lieferant wurde erstellt</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<CreatedAtActionResult> CreateSupplier([FromBody] SupplierForCreationDto supplierForCreation, CancellationToken cancellationToken)
    {
        var supplierDto = await _supplierService.CreateAsync(supplierForCreation, cancellationToken);

        return CreatedAtAction(nameof(CreateSupplier), new { id = supplierDto.Id }, supplierDto);
    }

    /// <summary>
    /// Löschen eines vorhanden Lieferanten
    /// </summary>
    /// <param name="supplierId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <response code="204">Lieferant wurde gelöscht</response>
    /// <response code="404">Lieferant wurde nicht gefunden</response>
    [HttpDelete("{supplierId:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<NoContentResult> DeleteSupplier(Guid supplierId, CancellationToken cancellationToken)
    {
        await _supplierService.DeleteAsync(supplierId, cancellationToken);

        return NoContent();
    }



}
