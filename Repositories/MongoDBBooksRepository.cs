using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
    private readonly FilterDefinitionBuilder<Book> filterBuilder = Builders<Book>.Filter;

    public MongoDBBooksRepository(IMongoClient mongoClient)
    {
      IMongoDatabase database = mongoClient.GetDatabase(databaseName);
      booksCollection = database.GetCollection<Book>(collectionName);
    }

    public async Task CreateBookAsync(Book book)
    {
      await booksCollection.InsertOneAsync(book);
    }

    public async Task DeleteBookAsync(Guid id)
    {
      var filter = filterBuilder.Eq(book => book.Id, id);
      await booksCollection.DeleteOneAsync(filter);
    }

    public async Task<Book> GetBookAsync(Guid id)
    {
      var filter = filterBuilder.Eq(book => book.Id, id);
      return await booksCollection.Find(filter).SingleOrDefaultAsync();
    }

    public async Task<IEnumerable<Book>> GetBooksAsync()
    {
      return await booksCollection.Find(new BsonDocument()).ToListAsync();
    }

    public async Task UpdateBookAsync(Book book)
    {
      var filter = filterBuilder.Eq(existingBook => existingBook.Id, book.Id);
      await booksCollection.ReplaceOneAsync(filter, book);
    }
  }
}