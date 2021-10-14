using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookCatalog.Api.DTOs;
using BookCatalog.Api.Entities;
using BookCatalog.Api.Repositores;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BookCatalog.Api.Controllers
{
  [ApiController]
  [Route("books")]
  public class BooksController : ControllerBase
  {
    private readonly IBooksRepository repository;
    private readonly ILogger<BooksController> logger;

    public BooksController(IBooksRepository repository, ILogger<BooksController> logger)
    {
      this.repository = repository;
      this.logger = logger;
    }

    // GET /books
    [HttpGet]
    public async Task<IEnumerable<BookDTO>> GetBooksAsync()
    {
      var books = (await repository.GetBooksAsync())
                  .Select(book => book.AsDTO());

      logger.LogInformation($"{DateTime.UtcNow.ToString("hh:mm:ss")}: Retrieved {books.Count()} books.");
      return books;
    }

    // GET /books/id
    [HttpGet("{id}")]
    public async Task<ActionResult<BookDTO>> GetBookAsync(Guid id)
    {
      var book = await repository.GetBookAsync(id);

      if (book is null)
      {
        return NotFound();
      }

      return book.AsDTO();
    }

    // POST /books
    [HttpPost]
    public async Task<ActionResult<BookDTO>> CreateBookAsync(CreateBookDTO bookDTO)
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

      await repository.CreateBookAsync(book);

      return CreatedAtAction(nameof(GetBookAsync), new { id = book.Id }, book.AsDTO());
    }

    // PUT /items/{id}
    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateBookAsync(Guid id, UpdateBookDTO bookDTO)
    {
      var existingBook = await repository.GetBookAsync(id);

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

      await repository.UpdateBookAsync(updatedBook);

      return NoContent();
    }

    //DELETE /books/{id}
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteBookAsync(Guid id)
    {
      var existingBook = await repository.GetBookAsync(id);

      if (existingBook is null)
      {
        return NotFound();
      }

      await repository.DeleteBookAsync(id);

      return NoContent();
    }
  }
}