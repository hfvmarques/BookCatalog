using System;
using BookCatalog.Api.Entities.Enums;

namespace BookCatalog.Api.Entities
{
  public class Book
  {
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string PublishingCompany { get; set; }
    public int PublicationYear { get; set; }
    public int Edition { get; set; }
    public string Subject { get; set; }
    public BookType BookType { get; set; }
  }
}