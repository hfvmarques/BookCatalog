using System.ComponentModel.DataAnnotations;

namespace BookCatalog.DTOs
{
  public record UpdateBookDTO
  {
    [Required]
    public string Title { get; init; }

    [Required]
    public string Author { get; init; }

    [Required]
    public string PublishingCompany { get; init; }

    [Required]
    [Range(1, 9999, ErrorMessage = "O ano de publicação precisa ter quatro dígitos")]
    public int PublicationYear { get; init; }

    [Required]
    public int Edition { get; init; }
  }
}