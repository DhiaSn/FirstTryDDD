using FirstTryDDD.SharedKarnel.Entities;

namespace FirstTryDDD.Core.AggregateModels.BookAggregate
{
    public class BookCategory : ParentEntity
    {
        public string CategoryName { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
