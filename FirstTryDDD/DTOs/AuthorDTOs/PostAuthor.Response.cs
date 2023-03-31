using FirstTryDDD.Core.AggregateModels.AuthorAggregate;

namespace FirstTryDDD.API.DTOs.AuthorDTOs
{
    public class PostAuthorResponse
    {
        public PostAuthorResponse(Author author)
        {
            Id = author.Id; 
            PhoneNumber = author.PhoneNumber; 
            Name = author.Name; 
            Email = author.Email; 
            Password = author.Password; 
            Age = author.Age; 
            CreatedDate = author.CreatedDate; 
        }
        public new Guid Id { get; set; }
        public string PhoneNumber { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int? Age { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
