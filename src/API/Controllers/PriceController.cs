using API.Middleware;
using Application.Behaviours;
using Application.Contracts.Domain.DTOs;
using Application.Features.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class PriceController : Controller
    {
        private readonly IMediator _mediator;

        public PriceController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get the best rates.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("GetBestRate")]
        [ProducesResponseType(typeof(PackageResponse), statusCode: 200)]
        public async Task<IActionResult> GetBestRate([FromBody] GetPriceCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);

                if(result == null)
                {
                    return NotFound();
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                if (ex is HttpStatusException httpException)
                {
                    return StatusCode((int) httpException.Status, httpException.Message);
                }else{
                    return BadRequest(ex.Message);
                }
            }
        }
    }
}