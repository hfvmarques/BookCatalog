using System.Collections.Generic;
using BookCatalog.Entities;
using BookCatalog.Repositores;
using Microsoft.AspNetCore.Mvc;

namespace BookCatalog.Controllers
{
  [ApiController]
  [Route("books")]
  public class BooksController : ControllerBase
  {
    private readonly InMemBooksRepository repository;

    public BooksController()
    {
      repository = new InMemBooksRepository();
    }

    // GET /books
    [HttpGet]
    public IEnumerable<Book> GetBooks()
    {
      var books = repository.GetBooks();
      return books;
    }
  }
}