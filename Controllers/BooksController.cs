using System;
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

    // GET /books/id
    [HttpGet("{id}")]
    public ActionResult<Book> GetBook(Guid id)
    {
      var book = repository.GetBook(id);

      if (book is null)
      {
        return NotFound();
      }

      return book;
    }
  }
}