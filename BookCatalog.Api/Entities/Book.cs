using System;

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
  }
}