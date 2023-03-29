using FirstTryDDD.SharedKarnel.Entities;

namespace FirstTryDDD.Core.AggregateModels.ReaderAggregate
{
    public class Reader : BaseEntity
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        //*** other relationships
        public ICollection<ReaderBookList> ReaderBookLists { get; set; }
    }
}
