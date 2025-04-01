using CRMSystem.WebAPI.DTOs.School.Students;
using CRMSystem.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CRMSystem.WebAPI.Controllers
{
    [ApiController]
    [Route("api/student-registration")]
    public class StudentRegistrationController(StudentRegistrationService service)
        : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RegisterStudentDto dto)
        {
            var result = await service.CreateStudentAsync(dto);
            return Ok(result);
        }
    }
}