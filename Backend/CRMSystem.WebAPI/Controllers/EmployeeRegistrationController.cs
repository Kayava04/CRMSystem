using CRMSystem.WebAPI.DTOs.School.Employees;
using CRMSystem.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CRMSystem.WebAPI.Controllers
{
    [ApiController]
    [Route("api/employee-registration")]
    public class EmployeeRegistrationController(EmployeeRegistrationService service)
        : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RegisterEmployeeDto dto)
        {
            var result = await service.CreateEmployeeAsync(dto);
            return Ok(result);
        }
        
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await service.GetEmployeeByIdAsync(id);
            
            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await service.GetAllEmployeesAsync();
            return Ok(result);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] RegisterEmployeeDto dto)
        {
            var result = await service.UpdateEmployeeAsync(id, dto);
            
            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await service.DeleteEmployeeAsync(id);
            return NoContent();
        }
    }
}