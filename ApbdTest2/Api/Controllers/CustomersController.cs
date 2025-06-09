using ApbdTest2.Api.Contracts.Response;
using ApbdTest2.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApbdTest2.Api.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class CustomersController(ICustomerService customerService) : ControllerBase
{
    [HttpGet("{customerId:int}/purchases")]
    [ProducesResponseType(typeof(CustomerPurchasesResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetCustomerPurchasesById([FromRoute] int customerId,
        CancellationToken cancellationToken = default)
    {
        var customer = await customerService.GetCustomerPurchasesByIdAsync(customerId, cancellationToken);
        if (customer == null)
        {
            return NotFound($"Customer with id = {customerId} does not exist");
        }
        
        return Ok(customer);
    }
}