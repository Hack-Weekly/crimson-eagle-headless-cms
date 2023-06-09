using CMS.API.DataAccessLayer.Models;
using Microsoft.Build.Evaluation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMS.API.DataAccessLayer.DTOs.APIUser
{
    public class APIUserDTO : APIUserLoginDTO
    {
        public string FName { get; set; }
        public string LName { get; set; }
        public string? OrganizationName { get; set; }
        public bool IsProjectOwner { get; set; }
    }
}
