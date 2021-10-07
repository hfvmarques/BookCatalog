using System;
using System.Collections.Generic;
using BookCatalog.Entities;
using MongoDB.Bson;
using MongoDB.Driver;

namespace BookCatalog.Repositores
{
  public class MongoDBBooksRepository : IBooksRepository
  {
    private const string databaseName = "bookCatalog";
    private const string collectionName = "books";
    private readonly IMongoCollection<Book> booksCollection;

    public MongoDBBooksRepository(IMongoClient mongoClient)
    {
      IMongoDatabase database = mongoClient.GetDatabase(databaseName);
      booksCollection = database.GetCollection<Book>(collectionName);
    }

    public void CreateBook(Book book)
    {
      booksCollection.InsertOne(book);
    }

    public void DeleteBook(Guid id)
    {
      throw new NotImplementedException();
    }

    public Book GetBook(Guid id)
    {
      throw new NotImplementedException();
    }

    public IEnumerable<Book> GetBooks()
    {
      return booksCollection.Find(new BsonDocument()).ToList();
    }

    public void UpdateBook(Book book)
    {
      throw new NotImplementedException();
    }
  }
}