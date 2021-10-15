using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookCatalog.Api.Controllers;
using BookCatalog.Api.DTOs;
using BookCatalog.Api.Entities;
using BookCatalog.Api.Repositores;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace BookCatalog.UnitTests
{
  public class BooksControllerTests
  {

    private readonly Mock<IBooksRepository> repositoryStub = new();
    private readonly Mock<ILogger<BooksController>> loggerStub = new();
    private readonly Random rand = new();

    // name convention UnitOfWork_StateUnderTest_ExpectedBehavior
    [Fact]
    public async Task GetBookAsync_WithUnexistingBook_ReturnsNotFound()
    {
      // Arrange
      repositoryStub.Setup(repo => repo.GetBookAsync(It.IsAny<Guid>())).ReturnsAsync((Book)null);

      var controller = new BooksController(repositoryStub.Object, loggerStub.Object);

      // Act
      var result = await controller.GetBookAsync(Guid.NewGuid());

      // Assert
      result.Result.Should().BeOfType<NotFoundResult>();
    }

    [Fact]
    public async Task GetBookAsync_WithExistingBook_ReturnsExpectedBook()
    {
      // Arrange
      var expectedBook = CreateRandomBook();

      repositoryStub.Setup(repo => repo.GetBookAsync(It.IsAny<Guid>())).ReturnsAsync(expectedBook);

      var controller = new BooksController(repositoryStub.Object, loggerStub.Object);

      // Act
      var result = await controller.GetBookAsync(Guid.NewGuid());

      // Assert
      result.Value.Should().BeEquivalentTo(expectedBook);
    }

    [Fact]
    public async Task GetBooksAsync_WithExistingBooks_ReturnsAllBooks()
    {
      // Arrange
      var expectedBooks = new[]
      {
          CreateRandomBook(),
          CreateRandomBook(),
          CreateRandomBook()
      };

      repositoryStub.Setup(repo => repo.GetBooksAsync()).ReturnsAsync(expectedBooks);

      var controller = new BooksController(repositoryStub.Object, loggerStub.Object);

      // Act
      var actualBooks = await controller.GetBooksAsync();

      // Assert
      actualBooks.Should().BeEquivalentTo(expectedBooks);
    }

    [Fact]
    public async Task GetBooksAsync_WithMatchingBooks_ReturnsMatchingBooks()
    {
      // Arrange
      var allBooks = new[]
      {
        new Book(){Title = "Educação"},
        new Book(){Title = "Ensino"},
        new Book(){Title = "Ensino de Psicologia"}
      };

      var titleToMatch = "Ensino";

      repositoryStub
        .Setup(repo => repo.GetBooksAsync())
        .ReturnsAsync(allBooks);

      var controller = new BooksController(repositoryStub.Object, loggerStub.Object);

      // Act
      IEnumerable<BookDTO> foundBooks = await controller.GetBooksAsync(titleToMatch);

      // Assert
      foundBooks.Should().OnlyContain(
        book => book.Title == allBooks[1].Title || book.Title == allBooks[2].Title
      );
    }

    [Fact]
    public async Task CreateBookAsync_WithBookToCreate_ReturnsCreatedBook()
    {
      // Arrange
      var bookToCreate = new CreateBookDTO(
        Guid.NewGuid().ToString(),
        Guid.NewGuid().ToString(),
        Guid.NewGuid().ToString(),
        rand.Next(1000, 9999),
        rand.Next(1, 999));

      var controller = new BooksController(repositoryStub.Object, loggerStub.Object);

      // Act
      var result = await controller.CreateBookAsync(bookToCreate);

      // Assert
      var createdBook = (result.Result as CreatedAtActionResult).Value as BookDTO;
      bookToCreate.Should().BeEquivalentTo(
        createdBook,
        options => options
          .ComparingByMembers<BookDTO>()
          .ExcludingMissingMembers()
      );
      createdBook.Id.Should().NotBeEmpty();
    }

    [Fact]
    public async Task UpdateBookAsync_WithExistingBook_ReturnsNoContent()
    {
      // Arrange
      var existingBook = CreateRandomBook();
      repositoryStub.Setup(repo => repo.GetBookAsync(It.IsAny<Guid>())).ReturnsAsync(existingBook);

      var bookId = existingBook.Id;
      var bookToUpdate = new UpdateBookDTO(
        Guid.NewGuid().ToString(),
        Guid.NewGuid().ToString(),
        Guid.NewGuid().ToString(),
        existingBook.PublicationYear + 5,
        existingBook.Edition + 1
      );

      var controller = new BooksController(repositoryStub.Object, loggerStub.Object);

      // Act
      var result = await controller.UpdateBookAsync(bookId, bookToUpdate);

      // Assert
      result.Should().BeOfType<NoContentResult>();
    }

    [Fact]
    public async Task DeleteBookAsync_WithExistingBook_ReturnsNoContent()
    {
      // Arrange
      var existingBook = CreateRandomBook();
      repositoryStub.Setup(repo => repo.GetBookAsync(It.IsAny<Guid>())).ReturnsAsync(existingBook);

      var controller = new BooksController(repositoryStub.Object, loggerStub.Object);

      // Act
      var result = await controller.DeleteBookAsync(existingBook.Id);

      // Assert
      result.Should().BeOfType<NoContentResult>();
    }

    private Book CreateRandomBook()
    {
      return new()
      {
        Id = Guid.NewGuid(),
        Title = Guid.NewGuid().ToString(),
        Author = Guid.NewGuid().ToString(),
        PublishingCompany = Guid.NewGuid().ToString(),
        PublicationYear = rand.Next(1000, 9999),
        Edition = rand.Next(1, 999)
      };
    }
  }
}
