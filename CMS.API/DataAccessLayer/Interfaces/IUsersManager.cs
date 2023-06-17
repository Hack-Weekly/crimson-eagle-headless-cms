using CMS.API.DataAccessLayer.DTOs;
using CMS.API.DataAccessLayer.DTOs.APIUser;

namespace CMS.API.DataAccessLayer.Interfaces
{
    public interface IUsersManager
    {
        Task<IEnumerable<APIUserDTO>> ListUsers();
        Task<APIUserDTO?> GetUserById(string id);
        Task<ResultDTO<APIUserDTO>> CreateNewUser(APIUserCreateDTO DTO);
        Task<ResultDTO<APIUserDTO>> UpdateUser(string id, APIUserUpdateDTO DTO);
        Task<ResultDTO<APIUserDTO>> DeleteUser(string id);
        Task<string?> GetProjectFromLoggedInUser();
        string? GetUserId();
    }
}
