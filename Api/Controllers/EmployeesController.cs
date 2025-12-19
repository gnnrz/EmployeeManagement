using Application.Employees.Create;
using Application.Employees.Delete;
using Application.Employees.GetAll;
using Application.Employees.GetById;
using Application.Employees.Update;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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

        /// <summary>
        /// Create employees
        /// </summary>
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(
                [FromBody] CreateEmployeeRequest request,
                CancellationToken cancellationToken)
        {
            var command = request.ToCommand();

            var result = await _mediator.Send(command, cancellationToken);

            if (result.IsFailure)
                return BadRequest(new { error = result.Error });

            return Ok();
        }

        /// <summary>
        /// Returns all employees
        /// </summary>
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var employees = await _mediator.Send(
                new GetAllEmployeesQuery(),
                cancellationToken
            );

            return Ok(employees);
        }

        /// <summary>
        /// Returns an employee by id
        /// </summary>
        [HttpGet("{id:guid}")]
        [Authorize]
        public async Task<IActionResult> GetById(
            Guid id,
            CancellationToken cancellationToken)
        {
            var employee = await _mediator.Send(
                new GetByIdEmployeeQuery(id),
                cancellationToken
            );

            if (employee is null)
                return NotFound();

            return Ok(employee);
        }

        /// <summary>
        /// Updates an employee
        /// </summary>
        [HttpPut("{id:guid}")]
        [Authorize]
        public async Task<IActionResult> Update(
            Guid id,
            [FromBody] UpdateEmployeeRequest request,
            CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(
                request.ToCommand(id),
                cancellationToken
            );

            if (result.IsFailure)
                return NotFound(result.Error);

            return NoContent();
        }

        /// <summary>
        /// Deletes an employee
        /// </summary>
        [HttpDelete("{id:guid}")]
        [Authorize]
        public async Task<IActionResult> Delete(
            Guid id,
            CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(
                new DeleteEmployeeCommand(id),
                cancellationToken
            );

            if (result.IsFailure)
                return NotFound(result.Error);

            return NoContent();
        }
    }
}