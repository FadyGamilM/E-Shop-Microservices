using Basket.API.Entities;
using Basket.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Basket.API.Controller
{
   [ApiController]
   [Route("api/v1/[controller]")]
   public class BasketController : ControllerBase
   {
      private readonly IBasketRepo _repo;
      public BasketController(IBasketRepo repo)
      {
         this._repo = repo;
      }

      [HttpGet("{userName}", Name = "GetBasket")]
      public async Task<IActionResult> GetBasket(string userName)
      {
         var basket = await _repo.GetBasket(userName);
         if (basket == null){
            return NotFound();
         }
         return Ok(basket);
      }

      [HttpPost]
      public async Task<IActionResult> UpdateBasket([FromBody] ShoppingCart basket)
      {
         var updatedBasket = await _repo.UpdateBasket(basket);
         return CreatedAtRoute(
            "GetBasket", 
            new { userName = updatedBasket.UserName }, 
            updatedBasket
            );
      }

      [HttpDelete("{userName}", Name = "DeleteBasket")]
      public async Task<IActionResult> DeleteBasket(string userName)
      {
         var deleteResult =  await _repo.DeleteBasket(userName);
         if (deleteResult == false){
            ModelState.AddModelError("DeleteBasket", "Error while deleting the basket");
            return StatusCode(500, ModelState);
         }
         return Ok();
      }
   }
}