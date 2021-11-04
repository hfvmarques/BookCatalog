using System;
using BookCatalog.Api.Entities.Enums;
using MongoDB.Bson.Serialization.Attributes;

namespace BookCatalog.Api.Entities
{
  public class Book
  {
    [BsonId]
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