using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Catalog.API.Repositories;
using Catalog.API.DTOs;
using Catalog.API.Entities;

namespace Catalog.API.Controllers
{
   [ApiController]
   [Route("api/v1/catalog")]
   public class CatalogController : ControllerBase
   {
      private readonly IProductRepo _repo;
      private readonly IMapper _mapper;
      public CatalogController(IProductRepo repo, IMapper mapper)
      {
         _repo = repo;
         _mapper = mapper;
      }

      [HttpGet("")]
      public async Task<IActionResult> GetProducts()
      {
         var products  = await this._repo.GetProducts();
         return Ok(products);
      }

      [HttpGet("{id:length(24)}", Name = "GetProduct")]
      public async Task<IActionResult> GetProductById(string id)
      {
         var product = await this._repo.GetProduct(id);
         if (product == null)
         {
            return NotFound();
         }
         return Ok(product);
      }

      [HttpGet("category/{categoryName}")]
      public async Task<IActionResult> GetProductByCategory( string categoryName)
      {
         var product = await this._repo.GetProductByCategory(categoryName);
         if (product == null)
         {
            return NotFound();
         }
         return Ok(product);
      }

      [HttpPost("")]
      public async Task<IActionResult> CreateProduct([FromBody] CreateProductDto productDto)
      {
         var productEntity = this._mapper.Map<Product>(productDto);
         await this._repo.CreateProduct(productEntity);
         return CreatedAtRoute("GetProduct", new { id = productEntity.Id }, productEntity);
      }

      [HttpPut("{id:length(24)}")]
      public async Task<IActionResult> UpdateProduct(string id, [FromBody] UpdateProductDto productDto)
      {
         var productEntity = await this._repo.GetProduct(id);
         if (productEntity == null)
         {
            return NotFound();
         }
         this._mapper.Map(productDto, productEntity); // Map the productDto to the productEntity
         var updateResult = await this._repo.UpdateProduct(productEntity);
         if (updateResult == true){
            return NoContent();
         }else{
            ModelState.AddModelError("UpdateProduct", "Unable to update product");
            return StatusCode(500, ModelState);
         }
      }

      [HttpDelete("{id:length(24)}")]
      public async Task<IActionResult> DeleteProduct(string id)
      {
         var productEntity = await this._repo.GetProduct(id);
         if (productEntity == null)
         {
            return NotFound();
         }
         var deleteResult = await this._repo.DeleteProduct(id);
         if (deleteResult == true){
            return NoContent();
         }else{
            ModelState.AddModelError("DeleteProduct", "Unable to delete product");
            return StatusCode(500, ModelState);
         }
      }
   }
}