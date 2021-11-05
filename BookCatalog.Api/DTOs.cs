using System;
using System.ComponentModel.DataAnnotations;
using BookCatalog.Api.Entities.Enums;

namespace BookCatalog.Api.DTOs
{
  public record BookDTO(
    Guid Id,
    string Title,
    string Author,
    string PublishingCompany,
    int PublicationYear,
    int Edition,
    string Subject,
    BookType BookType,
    string Borrowed
    );

  public record CreateBookDTO(
    [Required] string Title,
    [Required] string Author,
    [Required] string PublishingCompany,
    [Range(1, 9999)] int PublicationYear,
    [Range(1, 999)] int Edition,
    [Required] string Subject,
    [Required] BookType BookType,
    [Required] string Borrowed
    );

  public record UpdateBookDTO(
  [Required] string Title,
  [Required] string Author,
  [Required] string PublishingCompany,
  [Range(1, 9999)] int PublicationYear,
  [Range(1, 999)] int Edition,
  [Required] string Subject,
  [Required] BookType BookType,
  [Required] string Borrowed
  );
}