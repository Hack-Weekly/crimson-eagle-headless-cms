namespace CMS.API.DataAccessLayer.DTOs.AuthResponse
{
    public class AuthResponseDTO
    {
        public string UserId { get; set; }
        public string CompanyName { get; set; }
        public string Token { get; set; }
        public string? RefreshToken { get; internal set; }
    }
}
