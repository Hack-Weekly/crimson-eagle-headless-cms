using AutoMapper;
using CloudinaryDotNet.Actions;
using CMS.API.DataAccessLayer.DTOs;
using CMS.API.DataAccessLayer.DTOs.APIUser;
using CMS.API.DataAccessLayer.DTOs.UserFile;
using CMS.API.DataAccessLayer.Models;
using Microsoft.AspNetCore.Identity;

namespace CMS.API.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            // user management
            CreateMap<APIUser, APIUserDTO>().ReverseMap(); // Mapper will convert to and from DTO
            CreateMap<APIUser, APIUserRegisterDTO>().ReverseMap();
            CreateMap<APIUser, APIUserCreateDTO>().ReverseMap();
            CreateMap<APIUserUpdateDTO, APIUser>();
            CreateMap<IdentityError, ErrorMessage>();
            CreateMap<IdentityResult, ResultDTO<APIUserDTO>>();

            // file upload
            CreateMap<ProjectFile, ProjectFileDTO>().ReverseMap(); // Mapper will convert to and from DTO
            CreateMap<ImageUploadResult, DataAccessLayer.Models.UploadResult>();
            CreateMap<VideoUploadResult, DataAccessLayer.Models.UploadResult>();
        }
    }
}
