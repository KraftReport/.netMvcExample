using Microsoft.EntityFrameworkCore;
using MVCExample.Web.Features.Blog;
using MVCExample.Web.Features.Book;

namespace MVCExample.Web.EFDbContext;

public class AppDbContext: DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }
    
    public DbSet<BlogDataModel> Blog { get; set; }
    public DbSet<Book> Book { get; set; }
}