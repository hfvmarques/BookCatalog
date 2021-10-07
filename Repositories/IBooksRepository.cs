using System;
using System.Collections.Generic;
using BookCatalog.Entities;

namespace BookCatalog.Repositores
{
  public interface IBooksRepository
  {
    Book GetBook(Guid id);
    IEnumerable<Book> GetBooks();
  }
}