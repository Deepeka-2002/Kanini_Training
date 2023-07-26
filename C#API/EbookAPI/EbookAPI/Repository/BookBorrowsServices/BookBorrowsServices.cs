using EbookAPI.Models;

namespace EbookAPI.Repository.BookBorrowsServices
{
    public class BookBorrowsServices : IBookBorrowsServices
    {

        public EbookContext _context;

        public BookBorrowsServices(EbookContext context)
        {
            _context = context;
        }
        

    }
}
