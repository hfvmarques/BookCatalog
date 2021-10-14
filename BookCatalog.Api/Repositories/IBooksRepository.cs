using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookCatalog.Api.Entities;

namespace BookCatalog.Api.Repositores
{
  public interface IBooksRepository
  {
    Task<Book> GetBookAsync(Guid id);
    Task<IEnumerable<Book>> GetBooksAsync();
    Task CreateBookAsync(Book book);
    Task UpdateBookAsync(Book book);
    Task DeleteBookAsync(Guid id);
  }
}