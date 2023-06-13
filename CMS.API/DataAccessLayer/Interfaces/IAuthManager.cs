using CMS.API.DataAccessLayer.DTOs.APIUser;
using CMS.API.DataAccessLayer.DTOs.AuthResponse;
using Microsoft.AspNetCore.Identity;

namespace CMS.API.DataAccessLayer.Interfaces
{
    public interface IAuthManager
    {
        Task<IdentityResult> RegisterNewUser(APIUserRegisterDTO DTO);

        Task<AuthResponseDTO?> LoginUser(APIUserLoginDTO DTO);

        Task<string> CreateRefreshToken();
        Task<AuthResponseDTO?> VerifyRefreshToken(AuthResponseDTO DTO);
    }
}
