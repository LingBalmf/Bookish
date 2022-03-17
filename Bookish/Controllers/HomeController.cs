using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Bookish.Models;
using Bookish.Services;
using Bookish.Repositories;
using Bookish.Models.Request;

namespace Bookish.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IBookService _bookService;
    private readonly IAuthorService _authorService;

    public HomeController(

        IBookService bookService,
        IAuthorService authorService,
        ILogger<HomeController> logger
    )
    {
        _logger = logger;
        _bookService = bookService;
        _authorService = authorService;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult BookList()
    { 
        var books = _bookService.GetAllBooks();
        return View(books);
    }

    [HttpPost]
    public IActionResult CreateBook([FromForm] CreateBookRequest createBookRequest)
    {
        var newBook = _bookService.CreateBook(createBookRequest);

        return Created("/Home/BookList", newBook);
    }


    public IActionResult AuthorList()
    { 
        var authors = _authorService.GetAllAuthors();
        return View(authors);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
