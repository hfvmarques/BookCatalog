using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookCatalog.Api.Entities;

namespace BookCatalog.Api.Repositores
{
  public class InMemBooksRepository : IBooksRepository
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

    public async Task<IEnumerable<Book>> GetBooksAsync()
    {
      return await Task.FromResult(books);
    }

    public async Task<Book> GetBookAsync(Guid id)
    {
      var book = books.Where(book => book.Id == id).SingleOrDefault();
      return await Task.FromResult(book);
    }

    public async Task CreateBookAsync(Book book)
    {
      books.Add(book);
      await Task.CompletedTask;
    }

    public async Task UpdateBookAsync(Book book)
    {
      var index = books.FindIndex(existingBook => existingBook.Id == book.Id);
      books[index] = book;
      await Task.CompletedTask;
    }

    public async Task DeleteBookAsync(Guid id)
    {
      var index = books.FindIndex(existingBook => existingBook.Id == id);
      books.RemoveAt(index);
      await Task.CompletedTask;
    }
  }
}