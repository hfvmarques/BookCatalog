using System;

namespace BookCatalog.Entities
{
  public record Book
  {
    public Guid Id { get; init; }
    public string Title { get; init; }
    public string Author { get; init; }
    public string PublishingCompany { get; init; }
    public int PublicationYear { get; init; }
    public int Edition { get; init; }
  }
}