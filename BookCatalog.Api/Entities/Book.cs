using System;
using System.ComponentModel.DataAnnotations;
using BookCatalog.Api.Entities.Enums;
using MongoDB.Bson.Serialization.Attributes;

namespace BookCatalog.Api.Entities
{
  public class Book
  {
    [BsonId]
    public Guid Id { get; set; }

    [Required(ErrorMessage = "Campo obrigatório")]
    [Display(Name = "Título do livro")]
    public string Title { get; set; }

    [Display(Name = "Nome do(s)/da(s) autor(es)/(as)")]
    [Required(ErrorMessage = "Campo obrigatório")]
    public string Author { get; set; }

    [Display(Name = "Nome da editora")]
    [Required(ErrorMessage = "Campo obrigatório")]
    public string PublishingCompany { get; set; }

    [Display(Name = "Ano de publicação")]
    [Required(ErrorMessage = "Campo obrigatório")]
    public int PublicationYear { get; set; }

    [Display(Name = "Número da edição")]
    [Required(ErrorMessage = "Campo obrigatório")]
    public int Edition { get; set; }

    [Display(Name = "Assunto(s) do livro")]
    [Required(ErrorMessage = "Campo obrigatório")]
    public string Subject { get; set; }

    [Display(Name = "Tipo do livro (físico ou digital)")]
    [Required(ErrorMessage = "Campo obrigatório")]
    public BookType BookType { get; set; }
    public string Borrowed { get; set; }
  }
}