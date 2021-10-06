using System;
using System.Collections.Generic;
using System.Linq;
using BookCatalog.Entities;

namespace BookCatalog.Repositores
{
  public class InMemBooksRepository
  {
    private readonly List<Book> books = new()
    {
      new Book
      {
        Id = Guid.NewGuid(),
        Title = "Ensino: as abordagens do processo",
        Author = "Maria da Graça Nicoletti Mizukami",
        PublishingCompany = "Editora pedagógica e universitária LTDA.",
        PublicationYear = 1986,
        Edition = 1
      },
      new Book
      {
        Id = Guid.NewGuid(),
        Title = "Com todas as letras",
        Author = "Emilia Ferreiro",
        PublishingCompany = "Cortez editora",
        PublicationYear = 2011,
        Edition = 17
      },
      new Book
      {
        Id = Guid.NewGuid(),
        Title = "A construção do saber",
        Author = "Christian Laville Jean Dionne",
        PublishingCompany = "Editora UFMG",
        PublicationYear = 1999,
        Edition = 1
      }
    };

    public IEnumerable<Book> GetBooks()
    {
      return books;
    }

    public Book GetBook(Guid id)
    {
      return books.Where(book => book.Id == id).SingleOrDefault();
    }
  }
}