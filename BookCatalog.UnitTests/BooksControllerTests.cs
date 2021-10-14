using System;
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
      result.Value.Should().BeEquivalentTo(
          expectedBook,
          options => options.ComparingByMembers<Book>()
      );
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
      actualBooks.Should().BeEquivalentTo(
          expectedBooks,
          options => options.ComparingByMembers<Book>()
      );
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
