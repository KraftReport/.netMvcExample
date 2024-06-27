using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering; 

namespace MVCExample.Web.Features.Book
{
    public class BookController : Controller
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        public IActionResult CreateBook()
        {


            var categories = Enum.GetValues(typeof(CATEGORY))
                 .Cast<CATEGORY>()
                 .Select(c => new SelectListItem
                 {
                     Value = ((int)c).ToString(),
                     Text = c.ToString()
                 })
                 .ToList();

            ViewBag.Categories = categories;
            return View();
        }

        public async Task<IActionResult> BookView()
        { 
            var response = await _bookService.GetAllBooks();
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> SaveBook(Book book)
        {
            if (!ModelState.IsValid)
            {
                var categories = Enum.GetValues(typeof(CATEGORY))
     .Cast<CATEGORY>()
     .Select(c => new SelectListItem
     {
         Value = ((int)c).ToString(),
         Text = c.ToString()
     })
     .ToList();

                ViewBag.Categories = categories;
                return View("CreateBook", book);
            }
            await _bookService.CreateNewBook(book);
            return RedirectToAction("BookView");
        }

        public async Task<ActionResult> EditPage(int Id)
        {
            var categories = Enum.GetValues(typeof(CATEGORY))
                                    .Cast<CATEGORY>()
                                    .Select(c => new SelectListItem
                                    {
                                        Value = ((int)c).ToString(),
                                        Text = c.ToString()
                                    })
                                    .ToList();
            ViewBag.Categories = categories;
            var book = await _bookService.GetBookById(Id);
            return View(book);
        }

        [HttpPost]
        public async Task<ActionResult> EditBook(Book book)
        {
            if (!ModelState.IsValid)
            {
                var categories = Enum.GetValues(typeof(CATEGORY))
     .Cast<CATEGORY>()
     .Select(c => new SelectListItem
     {
         Value = ((int)c).ToString(),
         Text = c.ToString()
     })
     .ToList();

                ViewBag.Categories = categories;
                return View("EditPage", book);
            }
            await _bookService.EditBook(book);
            return RedirectToAction("BookView");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteBook(int Id)
        {
            await _bookService.DeleteBook(Id);
            return RedirectToAction("BookView");
        }
    }
}
