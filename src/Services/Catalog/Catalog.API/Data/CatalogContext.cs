using Catalog.API.Entities;
using MongoDB.Driver;

namespace Catalog.API.Data
{
   public class CatalogContext : ICatalogContext
   {
      public CatalogContext(IConfiguration configuration)
      {
         var client = new MongoClient(configuration.GetValue<string>("DbSettings:DbConn"));
         var database = client.GetDatabase(configuration.GetValue<string>("DbSettings:DbName"));
         Products = database.GetCollection<Product>(configuration.GetValue<string>("DbSettings:DbCollection"));
      }
      public IMongoCollection<Product> Products { get; }
   }
}