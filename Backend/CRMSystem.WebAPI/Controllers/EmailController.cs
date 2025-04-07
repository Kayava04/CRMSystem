using CRMSystem.WebAPI.DTOs.Email;
using CRMSystem.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CRMSystem.WebAPI.Controllers
{
    [Route("api/email")]
    [ApiController]
    public class EmailController(EmailService emailService)
        : ControllerBase
    {
        [HttpPost("send")]
        public async Task<IActionResult> SendMessage([FromBody] SendMessageDto dto)
        {
            var result = await emailService.SendMessageAsync(dto);
            return Ok(result);
        }

        [HttpGet("messages/{receiverId:guid}")]
        public async Task<IActionResult> GetMessagesByReceiverId(Guid receiverId)
        {
            var messages = await emailService.GetMessagesByReceiverIdAsync(receiverId);
            return Ok(messages);
        }
    }
}