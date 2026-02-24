using MediatR;
using Microsoft.AspNetCore.Mvc;
using Redarbor.Api.Contracts.Employees;
using Redarbor.Application.Common.Interfaces;
using Redarbor.Application.Employees.Commands;

namespace Redarbor.Api.Controllers;

[ApiController]
[Microsoft.AspNetCore.Mvc.Route("api/redarbor")]
public sealed class EmployeesController(IMediator mediator, IEmployeeReadRepository employeeReadRepository) : ControllerBase
{
    // GET /api/redarbor
    [HttpGet]
    public async Task<IActionResult> GetAllEmployees(CancellationToken ct)
    {
        var employees = await employeeReadRepository.GetAllAsync(ct);

        var response = employees.Select(EmployeeResponse.FromDomain);

        return Ok(response);
    }

    //GET /api/redarbor/{id}
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetEmployeeById(int id, CancellationToken ct)
    {
        var employee = await employeeReadRepository.GetByIdAsync(id, ct);
        if (employee is null) return NotFound();
        var response = EmployeeResponse.FromDomain(employee);
        return Ok(response);
    }

    //Post employee (create new employee)
    [HttpPost]
    public async Task<IActionResult> CreateEmployee([FromBody] CreateEmployeeRequest request, CancellationToken ct)
    {
        var command = request.ToCommand();

        var id = await mediator.Send(command, ct);

        return CreatedAtAction(nameof(GetEmployeeById), new { id }, new { id });
    }

    // PUT /api/redarbor/{id}
    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateUsername([FromRoute] int id, [FromBody] UpdateEmployeeRequest request, CancellationToken ct)
    {
        await mediator.Send(new UpdateEmployeeUsernameCommand(id, request.Username), ct);
        return NoContent();
    }

    // DELETE /api/redarbor/{id}
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id, CancellationToken ct)
    {
        await mediator.Send(new DeleteEmployeeCommand(id), ct);
        return NoContent();
    }

}