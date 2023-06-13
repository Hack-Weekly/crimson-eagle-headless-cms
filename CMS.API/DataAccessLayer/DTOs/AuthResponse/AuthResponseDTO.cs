namespace CMS.API.DataAccessLayer.DTOs.AuthResponse
{
    public class AuthResponseDTO
    {
        public required string UserId { get; set; }
        public string? CompanyName { get; set; }
        public required string Token { get; set; }
        public string? RefreshToken { get; internal set; }
    }
}
