using FirstTryDDD.Core.AggregateModels.BookAggregate;
using FirstTryDDD.SharedKarnel.Entities;

namespace FirstTryDDD.Core.AggregateModels.AuthorAggregate
{
    public class Author : BaseEntity
    {
        public string PhoneNumber { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int? Age { get; set; }

        //*** other relationships
        public ICollection<Book>? Books { get; set; }
    }
}
