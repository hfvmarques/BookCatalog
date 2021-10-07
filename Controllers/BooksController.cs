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

    // POST /books
    [HttpPost]
    public ActionResult<BookDTO> CreateBook(CreateBookDTO bookDTO)
    {
      Book book = new()
      {
        Id = Guid.NewGuid(),
        Title = bookDTO.Title,
        Author = bookDTO.Author,
        PublishingCompany = bookDTO.PublishingCompany,
        PublicationYear = bookDTO.PublicationYear,
        Edition = bookDTO.Edition
      };

      repository.CreateBook(book);

      return CreatedAtAction(nameof(GetBook), new { id = book.Id }, book.AsDTO());
    }

    // PUT /items/{id}
    [HttpPut("{id}")]
    public ActionResult UpdateBook(Guid id, UpdateBookDTO bookDTO)
    {
      var existingBook = repository.GetBook(id);

      if (existingBook is null)
      {
        return NotFound();
      }

      Book updatedBook = existingBook with
      {
        Title = bookDTO.Title,
        Author = bookDTO.Author,
        PublishingCompany = bookDTO.PublishingCompany,
        PublicationYear = bookDTO.PublicationYear,
        Edition = bookDTO.Edition
      };

      repository.UpdateBook(updatedBook);

      return NoContent();
    }

    //DELETE /books/{id}
    [HttpDelete("{id}")]
    public ActionResult DeleteBook(Guid id)
    {
      var existingBook = repository.GetBook(id);

      if (existingBook is null)
      {
        return NotFound();
      }

      repository.DeleteBook(id);

      return NoContent();
    }
  }
}