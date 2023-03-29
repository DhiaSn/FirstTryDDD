using FirstTryDDD.Core.AggregateModels.BookAggregate;

namespace FirstTryDDD.Core.AggregateModels.ReaderAggregate
{
    public class ReaderBookList
    {
        public int Id { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime RemovedDate { get; set; }

        //*** other relationships
        public Guid ReaderId { get; set; }
        public Reader Reader { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}
