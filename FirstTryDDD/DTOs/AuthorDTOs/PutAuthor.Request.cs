namespace FirstTryDDD.API.DTOs.AuthorDTOs
{
    public class PutAuthorRequest
    {
        public Guid Id { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public int? Age { get; set; }
    }
}
