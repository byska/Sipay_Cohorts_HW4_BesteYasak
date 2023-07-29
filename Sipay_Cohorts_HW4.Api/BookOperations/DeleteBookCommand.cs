using Sipay_Cohorts_HW4.DataAccess.Context;

namespace Sipay_Cohorts_HW4.Api.BookOperations
{
    public class DeleteBookCommand
    {
        public int Id { get; set; }

        private readonly BookStoreDbContext _dbContext;
        public DeleteBookCommand(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var book=_dbContext.Books.Find(Id);
            if(book is null)
            {
                throw new InvalidDataException("Verilen id'de bir kitap yoktur.");
            }
            _dbContext.Books.Remove(book);
            _dbContext.SaveChanges();
        }
        
    }
}
