using AutoMapper;
using Employee.API.Entities;
using Employee.API.Models;
using Employee.API.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Employee.API.Controllers
{
    [ApiController]
    [Route("api/employee")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;

        public EmployeeController(IEmployeeService employeeService,
            IMapper mapper)
        {
            _employeeService = employeeService ??
               throw new ArgumentNullException(nameof(employeeService));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Entities.Employee>>> GetEmployees()
        {
            try
            {
                var employees = await _employeeService.GetEmployeesAsync();
                return Ok(_mapper.Map<IEnumerable<EmployeeDto>>(employees));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message ?? e.InnerException?.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployee(int id)
        {
            try
            {
                var employee = await _employeeService.GetEmployeeAsync(id);
                if (employee == null)
                {
                    return NotFound();
                }

                return Ok(_mapper.Map<EmployeeDto>(employee));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message ?? e.InnerException?.Message);
            }

        }
        [HttpDelete("{id}")]
        public async Task DeleteEmployee(int id)
        {
            await _employeeService.DeleteEmployeeAsync(id);
        }

        [HttpPost]
        public async Task<IActionResult> EditEmployee(EmployeeDto employee)
        {
            try
            {
                var employeeEntity = await _employeeService.GetEmployeeAsync(employee.Id);
                if (employeeEntity == null)
                {
                    return NotFound();
                }
                _mapper.Map(employee, employeeEntity);
                await _employeeService.UpdateEmployeeAsync(employeeEntity);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message ?? e.InnerException?.Message);
            }
        }

    }
}
