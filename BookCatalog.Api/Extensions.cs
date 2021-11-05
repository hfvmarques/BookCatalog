using BookCatalog.Api.DTOs;
using BookCatalog.Api.Entities;

namespace BookCatalog.Api
{
  public static class Extensions
  {
    public static BookDTO AsDTO(this Book book)
    {
      return new BookDTO(
        book.Id,
        book.Title,
        book.Author,
        book.PublishingCompany,
        book.PublicationYear,
        book.Edition,
        book.Subject,
        book.BookType,
        book.Borrowed);
    }
  }
}