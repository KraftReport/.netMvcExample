using Microsoft.EntityFrameworkCore;
using MVCExample.Web.EFDbContext;

namespace MVCExample.Web.Features.Book
{
    public class BookService : IBookService
    {
        private readonly AppDbContext _context;
        public BookService(AppDbContext context) 
        {
            _context = context;
        }

        public async Task<int> CreateNewBook(Book book)
        {
            await _context.Book.AddAsync(book);
            return await _context.SaveChangesAsync(); 
        }

        public async Task<List<Book>> GetAllBooks()
        {
            return await _context.
                Book.
                AsNoTracking().
                ToListAsync();

        }

        public async Task<Book> GetBookById(int Id)
        {
            return await _context.Book.FindAsync(Id);
        }

        public async Task<int> EditBook(Book book)
        {
            Console.WriteLine(book.Id);
            var existingBook = _context.Book.Find(book.Id);
            if (existingBook != null)
            {
                existingBook.Name = book.Name;
                existingBook.author = book.author;
                existingBook.price = book.price;
                existingBook.category = book.category;
                await _context.SaveChangesAsync();
            }
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteBook(int Id)
        {
            var book = await _context.Book.FindAsync(Id);
            _context.Book.Remove(book);
            return await _context.SaveChangesAsync();
        }
    }
}
