using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Test4.Models;

namespace Test4.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController>? _logger;

        private readonly ICrudController<Author> _authorController;
        private readonly ICrudController<Book> _bookController;

        public HomeController(ICrudController<Author> authorController, ICrudController<Book> bookController, ILogger<HomeController> logger)
        {
            _authorController = authorController;
            _bookController = bookController;
            _logger = logger;
        }
        public async Task<IActionResult> IndexAsync()
        {

            var authorResult = await _authorController.Index();

            if (authorResult is ViewResult _authorResult)
            {
                var authorModels = (List<Author>)_authorResult.Model;

                var authorViewModels = authorModels.Select(a => new Author
                {
                    Id = a.Id,
                    LastName = a.LastName,
                    FirstName = a.FirstName,
                    MiddleName = a.MiddleName,
                    BirthDate = a.BirthDate,
                    Books = a.Books ?? new List<Book>()
                }).ToList();

                ViewBag.AuthorViewModels = authorViewModels;
            }

            var bookResult = await _bookController.Index();

            if (bookResult is ViewResult _bookResult)
            {
                var bookModels = (List<Book>)_bookResult.Model;

                var bookViewModels = bookModels.Select(b => new Book
                {
                    Id = b.Id,
                    Title = b.Title,
                    PageCount = b.PageCount,
                    Genre = b.Genre,
                    AuthorId = b.AuthorId,
                    Author = b.Author
                }).ToList();

                ViewBag.BookViewModels = bookViewModels;
            }

            return View();

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult CreateAll()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAll(AuthorBookViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var authorViewModel = viewModel.AuthorViewModels?.FirstOrDefault();
                var bookViewModel = viewModel.BookViewModels?.FirstOrDefault();

                if (authorViewModel != null && bookViewModel != null)
                {
                    // Создание автора
                    var author = new Author
                    {
                        LastName = authorViewModel.LastName,
                        FirstName = authorViewModel.FirstName,
                        MiddleName = authorViewModel.MiddleName,
                        BirthDate = authorViewModel.BirthDate
                    };

                    await _authorController.Create(author);

                    var book = new Book
                    {
                        Title = bookViewModel.Title,
                        PageCount = bookViewModel.PageCount,
                        Genre = bookViewModel.Genre,
                        AuthorId = author.Id  
                    };

                    await _bookController.Create(book);

                    return RedirectToAction("Index");
                }
            }
            return View(viewModel);
        }
    }
}









