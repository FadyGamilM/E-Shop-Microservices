using Catalog.API.Data;
using Catalog.API.Entities;
using MongoDB.Bson.IO;
using MongoDB.Driver;

namespace Catalog.API.Repositories
{
   public class ProductRepo : IProductRepo
   {
      private readonly CatalogContext _context;

      public ProductRepo(CatalogContext context)
      {
         _context = context;
      }
      // get all products
      public async Task<IEnumerable<Product>> GetProducts()
      {
         var products = await this._context.Products.Find(P => true).ToListAsync();
         return products;
      }
      // get product by id
      public async Task<Product> GetProduct(string id)
      {
         var product = await this._context.Products.Find(p => p.Id == id).FirstOrDefaultAsync();
         return product;
      }
      // get product by name
      public async Task<IEnumerable<Product>> GetProductByName(string name)
      {
         var products = await this._context.Products.Find(p => p.Name == name).ToListAsync();
         return products;
      }
      // create a new product
      public async Task CreateProduct(Product product)
      {
         await this._context.Products.InsertOneAsync(product);
      }
      // delete existing product
      public async Task<bool> DeleteProduct(string id)
      {
         var product = await GetProduct(id);
         if (product == null)
         {
            return false;
         }

        await this._context.Products.DeleteOneAsync(p => p.Id == id);
         return true;
      }


      public async Task<IEnumerable<Product>> GetProductByCategory(string categoryName)
      {
         return await _context.Products.Find(p => p.Category == categoryName).ToListAsync();
      }


      // update existing product
      public async Task<bool> UpdateProduct(Product product)
      {
         var existingProduct = await GetProduct(product.Id);
         if (existingProduct == null)
         {
            return false;
         }
         await this._context.Products.ReplaceOneAsync(p => p.Id == product.Id, product);
         return true;
      }
   }
}