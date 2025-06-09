using ApbdTest2.Api.Contracts.Request;
using ApbdTest2.Api.Contracts.Response;
using ApbdTest2.Application.Exceptions;
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
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetCustomerPurchasesById([FromRoute] int customerId,
        CancellationToken cancellationToken = default)
    {
        try
        {
            var customer = await customerService.GetCustomerPurchasesByIdAsync(customerId, cancellationToken);
            if (customer == null)
            {
                return NotFound($"Customer with id = {customerId} does not exist");
            }

            return Ok(customer);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected server error occured");
        }
        
    }

    [HttpPost]
    [ProducesResponseType(typeof(CustomerPurchasesResponseDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(string), StatusCodes.Status409Conflict)]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreateCustomerPurchases(
        [FromBody] CreateCustomerPurchasesRequestDto customerPurchasesRequestDto)
    {
        try
        {
            var customer = await customerService.CreatePurchasesForCustomerAsync(customerPurchasesRequestDto);
            if (customer == null)
            {
                return Conflict($"Customer cant purchase more than 5 tickets for a concert");
            }

            return CreatedAtAction(nameof(GetCustomerPurchasesById), customer);
        }
        catch (ConflictException ex)
        {
            return Conflict(ex.Message);
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected server error occured");
        }
    }
}