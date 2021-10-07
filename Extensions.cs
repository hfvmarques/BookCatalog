using BookCatalog.DTOs;
using BookCatalog.Entities;

namespace BookCatalog
{
  public static class Extensions
  {
    public static BookDTO AsDTO(this Book book)
    {
      return new BookDTO
      {
        Id = book.Id,
        Title = book.Title,
        Author = book.Author,
        PublishingCompany = book.PublishingCompany,
        PublicationYear = book.PublicationYear,
        Edition = book.Edition
      };
    }
  }
}