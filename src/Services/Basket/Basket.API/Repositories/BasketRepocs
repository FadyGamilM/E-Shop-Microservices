using Basket.API.Entities;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace Basket.API.Repositories
{
      public class BasketRepo : IBasketRepo
      {
         // we need to inject the IDistributedCache to the constructor
         private readonly IDistributedCache _redisCache;
         public BasketRepo(IDistributedCache redisCache)
         {
            this._redisCache = redisCache;
         }

         // we need to implement the methods from the interface
         // => Get the shopping cart from the redis database given the username
         public async Task<ShoppingCart> GetBasket(string userName)
         {
            // the returned shoppingCart related to this username is a shoppingCart json object, but we will convert it into string
            var basket = await _redisCache.GetStringAsync(userName);
            // validation
            if (string.IsNullOrEmpty(basket))
            {
               return null;
            }
            // if the shoppingCart is not null then we need to convert it into ShoppingCart object
            return JsonConvert.DeserializeObject<ShoppingCart>(basket);
         }

         // => Update the shopping cart in the redis database given the shopping cart
         public async Task<ShoppingCart> UpdateBasket(ShoppingCart basket)
         {
            // we need to convert the shoppingCart object into string
            await this._redisCache
                           .SetStringAsync(basket.UserName, JsonConvert.SerializeObject(basket));
            // return the created/updated basket
            return await GetBasket(basket.UserName);
         }

         // => Delete the shopping cart given the username as a key
         public async Task<bool> DeleteBasket(string userName)
         {
            await this._redisCache.RemoveAsync(userName);
            return true;
         }
      }
}