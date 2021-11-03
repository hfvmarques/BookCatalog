using System;
using System.ComponentModel.DataAnnotations;

namespace BookCatalog.Api.DTOs
{
  public record BookDTO(
    Guid Id,
    string Title,
    string Author,
    string PublishingCompany,
    int PublicationYear,
    int Edition,
    string Subject
    );
  public record CreateBookDTO(
    [Required] string Title,
    [Required] string Author,
    [Required] string PublishingCompany,
    [Range(1, 9999)] int PublicationYear,
    [Range(1, 999)] int Edition,
    [Required] string Subject
    );
  public record UpdateBookDTO(
  [Required] string Title,
  [Required] string Author,
  [Required] string PublishingCompany,
  [Range(1, 9999)] int PublicationYear,
  [Range(1, 999)] int Edition,
  [Required] string Subject
  );
}