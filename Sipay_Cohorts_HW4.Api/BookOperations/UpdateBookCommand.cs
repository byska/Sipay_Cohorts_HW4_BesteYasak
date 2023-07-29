using Sipay_Cohorts_HW4.DataAccess.Context;
using Sipay_Cohorts_HW4.Entities.DbSets;
using Sipay_Cohorts_HW4.Entities.Enums;

namespace Sipay_Cohorts_HW4.Api.BookOperations
{
    public class UpdateBookCommand
    {
        public int Id { get; set; }
        public UpdateBookModel Model { get; set; }

        private readonly BookStoreDbContext _dbContext;
        public UpdateBookCommand(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Handle()
        {
            var book = _dbContext.Books.Find(Id);
            if (book == null)
            {
                throw new ArgumentNullException("Belirtilen ID ile bir kayıt bulunamadı.");

            }

            book.Title = Model.Title !=default ? Model.Title: book.Title ;
            book.GenreId = Model.GenreId != default ? Model.GenreId : book.GenreId;
            book.PageCount = Model.PageCount != default ? Model.PageCount : book.PageCount;
            book.PublishDate = Model.PublishDate != default ? Model.PublishDate : book.PublishDate;
            _dbContext.Update(book);
            _dbContext.SaveChanges();
        }
        public class UpdateBookModel
        {
            public string Title { get; set; }
            public int GenreId { get; set; }
            public int PageCount { get; set; }
            public DateTime PublishDate { get; set; }
        }
    }
}
