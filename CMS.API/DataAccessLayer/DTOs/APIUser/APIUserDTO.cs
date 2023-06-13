namespace CMS.API.DataAccessLayer.DTOs.APIUser
{
    public class APIUserDTO
    {
        public required string Id { get; set; }
        public required string FName { get; set; }
        public required string LName { get; set; }
        public string? OrganizationName { get; set; }
        public required string ProjectId { get; set; }
        public required string Email { get; set; }
    }
}
