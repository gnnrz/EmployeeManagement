using Application.Employees.Create;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.EmployeesController
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmployeesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(
                [FromBody] CreateEmployeeRequest request,
                CancellationToken cancellationToken)
        {
            var command = request.ToCommand();

            var result = await _mediator.Send(command, cancellationToken);

            if (result.IsFailure)
                return BadRequest(new { error = result.Error });

            return CreatedAtAction(nameof(GetById), new { id = result.Value }, null);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(); // stub por enquanto
        }
    }
}