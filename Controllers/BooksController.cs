using System;
using System.Collections.Generic;
using System.Linq;
using BookCatalog.DTOs;
using BookCatalog.Entities;
using BookCatalog.Repositores;
using Microsoft.AspNetCore.Mvc;

namespace BookCatalog.Controllers
{
  [ApiController]
  [Route("books")]
  public class BooksController : ControllerBase
  {
    private readonly IBooksRepository repository;

    public BooksController(IBooksRepository repository)
    {
      this.repository = repository;
    }

    // GET /books
    [HttpGet]
    public IEnumerable<BookDTO> GetBooks()
    {
      var books = repository.GetBooks().Select(book => book.AsDTO());
      return books;
    }

    // GET /books/id
    [HttpGet("{id}")]
    public ActionResult<BookDTO> GetBook(Guid id)
    {
      var book = repository.GetBook(id);

      if (book is null)
      {
        return NotFound();
      }

      return book.AsDTO();
    }
  }
}