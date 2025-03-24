namespace CRMSystem.WebAPI.DTOs.Auth
{
    public record SignUpRequestDto(string FullName, string Email, string Username, string Password);
}