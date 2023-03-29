using FirstTryDDD.Core.AggregateModels.AuthorAggregate;
using FirstTryDDD.Core.AggregateModels.ReaderAggregate;
using FirstTryDDD.SharedKarnel.Entities;

namespace FirstTryDDD.Core.AggregateModels.BookAggregate
{
    public class Book : ParentEntity
    {
        public string Title { get; set; }
        public string Uri { get; set; }
        public DateTime PublishedDate { get; set; }
        public int TotalSells { get; set; }

        //*** other relationships
        public Guid AuthorId { get; set; }
        public Author Author { get; set; }

        public int CategoryId { get; set; }
        public BookCategory Category { get; set; }

        public ICollection<ReaderBookList> ReaderBookLists { get; set; }

    }
}
