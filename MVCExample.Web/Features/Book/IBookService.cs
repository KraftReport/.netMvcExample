namespace MVCExample.Web.Features.Book
{
    public interface IBookService
    {
        Task<int> CreateNewBook(Book book);
        Task<List<Book>> GetAllBooks();
        Task<Book> GetBookById(int id);
        Task<int> EditBook(Book book);
        Task<int> DeleteBook(int id);
    }
}
