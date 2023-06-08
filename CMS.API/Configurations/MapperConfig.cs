using AutoMapper;
using CMS.API.DataAccessLayer.DTOs.APIUser;
using CMS.API.DataAccessLayer.Models;

namespace CMS.API.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<APIUser, APIUserDTO>().ReverseMap(); // Mapper will convert to and from DTO
        }
    }
}
