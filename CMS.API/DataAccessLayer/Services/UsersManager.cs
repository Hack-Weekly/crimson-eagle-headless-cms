using AutoMapper;
using CMS.API.DataAccessLayer.DTOs;
using CMS.API.DataAccessLayer.DTOs.APIUser;
using CMS.API.DataAccessLayer.Interfaces;
using CMS.API.DataAccessLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace CMS.API.DataAccessLayer.Services
{
    public class UsersManager : IUsersManager
    {
        private IMapper _mapper;
        private readonly UserManager<APIUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private IcmsProjectRepository _csmProjectRepository;
        private APIUser? _user;

        public UsersManager(
            IMapper mapper,
            UserManager<APIUser> userManager,
            IHttpContextAccessor httpContextAccessor,
            IcmsProjectRepository cmsProjectRepository)
        {
            this._mapper = mapper;
            this._userManager = userManager;
            this._httpContextAccessor = httpContextAccessor;
            this._csmProjectRepository = cmsProjectRepository;
        }

        public async Task<IEnumerable<APIUserDTO>> ListUsers()
        {
            List<APIUser> users = await _userManager.Users.ToListAsync();
            return users.Select(_mapper.Map<APIUser, APIUserDTO>);
        }

        public async Task<APIUserDTO?> GetUserById(string id)
        {
            _user = await _userManager.FindByIdAsync(id);

            if (_user == null) return null;

            return _mapper.Map<APIUserDTO>(_user);
        }

        public async Task<ResultDTO<APIUserDTO>> CreateNewUser(APIUserCreateDTO DTO)
        {
            _user = _mapper.Map<APIUser>(DTO);
            _user.UserName = DTO.Email;

            if (_httpContextAccessor.HttpContext == null) return ErrorResult("500", "Context not found");
            var currentUserId = _httpContextAccessor.HttpContext?.User.FindFirstValue("uid");
            if (currentUserId == null) return ErrorResult("500", "User Id not found");

            var currentUser = await _userManager.FindByIdAsync(currentUserId);
            if (currentUser == null) return ErrorResult("500", "User not found");

            _user.ProjectId = currentUser.ProjectId;

            IdentityResult result = await _userManager.CreateAsync(_user, DTO.Password);

            if (!result.Succeeded)
            {
                return _mapper.Map<ResultDTO<APIUserDTO>>(result);
            }

            IdentityResult roleResult = await _userManager.AddToRoleAsync(_user, "PROJUSER");

            if (!roleResult.Succeeded)
            {
                return _mapper.Map<ResultDTO<APIUserDTO>>(result);
            }

            return new ResultDTO<APIUserDTO>
            {
                Succeeded = true,
                Payload = _mapper.Map<APIUser, APIUserDTO>(_user),
            };
        }

        public async Task<ResultDTO<APIUserDTO>> UpdateUser(string id, APIUserUpdateDTO DTO)
        {
            _user = await _userManager.FindByIdAsync(id);

            if (_user == null) return NotFoundUser();

            _user = _mapper.Map<APIUserUpdateDTO, APIUser>(DTO, _user);

            IdentityResult result = await _userManager.UpdateAsync(_user);

            if (!result.Succeeded)
            {
                return _mapper.Map<ResultDTO<APIUserDTO>>(result);
            }

            if (DTO.Password != null)
            {
                var token = await _userManager.GeneratePasswordResetTokenAsync(_user);
                IdentityResult resetResult = await _userManager.ResetPasswordAsync(_user, token, DTO.Password);

                if (!resetResult.Succeeded)
                {
                    return _mapper.Map<ResultDTO<APIUserDTO>>(resetResult);
                }
            }

            return new ResultDTO<APIUserDTO>
            {
                Succeeded = true,
                Payload = _mapper.Map<APIUser, APIUserDTO>(_user),
            };
        }

        public async Task<ResultDTO<APIUserDTO>> DeleteUser(string id)
        {
            _user = await _userManager.FindByIdAsync(id);

            if (_user == null) return NotFoundUser();

            IdentityResult result = await _userManager.DeleteAsync(_user);

            return _mapper.Map<ResultDTO<APIUserDTO>>(result);
        }

        private ResultDTO<APIUserDTO> NotFoundUser()
        {
            return new ResultDTO<APIUserDTO>
            {
                Succeeded = false,
                Errors = new ErrorMessage[1]
                {
                    new ErrorMessage
                    {
                        Code = "404",
                        Description = "User not found.",
                    }
                },
            };
        }

        private ResultDTO<APIUserDTO> ErrorResult(string code = "404", string description = "User not found.")
        {
            return new ResultDTO<APIUserDTO>
            {
                Succeeded = false,
                Errors = new ErrorMessage[1]
                {
                    new ErrorMessage
                    {
                        Code = code,
                        Description = description,
                    }
                },
            };
        }
    }
}
