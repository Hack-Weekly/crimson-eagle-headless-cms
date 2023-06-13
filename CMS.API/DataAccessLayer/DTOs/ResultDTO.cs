namespace CMS.API.DataAccessLayer.DTOs
{
    public class ResultDTO<T>
    {
        public Boolean Succeeded { get; set; } = false;
        public IEnumerable<ErrorMessage>? Errors { get; set; }
        public T? Payload { get; set; }
    }

    public class ErrorMessage
    {
        public string Code { get; set; } = String.Empty;
        public required string Description { get; set; }
    }
}