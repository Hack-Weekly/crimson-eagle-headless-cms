using AutoMapper;
using CMS.API.DataAccessLayer.DTOs.APIUser;
using CMS.API.DataAccessLayer.DTOs.AuthResponse;
using CMS.API.DataAccessLayer.Interfaces;
using CMS.API.DataAccessLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CMS.API.DataAccessLayer.Services
{
    public class AuthManager : IAuthManager
    {
        private IMapper _mapper;
        private UserManager<APIUser> _userManager;
        private readonly IConfiguration _configuration;
        private IcmsProjectRepository _csmProjectRepository;
        private APIUser? _user;

        private const string _loginProvider = "Crimson-Eagle";
        private const string _refreshToken = "RefreshToken";

        public AuthManager(
            IMapper mapper,
            UserManager<APIUser> userManager,
            IConfiguration configuration,
            IcmsProjectRepository cmsProjectRepository)
        {
            this._mapper = mapper;
            this._userManager = userManager;
            this._configuration = configuration;
            this._csmProjectRepository = cmsProjectRepository;
        }

        public async Task<AuthResponseDTO?> LoginUser(APIUserLoginDTO DTO)
        {
            _user = await _userManager.FindByEmailAsync(DTO.Email);

            if (_user == null) return null;

            bool isValidPassword = await _userManager.CheckPasswordAsync(_user, DTO.Password);

            if (!isValidPassword) return default;

            var issueNewToken = await GenerateToken();

            return new AuthResponseDTO
            {
                UserId = _user.Id,
                Token = issueNewToken,
                RefreshToken = await CreateRefreshToken()
            };
        }

        public async Task<IdentityResult> RegisterNewUser(APIUserRegisterDTO DTO)
        {
            _user = _mapper.Map<APIUser>(DTO);

            _user.UserName = DTO.Email;

            var project = await _csmProjectRepository.AddAsync(new cmsProject
            {
                Name = DTO.ProjectName,
                LastUpdated = DateTime.Now,
            });

            _user.Project = project;

            var registerResult = await _userManager.CreateAsync(_user, DTO.Password);

            if (!registerResult.Succeeded)
            {
                return registerResult;
            }

            return await _userManager.AddToRoleAsync(_user, "PROJOWNER");
        }

        private async Task<string> GenerateToken()
        {
            var securityKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(
                    _configuration["JwtSettings:Key"]
                    )
                );

            var userCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var userRoles = await _userManager.GetRolesAsync(_user!);

            var userRoleClaims = userRoles.Select(role => new Claim(ClaimTypes.Role, role)).ToList();

            /* Below is the method to retrieve claims that are stored in database */
            var userClaims = await _userManager.GetClaimsAsync(_user!);

            var userClaimsList = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, _user!.Email!),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, _user!.Email!),
                new Claim("uid", _user.Id), // custom claim user id
            }
            .Union(userClaims)
            .Union(userRoleClaims);

            var newToken = new JwtSecurityToken(
                    issuer: _configuration.GetValue<string>("JwtSettings:Issuer"),
                    audience: _configuration["JwtSettings:Audience"],
                    claims: userClaimsList,
                    expires: DateTime.Now
                                .AddMinutes(Convert.ToDouble(
                                    _configuration["JwtSettings:DurationInMinutes"])),
                    /*
                    expires: DateTime.Now
                                .AddMinutes(30),
                    */
                    signingCredentials: userCredentials

                ); ;

            return new JwtSecurityTokenHandler()
                .WriteToken(newToken);
        }

        public async Task<string> CreateRefreshToken()
        {
            await _userManager.RemoveAuthenticationTokenAsync(_user!, _loginProvider, _refreshToken); // removes current token from db

            var getNewRefreshToken = await _userManager.GenerateUserTokenAsync(_user!, _loginProvider, _refreshToken); // adds new token to db

            var giveNewRefreshToken = await _userManager.SetAuthenticationTokenAsync(_user!, _loginProvider, _refreshToken, getNewRefreshToken);

            return getNewRefreshToken;
        }

        public async Task<AuthResponseDTO?> VerifyRefreshToken(AuthResponseDTO DTO)
        {
            if (DTO.RefreshToken == null) return null;

            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var tokenContent = jwtSecurityTokenHandler.ReadJwtToken(DTO.Token);

            var username = tokenContent.Claims.ToList().FirstOrDefault(found => found.Type == JwtRegisteredClaimNames.Email)?.Value;

            if (username == null) return null;

            _user = await _userManager.FindByNameAsync(username);

            if (_user == null || _user.Id != DTO.UserId) return null;

            var isValidRefreshToken = await _userManager.VerifyUserTokenAsync(_user, _loginProvider, _refreshToken, DTO.RefreshToken);

            if (isValidRefreshToken)
            {
                var newToken = await GenerateToken();

                return new AuthResponseDTO
                {
                    Token = newToken,
                    UserId = _user.Id,
                    RefreshToken = await CreateRefreshToken()
                };
            }

            await _userManager.UpdateSecurityStampAsync(_user);

            return null;

        }
    }
}
